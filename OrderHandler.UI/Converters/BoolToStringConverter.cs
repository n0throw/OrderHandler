using System;
using System.Windows.Data;
using System.Globalization;

namespace OrderHandler.UI.Converters;

public class BoolToStringConverter : IValueConverter {
	public object Convert(object value,
						  Type targetType,
						  object parameter,
						  CultureInfo culture
	) {
		if (value is not bool data)
			return "Нет";

		return data ? "Да" : "Нет";
	}

	public object ConvertBack(object value,
							  Type targetType,
							  object parameter,
							  CultureInfo culture) {
		if (value is not string answer)
			return false;

		return answer == "Да";
	}
}