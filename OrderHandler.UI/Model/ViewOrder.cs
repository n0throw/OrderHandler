using OrderHandler.DB.Data;
using OrderHandler.UI.Core;
using OrderHandler.UI.Model.ViewOrderAdd;

namespace OrderHandler.UI.Model;

public class ViewOrder : PropertyChanger {
    private readonly int dbId;
    private ViewOrderMain viewOrderMain;
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
    private ViewPacking packing;
    private ViewStatusGeneric equipment;
    private ViewStatusGeneric shipment;
    private string? note;
    private ViewMounting mounting;

    public int DbId => dbId;
    public ViewOrderMain ViewOrderMain {
        get => viewOrderMain;
        set {
            viewOrderMain = value;
            OnPropertyChanged(nameof(ViewOrderMain));
        }
    }
    public ViewStatusGeneric DocConstructor {
        get => docConstructor;
        set {
            docConstructor = value;
            OnPropertyChanged(nameof(DocConstructor));
        }
    }
    public ViewStatusGeneric DocTechnologist {
        get => docTechnologist;
        set {
            docTechnologist = value;
            OnPropertyChanged(nameof(DocTechnologist));
        }
    }
    public ViewSupply Supply {
        get => supply;
        set {
            supply = value;
            OnPropertyChanged(nameof(Supply));
        }
    }
    public ViewSawCenter SawCenter {
        get => sawCenter;
        set {
            sawCenter = value;
            OnPropertyChanged(nameof(SawCenter));
        }
    }
    public ViewEdge Edge {
        get => edge;
        set {
            edge = value;
            OnPropertyChanged(nameof(Edge));
        }
    }
    public ViewAdditive Additive {
        get => additive;
        set {
            additive = value;
            OnPropertyChanged(nameof(Additive));
        }
    }
    public ViewMilling Milling {
        get => milling;
        set {
            milling = value;
            OnPropertyChanged(nameof(Milling));
        }
    }
    public ViewGrinding Grinding {
        get => grinding;
        set {
            grinding = value;
            OnPropertyChanged(nameof(Grinding));
        }
    }
    public ViewPress Press {
        get => press;
        set {
            press = value;
            OnPropertyChanged(nameof(Press));
        }
    }
    public ViewAssembling Assembling {
        get => assembling;
        set {
            assembling = value;
            OnPropertyChanged(nameof(Assembling));
        }
    }
    public ViewPacking Packing {
        get => packing;
        set {
            packing = value;
            OnPropertyChanged(nameof(Packing));
        }
    }
    public ViewStatusGeneric Equipment {
        get => equipment;
        set {
            equipment = value;
            OnPropertyChanged(nameof(Equipment));
        }
    }
    public ViewStatusGeneric Shipment {
        get => shipment;
        set {
            shipment = value;
            OnPropertyChanged(nameof(Shipment));
        }
    }
    public string? Note {
        get => note;
        set {
            note = value;
            OnPropertyChanged(nameof(Note));
        }
    }
    public ViewMounting Mounting {
        get => mounting;
        set {
            mounting = value;
            OnPropertyChanged(nameof(Mounting));
        }
    }

    public ViewOrder() { }

    public ViewOrder(int number, Order order) {
        dbId = order.Id;
        viewOrderMain = new(number, order.OrderMain);
        docConstructor = new(order.DocConstructor);
        docTechnologist = new(order.DocTechnologist);
        supply = new(order.Supply);
        sawCenter = new(order.SawCenter);
        edge = new(order.Edge);
        additive = new(order.Additive);
        milling = new(order.Milling);
        grinding = new(order.Grinding);
        press = new(order.Press);
        assembling = new(order.Assembling);
        packing = new(order.Packing);
        equipment = new(order.Equipment);
        shipment = new(order.Shipment);
        note = order.Note;
        mounting = new(order.Mounting);
    }

    public bool Validate() =>
        viewOrderMain.Validate() &&
        docConstructor.Validate() &&
        docTechnologist.Validate() &&
        supply.Validate() &&
        sawCenter.Validate() &&
        edge.Validate() &&
        additive.Validate() &&
        milling.Validate() &&
        grinding.Validate() &&
        press.Validate() &&
        assembling.Validate() &&
        packing.Validate() &&
        equipment.Validate() &&
        shipment.Validate() &&
        mounting.Validate();

    public static implicit operator Order(ViewOrder obj) => new() {
        OrderMain = obj.viewOrderMain,
        DocConstructor = obj.docConstructor,
        DocTechnologist = obj.docTechnologist,
        Supply = obj.supply,
        SawCenter = obj.sawCenter,
        Edge = obj.edge,
        Additive = obj.additive,
        Milling = obj.milling,
        Grinding = obj.grinding,
        Press = obj.press,
        Assembling = obj.assembling,
        Packing = obj.packing,
        Equipment = obj.equipment,
        Shipment = obj.shipment,
        Note = obj.note,
        Mounting = obj.mounting
    };
}
