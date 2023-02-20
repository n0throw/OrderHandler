using OrderHandler.UI.Contexts;
using System.Windows;

namespace OrderHandler.UI.Windows;

public partial class AddNewOrder : Window
{
    public AddNewOrder()
    {
        InitializeComponent();
        DataContext = new AddNewOrderContext();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
        => DialogResult = true;
}
