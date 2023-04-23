using System;
using System.Windows.Data;
using System.Globalization;

namespace OrderHandler.UI.Converters;

public class DateTimeToStringConverter : IValueConverter {
	public object Convert(object value,
						  Type targetType,
						  object parameter,
						  CultureInfo culture
	) {
		if (value is not DateTime date)
			return DateTime.Now;

		return date.Year == 1 
			? string.Empty 
			: (date).ToString("dd.MM.yyyy");
	}

	public object ConvertBack(object value,
							  Type targetType,
							  object parameter,
							  CultureInfo culture
	) => (DateTime)value;
}