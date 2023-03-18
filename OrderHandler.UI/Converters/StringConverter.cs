using System;
using System.Globalization;
using System.Windows.Data;

namespace OrderHandler.UI.Converters;

public class StringConverter : IValueConverter {
    public object Convert(object value,
                          Type targetType,
                          object parameter,
                          CultureInfo culture) {
        string? str = value as string;

        if (string.IsNullOrEmpty(str))
            return string.Empty;

        return str;
    }

    public object? ConvertBack(object value,
                               Type targetType,
                               object parameter,
                               CultureInfo culture) {
        string? str = value as string;

        if (string.IsNullOrEmpty(str))
            return null;

        return str;
    }
}