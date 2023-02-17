using System;

using OrderHandler.DB.Model.Additional.Order;
using OrderHandler.UI.Core;

namespace OrderHandler.UI.Model.ViewOrderData;

internal class ViewSupply : PropertyChanger
{
    private ViewStatusGeneric status;
    private decimal? cost;

    public ViewStatusGeneric Status
    {
        get => status;
        set
        {
            status = value;
            OnPropertyChanged(nameof(Status));
        }
    }

    public decimal? Cost
    {
        get => cost;
        set
        {
            cost = value;
            OnPropertyChanged(nameof(Cost));
        }
    }

    public ViewSupply(DateTime plannedDate)
        => status = new(plannedDate);

    public ViewSupply(Supply supply)
    {
        status = new(supply.Status);
        cost = supply.Cost;
    }
}