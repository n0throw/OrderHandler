using System;
using System.Collections.Generic;
using OrderHandler.UI.Model.ViewOrderAdd.Data;

namespace OrderHandler.UI.Model.Validation.Validators;
public interface IViewOrderMainValidator : IValidator<ViewDataOrderMain> {
    public bool ValidateOrderIssue(string? orderIssue, out List<string> error);
    public bool ValidateOrderDate(DateTime order, DateTime delivery, out List<string> error);
    public bool ValidateDeliveryDate(DateTime order, DateTime delivery, out List<string> error) ;
    public bool ValidateProductType(string? type, out List<string> error) ;
    public bool ValidateProductCost(decimal? productCost, out List<string> error) ;
}