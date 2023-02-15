using OrderHandler.DB.Context;
using OrderHandler.DB.Model;
using OrderHandler.UI.Core;
using OrderHandler.UI.Model;
using OrderHandler.UI.Model.OrderData;
using OrderHandler.UI.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OrderHandler.UI.Contexts;

internal class TableOrderManagerContext : PropertyChanger
{
    public ObservableCollection<ViewOrder> Order { get; set; }

    internal TableOrderManagerContext()
    {
        Order = new ObservableCollection<ViewOrder>();
        GetData();
    }

    private ViewOrder selectedOrder;
    public ViewOrder SelectedOrder
    {
        get => selectedOrder;
        set
        {
            selectedOrder = value;
            OnPropertyChanged(nameof(SelectedOrder));
        }
    }

    private RelayCommand addOrderCommand;
    public RelayCommand AddOrderCommand
    {
        get => addOrderCommand ??= new RelayCommand(obj =>
        {
            AddNewOrder addNewOrderWindow = new AddNewOrder();

            if (addNewOrderWindow.ShowDialog() == true)
            {
                GetData();
            }
        }, null);
    }

    private RelayCommand exitCommand;
    public RelayCommand ExitCommand
    {
        get => exitCommand ??= new RelayCommand(obj =>
        {
            GoToPage("Login");
        }, null);
    }

    private RelayCommand exitAppCommand;

    public RelayCommand ExitAppCommand
    {
        get => exitAppCommand ??= new RelayCommand(obj =>
        {
            Application.Current.Shutdown();
        }, null);
    }



    private RelayCommand changeRowDocumentationConstructor;

    public RelayCommand ChangeRowDocumentationConstructor
    {
        get => changeRowDocumentationConstructor ??= new RelayCommand(obj =>
        {
            ViewDocConstructor documentationConstructor = obj as ViewDocConstructor;
            int index = DocumentationConstructor.IndexOf(documentationConstructor);
            ViewOrder view = Order[index];

            using OrderContext orderDBContext = new();

            orderDBContext.Orders.Update(new Order()
            {
                Id = ++index,
                OrderMainData = new()
                {
                    UserDataId = view.UserName,
                    OrderIssue = view.OrderIssue,
                    OrderDate = view.OrderDate,
                    DeliveryDate = view.DeliveryDate,
                    NumberOfDays = (short)(view.DeliveryDate - view.OrderDate).TotalDays,
                    ProductType = view.ProductType,
                    ProductCost = view.ProductCost
                },
                DocumentationConstructor = new()
                {
                    PlannedDate = documentationConstructor.PlannedDate,
                    UserId = "Name",
                    Date = DateTime.Now
                }
            });

            orderDBContext.SaveChanges();
            GetData();
        }, null);
    }


    private RelayCommand changeRowOrder;

    public RelayCommand ChangeRowOrder
    {
        get => changeRowOrder ??= new RelayCommand(obj =>
        {
            ViewOrder view = obj as ViewOrder;
            int index = Order.IndexOf(view);
            ViewDocConstructor documentationConstructor = DocumentationConstructor[index];

            using OrderContext orderDBContext = new();

            orderDBContext.Orders.Update(new Order()
            {
                Id = ++index,
                OrderMainData = new()
                {
                    UserDataId = view.UserName,
                    OrderIssue = view.OrderIssue,
                    OrderDate = view.OrderDate,
                    DeliveryDate = view.DeliveryDate,
                    NumberOfDays = (short)(view.DeliveryDate - view.OrderDate).TotalDays,
                    ProductType = view.ProductType,
                    ProductCost = view.ProductCost
                },
                DocumentationConstructor = new()
                {
                    PlannedDate = documentationConstructor.PlannedDate,
                    UserId = "Name",
                    Date = DateTime.Now
                }
            });

            orderDBContext.SaveChanges();
            GetData();
        }, null);
    }

    private RelayCommand updateCommand;

    public RelayCommand UpdateCommand
    {
        get => updateCommand ??= new RelayCommand(obj =>
        {
            GetData();
        }, null);
    }

    private void GetData()
    {
        Order.Clear();

        using OrderContext orderDBContext = new();
        int index = 0;

        orderDBContext.Orders.
            ToList().
            ForEach(orderDB => Order.Add(
                new ViewOrder(
                    ++index,
                    orderDB)));
    }
}
