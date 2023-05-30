using System.Windows;

namespace OrderHandler.DBConfigurator;

public partial class MainWindow : Window {
	public MainWindow() {
		InitializeComponent();
		DataContext = new MainWindowContext();
	}
}