using System;
using System.Collections.Generic;

using OrderHandler.UI.Model.ViewOrderAdd;

namespace OrderHandler.UI.Model.Validation.Validators; 

public interface IViewDocConstValidator : IValidator<ViewDocConst> {
	public IEnumerable<string> ValidatePlannedDate(DateTime plannedDate);
}