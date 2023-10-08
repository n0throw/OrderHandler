using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

using OrderHandler.DB;
using OrderHandler.UI.Contexts.CommandsImpl;
using OrderHandler.UI.Contexts.Windows;
using OrderHandler.UI.Core;
using OrderHandler.UI.Core.Service.Dialog;
using OrderHandler.UI.Model;
using OrderHandler.UI.Windows;

namespace OrderHandler.UI.Contexts.Pages;

public class OrderManagerContext : MainPagePropertyChanger {

    readonly ITableOrderManagerCommandsImpl _commandsImpl;
	readonly IDialogService _dialogService;
    public ObservableCollection<ViewOrder> Orders { get; private set; }

    public OrderManagerContext(ITableOrderManagerCommandsImpl commandsImpl) {
        Orders = new();
        _commandsImpl = commandsImpl;
		_dialogService = new DialogService();
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
            _ => SetNewOrders(_commandsImpl.UpdateDataCommand()), 
            null
        );

    RelayCommand? _returnToMainMenuScreen;
    public RelayCommand ReturnToMainMenuScreen => 
        _returnToMainMenuScreen ??= new(
            _ => _commandsImpl.GoBackCommand(GoToPage), 
            null
        );
    
    RelayCommand? _showStatusWindowCommand;
    public RelayCommand ShowStatusWindowCommand => 
        _showStatusWindowCommand ??= new(
            _ => _commandsImpl.ShowStatusCommand(), 
            null
        );
    
    RelayCommand? _returnToLoginScreen;
    public RelayCommand ReturnToLoginScreen => 
        _returnToLoginScreen ??= new(
            _ => _commandsImpl.ExitCommand(GoToPage), 
            null
        );
    
    RelayCommand? _closeAppCommand;
    public override RelayCommand CloseAppCommand => 
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
    
    // ---------- Сепаратор ----------
    
    RelayCommand? _editRowOrder;
    public RelayCommand EditRowOrder => _editRowOrder ??= new(_ => {
        var newOrder = new NewOrder {
            DataContext = new NewOrderContext()
        };

        if (newOrder.ShowDialog() == true)
        {
            
        }
    }, null);
    
    RelayCommand? _delRowOrder;
    public RelayCommand DelRowOrder => _delRowOrder ??= new(_ => {
		long? idDb = SelectedOrder?.IdDb;
		if (idDb is null)
			return;
		var order = Orders.First(order => order.IdDb == idDb);
		Orders.Remove(order);
		
		using Context dbContext = new();
		using var transaction = dbContext.Database.BeginTransaction();

		try {
			var orderDb = dbContext.OrderInfos.First(o => o.Id == idDb);
			dbContext.OrderInfos.Remove(orderDb);
			dbContext.SaveChanges();
			transaction.Commit();
		} catch (Exception ex) {
			transaction.Rollback();
			_dialogService.ShowMessage(
				ex.Message,
				DialogLevel.Error
			);
		}
	}, null);
    
    RelayCommand? _setStatusDocConst;
    public RelayCommand SetStatusDocConst => _setStatusDocConst ??= new(_ => {
        
    }, null);

    RelayCommand? _setStatusDocTech;
    public RelayCommand SetStatusDocTech => _setStatusDocTech ??= new(_ => {
        
    }, null);

    RelayCommand? _setStatusSupply;
    public RelayCommand SetStatusSupply => _setStatusSupply ??= new(_ => {
        
    }, null);

    RelayCommand? _setStatusSawCenter;
    public RelayCommand SetStatusSawCenter => _setStatusSawCenter ??= new(_ => {
        
    }, null);

    RelayCommand? _setStatusEdge;
    public RelayCommand SetStatusEdge => _setStatusEdge ??= new(_ => {
        
    }, null);

    RelayCommand? _setStatusAdditive;
    public RelayCommand SetStatusAdditive => _setStatusAdditive ??= new(_ => {
        
    }, null);

    RelayCommand? _setStatusMilling;
    public RelayCommand SetStatusMilling => _setStatusMilling ??= new(_ => {
        
    }, null);

    RelayCommand? _setStatusGrinding;
    public RelayCommand SetStatusGrinding => _setStatusGrinding ??= new(_ => {
        
    }, null);

    RelayCommand? _setStatusPress;
    public RelayCommand SetStatusPress => _setStatusPress ??= new(_ => {
        
    }, null);

    RelayCommand? _setStatusAssembling;
    public RelayCommand SetStatusAssembling => _setStatusAssembling ??= new(_ => {
        
    }, null);

    RelayCommand? _setStatusPacking;
    public RelayCommand SetStatusPacking => _setStatusPacking ??= new(_ => {
        
    }, null);

    RelayCommand? _setStatusEquipment;
    public RelayCommand SetStatusEquipment => _setStatusEquipment ??= new(_ => {
        
    }, null);

    RelayCommand? _setStatusShipment;
    public RelayCommand SetStatusShipment => _setStatusShipment ??= new(_ => {
        
    }, null);

    RelayCommand? _editNoteColumn;
    public RelayCommand EditNoteColumn => _editNoteColumn ??= new(_ => {
        
    }, null);
    
    RelayCommand? _setStatusMounting;
    public RelayCommand SetStatusMounting => _setStatusMounting ??= new(_ => {
        
    }, null);
    
    // ---------- Сепаратор ----------
    
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
    
    // ---------- Настройки ----------
    
    RelayCommand? _showUserSettingsWindowCommand;
    public RelayCommand ShowUserSettingsWindowCommand => _showUserSettingsWindowCommand ??= new(_ => {
        
    }, null);
    
    RelayCommand? _showAddSettingsWindowCommand;
    public RelayCommand ShowAddSettingsWindowCommand => _showAddSettingsWindowCommand ??= new(_ => {
        
    }, null);

    // ---------- Контекстное Меню ----------
    // ---------- Больше не используется, все команды дублируются в Header Menu ----------
    RelayCommand? _changeStatusRowOrder;
    public RelayCommand ChangeStatusRowOrder => _changeStatusRowOrder ??= new(tableColumnInfoObj => {
        if (tableColumnInfoObj is not TableColumnInfo tableColumnInfo) {
            MessageBox.Show("Нет такого столбца");
            return;
        }

        if (tableColumnInfo.TableColumnName == TableColumnNames.None ||
            tableColumnInfo.TableSectionName == TableSectionNames.None)
            MessageBox.Show("Вы не выбрали строку");
        
    }, null);
    
    // тут фильтры учитываем
    void GetData() {
		using Context dbContext = new();
		var data = dbContext.OrderInfos
			.Select(x => new ViewOrder() {
				IdDb = x.Id,
				OrderMain = new() {
					OrderNumber = x.OrderMain.OrderNumber,
					IdUser = x.OrderMain.IdUser,
					FIO = x.OrderMain?.User?.CaseName?.GetFullRecordName() ?? "",
					FIO = dbContext.UserInfos.FirstOrDefault(u => u.Id == x.OrderMain.IdUser).CaseName
						.GetFullRecordName()
					OrderDate = x.OrderMain.OrderDate,
					DeliveryDate = x.OrderMain.DeliveryDate,
					Term = (int)x.OrderMain.Term,
					ProductType = x.OrderMain.ProductType,
					OrderAmount = x.OrderMain.OrderAmount,
				},
				DocConst = new() {
					PlannedDate = x.DocConst.PlannedDate,
					FIO = dbContext.UserInfos.FirstOrDefault(u => u.Id == x.DocConst.IdUser).CaseName
						.GetFullRecordName(),
					DateOfCompletion = x.DocConst.DateOfCompletion
				},
				DocTech = new() {
					PlannedDate = x.DocTech.PlannedDate,
					FIO = dbContext.UserInfos.FirstOrDefault(u => u.Id == x.DocTech.IdUser).CaseName
						.GetFullRecordName(),
					DateOfCompletion = x.DocTech.DateOfCompletion
				},
				Supply = new() {
					PlannedDate = x.Supply.PlannedDate,
					FIO = dbContext.UserInfos.FirstOrDefault(u => u.Id == x.Supply.IdUser).CaseName.GetFullRecordName(),
					DateOfCompletion = x.Supply.DateOfCompletion,
					RequiredAmount = x.Supply.RequiredAmount
				},
				SawCenter = new() {
					PlannedDate = x.SawCenter.PlannedDate,
					FIO = dbContext.UserInfos.FirstOrDefault(u => u.Id == x.SawCenter.IdUser).CaseName
						.GetFullRecordName(),
					DateOfCompletion = x.SawCenter.DateOfCompletion,
					AreaOfLCBOrMDF = x.SawCenter.AreaOfLCBOrMDF,
					AreaOfLHDF = x.SawCenter.AreaOfLHDF
				},
				Edge = new() {
					PlannedDate = x.Edge.PlannedDate,
					FIO = dbContext.UserInfos.FirstOrDefault(u => u.Id == x.Edge.IdUser).CaseName.GetFullRecordName(),
					DateOfCompletion = x.Edge.DateOfCompletion,
					AreaOfLCBOrMDF = x.Edge.AreaOfLCBOrMDF
				},
				Additive = new() {
					PlannedDate = x.Additive.PlannedDate,
					FIO = dbContext.UserInfos.FirstOrDefault(u => u.Id == x.Additive.IdUser).CaseName
						.GetFullRecordName(),
					DateOfCompletion = x.Additive.DateOfCompletion,
					AreaOfLCBOrMDF = x.Additive.AreaOfLCBOrMDF
				},
				Milling = new() {
					PlannedDate = x.Milling.PlannedDate,
					FIO = dbContext.UserInfos.FirstOrDefault(u => u.Id == x.Milling.IdUser).CaseName
						.GetFullRecordName(),
					DateOfCompletion = x.Milling.DateOfCompletion,
					AreaOfMDF = x.Milling.AreaOfMDF
				},
				Grinding = new() {
					PlannedDate = x.Grinding.PlannedDate,
					FIO = dbContext.UserInfos.FirstOrDefault(u => u.Id == x.Grinding.IdUser).CaseName
						.GetFullRecordName(),
					DateOfCompletion = x.Grinding.DateOfCompletion,
					AreaOfMDF = x.Grinding.AreaOfMDF
				},
				Press = new() {
					PlannedDate = x.Press.PlannedDate,
					FIO = dbContext.UserInfos.FirstOrDefault(u => u.Id == x.Press.IdUser).CaseName.GetFullRecordName(),
					DateOfCompletion = x.Press.DateOfCompletion,
					AreaOfLCBOrMDF = x.Press.AreaOfLCBOrMDF
				},
				Assembling = new() {
					PlannedDate = x.Assembling.PlannedDate,
					FIO = dbContext.UserInfos.FirstOrDefault(u => u.Id == x.Assembling.IdUser).CaseName
						.GetFullRecordName(),
					DateOfCompletion = x.Assembling.DateOfCompletion,
					AreaOfLCBOrMDF = x.Assembling.AreaOfLCBOrMDF
				},
				Packing = new() {
					PlannedDate = x.Packing.PlannedDate,
					FIO = dbContext.UserInfos.FirstOrDefault(u => u.Id == x.Packing.IdUser).CaseName
						.GetFullRecordName(),
					DateOfCompletion = x.Packing.DateOfCompletion,
					AreaOfLCBOrMDF = x.Packing.AreaOfLCBOrMDF
				},
				Equipment = new() {
					PlannedDate = x.Equipment.PlannedDate,
					FIO = dbContext.UserInfos.FirstOrDefault(u => u.Id == x.Equipment.IdUser).CaseName
						.GetFullRecordName(),
					DateOfCompletion = x.Equipment.DateOfCompletion,
				},
				Shipment = new() {
					PlannedDate = x.Shipment.PlannedDate,
					FIO = dbContext.UserInfos.FirstOrDefault(u => u.Id == x.Shipment.IdUser).CaseName
						.GetFullRecordName(),
					DateOfCompletion = x.Shipment.DateOfCompletion,
				},
				Note = x.Note,
				Mounting = new() {
					PlannedDate = x.Mounting.PlannedDate,
					IsNeed = x.Mounting.IsNeed
				},
			})
			.ToList();
		SetNewOrders(data);
	}

    void SetNewOrders(IEnumerable<ViewOrder> data) {
		if (!data.Any())
			return;
		
		Orders.Clear();
		var index = 1;
		data.ToList().ForEach(val => {
			val.Id = index++;
			Orders.Add(val);
		});
	}
}
