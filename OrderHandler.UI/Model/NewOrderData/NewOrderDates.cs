using OrderHandler.UI.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderHandler.UI.Model.NewOrderData;

internal class NewOrderDates : PropertyChanger, IDataErrorInfo
{
    private DateTime orderDate;
    private DateTime deliveryDate;
    private DateTime docConstructorDate;
    private DateTime docTechnologistDate;
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

    public NewOrderDates()
    {
        orderDate = DateTime.Now;
        deliveryDate = DateTime.Now.AddDays(30);
        docConstructorDate = DateTime.Now.AddDays(4);
        docTechnologistDate = DateTime.Now.AddDays(4);
        supplyDate = DateTime.Now.AddDays(5);
        sawCenterDate = DateTime.Now.AddDays(6);
        edgeDate = DateTime.Now.AddDays(7);
        additiveDate = DateTime.Now.AddDays(8);
        millingDate = DateTime.Now.AddDays(9);
        grindingDate = DateTime.Now.AddDays(10);
        pressDate = DateTime.Now.AddDays(11);
        assemblingDate = DateTime.Now.AddDays(12);
        packagingDate = DateTime.Now.AddDays(13);
        equipmentDate = DateTime.Now.AddDays(14);
        shipmentDate = DateTime.Now.AddDays(15);
        mountingDate = DateTime.Now.AddDays(30);
    }

    public string this[string columnName] => throw new NotImplementedException();
    public string Error => throw new NotImplementedException();


    public DateTime OrderDate
    {
        get => orderDate;
        set
        {
            orderDate = value;
            OnPropertyChanged(nameof(OrderDate));
        }
    }

    public DateTime DeliveryDate
    {
        get => deliveryDate;
        set
        {
            deliveryDate = value;
            OnPropertyChanged(nameof(DeliveryDate));
        }
    }

    public DateTime DocConstructorDate
    {
        get => docConstructorDate;
        set
        {
            docConstructorDate = value;
            OnPropertyChanged(nameof(DocConstructorDate));
        }
    }

    public DateTime DocTechnologistDate
    {
        get => docTechnologistDate;
        set
        {
            docTechnologistDate = value;
            OnPropertyChanged(nameof(DocTechnologistDate));
        }
    }

    public DateTime SupplyDate
    {
        get => supplyDate;
        set
        {
            supplyDate = value;
            OnPropertyChanged(nameof(SupplyDate));
        }
    }

    public DateTime SawCenterDate
    {
        get => sawCenterDate;
        set
        {
            sawCenterDate = value;
            OnPropertyChanged(nameof(SawCenterDate));
        }
    }

    public DateTime EdgeDate
    {
        get => edgeDate;
        set
        {
            edgeDate = value;
            OnPropertyChanged(nameof(EdgeDate));
        }
    }

    public DateTime AdditiveDate
    {
        get => additiveDate;
        set
        {
            additiveDate = value;
            OnPropertyChanged(nameof(AdditiveDate));
        }
    }

    public DateTime MillingDate
    {
        get => millingDate;
        set
        {
            millingDate = value;
            OnPropertyChanged(nameof(MillingDate));
        }
    }

    public DateTime GrindingDate
    {
        get => grindingDate;
        set
        {
            grindingDate = value;
            OnPropertyChanged(nameof(GrindingDate));
        }
    }

    public DateTime PressDate
    {
        get => pressDate;
        set
        {
            pressDate = value;
            OnPropertyChanged(nameof(PressDate));
        }
    }

    public DateTime AssemblingDate
    {
        get => assemblingDate;
        set
        {
            assemblingDate = value;
            OnPropertyChanged(nameof(AssemblingDate));
        }
    }

    public DateTime PackagingDate
    {
        get => packagingDate;
        set
        {
            packagingDate = value;
            OnPropertyChanged(nameof(PackagingDate));
        }
    }

    public DateTime EquipmentDate
    {
        get => equipmentDate;
        set
        {
            equipmentDate = value;
            OnPropertyChanged(nameof(EquipmentDate));
        }
    }

    public DateTime ShipmentDate
    {
        get => shipmentDate;
        set
        {
            shipmentDate = value;
            OnPropertyChanged(nameof(ShipmentDate));
        }
    }

    public DateTime MountingDate
    {
        get => mountingDate;
        set
        {
            mountingDate = value;
            OnPropertyChanged(nameof(MountingDate));
        }
    }
}
