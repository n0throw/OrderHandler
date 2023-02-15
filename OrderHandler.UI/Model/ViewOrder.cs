using OrderHandler.DB.Model;

using OrderHandler.UI.Core;
using OrderHandler.UI.Model.OrderData;

namespace OrderHandler.UI.Model;

internal class ViewOrder : PropertyChanger
{
    private int dbId;
    private ViewOrderMainData orderMainData;
    private ViewStatusGeneric docConstructor;
    private ViewStatusGeneric docTechnologist;
    private ViewSupply supply;
    private ViewSawCenter sawCenter;
    private ViewEdge edge;
    private ViewAdditive additive;
    private ViewMilling milling;
    private ViewGrinding grinding;
    private ViewPress press;
    private ViewAssembling assembling;
    private ViewPackaging packaging;
    private ViewStatusGeneric equipment;
    private ViewStatusGeneric shipment;
    private string? note;
    private ViewMounting mounting;

    public int DBID => dbId;
    public ViewOrderMainData OrderMainData
    {
        get => orderMainData;
        set
        {
            orderMainData = value;
            OnPropertyChanged(nameof(OrderMainData));
        }
    }
    public ViewStatusGeneric DocConstructor
    {
        get => docConstructor;
        set
        {
            docConstructor = value;
            OnPropertyChanged(nameof(DocConstructor));
        }
    }
    public ViewStatusGeneric DocTechnologist
    {
        get => docTechnologist;
        set
        {
            docTechnologist = value;
            OnPropertyChanged(nameof(DocTechnologist));
        }
    }
    public ViewSupply Supply
    {
        get => supply;
        set
        {
            supply = value;
            OnPropertyChanged(nameof(Supply));
        }
    }
    public ViewSawCenter SawCenter
    {
        get => sawCenter;
        set
        {
            sawCenter = value;
            OnPropertyChanged(nameof(SawCenter));
        }
    }
    public ViewEdge Edge
    {
        get => edge;
        set
        {
            edge = value;
            OnPropertyChanged(nameof(Edge));
        }
    }
    public ViewAdditive Additive
    {
        get => additive;
        set
        {
            additive = value;
            OnPropertyChanged(nameof(Additive));
        }
    }
    public ViewMilling Milling
    {
        get => milling;
        set
        {
            milling = value;
            OnPropertyChanged(nameof(Milling));
        }
    }
    public ViewGrinding Grinding
    {
        get => grinding;
        set
        {
            grinding = value;
            OnPropertyChanged(nameof(Grinding));
        }
    }
    public ViewPress Press
    {
        get => press;
        set
        {
            press = value;
            OnPropertyChanged(nameof(Press));
        }
    }
    public ViewAssembling Assembling
    {
        get => assembling;
        set
        {
            assembling = value;
            OnPropertyChanged(nameof(Assembling));
        }
    }
    public ViewPackaging Packaging
    {
        get => packaging;
        set
        {
            packaging = value;
            OnPropertyChanged(nameof(Packaging));
        }
    }
    public ViewStatusGeneric Equipment
    {
        get => equipment;
        set
        {
            equipment = value;
            OnPropertyChanged(nameof(Equipment));
        }
    }
    public ViewStatusGeneric Shipment
    {
        get => shipment;
        set
        {
            shipment = value;
            OnPropertyChanged(nameof(Shipment));
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
    public ViewMounting Mounting
    {
        get => mounting;
        set
        {
            mounting = value;
            OnPropertyChanged(nameof(Mounting));
        }
    }

    internal ViewOrder(int id, Order order)
    {
        dbId = order.Id;
        orderMainData = new(id, order.OrderMainData);
        docConstructor = new(order.DocumentationConstructor);
        docTechnologist = new(order.DocumentationTechnologist);
        supply = new(order.Supply);
        sawCenter = new(order.SawCenter);
        edge = new(order.Edge);
        additive = new(order.Additive);
        milling = new(order.Milling);
        grinding = new(order.Grinding);
        press = new(order.Press);
        assembling = new(order.Assembling);
        packaging = new(order.Packaging);
        equipment = new(order.Equipment);
        shipment = new(order.Shipment);
        note = order.Note;
        mounting = new(order.Mounting);
    }
}
