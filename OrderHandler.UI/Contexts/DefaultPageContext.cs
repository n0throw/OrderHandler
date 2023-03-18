using System;
using OrderHandler.UI.Core;

namespace OrderHandler.UI.Contexts;

public class DefaultPageContext : PropertyChanger {
    // выпилить и добавить в Binding на page?
    public bool LockedCaps => Console.CapsLock;

    public DefaultPageContext() { }

    private RelayCommand closePageCommand;
    public RelayCommand ClosePageCommand =>
        closePageCommand ??= new RelayCommand(obj => {
            GoToPage("Login");
        }, null);
}