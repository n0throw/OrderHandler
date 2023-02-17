using System;
using System.Globalization;
using System.Windows.Data;

namespace OrderHandler.UI.Converters;

public class BoolToStringConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is null)
            return "Нет";

        bool data = (bool)value;

        if (data)
            return "Да";
        return "Нет";
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is null)
            return false;

        if ((string)value == "Да")
            return true;
        return false;
    }
}