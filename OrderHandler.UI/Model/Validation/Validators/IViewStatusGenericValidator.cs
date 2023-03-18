using System;
using System.Collections.Generic;
using OrderHandler.UI.Model.ViewOrderAdd.Data;

namespace OrderHandler.UI.Model.Validation.Validators;
public interface IViewStatusGenericValidator : IValidator<ViewDataStatusGeneric> {
    public bool ValidatePlannedDate(DateTime planned, out List<string> error);
}
