using System;
using System.Collections.Generic;

using OrderHandler.UI.Model.ViewOrderAdd;

namespace OrderHandler.UI.Model.Validation.Validators;
public interface IViewOrderMainValidator : IValidator<ViewOrderMain> {
    public IEnumerable<string> ValidateOrderNumber(string orderIssue);
    public IEnumerable<string> ValidateOrderDate(DateTime order, DateTime delivery);
    public IEnumerable<string> ValidateDeliveryDate(DateTime order, DateTime delivery);
    public IEnumerable<string> ValidateProductType(string type);
    public IEnumerable<string> ValidateOrderAmount(decimal productCost);
}