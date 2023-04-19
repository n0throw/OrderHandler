using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using OrderHandler.DB.Data;
using OrderHandler.UI.Core;
using OrderHandler.UI.Core.Dialog;
using OrderHandler.UI.Core.Resolver;
using OrderHandler.UI.Model;
using OrderHandler.UI.Windows;
using OrderHandler.DB;

namespace OrderHandler.UI.Contexts;

public class TableOrderManagerContext : PropertyChanger {
    private readonly IDialogService dialogService;
    private readonly IOrderService orderService;
    public ObservableCollection<ViewOrder> Orders { get; set; }

    public TableOrderManagerContext() {
        Orders = new ObservableCollection<ViewOrder>();
        dialogService = new DefaultDialogService();
        orderService = new ExcelOrderService(dialogService);
        GetData();
    }

    private ViewOrder? selectedOrder;
    public ViewOrder? SelectedOrder {
        get => selectedOrder;
        set {
            selectedOrder = value;
            OnPropertyChanged(nameof(SelectedOrder));
        }
    }

    private RelayCommand? addOrderCommand;
    public RelayCommand AddOrderCommand
        => addOrderCommand ??= new RelayCommand(obj => {
            AddNewOrder addNewOrderWindow = new();

            if (addNewOrderWindow.ShowDialog() == true)
                GetData();
        }, null);

    private RelayCommand? exitCommand;
    public RelayCommand ExitCommand
        => exitCommand ??= new RelayCommand(obj
            => GoToPage("Login"), null);

    private RelayCommand? exitAppCommand;
    public RelayCommand ExitAppCommand
        => exitAppCommand ??= new RelayCommand(obj
            => Application.Current.Shutdown(), null);

    private RelayCommand? updateCommand;
    public RelayCommand UpdateCommand
        => updateCommand ??= new RelayCommand(obj
            => GetData(), null);

    private RelayCommand? showCountOrder;
    public RelayCommand ShowCountOrder
        => showCountOrder ??= new RelayCommand(obj => {
            dialogService.ShowMessage($"Количество заказов: {Orders.Count}");
        }, null);

    private RelayCommand? uploadTempExcel;
    public RelayCommand UploadTempExcel => uploadTempExcel ??= new RelayCommand(obj => {
        string? filePath = Utilities.GetTempExcelPath();

        if (filePath is null) {
            dialogService.ShowMessage("Отсутствует файл шаблона. Обратитесь к администратору!");
            return;
        }

        if (dialogService.SaveFileDialog("Шаблон Excel"))
            File.Copy(filePath, dialogService.FilePath);

    }, null);

    private RelayCommand? uploadExcelData;
    public RelayCommand UploadExcelData
        => uploadExcelData ??= new RelayCommand(obj => {
            if (dialogService.SaveFileDialog($"Данные заказов {DateTime.Now.ToString("dd.MM.yyyy HH.mm.ss")}"))
                orderService.Save(dialogService.FilePath, Orders);
        }, null);

    private RelayCommand? setStatus;
    public RelayCommand SetStatus
        => setStatus ??= new RelayCommand(obj => {
            if (obj is not string sectionName)
                return;

            if (!Enum.TryParse(sectionName, out TableSectionNames tableSection))
                return;

            if (!Utilities.CheckRole(tableSection, "test")) {
                dialogService.ShowMessage("У вас нет прав на данную операцию");
                return;
            }

            Order dbOrder;
            try {
                dbOrder = GetSelectedDBOrder();
            } catch (NullReferenceException ex) {
                dialogService.ShowMessage(ex.Message);
                return;
            }

            StatusDialogServise statusDialog = new(dbOrder, tableSection);
            statusDialog.SetStatus();

            using OrderContext db = new();
            using IDbContextTransaction transaction = db.Database.BeginTransaction();

            try {
                db.Orders.Update(dbOrder);
                db.SaveChanges();
                transaction.Commit();
                GetData();
            } catch (Exception ex) {
                transaction.Rollback();
                dialogService.ShowMessage(ex.Message);
            }
        }, null);


    private Order GetSelectedDBOrder() {
        int? dbid = SelectedOrder?.DbId;

        if (dbid is null)
            throw new NullReferenceException("Заказ не выделен");

        using OrderContext db = new();

        Order? dbOrder = db.Orders.SingleOrDefault(obj => obj.Id == dbid);

        if (dbOrder is null)
            throw new NullReferenceException("Заказ был удалён");

        return dbOrder;
    }

    private RelayCommand? delStatus;
    public RelayCommand DelStatus => delStatus ??= new RelayCommand(obj => {
        if (obj is not string sectionName)
            return;

        if (!Enum.TryParse(sectionName, out TableSectionNames tableSection))
            return;

        if (!Utilities.CheckRole(tableSection, "test")) {
            dialogService.ShowMessage("У вас нет прав на данную операцию");
            return;
        }

        Order dbOrder;
        try {
            dbOrder = GetSelectedDBOrder();
        } catch (NullReferenceException ex) {
            dialogService.ShowMessage(ex.Message);
            return;
        }

        StatusDialogServise statusDialog = new(dbOrder, tableSection);
        statusDialog.DelStatus();

        using OrderContext db = new();
        using IDbContextTransaction transaction = db.Database.BeginTransaction();

        try {
            db.Orders.Update(dbOrder);
            db.SaveChanges();
            transaction.Commit();
            GetData();
        } catch (Exception ex) {
            transaction.Rollback();
            dialogService.ShowMessage(ex.Message);
        }

    }, null);

    private void GetData() {
        Orders.Clear();

        using OrderContext orderDBContext = new();
        int index = 0;

        orderDBContext.Orders.
            ToList().
            ForEach(orderDB => Orders.Add(
                new ViewOrder(
                    ++index,
                    orderDB)));
    }
}
