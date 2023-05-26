using System;
using System.ComponentModel;

using OrderHandler.UI.Core;
using OrderHandler.UI.Model.Validation.Validators;

namespace OrderHandler.UI.Model.ViewOrderAdd;

public class ViewMilling : PropertyChanger, IDataErrorInfo {
    DateTime _plannedDate;
    string _FIO;
    DateTime _dateOfCompletion;
    decimal _areaOfMDF;
        
    public string Error => throw new NotImplementedException();
    IViewMillingValidator Validator { get; }

    internal long Id { get; set; }

    public DateTime PlannedDate {
        get => _plannedDate;
        set {
            _plannedDate = value;
            OnPropertyChanged();
        }
    }
    internal long? IdUser { get; set; }

    public string FIO {
        get => _FIO;
        set {
            _FIO = value;
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
    public decimal AreaOfMDF {
        get => _areaOfMDF;
        set {
            _areaOfMDF = value;
            OnPropertyChanged();
        }
    }

    public ViewMilling(IViewMillingValidator validator) =>
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
