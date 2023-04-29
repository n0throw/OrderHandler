using System;
using System.Collections.Generic;

using OrderHandler.UI.Model.ViewOrderAdd;

namespace OrderHandler.UI.Model.Validation.Validators; 

public class ViewSupplyValidator : Validator<ViewSupply>, IViewSupplyValidator {

	public ViewSupplyValidator(string separator = "\n") : base(separator) { }
	public override bool Validate(ViewSupply obj) {
		Errors.Clear();
		
		Errors.AddRange(
			CreateValidationResults(
				nameof(obj.PlannedDate),
				ValidatePlannedDate(obj.PlannedDate)
			)
		);
		Errors.AddRange(
			CreateValidationResults(
				nameof(obj.RequiredAmount),
				ValidateRequiredAmount(obj.RequiredAmount)
			)
		);
		
		return Errors.Count == 0;
	}

	public IEnumerable<string> ValidatePlannedDate(DateTime plannedDate) =>
		BaseTypeValidator.ValidateDate(plannedDate);
	
	public IEnumerable<string> ValidateRequiredAmount(decimal requiredAmount) =>
		BaseTypeValidator.ValidatePositiveDecimal(requiredAmount);
}