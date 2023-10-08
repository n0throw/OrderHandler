﻿using System;
using System.ComponentModel;

using OrderHandler.UI.Core;
using OrderHandler.UI.Model.Validation.Validators;

namespace OrderHandler.UI.Model.ViewOrderAdd;

public class ViewSupply : MainPagePropertyChanger, IDataErrorInfo {
    long _id;
    DateTime _plannedDate;
    long? _idUser;
    string _fio;
    DateTime _dateOfCompletion;
    decimal _requiredAmount;
        
    public string Error => throw new NotImplementedException();
    IViewSupplyValidator Validator { get; }

    public long Id {
        get => _id;
        set {
            _id = value;
            OnPropertyChanged();
        }
    }

    public DateTime PlannedDate {
        get => _plannedDate;
        set {
            _plannedDate = value;
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
    public DateTime DateOfCompletion {
        get => _dateOfCompletion;
        set {
            _dateOfCompletion = value;
            OnPropertyChanged();
        }
    }
    public decimal RequiredAmount {
        get => _requiredAmount;
        set {
            _requiredAmount = value;
            OnPropertyChanged();
        }
    }

    public ViewSupply() : this(new ViewSupplyValidator()) { }

    public ViewSupply(IViewSupplyValidator validator) {
        Validator = validator;
        _fio = string.Empty;
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
