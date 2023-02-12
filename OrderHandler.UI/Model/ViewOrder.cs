using OrderHandler.UI.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderHandler.UI.Model;

internal class ViewOrder : PropertyChanger
{
    private int id;
    private string userName;
    private string orderIssue;
    private DateOnly orderDate;
    private DateOnly deliveryDate;
    private short numberOfDays;
    private string productType;
    private decimal productCost;

    public int Id
    {
        get => id;
        set
        {
            id = value;
            OnPropertyChanged("Id");
        }
    }
    public string UserName
    {
        get => userName;
        set
        {
            userName = value;
            OnPropertyChanged("UserName");
        }
    }
    public string OrderIssue
    {
        get => orderIssue;
        set
        {
            orderIssue = value;
            OnPropertyChanged("OrderIssue");
        }
    }
    public DateOnly OrderDate
    {
        get => orderDate;
        set
        {
            orderDate = value;
            OnPropertyChanged("OrderDate");
        }
    }
    public DateOnly DeliveryDate
    {
        get => deliveryDate;
        set
        {
            deliveryDate = value;
            OnPropertyChanged("DeliveryDate");
        }
    }
    public short NumberOfDays
    {
        get => numberOfDays;
        set
        {
            numberOfDays = value;
            OnPropertyChanged("NumberOfDays");
        }
    }
    public string ProductType
    {
        get => productType;
        set
        {
            productType = value;
            OnPropertyChanged("ProductType");
        }
    }
    public decimal ProductCost
    {
        get => productCost;
        set
        {
            productCost = value;
            OnPropertyChanged("ProductCost");
        }
    }
}
