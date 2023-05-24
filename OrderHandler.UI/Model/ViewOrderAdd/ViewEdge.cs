using System;
using System.ComponentModel;

using OrderHandler.UI.Core;
using OrderHandler.UI.Model.Validation.Validators;

namespace OrderHandler.UI.Model.ViewOrderAdd;

public class ViewEdge : PropertyChanger, IDataErrorInfo {
    DateTime _plannedDate;
    string _FIO;
    DateTime _dateOfCompletion;
    decimal _areaOfLCBOrMDF;
        
    public string Error => throw new NotImplementedException();
    IViewEdgeValidator Validator { get; }

    internal int Id { get; set; }

    public DateTime PlannedDate {
        get => _plannedDate;
        set {
            _plannedDate = value;
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
    public DateTime DateOfCompletion {
        get => _dateOfCompletion;
        set {
            _dateOfCompletion = value;
            OnPropertyChanged();
        }
    }
    public decimal AreaOfLCBOrMDF {
        get => _areaOfLCBOrMDF;
        set {
            _areaOfLCBOrMDF = value;
            OnPropertyChanged();
        }
    }

    public ViewEdge(IViewEdgeValidator validator) =>
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
