using System;

using OrderHandler.DB.Model.Additional.Order;
using OrderHandler.UI.Core;

namespace OrderHandler.UI.Model.ViewOrderData;

internal class ViewAssembling : PropertyChanger
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

    public ViewAssembling(DateTime plannedDate)
        => status = new(plannedDate);

    public ViewAssembling(Assembling assembling)
    {
        status = new(assembling.Status);
        chipboardOrMDF = assembling.ChipboardOrMDF;
    }
}