using System;
using System.ComponentModel;

using OrderHandler.UI.Core;
using OrderHandler.UI.Model.Validation.Validators;

namespace OrderHandler.UI.Model.ViewOrderAdd;

public class ViewMounting : PropertyChanger, IDataErrorInfo {
    DateTime _plannedDate;
    bool _isNeed;
        
    public string Error => throw new NotImplementedException();
    IViewMountingValidator Validator { get; }

    internal int Id { get; set; }

    public DateTime PlannedDate {
        get => _plannedDate;
        set {
            _plannedDate = value;
            OnPropertyChanged();
        }
    }
    public bool IsNeed {
        get => _isNeed;
        set {
            _isNeed = value;
            OnPropertyChanged();
        }
    }
    
    public ViewMounting(IViewMountingValidator validator) =>
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
