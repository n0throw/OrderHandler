#region System_Using
using System.Windows.Controls;
using System.Windows.Navigation;
#endregion System_Using

#region OrderHandler_Using
using OrderHandler.UI.Core;
#endregion OrderHandler_Using

namespace OrderHandler.UI.Contexts;

internal class MainWindowContext : PropertyChanger
{
    private readonly PageManager pageManager;
    private readonly NavigationService navigationService;

    internal MainWindowContext(NavigationService navigationService)
    {
        this.navigationService = navigationService;
        pageManager = new(Navigate);
        Navigate(pageManager.SetFirstPage("Login"));
    }

    private void Navigate(Page page)
        => navigationService.Navigate(page);
}
