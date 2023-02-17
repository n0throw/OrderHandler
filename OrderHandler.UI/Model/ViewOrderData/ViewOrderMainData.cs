using System;

using OrderHandler.DB.Model.Additional.Order;
using OrderHandler.UI.Core;

namespace OrderHandler.UI.Model.ViewOrderData;

internal class ViewOrderMainData : PropertyChanger
{
    public ViewOrderMainData()
    {
        userName = string.Empty;
        orderIssue = string.Empty;
        orderDate = DateTime.Now;
        deliveryDate = DateTime.Now;
        productType = string.Empty;
    }

    public ViewOrderMainData(int id, OrderMainData orderMainData)
    {
        this.id = id;
        userName = orderMainData.UserDataId; // здесь выборка
        orderIssue = orderMainData.OrderIssue;
        orderDate = orderMainData.OrderDate;
        deliveryDate = orderMainData.DeliveryDate;
        numberOfDays = orderMainData.NumberOfDays;
        productType = orderMainData.ProductType;
        productCost = orderMainData.ProductCost;
    }

    private int id;
    private string? userName;
    private string? orderIssue;
    private DateTime orderDate;
    private DateTime deliveryDate;
    private short? numberOfDays;
    private string? productType;
    private decimal? productCost;

    public int Id
    {
        get => id;
        set
        {
            id = value;
            OnPropertyChanged("Id");
        }
    }
    public string? UserName
    {
        get => userName;
        set
        {
            userName = value;
            OnPropertyChanged("UserName");
        }
    }
    public string? OrderIssue
    {
        get => orderIssue;
        set
        {
            orderIssue = value;
            OnPropertyChanged("OrderIssue");
        }
    }
    public DateTime OrderDate
    {
        get => orderDate;
        set
        {
            orderDate = value;
            OnPropertyChanged("OrderDate");
        }
    }
    public DateTime DeliveryDate
    {
        get => deliveryDate;
        set
        {
            deliveryDate = value;
            OnPropertyChanged("DeliveryDate");
        }
    }
    public short? NumberOfDays
    {
        get => numberOfDays;
        set
        {
            numberOfDays = value;
            OnPropertyChanged("NumberOfDays");
        }
    }
    public string? ProductType
    {
        get => productType;
        set
        {
            productType = value;
            OnPropertyChanged("ProductType");
        }
    }
    public decimal? ProductCost
    {
        get => productCost;
        set
        {
            productCost = value;
            OnPropertyChanged("ProductCost");
        }
    }
}
