using System.Windows;

using OrderHandler.UI.Windows;

namespace OrderHandler.UI.Core;

public class MainPagePropertyChanger : BasePropertyChanger {
    public delegate void TurnPageHandler(string? alias);
    public event TurnPageHandler? TurnPage;

    RelayCommand? _closeAppCommand;
    public virtual RelayCommand CloseAppCommand => 
        _closeAppCommand ??= new(
            _ => 
                Application.Current.Shutdown(), 
            null
        );

    RelayCommand? _showBasicAppSettingsWindowCommand;
    public virtual RelayCommand ShowBasicAppSettingsWindowCommand =>
        _showBasicAppSettingsWindowCommand ??= new(
            _ => {
                //todo тут открываем окно "Основные настройки приложения". С настройкой языка, темы, формта, etc. Оно для всех одно
            }, null
        );
    
    RelayCommand? _showAboutAppWindowCommand;
    public virtual RelayCommand ShowAboutAppWindowCommand =>
        _showAboutAppWindowCommand ??= new(
            _ => {
                // todo Тут windowDialogManager бы какой-нибудь
                var aboutAppWindow = new AboutApp {
                    Owner = Application.Current.MainWindow
                };

                aboutAppWindow.ShowDialog();
            }, null
        );
    
    RelayCommand? _showUserAgreementWindowCommand;
    public virtual RelayCommand ShowUserAgreementWindowCommand =>
        _showUserAgreementWindowCommand ??= new(
            _ => {
                // todo Тут windowDialogManager бы какой-нибудь
                var userAgreementWindow = new UserAgreement {
                    Owner = Application.Current.MainWindow
                };

                userAgreementWindow.ShowDialog();
            }, null
        );
    
    protected void GoToPage(string? alias) =>
        TurnPage?.Invoke(alias);
}