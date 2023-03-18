using System;
using System.Linq;
using System.Collections.Generic;
using OrderHandler.UI.Model.ViewOrderAdd.Data;

namespace OrderHandler.UI.Model.Validation.Validators;
public class ViewOrderMainValidator : Validator<ViewDataOrderMain>, IViewOrderMainValidator {
    private const string obligatoryValue = "Это поле обязательно для заполнения";
    private const string valueGreaterZero = "Значение должно быть больше нуля";
    private const string orderOverDeliveryDate = "Дата заказа не может быть больше даты доставки";
    private const string orderDateIsSmall = "Дата заказа не может быть до 2019-го года";
    private const string deliveryDateIsSmall = "Дата доставки не может быть до 2019-го года";

    public ViewOrderMainValidator(string separator = "\n") : base(separator) { }

    public override bool Validate(ViewDataOrderMain obj) {
        Errors.Clear();

        if (!ValidateOrderIssue(obj.OrderIssue, out List<string> errorsOrderIssue))
            Errors.AddRange(CreateValidationResults(nameof(obj.OrderIssue), errorsOrderIssue));
        if (!ValidateOrderDate(obj.OrderDate, obj.DeliveryDate, out List<string> errorsOrderDate))
            Errors.AddRange(CreateValidationResults(nameof(obj.OrderDate), errorsOrderDate));
        if (!ValidateDeliveryDate(obj.OrderDate, obj.DeliveryDate, out List<string> errorsDeliveryDate))
            Errors.AddRange(CreateValidationResults(nameof(obj.DeliveryDate), errorsDeliveryDate));
        if (!ValidateProductType(obj.ProductType, out List<string> errorsProductType))
            Errors.AddRange(CreateValidationResults(nameof(obj.ProductType), errorsProductType));
        if (!ValidateProductCost(obj.ProductCost, out List<string> errorsProductCost))
            Errors.AddRange(CreateValidationResults(nameof(obj.ProductCost), errorsProductCost));

        return Errors.Count == 0;
    }

    public bool ValidateOrderIssue(string? orderIssue, out List<string> error) {
        error = new();
        if (orderIssue == string.Empty)
            error.Add(obligatoryValue);

        return !error.Any();
    }
    public bool ValidateOrderDate(DateTime order, DateTime delivery, out List<string> error) {
        error = new();
        if (order < delivery)
            error.Add(orderOverDeliveryDate);
        if (order < new DateTime(2019, 1, 1))
            error.Add(orderDateIsSmall);

        return !error.Any();
    }
    public bool ValidateDeliveryDate(DateTime order, DateTime delivery, out List<string> error) {
        error = new();
        if (order < delivery)
            error.Add(orderOverDeliveryDate);
        if (delivery < new DateTime(2019, 1, 1))
            error.Add(deliveryDateIsSmall);

        return !error.Any();
    }
    public bool ValidateProductType(string? type, out List<string> error) {
        error = new();
        if (type == string.Empty)
            error.Add(obligatoryValue);

        return !error.Any();
    }
    public bool ValidateProductCost(decimal? productCost, out List<string> error) {
        error = new();
        if (productCost is null)
            error.Add(obligatoryValue);
        if (productCost == 0)
            error.Add(valueGreaterZero);

        return !error.Any();
    }
}