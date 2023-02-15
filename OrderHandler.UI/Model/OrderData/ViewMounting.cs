using System;
using OrderHandler.DB.Model.Additional.Order;
using OrderHandler.UI.Core;

namespace OrderHandler.UI.Model.OrderData;

internal class ViewMounting : PropertyChanger
{
    private bool isMounting;
    private DateTime mountingDate;

    public bool IsMounting
    {
        get => isMounting;
        set
        {
            isMounting = value;
            OnPropertyChanged(nameof(IsMounting));
        }
    }

    public DateTime MountingDate
    {
        get => mountingDate;
        set
        {
            mountingDate = value;
            OnPropertyChanged(nameof(MountingDate));
        }
    }

    public ViewMounting(bool isMounting, DateTime mountingDate)
    {
        this.isMounting = isMounting;
        this.mountingDate = mountingDate;
    }

    public ViewMounting(Mounting mounting)
    {
        isMounting = mounting.IsMounting;
        mountingDate = mounting.MountingDate;
    }
}