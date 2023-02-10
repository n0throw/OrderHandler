#region System_Using
using System.Windows;
#endregion System_Using

#region OrderHandler_Using
using OrderHandler.UI.Contexts;
using OrderHandler.UI.Pages.Tables;
#endregion OrderHandler_Using

namespace OrderHandler.UI;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        //DataContext = new MainWindowContext(MainFrame.NavigationService);
        MainFrame.Navigate(new TableOrderManager());
    }
}
