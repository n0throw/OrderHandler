using System;
using System.Collections.Generic;

using OrderHandler.UI.Model.ViewOrderAdd;

namespace OrderHandler.UI.Model.Validation.Validators; 

public interface IViewGrindingValidator : IValidator<ViewGrinding> {
	public bool ValidatePlannedDate(DateTime plannedDate, out List<string> error);
	public bool ValidateAreaOfMDF(decimal areaOfMDF, out List<string> error);
}