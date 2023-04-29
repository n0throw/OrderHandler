using System;
using System.Collections.Generic;

using OrderHandler.UI.Model.ViewOrderAdd;

namespace OrderHandler.UI.Model.Validation.Validators; 

public class ViewMillingValidator : Validator<ViewMilling>, IViewMillingValidator {

	public ViewMillingValidator(string separator = "\n") : base(separator) { }

	public override bool Validate(ViewMilling obj) {
		Errors.Clear();
		
		Errors.AddRange(
			CreateValidationResults(
				nameof(obj.PlannedDate), 
				ValidatePlannedDate(obj.PlannedDate)
			)
		);
		Errors.AddRange(
			CreateValidationResults(
				nameof(obj.AreaOfMDF), 
				ValidateAreaOfMDF(obj.AreaOfMDF)
			)
		);
		
		return Errors.Count == 0;
	}

	public IEnumerable<string> ValidatePlannedDate(DateTime plannedDate) =>
		BaseTypeValidator.ValidateDate(plannedDate);

	public IEnumerable<string> ValidateAreaOfMDF(decimal areaOfMDF) =>
		BaseTypeValidator.ValidatePositiveDecimal(areaOfMDF);
}