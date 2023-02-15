using System;

using OrderHandler.DB.Model.Additional.Order;
using OrderHandler.UI.Core;

namespace OrderHandler.UI.Model.OrderData;

internal class ViewPackaging : PropertyChanger
{
    private ViewStatusGeneric status;
    private decimal chipboardOrMDF;

    public ViewStatusGeneric Status
    {
        get => status;
        set
        {
            status = value;
            OnPropertyChanged(nameof(Status));
        }
    }

    public decimal ChipboardOrMDF
    {
        get => chipboardOrMDF;
        set
        {
            chipboardOrMDF = value;
            OnPropertyChanged(nameof(ChipboardOrMDF));
        }
    }

    public ViewPackaging(DateTime plannedDate)
        => status = new(plannedDate);

    public ViewPackaging(Packaging packaging)
    {
        status = new(packaging.Status);
        chipboardOrMDF = packaging.ChipboardOrMDF;
    }
}