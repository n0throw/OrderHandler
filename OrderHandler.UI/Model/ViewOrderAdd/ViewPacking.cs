using System;
using OrderHandler.DB.Data.OrderAdd;
using OrderHandler.UI.Core;

namespace OrderHandler.UI.Model.ViewOrderAdd;

public class ViewPacking : PropertyChanger {
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

    public ViewPacking(DateTime plannedDate) =>
        status = new(plannedDate);

    public ViewPacking(Packing packaging) {
        status = new(packaging.Status);
        chipboardOrMDF = packaging.ChipboardOrMDF;
    }

    public static implicit operator Packing(ViewPacking obj) => new() {
        Status = obj.status,
        ChipboardOrMDF = obj.chipboardOrMDF
    };
}