using System;
using System.Collections.Generic;

using OrderHandler.UI.Model.ViewOrderAdd;

namespace OrderHandler.UI.Model.Validation.Validators; 

public class ViewSawCenterValidator : Validator<ViewSawCenter>, IViewSawCenterValidator {

	public ViewSawCenterValidator(string separator = "\n") : base(separator) { }
	public override bool Validate(ViewSawCenter obj) {
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
		Errors.AddRange(
			CreateValidationResults(
				nameof(obj.AreaOfLHDF),
				ValidateAreaOfLHDF(obj.AreaOfLHDF)
			)
		);
		
		return Errors.Count == 0;
	}

	public IEnumerable<string> ValidatePlannedDate(DateTime plannedDate) =>
		BaseTypeValidator.ValidateDate(plannedDate);

	public IEnumerable<string> ValidateAreaOfLCBOrMDF(decimal areaOfLCBOrMDF) =>
		BaseTypeValidator.ValidatePositiveDecimal(areaOfLCBOrMDF);

	public IEnumerable<string> ValidateAreaOfLHDF(decimal areaOfLHDF) =>
		BaseTypeValidator.ValidatePositiveDecimal(areaOfLHDF);
}