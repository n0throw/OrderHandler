using System;
using System.Globalization;
using System.Windows.Data;

namespace OrderHandler.UI.Converters.AttributeType;

public class StringConverter : IValueConverter {
	public object Convert(object value,
						  Type targetType,
						  object parameter,
						  CultureInfo culture
	) {
		var str = value as string;
		return string.IsNullOrEmpty(str) 
			? string.Empty
			: str;
	}

	public object? ConvertBack(object value,
							   Type targetType,
							   object parameter,
							   CultureInfo culture
	) {
		var str = value as string;
		return string.IsNullOrEmpty(str) 
			? null
			: str;
	}
}