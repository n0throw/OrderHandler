using System.Windows;

namespace OrderHandler.UI.AttachedProp;
public static class PasswordBoxAttach {
    public static string GetPasswordProp(DependencyObject obj) =>
        (string)obj.GetValue(PasswordProp);

    public static void SetPasswordProp(DependencyObject obj, string value) =>
        obj.SetValue(PasswordProp, value);

    public static readonly DependencyProperty PasswordProp =
        DependencyProperty.RegisterAttached(nameof(PasswordProp), typeof(string), typeof(PasswordBoxAttach));
}

