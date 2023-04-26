using System;
using System.Collections.Generic;

using OrderHandler.UI.Model.ViewOrderAdd;

namespace OrderHandler.UI.Model.Validation.Validators;
public interface IViewOrderMainValidator : IValidator<ViewOrderMain> {
    public bool ValidateOrderNumber(string? orderIssue, out List<string> error);
    public bool ValidateOrderDate(DateTime order, DateTime delivery, out List<string> error);
    public bool ValidateDeliveryDate(DateTime order, DateTime delivery, out List<string> error);
    public bool ValidateProductType(string? type, out List<string> error);
    public bool ValidateOrderAmount(decimal? productCost, out List<string> error);
}