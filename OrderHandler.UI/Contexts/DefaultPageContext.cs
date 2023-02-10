#region System_Using
using System;
#endregion System_Using

#region OrderHandler_Using
using OrderHandler.UI.Core;
#endregion OrderHandler_Using

namespace OrderHandler.UI.Contexts;

internal class DefaultPageContext : PropertyChanger
{
    // выпилить и добавить в Binding на page?
    internal bool LockedCaps => Console.CapsLock;

    internal DefaultPageContext()
    {

    }

    private RelayCommand closePageCommand;
    public RelayCommand ClosePageCommand
    {
        get => closePageCommand ??= new RelayCommand(obj =>
        {
            GoToPage("Login");
        }, null);
    }
}