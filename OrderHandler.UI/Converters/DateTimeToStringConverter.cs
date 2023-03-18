using System;
using System.Globalization;
using System.Windows.Data;

namespace OrderHandler.UI.Converters;

public class DateTimeToStringConverter : IValueConverter {
    public object Convert(object value,
                          Type targetType,
                          object parameter,
                          CultureInfo culture) {
        if (value is null)
            return DateTime.Now;

        DateTime date = (DateTime)value;

        if (date.Year == 1)
            return string.Empty;

        return (date).ToString("dd.MM.yyyy");
    }

    public object ConvertBack(object value,
                          Type targetType,
                          object parameter,
                          CultureInfo culture) =>
        (DateTime)value;
}