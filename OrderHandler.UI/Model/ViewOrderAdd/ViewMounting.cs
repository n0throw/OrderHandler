using System;
using System.ComponentModel;

using OrderHandler.UI.Core;
using OrderHandler.UI.Model.Validation.Validators;

namespace OrderHandler.UI.Model.ViewOrderAdd;

public class ViewMounting : MainPagePropertyChanger, IDataErrorInfo {
    long _id;
    DateTime _plannedDate;
    bool _isNeed;
        
    public string Error => throw new NotImplementedException();
    IViewMountingValidator Validator { get; }

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
    public bool IsNeed {
        get => _isNeed;
        set {
            _isNeed = value;
            OnPropertyChanged();
        }
    }
    
    public ViewMounting() : this(new ViewMountingValidator()) {}
    
    public ViewMounting(IViewMountingValidator validator) {
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
}
