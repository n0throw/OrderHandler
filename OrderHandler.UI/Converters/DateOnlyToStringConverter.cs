using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows;

namespace OrderHandler.UI.Converters;

public class DateOnlyToStringConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        => ((DateOnly)value).ToString("dd.MM.yyyy");

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        => DateOnly.Parse((string)value);
}