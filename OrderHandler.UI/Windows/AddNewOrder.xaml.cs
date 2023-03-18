using System.Windows;
using OrderHandler.UI.Contexts;

namespace OrderHandler.UI.Windows;

public partial class AddNewOrder : Window {
    public AddNewOrder() {
        InitializeComponent();
        DataContext = new AddNewOrderContext();
    }
}
