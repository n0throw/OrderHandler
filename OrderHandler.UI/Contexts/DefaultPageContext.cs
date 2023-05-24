using OrderHandler.UI.Core;

namespace OrderHandler.UI.Contexts;

public class DefaultPageContext : PropertyChanger {
    public DefaultPageContext() { }

    RelayCommand? _closePageCommand;
    public RelayCommand ClosePageCommand =>
        _closePageCommand ??= new(obj => {
            GoToPage("Login");
        }, null);
}