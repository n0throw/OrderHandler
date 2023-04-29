using System;
using System.Collections.Generic;

using OrderHandler.UI.Model.ViewOrderAdd;

namespace OrderHandler.UI.Model.Validation.Validators; 

public interface IViewGrindingValidator : IValidator<ViewGrinding> {
	public IEnumerable<string> ValidatePlannedDate(DateTime plannedDate);
	public IEnumerable<string> ValidateAreaOfMDF(decimal areaOfMDF);
}