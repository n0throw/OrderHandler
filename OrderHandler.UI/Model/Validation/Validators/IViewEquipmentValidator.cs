using System;
using System.Collections.Generic;

using OrderHandler.UI.Model.ViewOrderAdd;

namespace OrderHandler.UI.Model.Validation.Validators; 

public interface IViewEquipmentValidator : IValidator<ViewEquipment> {
	public IEnumerable<string> ValidatePlannedDate(DateTime plannedDate);
}