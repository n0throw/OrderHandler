using System;
using System.Linq;
using System.Text;
using System.Windows;
using System.Security.Cryptography;
using System.Collections.ObjectModel;

using OrderHandler.DB;
using OrderHandler.DB.Data;
using OrderHandler.DB.Data.UserAdd;
using OrderHandler.UI.Contexts.Windows;
using OrderHandler.UI.Core;
using OrderHandler.UI.Model;
using OrderHandler.UI.Pages;
using OrderHandler.UI.Windows.LoginWindows;

namespace OrderHandler.UI.Contexts.Pages;

public class LoginContext : MainPagePropertyChanger {
    UserCombo _currentSelection;
    readonly UserCombo _defaultUserCombo = new(-1, "Выберите пользователя");
    string _passwordHash;
    
    public ObservableCollection<UserCombo> UserCombos { get; }

    public LoginContext() {
        UserCombos = new();
        FillUserCombos();
        _passwordHash = string.Empty;
        _currentSelection = (UserCombo)_defaultUserCombo.Clone();
        
        // todo это надо будет вынести в "Конфигуратор подключения к БД".
        if (UserCombos.Count == 0) {
            var isCreateNewUser = MessageBox.Show(
                "В системе отсутствуют пользователи, создать нового?",
                "Создать нового пользователя?",
                MessageBoxButton.YesNo
            );

            if (isCreateNewUser == MessageBoxResult.Yes) {
                CreateAdminUser();
                MessageBox.Show(
                    "Создан новый пользователь с паролем: Admin. После настройки приложения не забудьте его удалить!",
                    "Информация"
                );
            } else 
                Application.Current.Shutdown();
        } else 
            CurrentSelection = UserCombos.First();
        Password = string.Empty;
    }
    
    public UserCombo CurrentSelection {
        get => _currentSelection;
        set {
            _currentSelection = value;
            OnPropertyChanged();
        }
    }
    public string Password {
        get => _passwordHash;
        set {
            _passwordHash = GetHashSHA256(value);
            OnPropertyChanged();
        }
    }
    
    // ---------- Меню страницы ----------
    // ---------- Настройки ----------
    RelayCommand? _showDBConnectSettingsWindow;
    public RelayCommand ShowDBConnectSettingsWindow => 
        _showDBConnectSettingsWindow ??= new(
            _ => {
                var dbConnectSettingsWindow = new DBConnectSettingsWindow {
                    Owner = Application.Current.MainWindow,
                    DataContext = new DBConnectSettingsWindowContext()
                };
                dbConnectSettingsWindow.ShowDialog();
            }, 
            null
        );
    
    // ---------- Команды на странице ----------
    RelayCommand? _entryCommand;
    public RelayCommand EntryCommand =>
        _entryCommand ??= new(_ => {
            using var db = new Context();

            bool ValidateUser(string dbPass, string currPass) {
                if (dbPass == string.Empty)
                    return false;
                return dbPass == currPass;
            }

            var user = db.UserInfos.ToList().FirstOrDefault(user => user != null && user.Id == _currentSelection.Id, null);

            if (ValidateUser(user?.PasswordHash ?? string.Empty, _passwordHash)) {
                GoToPage(nameof(MainMenu));
            } else {
                MessageBox.Show(
                    "Вы ввели не правильный пароль",
                    "Ошибка авторизации", 
                    MessageBoxButton.OK,
                    MessageBoxImage.Exclamation
                );
            }
        }, _ => {
            if (_currentSelection.Equals(_defaultUserCombo))
                return false;

            return _passwordHash switch {
                null => false,
                "" => false,
                var _ => true
            };
        });
    
    void CreateAdminUser() {
        using var db = new Context();
        using var transaction = db.Database.BeginTransaction();
        try {
            var caseName = new CaseName(
                "Admin",
                "Admin",
                "Admin"
            );
            db.CaseNames.Add(caseName);
        
            var user = new UserInfo() {
                Id = 1,
                Login = "Admin",
                PasswordHash = GetHashSHA256("Admin"),
                CaseName = caseName
            };
        
            db.UserInfos.Add(user);
            db.SaveChanges();
            transaction.Commit();
        } catch (Exception) {
            transaction.Rollback();
        }
    }

    string GetHashSHA256(string str) {
       if (str == string.Empty)
           return string.Empty;
       
       var hash = new StringBuilder();
       byte[] cryptBytes = SHA256.HashData(Encoding.UTF8.GetBytes(str));
       foreach (byte cryptoByte in cryptBytes)
           hash.Append(cryptoByte.ToString("x2"));

       return hash.ToString();
    }

    void FillUserCombos() {
        using var db = new Context();
        db.UserInfos.ToList().ForEach(user => {
            UserCombos.Add(new(user.Id, user.Login));
        });
    }
}
