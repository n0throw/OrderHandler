using System;
using System.Collections.Generic;

using OrderHandler.UI.Model.ViewOrderAdd;

namespace OrderHandler.UI.Model.Validation.Validators; 

public interface IViewPressValidator : IValidator<ViewPress> {
	public IEnumerable<string> ValidatePlannedDate(DateTime plannedDate);
	public IEnumerable<string> ValidateAreaOfLCBOrMDF(decimal areaOfLCBOrMDF);
}