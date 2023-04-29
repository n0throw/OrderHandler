using System;
using System.Collections.Generic;

using OrderHandler.UI.Model.ViewOrderAdd;

namespace OrderHandler.UI.Model.Validation.Validators; 

public interface IViewSupplyValidator : IValidator<ViewSupply> {
	public IEnumerable<string> ValidatePlannedDate(DateTime plannedDate);
	public IEnumerable<string> ValidateRequiredAmount(decimal requiredAmount);
}