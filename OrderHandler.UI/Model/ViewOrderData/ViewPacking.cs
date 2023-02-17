using System;

using OrderHandler.DB.Model.Additional.Order;
using OrderHandler.UI.Core;

namespace OrderHandler.UI.Model.ViewOrderData;

internal class ViewPacking : PropertyChanger
{
    private ViewStatusGeneric status;
    private decimal? chipboardOrMDF;

    public ViewStatusGeneric Status
    {
        get => status;
        set
        {
            status = value;
            OnPropertyChanged(nameof(Status));
        }
    }

    public decimal? ChipboardOrMDF
    {
        get => chipboardOrMDF;
        set
        {
            chipboardOrMDF = value;
            OnPropertyChanged(nameof(ChipboardOrMDF));
        }
    }

    public ViewPacking(DateTime plannedDate)
        => status = new(plannedDate);

    public ViewPacking(Packing packaging)
    {
        status = new(packaging.Status);
        chipboardOrMDF = packaging.ChipboardOrMDF;
    }
}