﻿using System;
using System.Collections.Generic;

using OrderHandler.UI.Model.ViewOrderAdd;

namespace OrderHandler.UI.Model.Validation.Validators; 

public interface IViewMountingValidator : IValidator<ViewMounting> {
	public IEnumerable<string> ValidatePlannedDate(DateTime plannedDate);
}