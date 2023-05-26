using System.Windows;
using OrderHandler.UI.Contexts;
using OrderHandler.UI.Contexts.Windows;

namespace OrderHandler.UI.Windows;

public partial class NewOrder : Window {
    public NewOrder() {
        InitializeComponent();
        DataContext = new NewOrderContext();
    }
}
