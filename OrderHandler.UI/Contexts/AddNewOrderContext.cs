using OrderHandler.DB.Context;
using OrderHandler.DB.Model;
using OrderHandler.DB.Model.Additional.Order;
using OrderHandler.UI.Core;
using OrderHandler.UI.Model;
using OrderHandler.UI.Model.NewOrderData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderHandler.UI.Contexts;

internal class AddNewOrderContext : PropertyChanger
{
    private NewOrder newOrder;
    public NewOrder NewOrder
    {
        get => newOrder;
        set
        {
            newOrder = value;
            OnPropertyChanged(nameof(NewOrder));
        }
    }

    internal AddNewOrderContext()
    {
        newOrder = new();
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
                    newOrder.MainData.UserName,
                    newOrder.MainData.OrderIssue,
                    newOrder.Dates.OrderDate,
                    newOrder.Dates.DeliveryDate,
                    (short)(newOrder.Dates.DeliveryDate - newOrder.Dates.OrderDate).TotalDays,
                    newOrder.MainData.ProductType,
                    newOrder.MainData.ProductCost),
                new StatusGeneric(newOrder.Dates.DocConstructorDate),
                new StatusGeneric(newOrder.Dates.DocTechnologistDate),
                new Supply(newOrder.Dates.SupplyDate),
                new SawCenter(newOrder.Dates.SawCenterDate),
                new Edge(newOrder.Dates.EdgeDate),
                new Additive(newOrder.Dates.AdditiveDate),
                new Milling(newOrder.Dates.MillingDate),
                new Grinding(newOrder.Dates.GrindingDate),
                new Press(newOrder.Dates.PressDate),
                new Assembling(newOrder.Dates.AssemblingDate),
                new Packing(newOrder.Dates.PackagingDate),
                new StatusGeneric(newOrder.Dates.EquipmentDate),
                new StatusGeneric(newOrder.Dates.ShipmentDate),
                newOrder.MainData.Note,
                new Mounting(
                    newOrder.MainData.IsMounting,
                    newOrder.Dates.MountingDate)));

            orderDBContext.SaveChanges();
        }, obj => NewOrder.MainData.CheckAllValidation());
    }
}
