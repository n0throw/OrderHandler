using System;
using System.Collections.Generic;

using OrderHandler.UI.Model.ViewOrderAdd;

namespace OrderHandler.UI.Model.Validation.Validators; 

public interface IViewAdditiveValidator : IValidator<ViewAdditive> {
	public bool ValidatePlannedDate(DateTime plannedDate, out List<string> error);
	public bool ValidateAreaOfLCBOrMDF(decimal areaOfLCBOrMDF, out List<string> error);
}