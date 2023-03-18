using System;
using System.Globalization;
using System.Windows.Data;

namespace OrderHandler.UI.Converters;

public class BoolToStringConverter : IValueConverter {
    public object Convert(object value,
                              Type targetType,
                              object parameter,
                              CultureInfo culture) {
        if (value is null)
            return "Нет";

        bool data = (bool)value;

        return data ? "Да" : (object)"Нет";
    }

    public object ConvertBack(object value,
                              Type targetType,
                              object parameter,
                              CultureInfo culture) {
        if (value is null)
            return false;

        return (string)value == "Да";
    }
}