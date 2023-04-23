using OrderHandler.UI.AttachedProp;
using System.Windows.Controls;

namespace OrderHandler.UI.Pages;

public partial class Login : Page {
    public Login() =>
        InitializeComponent();

    private void PasswordBox_PasswordChanged(object sender, System.Windows.RoutedEventArgs e) {
        PasswordBox pBox = sender as PasswordBox;
        PasswordBoxAttach.SetPasswordProp(pBox, pBox.Password);
    }
}