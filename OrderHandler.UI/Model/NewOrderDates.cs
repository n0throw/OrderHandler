using OrderHandler.UI.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderHandler.UI.Model;

internal class NewOrderDates : PropertyChanger, IDataErrorInfo
{
    private DateTime orderDate;
    private DateTime deliveryDate;
    private DateTime documentationConstructorDate;
    private DateTime documentationTechnologistDate;
    private DateTime supplyDate;
    private DateTime sawCenterDate;
    private DateTime edgeDate;
    private DateTime additiveDate;
    private DateTime millingDate;
    private DateTime grindingDate;
    private DateTime pressDate;
    private DateTime assemblingDate;
    private DateTime packagingDate;
    private DateTime equipmentDate;
    private DateTime shipmentDate;
    private DateTime mountingDate;

    public string this[string columnName] => throw new NotImplementedException();
    public string Error => throw new NotImplementedException();


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

    public DateTime DocumentationConstructorDate
    {
        get => documentationConstructorDate;
        set
        {
            documentationConstructorDate = value;
            OnPropertyChanged("DocumentationConstructorDate");
        }
    }

    public DateTime DocumentationTechnologistDate
    {
        get => documentationTechnologistDate;
        set
        {
            documentationTechnologistDate = value;
            OnPropertyChanged("DocumentationTechnologistDate");
        }
    }

    public DateTime SupplyDate
    {
        get => supplyDate;
        set
        {
            supplyDate = value;
            OnPropertyChanged("SupplyDate");
        }
    }

    public DateTime SawCenterDate
    {
        get => sawCenterDate;
        set
        {
            sawCenterDate = value;
            OnPropertyChanged("SawCenterDate");
        }
    }

    public DateTime EdgeDate
    {
        get => edgeDate;
        set
        {
            edgeDate = value;
            OnPropertyChanged("EdgeDate");
        }
    }

    public DateTime AdditiveDate
    {
        get => additiveDate;
        set
        {
            additiveDate = value;
            OnPropertyChanged("AdditiveDate");
        }
    }

    public DateTime MillingDate
    {
        get => millingDate;
        set
        {
            millingDate = value;
            OnPropertyChanged("MillingDate");
        }
    }

    public DateTime GrindingDate
    {
        get => grindingDate;
        set
        {
            grindingDate = value;
            OnPropertyChanged("GrindingDate");
        }
    }

    public DateTime PressDate
    {
        get => pressDate;
        set
        {
            pressDate = value;
            OnPropertyChanged("PressDate");
        }
    }

    public DateTime AssemblingDate
    {
        get => assemblingDate;
        set
        {
            assemblingDate = value;
            OnPropertyChanged("AssemblingDate");
        }
    }

    public DateTime PackagingDate
    {
        get => packagingDate;
        set
        {
            packagingDate = value;
            OnPropertyChanged("PackagingDate");
        }
    }

    public DateTime EquipmentDate
    {
        get => equipmentDate;
        set
        {
            equipmentDate = value;
            OnPropertyChanged("EquipmentDate");
        }
    }

    public DateTime ShipmentDate
    {
        get => shipmentDate;
        set
        {
            shipmentDate = value;
            OnPropertyChanged("ShipmentDate");
        }
    }

    public DateTime MountingDate
    {
        get => mountingDate;
        set
        {
            mountingDate = value;
            OnPropertyChanged("MountingDate");
        }
    }
}
