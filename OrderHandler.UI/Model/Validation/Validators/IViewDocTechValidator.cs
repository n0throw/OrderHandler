using System;
using System.Collections.Generic;

using OrderHandler.UI.Model.ViewOrderAdd;

namespace OrderHandler.UI.Model.Validation.Validators; 

public interface IViewDocTechValidator : IValidator<ViewDocTech> {
	public IEnumerable<string> ValidatePlannedDate(DateTime plannedDate);
}