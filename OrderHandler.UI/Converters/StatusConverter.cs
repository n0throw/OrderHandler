using OrderHandler.UI.Model;

using System;
using System.Globalization;
using System.Windows.Data;

namespace OrderHandler.UI.Converters;

public class StatusConverter : IMultiValueConverter
{
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        => new Tuple<ViewOrder, string>(
            (ViewOrder)values[0],
            (string)values[1]);

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
