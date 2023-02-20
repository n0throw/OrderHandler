using OrderHandler.UI.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderHandler.UI.Model.NewOrderData;

internal class NewOrderMainData : PropertyChanger, IDataErrorInfo
{
    private string? userName;
    private string? orderIssue;
    private string? productType;
    private decimal? productCost;
    private string? note;
    private bool isMounting;

    private const string obligatoryValue = "Это поле обязательно для заполнения";
    private const string valueGreaterZero = "Значение должно быть больше нуля";

    private static readonly string[] ValidatedProperties =
    {
        nameof(OrderIssue),
        nameof(ProductType),
        nameof(ProductCost)
    };

    public string this[string columnName] => columnName switch
    {
        nameof(OrderIssue) => ValidationOrderIssue(),
        nameof(ProductType) => ValidationProductType(),
        nameof(ProductCost) => ValidationProductCost(),
        _ => string.Empty
    };

    public string Error => throw new NotImplementedException();

    public string? UserName
    {
        get => userName;
        set
        {
            userName = value;
            OnPropertyChanged(nameof(UserName));
        }
    }

    public string? OrderIssue
    {
        get => orderIssue;
        set
        {
            orderIssue = value;
            OnPropertyChanged(nameof(OrderIssue));
        }
    }

    public string? ProductType
    {
        get => productType;
        set
        {
            productType = value;
            OnPropertyChanged(nameof(ProductType));
        }
    }

    public decimal? ProductCost
    {
        get => productCost;
        set
        {
            productCost = value;
            OnPropertyChanged(nameof(ProductCost));
        }
    }

    public string? Note
    {
        get => note;
        set
        {
            note = value;
            OnPropertyChanged(nameof(Note));
        }
    }

    public bool IsMounting
    {
        get => isMounting;
        set
        {
            isMounting = value;
            OnPropertyChanged(nameof(IsMounting));
        }
    }

    public bool CheckAllValidation()
    {
        foreach (string prop in ValidatedProperties)
        {
            if (this[prop] != string.Empty)
                return false;
        }

        return true;
    }

    private string ValidationOrderIssue()
    {
        if (orderIssue == string.Empty)
            return obligatoryValue;

        return string.Empty;
    }

    private string ValidationProductType()
    {
        if (ProductType == string.Empty)
            return obligatoryValue;

        return string.Empty;
    }

    private string ValidationProductCost()
    {
        if (productCost is null)
            return obligatoryValue;

        if (productCost == 0)
            return valueGreaterZero;

        return string.Empty;
    }
}
