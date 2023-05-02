using System;
using System.Windows;
using System.Collections.Generic;
using System.IO;

using OrderHandler.UI.Core;
using OrderHandler.UI.Model;
using OrderHandler.UI.Windows;
using OrderHandler.UI.Core.Dialog;

namespace OrderHandler.UI.Contexts.CommandsImpl; 

public class TableOrderManagerCommandsImpl : ITableOrderManagerCommandsImpl {
	readonly IDialogService _dialogService;
	readonly IOrderService _orderService;

	public TableOrderManagerCommandsImpl(IDialogService dialogService, IOrderService orderService) {
		_dialogService = dialogService;
		_orderService = orderService;
		// _dialogService = new DefaultDialogService();
		// _orderService = new ExcelOrderService(_dialogService);
	}
	public List<ViewOrder> UpdateDataCommand() =>
		GetData();

	public void GoBackCommand(Action<string> func) =>
		func.Invoke("MainMenu");

	public void ShowStatusCommand() => 
		_dialogService.ShowMessage("Нет прав");

	public void ExitCommand(Action<string> func) =>
		func.Invoke("Login");

	public void CloseAppCommand() =>
		Application.Current.Shutdown();

	public IEnumerable<ViewOrder> AddNewOrderCommand() {
		AddNewOrder addNewOrderWindow = new();

		return addNewOrderWindow.ShowDialog() == true 
			? GetData() 
			: new();
	}

	public IEnumerable<ViewOrder> MassLoadingOrdersCommand() {
		_dialogService.ShowMessage("Массовая загрузка из Excel не работает с вашей версией MS Office");
		throw new NotImplementedException();
	}

	public void UploadToExcelData(IEnumerable<ViewOrder> data) {
		if (_dialogService.SaveFileDialog($"Данные заказов от {DateTime.Now:dd.MM.yyyy HH.mm.ss}"))
			_orderService.Save(_dialogService.FilePath, data);
	}

	public void UploadTemplateExcel() {
		string? filePath = Utilities.GetTempExcelPath();

		if (filePath is null) {
			_dialogService.ShowMessage("Отсутствует файл шаблона. Обратитесь к администратору!");
			return;
		}

		if (_dialogService.SaveFileDialog("Шаблон Excel"))
			File.Copy(filePath, _dialogService.FilePath);
	}

	public void ShowCountOrders(int count) =>
		_dialogService.ShowMessage($"Количество заказов: {count}");
	
	List<ViewOrder> GetData() {
		throw new NotImplementedException();
	}
}