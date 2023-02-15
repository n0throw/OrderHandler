using OrderHandler.UI.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderHandler.UI.Model;

internal class NewOrderMainData : PropertyChanger, IDataErrorInfo
{
    private string userName;
    private string orderIssue;
    private string productType;
    private decimal productCost;
    private string? note;
    private bool isMounting;

    public string this[string columnName] => throw new NotImplementedException();
    public string Error => throw new NotImplementedException();

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

    public string? Note
    {
        get => note;
        set
        {
            note = value;
            OnPropertyChanged("Note");
        }
    }

    public bool IsMounting
    {
        get => isMounting;
        set
        {
            isMounting = value;
            OnPropertyChanged("IsMounting");
        }
    }
}
