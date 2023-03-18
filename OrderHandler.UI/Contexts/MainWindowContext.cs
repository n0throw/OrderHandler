using System.Windows.Controls;
using System.Windows.Navigation;
using OrderHandler.UI.Core;

namespace OrderHandler.UI.Contexts;

public class MainWindowContext : PropertyChanger {
    private readonly PageManager pageManager;
    private readonly NavigationService navigationService;

    public MainWindowContext(NavigationService navigationService) {
        this.navigationService = navigationService;
        pageManager = new(Navigate);
        Navigate(pageManager.SetFirstPage("Login"));
    }

    private void Navigate(Page page) =>
        navigationService.Navigate(page);
}
