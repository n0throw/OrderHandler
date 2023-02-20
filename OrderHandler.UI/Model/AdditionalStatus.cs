using OrderHandler.UI.Core;

using System;
using System.ComponentModel;
using System.Windows;

namespace OrderHandler.UI.Model;

internal class AdditionalStatus : PropertyChanger, IDataErrorInfo
{
    private decimal? cost;
    public decimal? Cost
    {
        get => cost;
        set
        {
            cost = value;
            OnPropertyChanged(nameof(Cost));
        }
    }

    private decimal? chipboardOrMDF;
    public decimal? ChipboardOrMDF
    {
        get => chipboardOrMDF;
        set
        {
            chipboardOrMDF = value;
            OnPropertyChanged(nameof(ChipboardOrMDF));
        }
    }

    private decimal? mdf;
    public decimal? MDF
    {
        get => mdf;
        set
        {
            mdf = value;
            OnPropertyChanged(nameof(MDF));
        }
    }

    private decimal? hdf;
    public decimal? HDF
    {
        get => hdf;
        set
        {
            hdf = value;
            OnPropertyChanged(nameof(HDF));
        }
    }

    private string note;
    public string Note
    {
        get => note;
        set
        {
            note = value;
            OnPropertyChanged(nameof(Note));
        }
    }

    private DateTime mounting;
    public DateTime Mounting
    {
        get => mounting;
        set
        {
            mounting = value;
            OnPropertyChanged(nameof(Mounting));
        }
    }

    private AdditionalStatusVisibility additionalStatusVisibility;
    public AdditionalStatusVisibility AdditionalStatusVisibility
    {
        get => additionalStatusVisibility;
        set
        {
            additionalStatusVisibility = value;
            OnPropertyChanged(nameof(AdditionalStatusVisibility));
        }
    }

    internal AdditionalStatus(AdditionalStatusVisibility additionalStatusVisibility, string note, DateTime mounting)
    {
        this.additionalStatusVisibility = additionalStatusVisibility;
        this.note = note;
        if (mounting != DateTime.MinValue)
            this.mounting = mounting;
        else
            this.mounting = DateTime.Now;
    }

    private static readonly string[] validatedProperties =
    {
        nameof(Cost),
        nameof(ChipboardOrMDF),
        nameof(MDF),
        nameof(HDF)
    };

    private const string obligatoryValue = "Это поле обязательно для заполнения";
    private const string valueGreaterZero = "Значение должно быть больше нуля";

    public bool CheckAllValidation()
    {
        foreach(string property in validatedProperties)
            if (this[property] != string.Empty)
                return false;

        return true;
    }

    public string this[string columnName] => columnName switch
    {
        nameof(Cost) => ValidationCost(),
        nameof(ChipboardOrMDF) => ValidationChipboardOrMDF(),
        nameof(MDF) => ValidationMDF(),
        nameof(HDF) => ValidationHDF(),
        nameof(Mounting) => ValidationMounting(),
        _ => string.Empty
    };

    private string ValidationCost()
    {
        if (additionalStatusVisibility.Cost == Visibility.Collapsed)
            return string.Empty;

        if (cost is null)
            return obligatoryValue;

        if (cost == 0)
            return valueGreaterZero;

        return string.Empty;
    }

    private string ValidationChipboardOrMDF()
    {
        if (additionalStatusVisibility.ChipboardOrMDF == Visibility.Collapsed)
            return string.Empty;

        if (chipboardOrMDF is null)
            return obligatoryValue;

        if (chipboardOrMDF == 0)
            return valueGreaterZero;

        return string.Empty;
    }

    private string ValidationMDF()
    {
        if (additionalStatusVisibility.MDF == Visibility.Collapsed)
            return string.Empty;

        if (mdf is null)
            return obligatoryValue;

        if (mdf == 0)
            return valueGreaterZero;

        return string.Empty;
    }

    private string ValidationHDF()
    {
        if (additionalStatusVisibility.HDF == Visibility.Collapsed)
            return string.Empty;

        if (hdf is null)
            return obligatoryValue;

        if (hdf == 0)
            return valueGreaterZero;

        return string.Empty;
    }

    private string ValidationMounting()
    {
        return string.Empty;
    }

    public string Error => throw new NotImplementedException();
}