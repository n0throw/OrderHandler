using System;
using System.Windows;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using OrderHandler.DB;
using OrderHandler.UI.Core;
using OrderHandler.UI.Core.FilesExtensions.Excel;
using OrderHandler.UI.Core.Service.Dialog;
using OrderHandler.UI.Core.Service.File;
using OrderHandler.UI.Model;
using OrderHandler.UI.Windows;

namespace OrderHandler.UI.Contexts.CommandsImpl; 

public class TableOrderManagerCommandsImpl : ITableOrderManagerCommandsImpl {
	readonly IDialogService _dialogService;
	readonly IFileService<ViewOrder, ExcelFileInfo> _excelFileService;

	public TableOrderManagerCommandsImpl(IDialogService dialogService, IFileService<ViewOrder, ExcelFileInfo> excelFileService) {
		_dialogService = dialogService;
		_excelFileService = excelFileService;
		// _dialogService = new DefaultDialogService();
		// _orderService = new ExcelOrderService(_dialogService);
	}
	public List<ViewOrder> UpdateDataCommand() =>
		GetData();

	public void GoBackCommand(Action<string> func) =>
		func.Invoke("MainMenu");

	public void ShowStatusCommand() => 
		_dialogService.ShowMessage("Нет прав", DialogLevel.Warning);

	public void ExitCommand(Action<string> func) =>
		func.Invoke("Login");

	public void CloseAppCommand() =>
		Application.Current.Shutdown();

	public IEnumerable<ViewOrder> AddNewOrderCommand() {
		NewOrder addNewOrderWindow = new();

		return addNewOrderWindow.ShowDialog() == true 
			? GetData() 
			: new();
	}

	public IEnumerable<ViewOrder> MassLoadingOrdersCommand() {
		_dialogService.ShowMessage("Массовая загрузка из Excel не работает с вашей версией MS Office", DialogLevel.Error);
		throw new NotImplementedException();
	}

	public void UploadToExcelData(IEnumerable<ViewOrder> data) {
		// todo Тут окно, в котором заполняется ExcelFileInfo. Данные должны запоминаться и храниться в БД, а так же в сессии для каждого клиента
		string? filePath = _dialogService.SaveFileDialog(
			"Сохранение",
			$"Данные заказов от {DateTime.Now:dd.MM.yyyy HH.mm.ss}",
			".xlsx", 
			new List<string> {
				"Excel (.xlsx)|*.xlsx", 
				"Старый Excel (.xls)|*.xls"
			}
		);
		if (filePath is not null)
			_excelFileService.Save(filePath, data, new(ExcelVersion.XSSF, true));
	}

	public void UploadTemplateExcel() {
		// todo Тут выбор скачивать старый или новый шаблон, в зависимости от того, что юзер выбрал
		string? templateFilePath = Utilities.GetTempExcelPath();

		if (templateFilePath is null) {
			_dialogService.ShowMessage(
				"Отсутствует файл шаблона. Обратитесь к администратору!", 
				DialogLevel.Error
			);
			return;
		}
		string? filePath = _dialogService.SaveFileDialog(
			"Сохранение",
			$"Excel шаблон данных заказов",
			".xlsx", 
			new List<string> {
				"Excel (.xlsx)|*.xlsx", 
				"Старый Excel (.xls)|*.xls"
			}
		);
		if (filePath is not null)
			File.Copy(templateFilePath, filePath);
	}

	public void ShowCountOrders(int count) =>
		_dialogService.ShowMessage($"Количество заказов: {count}", DialogLevel.Information);
	
	List<ViewOrder> GetData() {
		using Context dbContext = new();
		return dbContext.OrderInfos
				.Select(x => new ViewOrder() {
					IdDb = x.Id,
					OrderMain = new() {
						OrderNumber = x.OrderMain.OrderNumber,
						IdUser = x.OrderMain.IdUser, 
						FIO = dbContext.UserInfos.FirstOrDefault(u => u.Id == x.OrderMain.IdUser).CaseName.GetFullRecordName(),
						OrderDate = x.OrderMain.OrderDate,
						DeliveryDate = x.OrderMain.DeliveryDate,
						Term = (int)x.OrderMain.Term,
						ProductType = x.OrderMain.ProductType,
						OrderAmount = x.OrderMain.OrderAmount,
					},
					DocConst = new() {
						PlannedDate = x.DocConst.PlannedDate,
						FIO = dbContext.UserInfos.FirstOrDefault(u => u.Id == x.DocConst.IdUser).CaseName.GetFullRecordName(),
						DateOfCompletion = x.DocConst.DateOfCompletion
					},
					DocTech = new() {
						PlannedDate = x.DocTech.PlannedDate,
						FIO = dbContext.UserInfos.FirstOrDefault(u => u.Id == x.DocTech.IdUser).CaseName.GetFullRecordName(),
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
						FIO = dbContext.UserInfos.FirstOrDefault(u => u.Id == x.SawCenter.IdUser).CaseName.GetFullRecordName(),
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
						FIO = dbContext.UserInfos.FirstOrDefault(u => u.Id == x.Additive.IdUser).CaseName.GetFullRecordName(),
						DateOfCompletion = x.Additive.DateOfCompletion,
						AreaOfLCBOrMDF = x.Additive.AreaOfLCBOrMDF
					},
					Milling = new() {
						PlannedDate = x.Milling.PlannedDate,
						FIO = dbContext.UserInfos.FirstOrDefault(u => u.Id == x.Milling.IdUser).CaseName.GetFullRecordName(),
						DateOfCompletion = x.Milling.DateOfCompletion,
						AreaOfMDF = x.Milling.AreaOfMDF
					},
					Grinding = new() {
						PlannedDate = x.Grinding.PlannedDate,
						FIO = dbContext.UserInfos.FirstOrDefault(u => u.Id == x.Grinding.IdUser).CaseName.GetFullRecordName(),
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
						FIO = dbContext.UserInfos.FirstOrDefault(u => u.Id == x.Assembling.IdUser).CaseName.GetFullRecordName(),
						DateOfCompletion = x.Assembling.DateOfCompletion,
						AreaOfLCBOrMDF = x.Assembling.AreaOfLCBOrMDF
					},
					Packing = new() {
						PlannedDate = x.Packing.PlannedDate,
						FIO = dbContext.UserInfos.FirstOrDefault(u => u.Id == x.Packing.IdUser).CaseName.GetFullRecordName(),
						DateOfCompletion = x.Packing.DateOfCompletion,
						AreaOfLCBOrMDF = x.Packing.AreaOfLCBOrMDF
					},
					Equipment = new() {
						PlannedDate = x.Equipment.PlannedDate,
						FIO = dbContext.UserInfos.FirstOrDefault(u => u.Id == x.Equipment.IdUser).CaseName.GetFullRecordName(),
						DateOfCompletion = x.Equipment.DateOfCompletion,
					},
					Shipment = new() {
						PlannedDate = x.Shipment.PlannedDate,
						FIO = dbContext.UserInfos.FirstOrDefault(u => u.Id == x.Shipment.IdUser).CaseName.GetFullRecordName(),
						DateOfCompletion = x.Shipment.DateOfCompletion,
					},
					Note = x.Note,
					Mounting = new() {
						PlannedDate = x.Mounting.PlannedDate,
						IsNeed = x.Mounting.IsNeed
					},
				}).ToList();
	}
}