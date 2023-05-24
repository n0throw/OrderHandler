using System.Windows;

using OrderHandler.UI.AttachedProp;
using System.Windows.Controls;

namespace OrderHandler.UI.Pages;

public partial class Login : Page {
    public Login() =>
        InitializeComponent();

    void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e) {
        if (sender is PasswordBox pBox)
            PasswordBoxAttach.SetPasswordProp(pBox, pBox.Password);
        else
            MessageBox.Show("Password Box не найден?");
    }
}