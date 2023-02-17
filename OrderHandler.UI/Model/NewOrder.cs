using OrderHandler.UI.Core;
using OrderHandler.UI.Model.NewOrderData;

namespace OrderHandler.UI.Model;

internal class NewOrder : PropertyChanger
{
    private NewOrderMainData mainData;
    private NewOrderDates dates;

    public NewOrderMainData MainData
    {
        get => mainData;
        set
        {
            mainData = value;
            OnPropertyChanged(nameof(MainData));
        }
    }

    public NewOrderDates Dates
    {
        get => dates;
        set
        {
            dates = value;
            OnPropertyChanged(nameof(Dates));
        }
    }

    public NewOrder()
    {
        mainData = new();
        dates = new();
    }
}
