using System;
using System.Collections.Generic;

using OrderHandler.UI.Model;

namespace OrderHandler.UI.Contexts.CommandsImpl; 

public interface ITableOrderManagerCommandsImpl {
	// ------------------------------ Меню страницы ------------------------------
	// ---------- Меню ----------
	public List<ViewOrder> UpdateDataCommand();
	public void GoBackCommand(Action<string> func);
	public void ShowStatusCommand();
	public void ExitCommand(Action<string> func);
	public void CloseAppCommand();
	// ---------- Утилиты ----------
	public IEnumerable<ViewOrder> AddNewOrderCommand();
	public IEnumerable<ViewOrder> MassLoadingOrdersCommand();
	public void UploadToExcelData(IEnumerable<ViewOrder> data);
	public void UploadTemplateExcel();
	public void ShowCountOrders(int count);
	// ---------- Фильтры ----------
	// ------------------------------ Контекстное меню ------------------------------
	
	
}