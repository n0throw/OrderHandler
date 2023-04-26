using System;
using System.Collections.Generic;

using OrderHandler.UI.Model.ViewOrderAdd;

namespace OrderHandler.UI.Model.Validation.Validators; 

public interface IViewShipmentValidator : IValidator<ViewShipment> {
	public bool ValidatePlannedDate(DateTime plannedDate, out List<string> error);
}