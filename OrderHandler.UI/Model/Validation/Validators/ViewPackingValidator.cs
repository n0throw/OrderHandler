using System;
using System.Collections.Generic;

using OrderHandler.UI.Model.ViewOrderAdd;

namespace OrderHandler.UI.Model.Validation.Validators; 

public class ViewPackingValidator : Validator<ViewPacking>, IViewPackingValidator {

	public ViewPackingValidator(string separator = "\n") : base(separator) { }

	public override bool Validate(ViewPacking obj) {
		Errors.Clear();
		
		Errors.AddRange(
			CreateValidationResults(
				nameof(obj.PlannedDate),
				ValidatePlannedDate(obj.PlannedDate)
			)
		);
		Errors.AddRange(
			CreateValidationResults(
				nameof(obj.AreaOfLCBOrMDF),
				ValidateAreaOfLCBOrMDF(obj.AreaOfLCBOrMDF)
			)
		);
		
		return Errors.Count == 0;
	}

	public IEnumerable<string> ValidatePlannedDate(DateTime plannedDate) =>
		BaseTypeValidator.ValidateDate(plannedDate);

	public IEnumerable<string> ValidateAreaOfLCBOrMDF(decimal areaOfLCBOrMDF) =>
		BaseTypeValidator.ValidatePositiveDecimal(areaOfLCBOrMDF);
}