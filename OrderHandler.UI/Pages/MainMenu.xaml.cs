using System.Windows.Controls;

using OrderHandler.UI.Contexts.Pages;

namespace OrderHandler.UI.Pages; 

public partial class MainMenu : Page {
	public MainMenu() {
		InitializeComponent();
		DataContext = new MainMenuContext();
	}
}