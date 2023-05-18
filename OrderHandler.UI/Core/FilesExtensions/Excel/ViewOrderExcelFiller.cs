using System.Collections.Generic;
using System.Globalization;

using NPOI.SS.UserModel;

using OrderHandler.UI.Model;
using OrderHandler.UI.Model.ViewOrderAdd;

namespace OrderHandler.UI.Core.FilesExtensions.Excel;

class ViewOrderExcelFiller {
	class RowFiller {
		int _columnCounter;
		readonly IRow _row;
		int ColumnCounter => _columnCounter++;

		internal RowFiller(IRow row) {
			_columnCounter = 0;
			_row = row;
		}
		
		internal void FillRow(ViewOrder order) {
			FillOrderMain(order.OrderMain);
			FillDocConst(order.DocConst);
			FillDocTech(order.DocTech);
			FillSupply(order.Supply);
			FillSawCenter(order.SawCenter);
			FillEdge(order.Edge);
			FillAdditive(order.Additive);
			FillMilling(order.Milling);
			FillGrinding(order.Grinding);
			FillPress(order.Press);
			FillAssembling(order.Assembling);
			FillPacking(order.Packing);
			FillEquipment(order.Equipment);
			FillShipment(order.Shipment);
			CreateCell(order.Note);
			FillMounting(order.Mounting);
			
			_columnCounter = 0;
		}
		
		void FillOrderMain(ViewOrderMain orderMain) {
			CreateCell(orderMain.Id.ToString());
			CreateCell(orderMain.FIO);
			CreateCell(orderMain.OrderNumber);
			CreateCell(orderMain.OrderDate.ToString("dd.MM.yyyy"));
			CreateCell(orderMain.DeliveryDate.ToString("dd.MM.yyyy"));
			CreateCell(orderMain.Term.ToString());
			CreateCell(orderMain.ProductType);
			CreateCell(orderMain.OrderAmount.ToString(CultureInfo.CurrentCulture));
		}

		void FillDocConst(ViewDocConst docConst) {
			CreateCell(docConst.PlannedDate.ToString("dd.MM.yyyy"));
			CreateCell(docConst.FIO);
			CreateCell(docConst.DateOfCompletion.ToString("dd.MM.yyyy"));
		}

		void FillDocTech(ViewDocTech docTech) {
			CreateCell(docTech.PlannedDate.ToString("dd.MM.yyyy"));
			CreateCell(docTech.FIO);
			CreateCell(docTech.DateOfCompletion.ToString("dd.MM.yyyy"));
		}

		void FillSupply(ViewSupply supply) {
			CreateCell(supply.PlannedDate.ToString("dd.MM.yyyy"));
			CreateCell(supply.FIO);
			CreateCell(supply.DateOfCompletion.ToString("dd.MM.yyyy"));
			CreateCell(supply.RequiredAmount.ToString(CultureInfo.CurrentCulture));
		}

		void FillSawCenter(ViewSawCenter sawCenter) {
			CreateCell(sawCenter.PlannedDate.ToString("dd.MM.yyyy"));
			CreateCell(sawCenter.FIO);
			CreateCell(sawCenter.DateOfCompletion.ToString("dd.MM.yyyy"));
			CreateCell(sawCenter.AreaOfLCBOrMDF.ToString(CultureInfo.CurrentCulture));
			CreateCell(sawCenter.AreaOfLHDF.ToString(CultureInfo.CurrentCulture));
		}

		void FillEdge(ViewEdge edge) {
			CreateCell(edge.PlannedDate.ToString("dd.MM.yyyy"));
			CreateCell(edge.FIO);
			CreateCell(edge.DateOfCompletion.ToString("dd.MM.yyyy"));
			CreateCell(edge.AreaOfLCBOrMDF.ToString(CultureInfo.CurrentCulture));
		}

		void FillAdditive(ViewAdditive additive) {
			CreateCell(additive.PlannedDate.ToString("dd.MM.yyyy"));
			CreateCell(additive.FIO);
			CreateCell(additive.DateOfCompletion.ToString("dd.MM.yyyy"));
			CreateCell(additive.AreaOfLCBOrMDF.ToString(CultureInfo.CurrentCulture));
		}
		void FillMilling(ViewMilling milling) {
			CreateCell(milling.PlannedDate.ToString("dd.MM.yyyy"));
			CreateCell(milling.FIO);
			CreateCell(milling.DateOfCompletion.ToString("dd.MM.yyyy"));
			CreateCell(milling.AreaOfMDF.ToString(CultureInfo.CurrentCulture));
		}
		
		void FillGrinding(ViewGrinding grinding) {
			CreateCell(grinding.PlannedDate.ToString("dd.MM.yyyy"));
			CreateCell(grinding.FIO);
			CreateCell(grinding.DateOfCompletion.ToString("dd.MM.yyyy"));
			CreateCell(grinding.AreaOfMDF.ToString(CultureInfo.CurrentCulture));
		}
		
		void FillPress(ViewPress press) {
			CreateCell(press.PlannedDate.ToString("dd.MM.yyyy"));
			CreateCell(press.FIO);
			CreateCell(press.DateOfCompletion.ToString("dd.MM.yyyy"));
			CreateCell(press.AreaOfLCBOrMDF.ToString(CultureInfo.CurrentCulture));
		}
		
		void FillAssembling(ViewAssembling assembling) {
			CreateCell(assembling.PlannedDate.ToString("dd.MM.yyyy"));
			CreateCell(assembling.FIO);
			CreateCell(assembling.DateOfCompletion.ToString("dd.MM.yyyy"));
			CreateCell(assembling.AreaOfLCBOrMDF.ToString(CultureInfo.CurrentCulture));
		}
		
		void FillPacking(ViewPacking packing) {
			CreateCell(packing.PlannedDate.ToString("dd.MM.yyyy"));
			CreateCell(packing.FIO);
			CreateCell(packing.DateOfCompletion.ToString("dd.MM.yyyy"));
			CreateCell(packing.AreaOfLCBOrMDF.ToString(CultureInfo.CurrentCulture));
		}
		
		void FillEquipment(ViewEquipment equipment) {
			CreateCell(equipment.PlannedDate.ToString("dd.MM.yyyy"));
			CreateCell(equipment.FIO);
			CreateCell(equipment.DateOfCompletion.ToString("dd.MM.yyyy"));
		}
		
		void FillShipment(ViewShipment shipment) {
			CreateCell(shipment.PlannedDate.ToString("dd.MM.yyyy"));
			CreateCell(shipment.FIO);
			CreateCell(shipment.DateOfCompletion.ToString("dd.MM.yyyy"));
		}

		void FillMounting(ViewMounting mounting) {
			if (mounting.IsNeed) {
				CreateCell("Да");
				CreateCell(mounting.PlannedDate.ToString("dd.MM.yyyy"));
			} else
				CreateCell("Нет");
		}
		
		void CreateCell(string value) => _row.CreateCell(ColumnCounter).SetCellValue(value);
	}
	
	int _rowCounter;
	readonly int _startRow;
	readonly ISheet _sheet;
	int RowCounter => _rowCounter++;

	internal ViewOrderExcelFiller(ISheet sheet, int startRow) {
		_startRow = startRow;
		_rowCounter = _startRow;
		_sheet = sheet;
	}

	internal void FillOrdersData(IEnumerable<ViewOrder> orders) {
		foreach (var order in orders) 
			new RowFiller(_sheet.GetRow(RowCounter)).FillRow(order);
		_rowCounter = _startRow;
	}
}