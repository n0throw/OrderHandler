using OrderHandler.DB.Context;
using OrderHandler.DB.Model;
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
    public ViewOrder ViewOrder { get; set; }
    public ViewDocumentationConstructor DocumentationConstructor { get; set; }

    internal AddNewOrderContext()
    {
        ViewOrder = new();
        DocumentationConstructor = new();
    }


    private RelayCommand addCommand;
    public RelayCommand AddCommand
    {
        get => addCommand ??= new RelayCommand(obj =>
        {
            using OrderContext orderDBContext = new();
            Order? lastOrder = orderDBContext.Orders.ToList().LastOrDefault();
            int index;

            if (lastOrder is not null)
                index = lastOrder.Id;
            else
                index = 0;

            orderDBContext.Orders.Add(new Order()
            {
                Id = ++index,
                OrderMainData = new()
                {
                    UserDataId = ViewOrder.UserName,
                    OrderIssue = ViewOrder.OrderIssue,
                    OrderDate = ViewOrder.OrderDate,
                    DeliveryDate = ViewOrder.DeliveryDate,
                    NumberOfDays = (short)(ViewOrder.DeliveryDate.DayNumber - ViewOrder.OrderDate.DayNumber),
                    ProductType = ViewOrder.ProductType,
                    ProductCost = ViewOrder.ProductCost
                },
                DocumentationConstructor = new()
                {
                    PlannedDate = DocumentationConstructor.PlannedDate
                }
            });

            orderDBContext.SaveChanges();
        }, null);
    }
}
