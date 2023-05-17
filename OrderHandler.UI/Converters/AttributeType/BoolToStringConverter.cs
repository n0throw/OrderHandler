using System;
using System.Globalization;
using System.Windows.Data;

namespace OrderHandler.UI.Converters.AttributeType;

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