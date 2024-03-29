﻿using System;
using System.Globalization;
using System.Windows.Data;

namespace OrderHandler.UI.Converters.AttributeType;

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