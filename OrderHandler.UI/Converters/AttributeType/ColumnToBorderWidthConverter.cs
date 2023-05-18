using System;
using System.Linq;
using System.Windows.Data;
using System.Globalization;

namespace OrderHandler.UI.Converters.AttributeType;

public class ColumnToBorderWidthConverter : IMultiValueConverter {
	const double BorderPixels = 7.0;

	public object Convert(object[] values,
		Type targetType,
		object parameter,
		CultureInfo culture
	) => values
		.Select(val => (double)val)
		.Sum() + 0.1;//values.Length - BorderPixels;

	public object[] ConvertBack(object value,
								Type[] targetTypes,
								object parameter,
								CultureInfo culture
	) => throw new NotSupportedException();
}