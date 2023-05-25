using OrderHandler.UI.Core;

namespace OrderHandler.UI.Contexts;

public class DefaultPageContext : PropertyChanger {
    public DefaultPageContext() { }
    
    
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
            GoToPage("Login");
        }, null);
}