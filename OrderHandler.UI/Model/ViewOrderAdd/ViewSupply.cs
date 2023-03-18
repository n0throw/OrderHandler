using System;
using OrderHandler.DB.Data.OrderAdd;
using OrderHandler.UI.Core;

namespace OrderHandler.UI.Model.ViewOrderAdd;

public class ViewSupply : PropertyChanger {
    private ViewStatusGeneric status;
    private decimal? cost;

    public ViewStatusGeneric Status {
        get => status;
        set {
            status = value;
            OnPropertyChanged(nameof(Status));
        }
    }
    public decimal? Cost {
        get => cost;
        set {
            cost = value;
            OnPropertyChanged(nameof(Cost));
        }
    }

    public ViewSupply(DateTime plannedDate) =>
        status = new(plannedDate);

    public ViewSupply(Supply supply) {
        status = new(supply.Status);
        cost = supply.Cost;
    }

    public static implicit operator Supply(ViewSupply obj) => new() {
        Status = obj.status,
        Cost = obj.cost
    };
}