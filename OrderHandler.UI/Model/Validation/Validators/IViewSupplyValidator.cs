using System;
using System.Collections.Generic;

using OrderHandler.UI.Model.ViewOrderAdd;

namespace OrderHandler.UI.Model.Validation.Validators; 

public interface IViewSupplyValidator : IValidator<ViewSupply> {
	public bool ValidatePlannedDate(DateTime plannedDate, out List<string> error);
	public bool ValidateRequiredAmount(decimal requiredAmount, out List<string> error);
}