using System;
using System.Linq;
using System.Text;
using System.Windows;
using System.Security.Cryptography;
using System.Collections.ObjectModel;

using OrderHandler.DB;
using OrderHandler.DB.Data;
using OrderHandler.DB.Data.UserAdd;

using OrderHandler.UI.Core;
using OrderHandler.UI.Model;
using OrderHandler.UI.Pages;
using OrderHandler.UI.Windows.LoginWindows;

namespace OrderHandler.UI.Contexts.Pages;

public class LoginContext : PropertyChanger {
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
                GoToPage(nameof(DBConnectSettingsWindow));
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

            User defaultUser = new() {
                Id = -1,
                PasswordHash = string.Empty,
            };
            var user = db.Users.ToList().FirstOrDefault(user => user.Id == _currentSelection.Id, defaultUser);

            if (ValidateUser(user.PasswordHash, _passwordHash)) {
                GoToPage(nameof(OrderManager));
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
        var user = new User {
            Id = 1,
            Login = "Admin",
            PasswordHash = GetHashSHA256("Admin")
        };
        db.Users.Add(user);
        var givenName = new GivenName {
            LastName = "Admin",
            FirstName = "Admin",
            MiddleName = "Admin"
        };
        
        var profile = new CaseName {
            User = user,
            Nominative = (GivenName)givenName.Clone(),
            Genitive = (GivenName)givenName.Clone(),
            Dative = (GivenName)givenName.Clone(),
            Accusative = (GivenName)givenName.Clone(),
            Ablative = (GivenName)givenName.Clone(),
            Prepositional = (GivenName)givenName.Clone()
        };
        db.CaseNames.Add(profile);

        db.SaveChanges();
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
        db.Users.ToList().ForEach(user => {
            UserCombos.Add(new(user.Id, user.Login));
        });
    }
}
