using System;
using System.Collections.Generic;

namespace OrderHandler.UI.Model.Validation.Validators; 

static class BaseTypeValidator {
	const string ObligatoryValue = "Это поле обязательно для заполнения";
	const string DateIsSmall = "Дата не может быть до 2019-го года";
	const string ValueCanNotNegative = "Значение не может быть отрицательным";

	internal static IEnumerable<string> ValidateDate(DateTime date) {
		List<string> error = new();
		if (date < new DateTime(2019, 1, 1))
			error.Add(DateIsSmall);

		return error;
	}

	internal static IEnumerable<string> ValidatePositiveDecimal(decimal val) {
		List<string> error = new();
		if (val < 0)
			error.Add(ValueCanNotNegative);

		return error;
	}
	
	internal static IEnumerable<string> ValidateObligatoryString(string str) {
		List<string> error = new();
		if (str == string.Empty)
			error.Add(ObligatoryValue);

		return error;
	}
}