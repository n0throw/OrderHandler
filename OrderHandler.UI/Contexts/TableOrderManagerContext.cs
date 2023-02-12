using OrderHandler.DB.Context;
using OrderHandler.DB.Model;
using OrderHandler.UI.Core;
using OrderHandler.UI.Model;
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
    public ObservableCollection<ViewDocumentationConstructor> DocumentationConstructor { get; set; }

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

    private ViewDocumentationConstructor selectedDocumentationConstructor;
    public ViewDocumentationConstructor SelectedDocumentationConstructor
    {
        get => selectedDocumentationConstructor;
        set
        {
            selectedDocumentationConstructor = value;
            OnPropertyChanged(nameof(SelectedDocumentationConstructor));
        }
    }

    internal TableOrderManagerContext()
    {
        Order = new ObservableCollection<ViewOrder>();
        DocumentationConstructor = new ObservableCollection<ViewDocumentationConstructor>();
        GetData();
    }

    private void GetData()
    {
        Order.Clear();
        DocumentationConstructor.Clear();

        using OrderContext orderDBContext = new();
        int index = 0;

        orderDBContext.Orders.ToList().ForEach(orderDB =>
        {
            Order.Add(new()
            {
                Id = ++index,
                UserName = orderDB.OrderMainData.UserDataId,
                OrderIssue = orderDB.OrderMainData.OrderIssue,
                OrderDate = orderDB.OrderMainData.OrderDate,
                DeliveryDate = orderDB.OrderMainData.DeliveryDate,
                NumberOfDays = orderDB.OrderMainData.NumberOfDays,
                ProductType = orderDB.OrderMainData.ProductType,
                ProductCost = orderDB.OrderMainData.ProductCost
            });
            DocumentationConstructor.Add(new()
            {
                PlannedDate = orderDB.DocumentationConstructor.PlannedDate,
                UserName = orderDB.DocumentationConstructor.UserId,
                Date = orderDB.DocumentationConstructor.Date
            });
        });
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
            ViewDocumentationConstructor documentationConstructor = obj as ViewDocumentationConstructor;
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
                    NumberOfDays = (short)(view.DeliveryDate.DayNumber - view.OrderDate.DayNumber),
                    ProductType = view.ProductType,
                    ProductCost = view.ProductCost
                },
                DocumentationConstructor = new()
                {
                    PlannedDate = documentationConstructor.PlannedDate,
                    UserId = "Name",
                    Date = DateOnly.FromDateTime(DateTime.Now)
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
            ViewDocumentationConstructor documentationConstructor = DocumentationConstructor[index];

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
                    NumberOfDays = (short)(view.DeliveryDate.DayNumber - view.OrderDate.DayNumber),
                    ProductType = view.ProductType,
                    ProductCost = view.ProductCost
                },
                DocumentationConstructor = new()
                {
                    PlannedDate = documentationConstructor.PlannedDate,
                    UserId = "Name",
                    Date = DateOnly.FromDateTime(DateTime.Now)
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
}
