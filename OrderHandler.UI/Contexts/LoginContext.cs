using OrderHandler.DB;
using OrderHandler.DB.Data;
using OrderHandler.UI.Core;
using OrderHandler.UI.Model;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace OrderHandler.UI.Contexts;

public class LoginContext : PropertyChanger {
    UserCombo _currentSelection;
    string _password;

    public ObservableCollection<UserCombo> UserCombos { get; set; }
    public UserCombo CurrentSelection {
        get => _currentSelection;
        set {
            _currentSelection = value;
            OnPropertyChanged(nameof(CurrentSelection));
        }
    }
    public string Password {
        get => _password;
        set {
            _password = value;
            OnPropertyChanged(nameof(Password));
        }
    }

    public LoginContext() {
        UserCombos = new ObservableCollection<UserCombo>();
        FillUserCombos();
    }

    void FillUserCombos() => throw new NotImplementedException();

    RelayCommand? entryCommand;
    public RelayCommand EntryCommand =>
        entryCommand ??= new RelayCommand(obj => {
            using var dbContext = new Context();
            var validateUser = (string dbPass, string currPass) => {
                if (dbPass == string.Empty)
                    return false;
                if (dbPass != currPass)
                    return false;
                return true;
            };

            User defaultUser = new() {
                Id = -1,
                PasswordHash = string.Empty,
            };
            User user = dbContext.Users.FirstOrDefault(user => user.Id == currentSelection.Id, defaultUser);

            if (validateUser(user.PasswordHash, password)) {
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

    private RelayCommand closePageCommand;
    public RelayCommand ClosePageCommand =>
        closePageCommand ??= new RelayCommand(obj => {
            GoToPage(null);
        }, null);

    private RelayCommand tablePageCommand;
    public RelayCommand TablePageCommand =>
        tablePageCommand ??= new RelayCommand(obj => {
            GoToPage("TableOrderManager");
        }, null);
}
