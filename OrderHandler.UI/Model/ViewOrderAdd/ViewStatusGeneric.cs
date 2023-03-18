using System;
using System.ComponentModel;
using OrderHandler.DB.Data.OrderAdd;
using OrderHandler.UI.Model.Validation.Validators;
using OrderHandler.UI.Model.ViewOrderAdd.Data;

namespace OrderHandler.UI.Model.ViewOrderAdd;

public class ViewStatusGeneric : ViewDataStatusGeneric, IDataErrorInfo {
    public string Error => throw new NotImplementedException();
    public IViewStatusGenericValidator Validator { get; init; }

    public new DateTime PlannedDate {
        get => base.PlannedDate;
        set {
            base.PlannedDate = value;
            OnPropertyChanged(nameof(PlannedDate));
        }
    }
    public new string? UserName {
        get => base.UserName;
        set {
            base.UserName = value;
            OnPropertyChanged(nameof(UserName));
        }
    }
    public new DateTime Date {
        get => base.Date;
        set {
            base.Date = value;
            OnPropertyChanged(nameof(Date));
        }
    }

    public ViewStatusGeneric() : this(new ViewStatusGenericValidator()) { }
    public ViewStatusGeneric(IViewStatusGenericValidator validator) {
        PlannedDate = DateTime.Now;
        Validator = validator;
    }
    public ViewStatusGeneric(StatusGeneric status) : this(status, new ViewStatusGenericValidator()) { }
    public ViewStatusGeneric(StatusGeneric status, IViewStatusGenericValidator validator) {
        PlannedDate = status.PlannedDate;
        UserName = status.UserId; // выборка
        Date = status.Date;

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

    public static implicit operator StatusGeneric(ViewStatusGeneric obj) => new() {
        PlannedDate = obj.PlannedDate,
        UserId = obj.UserName,
        Date = obj.Date
    };
}