using OrderHandler.UI.Core;

namespace OrderHandler.UI.Contexts;

public class LoginContext : PropertyChanger {
    public LoginContext() { }

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
