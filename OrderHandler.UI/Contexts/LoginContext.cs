#region System_Using
using System;
#endregion System_Using

#region OrderHandler_Using
using OrderHandler.UI.Core;
#endregion OrderHandler_Using

namespace OrderHandler.UI.Contexts;

internal class LoginContext : PropertyChanger
{
    // выпилить и добавить в Binding на page?
    public bool LockedCaps { get; set; } = Console.CapsLock;

    internal LoginContext()
    {

    }

    private RelayCommand closePageCommand;
    public RelayCommand ClosePageCommand
    {
        get => closePageCommand ??= new RelayCommand(obj =>
        {
            GoToPage(null);
        }, null);
    }

    private RelayCommand tablePageCommand;
    public RelayCommand TablePageCommand
    {
        get => tablePageCommand ??= new RelayCommand(obj =>
        {
            GoToPage("TableOrderManager");
        }, null);
    }
}
