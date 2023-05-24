using System;
using System.ComponentModel;

using OrderHandler.UI.Core;
using OrderHandler.UI.Model.Validation.Validators;

namespace OrderHandler.UI.Model.ViewOrderAdd;

public class ViewOrderMain : PropertyChanger, IDataErrorInfo  {
    string _orderNumber;
    string _FIO;
    DateTime _orderDate;
    DateTime _deliveryDate;
    int _term;
    string _productType;
    decimal _orderAmount;
    
    public string Error => throw new NotImplementedException();
    IViewOrderMainValidator Validator { get; }

    internal int Id { get; set; }

    public string OrderNumber {
        get => _orderNumber;
        set {
            _orderNumber = value;
            OnPropertyChanged();
        }
    }
    internal int? IdUser { get; set; }

    public string FIO {
        get => _FIO;
        set {
            _FIO = value;
            OnPropertyChanged();
        }
}
    public DateTime OrderDate {
        get => _orderDate;
        set {
            _orderDate = value;
            OnPropertyChanged();
        }
    }
    public DateTime DeliveryDate {
        get => _deliveryDate;
        set {
            _deliveryDate = value;
            OnPropertyChanged();
        }
    }
    public int Term {
        get => _term;
        set {
            _term = value;
            OnPropertyChanged();
        }
    }
    public string ProductType {
        get => _productType;
        set {
            _productType = value;
            OnPropertyChanged();
        }
    }
    public decimal OrderAmount {
        get => _orderAmount;
        set {
            _orderAmount = value;
            OnPropertyChanged();
        }
    }
    
    public ViewOrderMain(IViewOrderMainValidator validator) =>
        Validator = validator;
    
    public bool Validate() =>
        Validator.Validate(this);

    public string this[string columnName] {
        get {
            Validate();
            return Validator[columnName];
        }
    }
}
