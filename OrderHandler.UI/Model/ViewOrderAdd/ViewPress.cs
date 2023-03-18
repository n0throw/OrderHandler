using System;
using OrderHandler.DB.Data.OrderAdd;
using OrderHandler.UI.Core;

namespace OrderHandler.UI.Model.ViewOrderAdd;

public class ViewPress : PropertyChanger {
    private ViewStatusGeneric status;
    private decimal? mdf;

    public ViewStatusGeneric Status {
        get => status;
        set {
            status = value;
            OnPropertyChanged(nameof(Status));
        }
    }
    public decimal? MDF {
        get => mdf;
        set {
            mdf = value;
            OnPropertyChanged(nameof(MDF));
        }
    }

    public ViewPress(DateTime plannedDate) =>
        status = new(plannedDate);

    public ViewPress(Press press) {
        status = new(press.Status);
        mdf = press.MDF;
    }

    public static implicit operator Press(ViewPress obj) => new() {
        Status = obj.status,
        MDF = obj.mdf
    };
}