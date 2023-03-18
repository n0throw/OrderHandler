using System;
using System.ComponentModel;
using OrderHandler.DB.Data.OrderAdd;
using OrderHandler.UI.Model.ViewOrderAdd.Data;
using OrderHandler.UI.Model.Validation.Validators;

namespace OrderHandler.UI.Model.ViewOrderAdd;

public class ViewOrderMain : ViewDataOrderMain, IDataErrorInfo {
    public string Error => throw new NotImplementedException();
    public IViewOrderMainValidator Validator { get; init; }
    public new int Number {
        get => base.Number;
        set {
            base.Number = value;
            OnPropertyChanged(nameof(Number));
        }
    }
    public new string? UserName {
        get => base.UserName;
        set {
            base.UserName = value;
            OnPropertyChanged(nameof(UserName));
        }
    }
    public new string? OrderIssue {
        get => base.OrderIssue;
        set {
            base.OrderIssue = value;
            OnPropertyChanged(nameof(OrderIssue));
        }
    }
    public new DateTime OrderDate {
        get => base.OrderDate;
        set {
            base.OrderDate = value;
            OnPropertyChanged(nameof(OrderDate));
        }
    }
    public new DateTime DeliveryDate {
        get => base.DeliveryDate;
        set {
            base.DeliveryDate = value;
            OnPropertyChanged(nameof(DeliveryDate));
        }
    }
    public new short? NumberOfDays {
        get => base.NumberOfDays;
        set {
            base.NumberOfDays = value;
            OnPropertyChanged(nameof(NumberOfDays));
        }
    }
    public new string? ProductType {
        get => base.ProductType;
        set {
            base.ProductType = value;
            OnPropertyChanged(nameof(ProductType));
        }
    }
    public new decimal? ProductCost {
        get => base.ProductCost;
        set {
            base.ProductCost = value;
            OnPropertyChanged(nameof(ProductCost));
        }
    }

    public ViewOrderMain() : this(new ViewOrderMainValidator()) { }
    public ViewOrderMain(IViewOrderMainValidator validator) {
        UserName = string.Empty;
        OrderIssue = string.Empty;
        OrderDate = DateTime.Now;
        DeliveryDate = DateTime.Now;
        ProductType = string.Empty;
        Validator = validator;
    }
    public ViewOrderMain(int number, OrderMain orderMainData) : this(number, orderMainData, new ViewOrderMainValidator()) { }
    public ViewOrderMain(int number, OrderMain orderMainData, IViewOrderMainValidator validator) {
        Number = number;
        UserName = orderMainData.UserId; // здесь выборка
        OrderIssue = orderMainData.OrderIssue;
        OrderDate = orderMainData.OrderDate;
        DeliveryDate = orderMainData.DeliveryDate;
        NumberOfDays = orderMainData.NumberOfDays;
        ProductType = orderMainData.ProductType;
        ProductCost = orderMainData.ProductCost;
        Validator = validator;
    }

    public bool Validate() =>
        Validator.Validate(this);

    public string this[string columnName] {
        get {
            Validate();
            return Validator[columnName];
        }
    }

    public static implicit operator OrderMain(ViewOrderMain obj) => new() {
        UserId = obj.UserName,
        OrderIssue = obj.OrderIssue,
        OrderDate = obj.OrderDate,
        DeliveryDate = obj.DeliveryDate,
        NumberOfDays = obj.NumberOfDays,
        ProductType = obj.ProductType,
        ProductCost = obj.ProductCost
    };
}