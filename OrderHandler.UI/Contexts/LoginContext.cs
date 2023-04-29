using System.Linq;
using System.Text;
using System.Windows;
using System.Security.Cryptography;
using System.Collections.ObjectModel;

using OrderHandler.DB;
using OrderHandler.DB.Data;

using OrderHandler.UI.Core;
using OrderHandler.UI.Model;

using OrderHandler.DB.Data.UserAdd;

namespace OrderHandler.UI.Contexts;

public class LoginContext : PropertyChanger {
    UserCombo _currentSelection;
    string _passwordHash;

    public ObservableCollection<UserCombo> UserCombos { get; }
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

    public LoginContext() {
        UserCombos = new();
        FillUserCombos();

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

    void CreateAdminUser() {
        using var db = new Context();
        var user = new User {
            Id = 1,
            Login = "Admin",
            PasswordHash = GetHashSHA256("Admin")
        };
        db.Users.Add(user);
        
        var profile = new CaseName {
            User = user
        };
        db.CaseNames.Add(profile);
    
        
        var nominative = new GivenName {
            LastName = "Admin",
            FirstName = "Admin",
            MiddleName = "Admin",
            Nominative = profile
        };
        var genitive = new GivenName {
            LastName = "Admin",
            FirstName = "Admin",
            MiddleName = "Admin",
            Genitive = profile
        };
        var dative = new GivenName {
            LastName = "Admin",
            FirstName = "Admin",
            MiddleName = "Admin",
            Dative = profile
        };
        var accusative = new GivenName {
            LastName = "Admin",
            FirstName = "Admin",
            MiddleName = "Admin",
            Accusative = profile
        };
        var ablative = new GivenName {
            LastName = "Admin",
            FirstName = "Admin",
            MiddleName = "Admin",
            Ablative = profile
        };
        var prepositional = new GivenName() {
            LastName = "Admin",
            FirstName = "Admin",
            MiddleName = "Admin",
            Prepositional = profile
        };
        db.GivenNames.AddRange(
            nominative,
            genitive,
            dative,
            accusative,
            ablative,
            prepositional
        );

        db.SaveChanges();
    }
    
    string GetHashSHA256(string str)
    {
        var SHA256 = new SHA256Managed();
        var hash = new StringBuilder();
        byte[] cryptBytes = SHA256.ComputeHash(Encoding.UTF8.GetBytes(str));
        foreach (byte crypeByte in cryptBytes)
            hash.Append(crypeByte.ToString("x2"));
        
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
            var user = db.Users.FirstOrDefault(user => user.Id == _currentSelection.Id, defaultUser);

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
        }, null);

    RelayCommand? _closePageCommand;
    public RelayCommand ClosePageCommand =>
        _closePageCommand ??= new(_ => {
            GoToPage(null);
        }, null);

    RelayCommand? _tablePageCommand;
    public RelayCommand TablePageCommand =>
        _tablePageCommand ??= new(_ => {
            GoToPage("TableOrderManager");
        }, null);
}
