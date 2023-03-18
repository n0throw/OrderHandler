using System;
using OrderHandler.DB.Data.OrderAdd;
using OrderHandler.UI.Core;

namespace OrderHandler.UI.Model.ViewOrderAdd;

public class ViewSawCenter : PropertyChanger {
    private ViewStatusGeneric status;
    private decimal? chipboardOrMDF;
    private decimal? hdf;

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
    public decimal? HDF {
        get => hdf;
        set {
            hdf = value;
            OnPropertyChanged(nameof(HDF));
        }
    }

    public ViewSawCenter(DateTime plannedDate) =>
        status = new(plannedDate);

    public ViewSawCenter(SawCenter sawCenter) {
        status = new(sawCenter.Status);
        chipboardOrMDF = sawCenter.ChipboardOrMDF;
        hdf = sawCenter.HDF;
    }

    public static implicit operator SawCenter(ViewSawCenter obj) => new() {
        Status = obj.status,
        ChipboardOrMDF = obj.chipboardOrMDF,
        HDF = obj.HDF
    };
}