using System;
using OrderHandler.DB.Data.OrderAdd;
using OrderHandler.UI.Core;

namespace OrderHandler.UI.Model.ViewOrderAdd;

public class ViewMilling : PropertyChanger {
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

    public ViewMilling(DateTime plannedDate) =>
        status = new(plannedDate);

    public ViewMilling(Milling milling) {
        status = new(milling.Status);
        mdf = milling.MDF;
    }

    public static implicit operator Milling(ViewMilling obj) => new() {
        Status = obj.status,
        MDF = obj.mdf
    };
}