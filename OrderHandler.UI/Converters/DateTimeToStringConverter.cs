using System;
using System.Globalization;
using System.Windows.Data;

namespace OrderHandler.UI.Converters;

public class DateTimeToStringConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        DateTime data = (DateTime)value;
        
        if (data == DateTime.MinValue)
            return string.Empty;

        return data.ToString("dd.MM.yyyy");
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        => DateTime.Parse((string)value);
}