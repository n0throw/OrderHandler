using System;
using System.Windows.Controls;

namespace OrderHandler.UI.Pages;

public partial class Login : Page
{
    public Login()
        => InitializeComponent();

    private void PreviewKeyDown_Caps(object sender, System.Windows.Input.KeyEventArgs e)
        => CapsLocked.IsChecked = Console.CapsLock;
}