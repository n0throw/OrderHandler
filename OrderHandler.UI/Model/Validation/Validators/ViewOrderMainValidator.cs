using System;
using System.Linq;
using System.Collections.Generic;

using OrderHandler.UI.Model.ViewOrderAdd;

namespace OrderHandler.UI.Model.Validation.Validators;
public class ViewOrderMainValidator : Validator<ViewOrderMain>, IViewOrderMainValidator {
    const string ObligatoryValue = "Это поле обязательно для заполнения";
    const string ValueGreaterZero = "Значение должно быть больше нуля";
    const string OrderOverDeliveryDate = "Дата заказа не может быть больше даты доставки";
    const string OrderDateIsSmall = "Дата заказа не может быть до 2019-го года";
    const string DeliveryDateIsSmall = "Дата доставки не может быть до 2019-го года";

    public ViewOrderMainValidator(string separator = "\n") : base(separator) { }

    public override bool Validate(ViewOrderMain obj) {
        Errors.Clear();

        if (!ValidateOrderNumber(obj.OrderNumber, out var errorsOrderIssue))
            Errors.AddRange(CreateValidationResults(nameof(obj.OrderNumber), errorsOrderIssue));
        if (!ValidateOrderDate(obj.OrderDate, obj.DeliveryDate, out var errorsOrderDate))
            Errors.AddRange(CreateValidationResults(nameof(obj.OrderDate), errorsOrderDate));
        if (!ValidateDeliveryDate(obj.OrderDate, obj.DeliveryDate, out var errorsDeliveryDate))
            Errors.AddRange(CreateValidationResults(nameof(obj.DeliveryDate), errorsDeliveryDate));
        if (!ValidateProductType(obj.ProductType, out var errorsProductType))
            Errors.AddRange(CreateValidationResults(nameof(obj.ProductType), errorsProductType));
        if (!ValidateOrderAmount(obj.OrderAmount, out var errorsProductCost))
            Errors.AddRange(CreateValidationResults(nameof(obj.OrderAmount), errorsProductCost));

        return Errors.Count == 0;
    }

    public bool ValidateOrderNumber(string? orderNumber, out List<string> error) {
        error = new();
        if (orderNumber == string.Empty)
            error.Add(ObligatoryValue);

        return !error.Any();
    }
    public bool ValidateOrderDate(DateTime order, DateTime delivery, out List<string> error) {
        error = new();
        if (order < delivery)
            error.Add(OrderOverDeliveryDate);
        if (order < new DateTime(2019, 1, 1))
            error.Add(OrderDateIsSmall);

        return !error.Any();
    }
    public bool ValidateDeliveryDate(DateTime order, DateTime delivery, out List<string> error) {
        error = new();
        if (order < delivery)
            error.Add(OrderOverDeliveryDate);
        if (delivery < new DateTime(2019, 1, 1))
            error.Add(DeliveryDateIsSmall);

        return !error.Any();
    }
    public bool ValidateProductType(string? type, out List<string> error) {
        error = new();
        if (type == string.Empty)
            error.Add(ObligatoryValue);

        return !error.Any();
    }
    public bool ValidateOrderAmount(decimal? orderAmount, out List<string> error) {
        error = new();
        switch (orderAmount) {
            case null:
                error.Add(ObligatoryValue);
                break;
            case 0:
                error.Add(ValueGreaterZero);
                break;
        }

        return !error.Any();
    }
}