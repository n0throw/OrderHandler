using OrderHandler.DB.Context;
using OrderHandler.DB.Model;
using OrderHandler.DB.Model.Additional.Order;
using OrderHandler.UI.Core;
using OrderHandler.UI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderHandler.UI.Contexts;

internal class AddNewOrderContext : PropertyChanger
{
    public NewOrderMainData NewOrderMainData { get; set; }
    public NewOrderDates NewOrderDates { get; set; }

    internal AddNewOrderContext()
    {
        NewOrderMainData = new();
        NewOrderDates = new();
    }


    private RelayCommand? addCommand;
    public RelayCommand AddCommand
    {
        get => addCommand ??= new RelayCommand(obj =>
        {
            using OrderContext orderDBContext = new();
            int index = orderDBContext.GetLastIndex();

            orderDBContext.Orders.Add(new Order(
                ++index,
                new OrderMainData(
                    NewOrderMainData.UserName,
                    NewOrderMainData.OrderIssue,
                    NewOrderDates.OrderDate,
                    NewOrderDates.DeliveryDate,
                    (short)(NewOrderDates.DeliveryDate - NewOrderDates.OrderDate).TotalDays,
                    NewOrderMainData.ProductType,
                    NewOrderMainData.ProductCost),
                new StatusGeneric(NewOrderDates.DocumentationConstructorDate),
                new StatusGeneric(NewOrderDates.DocumentationTechnologistDate),
                new Supply(NewOrderDates.SupplyDate),
                new SawCenter(NewOrderDates.SawCenterDate),
                new Edge(NewOrderDates.EdgeDate),
                new Additive(NewOrderDates.AdditiveDate),
                new Milling(NewOrderDates.MillingDate),
                new Grinding(NewOrderDates.GrindingDate),
                new Press(NewOrderDates.PressDate),
                new Assembling(NewOrderDates.AssemblingDate),
                new Packaging(NewOrderDates.PackagingDate),
                new StatusGeneric(NewOrderDates.EquipmentDate),
                new StatusGeneric(NewOrderDates.ShipmentDate),
                NewOrderMainData.Note,
                new Mounting(
                    NewOrderMainData.IsMounting,
                    NewOrderDates.MountingDate)));

            orderDBContext.SaveChanges();
        }, null);
    }
}
