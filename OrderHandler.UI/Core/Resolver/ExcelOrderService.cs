using Microsoft.Office.Interop.Excel;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using OrderHandler.DB.Data;
using OrderHandler.UI.Core.Dialog;
using OrderHandler.UI.Model;

namespace OrderHandler.UI.Core.Resolver;

public class ExcelOrderService : IOrderService {
    private readonly IDialogService dialogService;

    public ExcelOrderService(IDialogService dialogService) =>
        this.dialogService = dialogService;

    public IEnumerable<Order> Open(string fileName) {
        // Тут нормальный API Excel использовать
        return new List<Order>();
    }

    public void Save(string fileName, IEnumerable<ViewOrder> orders) {
        // Тут нормальный API Excel использовать
        string? filePath = Utilities.GetTempExcelPath();

        if (filePath is null) {
            dialogService.ShowMessage("Отсутствует файл шаблона. Обратитесь к администратору!");
            return;
        }

        Application app = new() {
            Visible = false,
            SheetsInNewWorkbook = 1
        };

        app.Workbooks.Open(filePath);

        Worksheet sheet = (Worksheet)app.Worksheets.get_Item(1);

        int x, y = 2;
        foreach (ViewOrder order in orders) {
            x = 0;
            y++;

            sheet.Cells[y, ++x] = order.ViewOrderMain.Number;
            sheet.Cells[y, ++x] = order.ViewOrderMain.UserName;
            sheet.Cells[y, ++x] = order.ViewOrderMain.OrderIssue;
            sheet.Cells[y, ++x] = order.ViewOrderMain.OrderDate.ToString("dd.MM.yyyy");
            sheet.Cells[y, ++x] = order.ViewOrderMain.DeliveryDate.ToString("dd.MM.yyyy");
            sheet.Cells[y, ++x] = order.ViewOrderMain.NumberOfDays;
            sheet.Cells[y, ++x] = order.ViewOrderMain.ProductType;
            sheet.Cells[y, ++x] = order.ViewOrderMain.ProductCost;

            sheet.Cells[y, ++x] = order.DocConstructor.PlannedDate.ToString("dd.MM.yyyy");
            sheet.Cells[y, ++x] = order.DocConstructor.UserName;
            sheet.Cells[y, ++x] = order.DocConstructor.Date.ToString("dd.MM.yyyy");

            sheet.Cells[y, ++x] = order.DocTechnologist.PlannedDate.ToString("dd.MM.yyyy");
            sheet.Cells[y, ++x] = order.DocTechnologist.UserName;
            sheet.Cells[y, ++x] = order.DocTechnologist.Date.ToString("dd.MM.yyyy");

            sheet.Cells[y, ++x] = order.Supply.Status.PlannedDate.ToString("dd.MM.yyyy");
            sheet.Cells[y, ++x] = order.Supply.Status.UserName;
            sheet.Cells[y, ++x] = order.Supply.Status.Date.ToString("dd.MM.yyyy");
            sheet.Cells[y, ++x] = order.Supply.Cost;

            sheet.Cells[y, ++x] = order.SawCenter.Status.PlannedDate.ToString("dd.MM.yyyy");
            sheet.Cells[y, ++x] = order.SawCenter.Status.UserName;
            sheet.Cells[y, ++x] = order.SawCenter.Status.Date.ToString("dd.MM.yyyy");
            sheet.Cells[y, ++x] = order.SawCenter.ChipboardOrMDF;
            sheet.Cells[y, ++x] = order.SawCenter.HDF;

            sheet.Cells[y, ++x] = order.Edge.Status.PlannedDate.ToString("dd.MM.yyyy");
            sheet.Cells[y, ++x] = order.Edge.Status.UserName;
            sheet.Cells[y, ++x] = order.Edge.Status.Date.ToString("dd.MM.yyyy");
            sheet.Cells[y, ++x] = order.Edge.ChipboardOrMDF;

            sheet.Cells[y, ++x] = order.Additive.Status.PlannedDate.ToString("dd.MM.yyyy");
            sheet.Cells[y, ++x] = order.Additive.Status.UserName;
            sheet.Cells[y, ++x] = order.Additive.Status.Date.ToString("dd.MM.yyyy");
            sheet.Cells[y, ++x] = order.Additive.ChipboardOrMDF;

            sheet.Cells[y, ++x] = order.Milling.Status.PlannedDate.ToString("dd.MM.yyyy");
            sheet.Cells[y, ++x] = order.Milling.Status.UserName;
            sheet.Cells[y, ++x] = order.Milling.Status.Date.ToString("dd.MM.yyyy");
            sheet.Cells[y, ++x] = order.Milling.MDF;

            sheet.Cells[y, ++x] = order.Grinding.Status.PlannedDate.ToString("dd.MM.yyyy");
            sheet.Cells[y, ++x] = order.Grinding.Status.UserName;
            sheet.Cells[y, ++x] = order.Grinding.Status.Date.ToString("dd.MM.yyyy");
            sheet.Cells[y, ++x] = order.Grinding.MDF;


            sheet.Cells[y, ++x] = order.Press.Status.PlannedDate.ToString("dd.MM.yyyy");
            sheet.Cells[y, ++x] = order.Press.Status.UserName;
            sheet.Cells[y, ++x] = order.Press.Status.Date.ToString("dd.MM.yyyy");
            sheet.Cells[y, ++x] = order.Press.MDF;

            sheet.Cells[y, ++x] = order.Assembling.Status.PlannedDate.ToString("dd.MM.yyyy");
            sheet.Cells[y, ++x] = order.Assembling.Status.UserName;
            sheet.Cells[y, ++x] = order.Assembling.Status.Date.ToString("dd.MM.yyyy");
            sheet.Cells[y, ++x] = order.Assembling.ChipboardOrMDF;

            sheet.Cells[y, ++x] = order.Packing.Status.PlannedDate.ToString("dd.MM.yyyy");
            sheet.Cells[y, ++x] = order.Packing.Status.UserName;
            sheet.Cells[y, ++x] = order.Packing.Status.Date.ToString("dd.MM.yyyy");
            sheet.Cells[y, ++x] = order.Packing.ChipboardOrMDF;

            sheet.Cells[y, ++x] = order.Equipment.PlannedDate.ToString("dd.MM.yyyy");
            sheet.Cells[y, ++x] = order.Equipment.UserName;
            sheet.Cells[y, ++x] = order.Equipment.Date.ToString("dd.MM.yyyy");

            sheet.Cells[y, ++x] = order.Shipment.PlannedDate.ToString("dd.MM.yyyy");
            sheet.Cells[y, ++x] = order.Shipment.UserName;
            sheet.Cells[y, ++x] = order.Shipment.Date.ToString("dd.MM.yyyy");

            sheet.Cells[y, ++x] = order.Note;

            if (order.Mounting.IsMounting) {
                sheet.Cells[y, ++x] = "Да";
                sheet.Cells[y, ++x] = order.Mounting.Date.ToString("dd.MM.yyyy");
            } else
                sheet.Cells[y, ++x] = "Нет";
        }

        app.ActiveWorkbook.SaveAs(fileName);
        app.Quit();
        Marshal.ReleaseComObject(app);
    }
}
