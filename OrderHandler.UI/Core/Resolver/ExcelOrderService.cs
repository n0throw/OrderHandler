using System;
using System.Globalization;
using System.Collections.Generic;

using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;

using OrderHandler.DB.Data;

using OrderHandler.UI.Model;
using OrderHandler.UI.Core.Dialog;

namespace OrderHandler.UI.Core.Resolver;

public class ExcelOrderService : IOrderService {
    readonly IDialogService _dialogService;

    public ExcelOrderService(IDialogService dialogService) =>
        _dialogService = dialogService;

    public IEnumerable<Order> Open(string fileName) {
        // Тут нормальный API Excel использовать
        return new List<Order>();
    }

    IWorkbook GetTemplateWorkbook(ExcelVersion excelVersion) {
        // Тут fileStream который в зависимости от версии template выбирает xls или xlxs
        IWorkbook workbook;
        if (excelVersion == ExcelVersion.XSSF)
            workbook = new XSSFWorkbook();
        else
            workbook = new HSSFWorkbook();
        return workbook;
    }

    void FillOrdersData(ISheet sheet, IEnumerable<ViewOrder> orders) {
        var rowCounter = 2;
        foreach (var order in orders) {
            var row = sheet.GetRow(rowCounter);
            var columnCounter = 0;
            rowCounter++;

            void CreateCell(string value) => row.CreateCell(columnCounter++).SetCellValue(value);

            CreateCell(order.OrderMain.Id.ToString());
            CreateCell(order.OrderMain.FIO);
            CreateCell(order.OrderMain.OrderNumber);
            CreateCell(order.OrderMain.OrderDate.ToString("dd.MM.yyyy"));
            CreateCell(order.OrderMain.DeliveryDate.ToString("dd.MM.yyyy"));
            CreateCell(order.OrderMain.Term.ToString());
            CreateCell(order.OrderMain.ProductType);
            CreateCell(order.OrderMain.OrderAmount.ToString(CultureInfo.CurrentCulture));

            CreateCell(order.DocConst.PlannedDate.ToString("dd.MM.yyyy"));
            CreateCell(order.DocConst.FIO);
            CreateCell(order.DocConst.DateOfCompletion.ToString("dd.MM.yyyy"));

            CreateCell(order.DocTech.PlannedDate.ToString("dd.MM.yyyy"));
            CreateCell(order.DocTech.FIO);
            CreateCell(order.DocTech.DateOfCompletion.ToString("dd.MM.yyyy"));

            CreateCell(order.Supply.PlannedDate.ToString("dd.MM.yyyy"));
            CreateCell(order.Supply.FIO);
            CreateCell(order.Supply.DateOfCompletion.ToString("dd.MM.yyyy"));
            CreateCell(order.Supply.RequiredAmount.ToString(CultureInfo.CurrentCulture));

            CreateCell(order.SawCenter.PlannedDate.ToString("dd.MM.yyyy"));
            CreateCell(order.SawCenter.FIO);
            CreateCell(order.SawCenter.DateOfCompletion.ToString("dd.MM.yyyy"));
            CreateCell(order.SawCenter.AreaOfLCBOrMDF.ToString(CultureInfo.CurrentCulture));
            CreateCell(order.SawCenter.AreaOfLHDF.ToString(CultureInfo.CurrentCulture));

            CreateCell(order.Edge.PlannedDate.ToString("dd.MM.yyyy"));
            CreateCell(order.Edge.FIO);
            CreateCell(order.Edge.DateOfCompletion.ToString("dd.MM.yyyy"));
            CreateCell(order.Edge.AreaOfLCBOrMDF.ToString(CultureInfo.CurrentCulture));

            CreateCell(order.Additive.PlannedDate.ToString("dd.MM.yyyy"));
            CreateCell(order.Additive.FIO);
            CreateCell(order.Additive.DateOfCompletion.ToString("dd.MM.yyyy"));
            CreateCell(order.Additive.AreaOfLCBOrMDF.ToString(CultureInfo.CurrentCulture));

            CreateCell(order.Milling.PlannedDate.ToString("dd.MM.yyyy"));
            CreateCell(order.Milling.FIO);
            CreateCell(order.Milling.DateOfCompletion.ToString("dd.MM.yyyy"));
            CreateCell(order.Milling.AreaOfMDF.ToString(CultureInfo.CurrentCulture));

            CreateCell(order.Grinding.PlannedDate.ToString("dd.MM.yyyy"));
            CreateCell(order.Grinding.FIO);
            CreateCell(order.Grinding.DateOfCompletion.ToString("dd.MM.yyyy"));
            CreateCell(order.Grinding.AreaOfMDF.ToString(CultureInfo.CurrentCulture));
            
            CreateCell(order.Press.PlannedDate.ToString("dd.MM.yyyy"));
            CreateCell(order.Press.FIO);
            CreateCell(order.Press.DateOfCompletion.ToString("dd.MM.yyyy"));
            CreateCell(order.Press.AreaOfLCBOrMDF.ToString(CultureInfo.CurrentCulture));

            CreateCell(order.Assembling.PlannedDate.ToString("dd.MM.yyyy"));
            CreateCell(order.Assembling.FIO);
            CreateCell(order.Assembling.DateOfCompletion.ToString("dd.MM.yyyy"));
            CreateCell(order.Assembling.AreaOfLCBOrMDF.ToString(CultureInfo.CurrentCulture));

            CreateCell(order.Packing.PlannedDate.ToString("dd.MM.yyyy"));
            CreateCell(order.Packing.FIO);
            CreateCell(order.Packing.DateOfCompletion.ToString("dd.MM.yyyy"));
            CreateCell(order.Packing.AreaOfLCBOrMDF.ToString(CultureInfo.CurrentCulture));

            CreateCell(order.Equipment.PlannedDate.ToString("dd.MM.yyyy"));
            CreateCell(order.Equipment.FIO);
            CreateCell(order.Equipment.DateOfCompletion.ToString("dd.MM.yyyy"));

            CreateCell(order.Shipment.PlannedDate.ToString("dd.MM.yyyy"));
            CreateCell(order.Shipment.FIO);
            CreateCell(order.Shipment.DateOfCompletion.ToString("dd.MM.yyyy"));

            CreateCell(order.Note);

            if (order.Mounting.IsNeed) {
                CreateCell("Да");
                CreateCell(order.Mounting.PlannedDate.ToString("dd.MM.yyyy"));
            } else
                CreateCell("Нет");
        }
    }
    
    void fillInfoHeader(ISheet sheet) {
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
    
    void fillInfoData(ISheet sheet) {
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
    
    void saveWorkbook(IWorkbook workbook) {
        
    }
    
    public void Save(string fileName, ExcelVersion excelVersion, IEnumerable<ViewOrder> orders, bool fillInfo = false) {
        var workbook = GetTemplateWorkbook(excelVersion);
        
        var sheetOrders = workbook.GetSheet("Список заказов");
        FillOrdersData(sheetOrders, orders);
        if (fillInfo) {
            var sheetInfo = workbook.CreateSheet("Информация");
            fillInfoHeader(sheetInfo);
            fillInfoData(sheetInfo);
        }
        saveWorkbook(workbook);
    }
}
