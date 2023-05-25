using System.Windows;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace OrderHandler.UI.Core;

public class PropertyChanger : INotifyPropertyChanged {
    public delegate void TurnPageHandler(string? alias);
    public event TurnPageHandler? TurnPage;
    public event PropertyChangedEventHandler? PropertyChanged;

    RelayCommand? _closeAppCommand;
    public virtual RelayCommand CloseAppCommand => 
        _closeAppCommand ??= new(
            _ => 
                Application.Current.Shutdown(), 
            null
        );

    RelayCommand? _basicAppSettingsCommand;
    public virtual RelayCommand BasicAppSettingsCommand =>
        _basicAppSettingsCommand ??= new(
            _ => {
                //todo тут открываем окно "Основные настройки приложения". С настройкой языка, темы, формта, etc. Оно для всех одно
            }, null
        );
    
    RelayCommand? _aboutAppCommand;
    public virtual RelayCommand AboutAppCommand =>
        _aboutAppCommand ??= new(
            _ => {
                //todo тут открываем окно "О приложении". Оно для всех одно
            }, null
        );
    
    RelayCommand? _userAgreementCommand;
    public virtual RelayCommand UserAgreementCommand =>
        _userAgreementCommand ??= new(
            _ => {
                //todo тут открываем окно "Пользовательское соглашение". Показывает информацию о лицензии на приложении и доп. библиотеки. Оно для всех одно
            }, null
        );
    
    protected void OnPropertyChanged([CallerMemberName] string prop = "") =>
        PropertyChanged?.Invoke(this, new(prop));

    protected void GoToPage(string? alias) =>
        TurnPage?.Invoke(alias);
}