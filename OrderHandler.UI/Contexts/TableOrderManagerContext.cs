using Microsoft.EntityFrameworkCore.Storage;

using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

using OrderHandler.DB.Data;
using OrderHandler.UI.Contexts.CommandsImpl;
using OrderHandler.UI.Core;
using OrderHandler.UI.Model;

namespace OrderHandler.UI.Contexts;

public class TableOrderManagerContext : PropertyChanger {

    readonly ITableOrderManagerCommandsImpl _commandsImpl;
    public ObservableCollection<ViewOrder> Orders { get; private set; }

    public TableOrderManagerContext(ITableOrderManagerCommandsImpl commandsImpl) {
        Orders = new();
        _commandsImpl = commandsImpl;
        GetData();
    }

    ViewOrder? _selectedOrder;
    public ViewOrder? SelectedOrder {
        get => _selectedOrder;
        set {
            _selectedOrder = value;
            OnPropertyChanged();
        }
    }
    // ---------- Меню страницы ----------
    // ---------- Меню ----------
    RelayCommand? _updateDataCommand;
    public RelayCommand UpdateDataCommand => 
        _updateDataCommand ??= new(
            _ => Orders = new(_commandsImpl.UpdateDataCommand()), 
            null
        );

    RelayCommand? _goBackCommand;
    public RelayCommand GoBackCommand => 
        _goBackCommand ??= new(
            _ => _commandsImpl.GoBackCommand(GoToPage), 
            null
        );
    
    RelayCommand? _showStatusCommand;
    public RelayCommand ShowStatusCommand => 
        _showStatusCommand ??= new(
            _ => _commandsImpl.ShowStatusCommand(), 
            null
        );
    
    RelayCommand? _exitCommand;
    public RelayCommand ExitCommand => 
        _exitCommand ??= new(
            _ => _commandsImpl.ExitCommand(GoToPage), 
            null
        );
    
    RelayCommand? _closeAppCommand;
    public RelayCommand CloseAppCommand => 
        _closeAppCommand ??= new(
            _ => _commandsImpl.CloseAppCommand(), 
            null
        );
    
    // ---------- Утилиты ----------
    RelayCommand? _addNewOrderCommand;
    public RelayCommand AddNewOrderCommand => 
        _addNewOrderCommand ??= new(
            _ => SetNewOrders(_commandsImpl.AddNewOrderCommand()),
            null
        );
    
    RelayCommand? _massLoadingOrdersCommand;
    public RelayCommand MassLoadingOrdersCommand => 
        _massLoadingOrdersCommand ??= new(
            _ => SetNewOrders(_commandsImpl.MassLoadingOrdersCommand()), 
            null
        );
    
    RelayCommand? _uploadToExcelData;
    public RelayCommand UploadToExcelData => 
        _uploadToExcelData ??= new(
            _ => _commandsImpl.UploadToExcelData(Orders), 
            null
        );

    RelayCommand? _uploadTemplateExcel;
    public RelayCommand UploadTemplateExcel => 
        _uploadTemplateExcel ??= new(
            _ => _commandsImpl.UploadTemplateExcel(), 
            null
        );
    
    RelayCommand? _showCountOrders;
    public RelayCommand ShowCountOrders => 
        _showCountOrders ??= new(
            _ => _commandsImpl.ShowCountOrders(Orders.Count), 
            null
        );
    
    // ---------- Фильтры ----------

    RelayCommand? _setColumnFilter;
    public RelayCommand SetColumnFilter => _setColumnFilter ??= new(_ => {
        
    }, null);
    
    RelayCommand? _setRowFilter;
    public RelayCommand SetRowFilter => _setRowFilter ??= new(_ => {
        
    }, null);
    
    RelayCommand? _setQueryFilter;
    public RelayCommand SetQueryFilter => _setQueryFilter ??= new(_ => {
        
    }, null);

    // ---------- Контекстное меню ----------
    RelayCommand? _editRowOrder;
    public RelayCommand EditRowOrder => _editRowOrder ??= new(_ => {
        
    }, null);
    
    RelayCommand? _delRowOrder;
    public RelayCommand DelRowOrder => _delRowOrder ??= new(_ => {
        
    }, null);
    
    RelayCommand? _changeStatusRowOrder;
    // TODO
    // Тут шляпа
    // Нужно сделать адекватный column range template для таблиц
    // И ужу по нему проверять, а не по наименованию столбца
    // А то парсить 100+ столбцов не вариант в виде Enumaration
    public RelayCommand ChangeStatusRowOrder => _changeStatusRowOrder ??= new(columnHeader => {
        if (columnHeader is not string colName) {
            MessageBox.Show("Не удалось получить идентификатор столбца");
            return;
        }

        if (!Enum.TryParse(colName, out TableSectionNames colIndex)) {
            MessageBox.Show("Такой столбец не учтён");
            return;
        }
        
        switch (colIndex) {
            case TableSectionNames.IdColumn:
            case TableSectionNames.OrderIssueColumn:
            case TableSectionNames.OrderManagerColumn:
            case TableSectionNames.OrderDateColumn:
            case TableSectionNames.DeliveryDateColumn:
            case TableSectionNames.NumberOfDaysColumn:
            case TableSectionNames.ProductTypeColumn:
            case TableSectionNames.ProductCostColumn:
                
                break;
            case TableSectionNames.DocConstPlannedDateColumn:
            case TableSectionNames.DocConstFIOColumn:
            case TableSectionNames.DocConstDateColumn:
                break;
            case TableSectionNames.DocTechPlannedDateColumn:
            case TableSectionNames.DocTechFIOColumn:
            case TableSectionNames.DocTechDateColumn:
                break;
            case TableSectionNames.SupplyPlannedDateColumn:
            case TableSectionNames.SupplyFIOColumn:
            case TableSectionNames.SupplyDateColumn:
            case TableSectionNames.SupplyRequiredAmountColumn:
                break;
            case TableSectionNames.SawCenterPlannedDateColumn:
            case TableSectionNames.SawCenterFIOColumn:
            case TableSectionNames.SawCenterDateColumn:
            case TableSectionNames.SawCenterAreaOfLCBOrMDFColumn:
            case TableSectionNames.SawCenterAreaOfLHDFColumn:
                break;
            case TableSectionNames.EdgePlannedDateColumn:
            case TableSectionNames.EdgeFIOColumn:
            case TableSectionNames.EdgeDateColumn:
            case TableSectionNames.EdgeAreaOfLCBOrMDFColumn:
                break;
            case TableSectionNames.AdditivePlannedDateColumn:
            case TableSectionNames.AdditiveFIOColumn:
            case TableSectionNames.AdditiveDateColumn:
            case TableSectionNames.AdditiveAreaOfLCBOrMDFColumn:
                break;
            case TableSectionNames.MillingPlannedDateColumn:
            case TableSectionNames.MillingFIOColumn:
            case TableSectionNames.MillingDateColumn:
            case TableSectionNames.MillingAreaOfMDFColumn:
                break;
            case TableSectionNames.GrindingPlannedDateColumn:
            case TableSectionNames.GrindingFIOColumn:
            case TableSectionNames.GrindingDateColumn:
            case TableSectionNames.GrindingAreaOfMDFColumn:
                break;
            case TableSectionNames.PressPlannedDateColumn:
            case TableSectionNames.PressFIOColumn:
            case TableSectionNames.PressDateColumn:
            case TableSectionNames.PressAreaOfMDFColumn:
                break;
            case TableSectionNames.AssemblingPlannedDateColumn:
            case TableSectionNames.AssemblingFIOColumn:
            case TableSectionNames.AssemblingDateColumn:
            case TableSectionNames.AssemblingAreaOfLCBOrMDFColumn:
                break;
            case TableSectionNames.PackingPlannedDateColumn:
            case TableSectionNames.PackingFIOColumn:
            case TableSectionNames.PackingDateColumn:
            case TableSectionNames.PackingAreaOfLCBOrMDFColumn:
                break;
            case TableSectionNames.EquipmentPlannedDateColumn:
            case TableSectionNames.EquipmentFIOColumn:
            case TableSectionNames.EquipmentDateColumn:
                break;
            case TableSectionNames.ShipmentPlannedDateColumn:
            case TableSectionNames.ShipmentFIOColumn:
            case TableSectionNames.ShipmentDateColumn:
                break;
            case TableSectionNames.NoteColumn:
                break;
            case TableSectionNames.MountingIsNeedColumn:
            case TableSectionNames.MountingPlannedDateColumn:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }, null);
    
    RelayCommand? _editNoteRowOrder;
    public RelayCommand EditNoteRowOrder => _editNoteRowOrder ??= new(_ => {
        
    }, null);
    

    RelayCommand? _setStatus;
    public RelayCommand SetStatus => _setStatus ??= new(obj => {
        if (obj is not string sectionName)
            return;

        if (!Enum.TryParse(sectionName, out TableSectionNames tableSection))
            return;

        if (!Utilities.CheckRole(tableSection, "test")) {
            _dialogService.ShowMessage("У вас нет прав на данную операцию");
            return;
        }

        Order dbOrder;
        try {
            dbOrder = GetSelectedDbOrder();
        } catch (NullReferenceException ex) {
            _dialogService.ShowMessage(ex.Message);
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
            _dialogService.ShowMessage(ex.Message);
        }
    }, null);
    
    RelayCommand? _delStatus;
    public RelayCommand DelStatus => _delStatus ??= new(obj => {
        if (obj is not string sectionName)
            return;

        if (!Enum.TryParse(sectionName, out TableSectionNames tableSection))
            return;

        if (!Utilities.CheckRole(tableSection, "test")) {
            _dialogService.ShowMessage("У вас нет прав на данную операцию");
            return;
        }

        Order dbOrder;
        try {
            dbOrder = GetSelectedDbOrder();
        } catch (NullReferenceException ex) {
            _dialogService.ShowMessage(ex.Message);
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
            _dialogService.ShowMessage(ex.Message);
        }

    }, null);

    Order GetSelectedDbOrder() {
        int? dbid = SelectedOrder?.DbId;

        if (dbid is null)
            throw new NullReferenceException("Заказ не выделен");

        using OrderContext db = new();

        Order? dbOrder = db.Orders.SingleOrDefault(obj => obj.Id == dbid);

        if (dbOrder is null)
            throw new NullReferenceException("Заказ был удалён");

        return dbOrder;
    }



    void GetData() {
        Orders.Clear();

        using OrderContext orderDBContext = new();
        var index = 0;

        orderDBContext.Orders.
            ToList().
            ForEach(orderDB => Orders.Add(
                new ViewOrder(
                    ++index,
                    orderDB)));
    }

    void SetNewOrders(IEnumerable<ViewOrder> data) {
        if (!data.Any())
            Orders = new(data);
    }
}
