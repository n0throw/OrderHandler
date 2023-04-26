﻿using System;
using System.Collections.Generic;

using OrderHandler.UI.Model.ViewOrderAdd;

namespace OrderHandler.UI.Model.Validation.Validators; 

public interface IViewEdgeValidator : IValidator<ViewEdge> {
	public bool ValidatePlannedDate(DateTime plannedDate, out List<string> error);
	public bool ValidateAreaOfLCBOrMDF(decimal areaOfLCBOrMDF, out List<string> error);
}