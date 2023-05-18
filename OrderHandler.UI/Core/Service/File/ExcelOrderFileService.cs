using System;
using System.Collections.Generic;

using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;

using OrderHandler.UI.Model;
using OrderHandler.UI.Core.FilesExtensions.Excel;

namespace OrderHandler.UI.Core.Service.File; 

public class ExcelOrderFileService : IFileService<ViewOrder, ExcelFileInfo> {
	public IEnumerable<ViewOrder> Open(string filePath) => throw new NotImplementedException();

	public void Save(string filePath, IEnumerable<ViewOrder> data, ExcelFileInfo fileInfo) {
		var workbook = GetTemplateWorkbook(fileInfo.ExcelVersion);
		new ViewOrderExcelFiller(workbook.GetSheet("Список заказов"), 2)
			.FillOrdersData(data);
		
		if (fileInfo.FillInfoSheet) {
			var sheetInfo = workbook.CreateSheet("Информация");
			FillInfoHeader(sheetInfo);
			FillInfoData(sheetInfo);
		}
		SaveWorkbook(workbook);
	}
	
	IWorkbook GetTemplateWorkbook(ExcelVersion excelVersion) {
		// Тут fileStream который в зависимости от версии выбирает template XLS или XLXS
		IWorkbook workbook;
		if (excelVersion == ExcelVersion.XSSF)
			workbook = new XSSFWorkbook();
		else
			workbook = new HSSFWorkbook();
		return workbook;
	}

	void FillInfoHeader(ISheet sheet) {
		var cellLockStyle = sheet.Workbook.CreateCellStyle();
		cellLockStyle.IsLocked = true;
        
		var headerRow = sheet.GetRow(0);
		var cellFIO = headerRow.CreateCell(0);
		cellFIO.SetCellValue("ФИО");
		cellFIO.CellStyle = cellLockStyle;
        
		var cellDate = headerRow.CreateCell(1);
		cellDate.SetCellValue("Дата");
		cellDate.CellStyle = cellLockStyle;
	}
    
	void FillInfoData(ISheet sheet) {
		var cellLockStyle = sheet.Workbook.CreateCellStyle();
		cellLockStyle.IsLocked = true;
        
		var dataRow = sheet.GetRow(1);
		var cellFIO = dataRow.CreateCell(0);
		cellFIO.SetCellValue("Юзер");
		cellFIO.CellStyle = cellLockStyle;
        
		var cellDate = dataRow.CreateCell(1);
		cellDate.SetCellValue(DateTime.Now);
		cellDate.CellStyle = cellLockStyle;
	}
	
	void SaveWorkbook(IWorkbook workbook) {
        
	}
}