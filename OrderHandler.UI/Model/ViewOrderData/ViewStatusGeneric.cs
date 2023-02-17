using System;

using OrderHandler.DB.Model.Additional.Order;
using OrderHandler.UI.Core;

namespace OrderHandler.UI.Model.ViewOrderData;

internal class ViewStatusGeneric : PropertyChanger
{
    public DateTime plannedDate;
    public string? userName;
    public DateTime date;

    public DateTime PlannedDate
    {
        get => plannedDate;
        set
        {
            plannedDate = value;
            OnPropertyChanged(nameof(PlannedDate));
        }
    }
    public string? UserName
    {
        get => userName;
        set
        {
            userName = value;
            OnPropertyChanged(nameof(UserName));
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

    public ViewStatusGeneric(DateTime plannedDate)
        => PlannedDate = plannedDate;

    public ViewStatusGeneric(StatusGeneric status)
    {
        plannedDate = status.PlannedDate;
        userName = status.UserId; // выборка
        date = status.Date;
    }
}