using System;
using OrderHandler.DB.Model.Additional.Order;
using OrderHandler.UI.Core;

namespace OrderHandler.UI.Model.ViewOrderData;

internal class ViewMounting : PropertyChanger
{
    private bool isMounting;
    private DateTime date;

    public bool IsMounting
    {
        get => isMounting;
        set
        {
            isMounting = value;
            OnPropertyChanged(nameof(IsMounting));
        }
    }

    public DateTime Date
    {
        get => date;
        set
        {
            date = value;
            OnPropertyChanged(nameof(Date));
        }
    }

    public ViewMounting(bool isMounting, DateTime date)
    {
        this.isMounting = isMounting;
        this.date = date;
    }

    public ViewMounting(Mounting mounting)
    {
        isMounting = mounting.IsMounting;
        date = mounting.Date;
    }
}