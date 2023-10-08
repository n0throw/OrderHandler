using System;
using System.ComponentModel;

using OrderHandler.UI.Core;
using OrderHandler.UI.Model.Validation.Validators;

namespace OrderHandler.UI.Model.ViewOrderAdd;

public class ViewOrderMain : MainPagePropertyChanger, IDataErrorInfo  {
    long _id;
    string _orderNumber;
    long? _idUser;
    string _fio;
    DateTime _orderDate;
    DateTime _deliveryDate;
    int _term;
    string _productType;
    decimal _orderAmount;
    
    public string Error => throw new NotImplementedException();
    IViewOrderMainValidator Validator { get; }

    public long Id {
        get => _id;
        set {
            _id = value;
            OnPropertyChanged();
        }
    }

    public string OrderNumber {
        get => _orderNumber;
        set {
            _orderNumber = value;
            OnPropertyChanged();
        }
    }
    public long? IdUser {
        get => _idUser;
        set {
            _idUser = value;
            FIO = "asd"; // todo add fio from DB
            OnPropertyChanged();
        }
    }

    public string FIO {
        get => _fio;
        set {
            _fio = value;
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
    
    public ViewOrderMain() : this(new ViewOrderMainValidator()) {}
    
    public ViewOrderMain(IViewOrderMainValidator validator) {
        Validator = validator;
        _orderNumber = string.Empty;
        _fio = string.Empty;
        _productType = string.Empty;
    }

    public bool Validate() =>
        Validator.Validate(this);

    public string this[string columnName] {
        get {
            Validate();
            return Validator[columnName];
        }
    }
}
