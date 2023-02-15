using System;

using OrderHandler.DB.Model.Additional.Order;
using OrderHandler.UI.Core;

namespace OrderHandler.UI.Model.OrderData;

internal class ViewSawCenter : PropertyChanger
{
    private ViewStatusGeneric status;
    private decimal chipboardOrMDF;
    private decimal hdf;

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

    public decimal HDF
    {
        get => hdf;
        set
        {
            hdf = value;
            OnPropertyChanged(nameof(HDF));
        }
    }

    public ViewSawCenter(DateTime plannedDate)
        => status = new(plannedDate);

    public ViewSawCenter(SawCenter sawCenter)
    {
        status = new(sawCenter.Status);
        chipboardOrMDF = sawCenter.ChipboardOrMDF;
        hdf = sawCenter.HDF;
    }
}