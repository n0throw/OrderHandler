using OrderHandler.UI.Core;
using OrderHandler.UI.Pages;

namespace OrderHandler.UI.Contexts.Pages;

public class ErrorContext : PropertyChanger {
    string _description;
    public ErrorContext() { }

    public string Description {
        get => _description;
        set {
            _description = value;
            OnPropertyChanged();
        }
    }
    
    
    // ---------- Меню страницы ----------
    // ---------- Статусы ----------
    RelayCommand? _showStatusWindowCommand;
    public RelayCommand ShowStatusWindowCommand =>
        _showStatusWindowCommand ??= new(obj => {
            
        }, null);
    
    RelayCommand? _returnToMainMenuScreen;
    public RelayCommand ReturnToMainMenuScreen =>
        _returnToMainMenuScreen ??= new(obj => {
            
        }, null);
    
    RelayCommand? _returnToLoginScreen;
    public RelayCommand ReturnToLoginScreen =>
        _returnToLoginScreen ??= new(obj => {
            GoToPage(nameof(Login));
        }, null);
}