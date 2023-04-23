using System;
using System.Linq;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Controls;

namespace OrderHandler.UI.Converters;

public class ColumnToBorderWidthConverter : IMultiValueConverter {
	public object Convert(object[] values,
						  Type targetType,
						  object parameter,
						  CultureInfo culture
	) => values
		 .Select(val => ((DataGridLength)val).Value)
		 .Sum() + values.Length - 1.0;

	public object[] ConvertBack(object value,
								Type[] targetTypes,
								object parameter,
								CultureInfo culture
	) => throw new NotSupportedException();
}