using System.Windows;

using OrderHandler.UI.Contexts.Windows;

namespace OrderHandler.UI.Windows;

public partial class MainWindow : Window {
	public MainWindow() {
		InitializeComponent();
		DataContext = new MainWindowContext(MainFrame.NavigationService);
	}
}