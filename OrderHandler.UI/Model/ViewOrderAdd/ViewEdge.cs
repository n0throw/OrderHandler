using System;
using OrderHandler.DB.Data.OrderAdd;
using OrderHandler.UI.Core;

namespace OrderHandler.UI.Model.ViewOrderAdd;

public class ViewEdge : PropertyChanger {
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

    public ViewEdge(DateTime plannedDate) =>
        status = new(plannedDate);

    public ViewEdge(Edge edge) {
        status = new(edge.Status);
        chipboardOrMDF = edge.ChipboardOrMDF;
    }

    public static implicit   operator Edge(ViewEdge obj) => new() {
        Status = obj.status,
        ChipboardOrMDF = obj.chipboardOrMDF
    };
}