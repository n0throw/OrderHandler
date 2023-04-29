using OrderHandler.UI.Core;
using OrderHandler.UI.Model.ViewOrderAdd;

namespace OrderHandler.UI.Model;

public class ViewOrder : PropertyChanger {
    /// <summary>
    /// Id в БД
    /// </summary>
    int _idDb;
    /// <summary>
    /// Id в отображении
    /// </summary>
    int _id;
    ViewOrderMain _orderMain;
    ViewDocConst _docConst;
    ViewDocTech _docTech;
    ViewSupply _supply;
    ViewSawCenter _sawCenter;
    ViewEdge _edge;
    ViewAdditive _additive;
    ViewMilling _milling;
    ViewGrinding _grinding;
    ViewPress _press;
    ViewAssembling _assembling;
    ViewPacking _packing;
    ViewEquipment _equipment;
    ViewShipment _shipment;
    string _note;
    ViewMounting _mounting;
    
    internal int IdDb {
        get => _idDb;
        set => _idDb = value;
    }
    public int Id {
        get => _id;
        set {
            _id = value;
            OnPropertyChanged();
        }
    }
    public ViewOrderMain OrderMain {
        get => _orderMain;
        set {
            _orderMain = value;
            OnPropertyChanged();
        }
    }
    public ViewDocConst DocConst {
        get => _docConst;
        set {
            _docConst = value;
            OnPropertyChanged();
        }
    }
    public ViewDocTech DocTech {
        get => _docTech;
        set {
            _docTech = value;
            OnPropertyChanged();
        }
    }
    public ViewSupply Supply {
        get => _supply;
        set {
            _supply = value;
            OnPropertyChanged();
        }
    }
    public ViewSawCenter SawCenter {
        get => _sawCenter;
        set {
            _sawCenter = value;
            OnPropertyChanged();
        }
    }
    public ViewEdge Edge {
        get => _edge;
        set {
            _edge = value;
            OnPropertyChanged();
        }
    }
    public ViewAdditive Additive {
        get => _additive;
        set {
            _additive = value;
            OnPropertyChanged();
        }
    }
    public ViewMilling Milling {
        get => _milling;
        set {
            _milling = value;
            OnPropertyChanged();
        }
    }
    public ViewGrinding Grinding {
        get => _grinding;
        set {
            _grinding = value;
            OnPropertyChanged();
        }
    }
    public ViewPress Press {
        get => _press;
        set {
            _press = value;
            OnPropertyChanged();
        }
    }
    public ViewAssembling Assembling {
        get => _assembling;
        set {
            _assembling = value;
            OnPropertyChanged();
        }
    }
    public ViewPacking Packing {
        get => _packing;
        set {
            _packing = value;
            OnPropertyChanged();
        }
    }
    public ViewEquipment Equipment {
        get => _equipment;
        set {
            _equipment = value;
            OnPropertyChanged();
        }
    }
    public ViewShipment Shipment {
        get => _shipment;
        set {
            _shipment = value;
            OnPropertyChanged();
        }
    }
    public string Note {
        get => _note;
        set {
            _note = value;
            OnPropertyChanged();
        }
    }
    public ViewMounting Mounting {
        get => _mounting;
        set {
            _mounting = value;
            OnPropertyChanged();
        }
    }

    public ViewOrder() { }
    
    public bool Validate() =>
        _orderMain.Validate() &&
        _docConst.Validate() &&
        _docTech.Validate() &&
        _supply.Validate() &&
        _sawCenter.Validate() &&
        _edge.Validate() &&
        _additive.Validate() &&
        _milling.Validate() &&
        _grinding.Validate() &&
        _press.Validate() &&
        _assembling.Validate() &&
        _packing.Validate() &&
        _equipment.Validate() &&
        _shipment.Validate() &&
        _mounting.Validate();
}