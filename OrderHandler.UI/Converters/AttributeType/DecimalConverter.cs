using System;
using System.Globalization;
using System.Windows.Data;

namespace OrderHandler.UI.Converters.AttributeType;

public class DecimalConverter : IValueConverter {
	public object Convert(object value,
						  Type targetType,
						  object parameter,
						  CultureInfo culture) {
		return value is not decimal num 
			? string.Empty 
			: num.ToString(CultureInfo.CurrentCulture);
	}

	public object? ConvertBack(object value,
							   Type targetType,
							   object parameter,
							   CultureInfo culture) {
		var str = value as string;

		if (string.IsNullOrEmpty(str))
			return null;

		if (decimal.TryParse(str, out decimal num))
			return num;

		return null;
	}
}