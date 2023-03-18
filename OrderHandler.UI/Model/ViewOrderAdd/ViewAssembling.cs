using System;
using OrderHandler.DB.Data.OrderAdd;
using OrderHandler.UI.Core;

namespace OrderHandler.UI.Model.ViewOrderAdd;

public class ViewAssembling : PropertyChanger {
    private ViewStatusGeneric status;
    private decimal? chipboardOrMDF;

    public ViewStatusGeneric Status {
        get => status;
        set {
            status = value;
            OnPropertyChanged(nameof(Status));
        }
    }
    public decimal? ChipboardOrMDF {
        get => chipboardOrMDF;
        set {
            chipboardOrMDF = value;
            OnPropertyChanged(nameof(ChipboardOrMDF));
        }
    }

    public ViewAssembling(DateTime plannedDate) =>
        status = new(plannedDate);

    public ViewAssembling(Assembling assembling) {
        status = new(assembling.Status);
        chipboardOrMDF = assembling.ChipboardOrMDF;
    }

    public static implicit operator Assembling(ViewAssembling obj) => new() {
        Status = obj.status,
        ChipboardOrMDF = obj.chipboardOrMDF
    };
}