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

namespace OrderHandler.UI.Contexts;

public class LoginContext : PropertyChanger {
    UserCombo? _currentSelection;
    string? _passwordHash;
    
    public ObservableCollection<UserCombo> UserCombos { get; }
    public UserCombo? CurrentSelection {
        get => _currentSelection;
        set {
            _currentSelection = value;
            OnPropertyChanged();
        }
    }
    public string? Password {
        get => _passwordHash;
        set {
            _passwordHash = GetHashSHA256(value);
            OnPropertyChanged();
        }
    }

    public LoginContext() {
        UserCombos = new();
        FillUserCombos();
        
        // todo это надо будет вынести в "Настройки подключения к базе данных".
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
    
    // ---------- Меню страницы ----------
    // ---------- Настройки ----------
    RelayCommand? _showBDConnectSettingsWindow;
    public RelayCommand ShowBDConnectSettingsWindow => 
        _showBDConnectSettingsWindow ??= new(
            _ => {
                
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
                GoToPage("TableOrderManager");
            } else {
                MessageBox.Show(
                    "Вы ввели не правильный пароль",
                    "Ошибка авторизации", 
                    MessageBoxButton.OK,
                    MessageBoxImage.Exclamation
                );
            }
        }, _ => {
            if (_currentSelection is null)
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

    string? GetHashSHA256(string? str) {
        if (str is null)
            return null;
        
        var hash = new StringBuilder();
        byte[] cryptBytes = SHA256.HashData(Encoding.UTF8.GetBytes(str));
        foreach (byte cryptoByte in cryptBytes)
            hash.Append(cryptoByte.ToString("x2"));

        return hash.ToString();
    }

    void FillUserCombos() {
        using var db = new Context();
        db.Users.ToList().ForEach(user => {
            UserCombos.Add(new() {
                Id = user.Id,
                FIO = user.Login
            });
        });
    }
}
