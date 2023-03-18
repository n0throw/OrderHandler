using System;
using OrderHandler.DB.Data.OrderAdd;
using OrderHandler.UI.Model.ViewOrderAdd.Data;

namespace OrderHandler.UI.Model.ViewOrderAdd;

public class ViewAdditive : ViewDataAdditive {
    public new ViewStatusGeneric Status {
        get => base.Status;
        set {
            base.Status = value;
            OnPropertyChanged(nameof(Status));
        }
    }
    public new decimal? ChipboardOrMDF {
        get => base.ChipboardOrMDF;
        set {
            base.ChipboardOrMDF = value;
            OnPropertyChanged(nameof(ChipboardOrMDF));
        }
    }

    public ViewAdditive(DateTime plannedDate) =>
        status = new(plannedDate);

    public ViewAdditive(Additive additive) {
        status = new(additive.Status);
        chipboardOrMDF = additive.ChipboardOrMDF;
    }

    public static implicit operator Additive(ViewAdditive obj) => new() {
        Status = obj.status,
        ChipboardOrMDF = obj.chipboardOrMDF
    };
}