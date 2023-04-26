using System;
using System.ComponentModel;

using OrderHandler.UI.Core;
using OrderHandler.UI.Model.Validation.Validators;

namespace OrderHandler.UI.Model.ViewOrderAdd;

public class ViewGrinding : PropertyChanger, IDataErrorInfo {
    int _id;
    DateTime _plannedDate;
    int? _idUser;
    string _FIO;
    DateTime _dateOfCompletion;
    decimal _areaOfMDF;
        
    public string Error => throw new NotImplementedException();
    IViewGrindingValidator Validator { get; }

    internal int Id {
        get => _id;
        set => _id = value;
    }
    public DateTime PlannedDate {
        get => _plannedDate;
        set {
            _plannedDate = value;
            OnPropertyChanged();
        }
    }
    internal int? IdUser {
        get => _idUser;
        set => _idUser = value;
    }
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

    public ViewGrinding(IViewGrindingValidator validator) =>
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
