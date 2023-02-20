using OrderHandler.UI.Core;

using System.Windows;

namespace OrderHandler.UI.Model;

public class AdditionalStatusVisibility : PropertyChanger
{
    private Visibility cost;
    public Visibility Cost
    {
        get => cost;
        set
        {
            cost = value;
            OnPropertyChanged(nameof(Cost));
        }
    }

    private Visibility chipboardOrMDF;
    public Visibility ChipboardOrMDF
    {
        get => chipboardOrMDF;
        set
        {
            chipboardOrMDF = value;
            OnPropertyChanged(nameof(ChipboardOrMDF));
        }
    }

    private Visibility mdf;
    public Visibility MDF
    {
        get => mdf;
        set
        {
            mdf = value;
            OnPropertyChanged(nameof(MDF));
        }
    }

    private Visibility hdf;
    public Visibility HDF
    {
        get => hdf;
        set
        {
            hdf = value;
            OnPropertyChanged(nameof(HDF));
        }
    }

    private Visibility mounting;
    public Visibility Mounting
    {
        get => mounting;
        set
        {
            mounting = value;
            OnPropertyChanged(nameof(Mounting));
        }
    }

    private Visibility note;
    public Visibility Note
    {
        get => note;
        set
        {
            note = value;
            OnPropertyChanged(nameof(Note));
        }
    }

    public AdditionalStatusVisibility(
        Visibility cost = Visibility.Collapsed,
        Visibility chipboardOrMDF = Visibility.Collapsed,
        Visibility mdf = Visibility.Collapsed,
        Visibility hdf = Visibility.Collapsed,
        Visibility mounting = Visibility.Collapsed,
        Visibility note = Visibility.Collapsed)
    {
        this.cost = cost;
        this.chipboardOrMDF = chipboardOrMDF;
        this.mdf = mdf;
        this.hdf = hdf;
        this.mounting = mounting;
        this.note = note;
    }
}
