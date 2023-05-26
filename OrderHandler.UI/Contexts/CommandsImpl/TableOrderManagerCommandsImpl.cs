using System;
using System.Windows;
using System.Collections.Generic;
using System.IO;

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
		throw new NotImplementedException();
	}
}