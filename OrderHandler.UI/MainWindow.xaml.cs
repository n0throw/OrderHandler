using System.Windows;
using OrderHandler.UI.Contexts;

namespace OrderHandler.UI;

public partial class MainWindow : Window {
	public MainWindow() {
		InitializeComponent();
		DataContext = new MainWindowContext(MainFrame.NavigationService);
	}
}