using System;
using System.Globalization;
using System.Windows.Data;

namespace OrderHandler.UI.Converters;

public class DecimalConverter : IValueConverter {
    public object Convert(object value,
                          Type targetType,
                          object parameter,
                          CultureInfo culture) {
        if (value is not decimal num)
            return string.Empty;
        else
            return num.ToString();
    }

    public object? ConvertBack(object value,
                               Type targetType,
                               object parameter,
                               CultureInfo culture) {
        string? str = value as string;

        if (string.IsNullOrEmpty(str))
            return null;

        if (decimal.TryParse(str, out decimal num))
            return num;

        return null;
    }
}