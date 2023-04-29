using System;
using System.Collections.Generic;

using OrderHandler.UI.Model.ViewOrderAdd;

namespace OrderHandler.UI.Model.Validation.Validators; 

public class ViewMountingValidator : Validator<ViewMounting>, IViewMountingValidator {

	public ViewMountingValidator(string separator = "\n") : base(separator) { }

	public override bool Validate(ViewMounting obj) {
		Errors.Clear();
		
		Errors.AddRange(
			CreateValidationResults(
				nameof(obj.PlannedDate), 
				ValidatePlannedDate(obj.PlannedDate)
			)
		);
		
		return Errors.Count == 0;
	}

	public IEnumerable<string> ValidatePlannedDate(DateTime plannedDate) =>
		BaseTypeValidator.ValidateDate(plannedDate);
}