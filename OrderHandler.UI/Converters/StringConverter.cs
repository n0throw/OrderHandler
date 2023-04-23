using System;
using System.Windows.Data;
using System.Globalization;

namespace OrderHandler.UI.Converters;

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