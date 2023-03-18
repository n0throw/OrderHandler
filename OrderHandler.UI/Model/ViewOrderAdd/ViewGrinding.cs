using System;
using OrderHandler.DB.Data.OrderAdd;
using OrderHandler.UI.Core;

namespace OrderHandler.UI.Model.ViewOrderAdd;

public class ViewGrinding : PropertyChanger {
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

    public ViewGrinding(DateTime plannedDate) =>
        status = new(plannedDate);

    public ViewGrinding(Grinding grinding) {
        status = new(grinding.Status);
        mdf = grinding.MDF;
    }

    public static implicit operator Grinding(ViewGrinding obj) => new() {
        Status = obj.status,
        MDF = obj.mdf
    };
}