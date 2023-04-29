using System;
using System.Collections.Generic;
using System.Linq;

using OrderHandler.UI.Model.ViewOrderAdd;

namespace OrderHandler.UI.Model.Validation.Validators;
public class ViewOrderMainValidator : Validator<ViewOrderMain>, IViewOrderMainValidator {
    const string OrderOverDeliveryDate = "Дата заказа не может быть больше даты доставки";

    public ViewOrderMainValidator(string separator = "\n") : base(separator) { }

    public override bool Validate(ViewOrderMain obj) {
        Errors.Clear();

        Errors.AddRange(
            CreateValidationResults(
                nameof(obj.OrderNumber), 
                ValidateOrderNumber(obj.OrderNumber)
            )
        );
        Errors.AddRange(
            CreateValidationResults(
                nameof(obj.OrderDate), 
                ValidateOrderDate(obj.OrderDate, obj.DeliveryDate)
            )
        );
        Errors.AddRange(
            CreateValidationResults(
                nameof(obj.DeliveryDate), 
                ValidateDeliveryDate(obj.OrderDate, obj.DeliveryDate)
            )
        );
        Errors.AddRange(
            CreateValidationResults(
                nameof(obj.ProductType), 
                ValidateProductType(obj.ProductType)
            )
        );
        Errors.AddRange(
            CreateValidationResults(
                nameof(obj.OrderAmount), 
                ValidateOrderAmount(obj.OrderAmount)
            )
        );

        return Errors.Count == 0;
    }

    public IEnumerable<string> ValidateOrderNumber(string orderNumber) =>
        BaseTypeValidator.ValidateObligatoryString(orderNumber);
    
    public IEnumerable<string> ValidateOrderDate(DateTime order, DateTime delivery) {
        var error = BaseTypeValidator
            .ValidateDate(order)
            .ToList();
        if (order < delivery)
            error.Add(OrderOverDeliveryDate);

        return error;
    }
    
    public IEnumerable<string> ValidateDeliveryDate(DateTime order, DateTime delivery) {
        var error = BaseTypeValidator
            .ValidateDate(order)
            .ToList();
        if (order < delivery)
            error.Add(OrderOverDeliveryDate);

        return error;
    }

    public IEnumerable<string> ValidateProductType(string type) =>
        BaseTypeValidator.ValidateObligatoryString(type);

    public IEnumerable<string> ValidateOrderAmount(decimal orderAmount) =>
        BaseTypeValidator.ValidatePositiveDecimal(orderAmount);
}