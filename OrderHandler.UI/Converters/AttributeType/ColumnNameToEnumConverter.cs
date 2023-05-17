using System;
using System.Globalization;
using System.Windows.Data;

using OrderHandler.UI.Core;

namespace OrderHandler.UI.Converters.AttributeType; 

// TODO
// Тут шляпа
// Нужно сделать адекватный column range template для таблиц
// И уже по нему проверять, а не по наименованию столбца
// А то парсить 20+ столбцов не вариант в виде Enumaration
public class ColumnNameToEnumConverter  : IValueConverter
{
	public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
        if (value is not string columnNameStr)
			return new TableColumnInfo(TableSectionNames.None, TableColumnNames.None);

        if (!Enum.TryParse(columnNameStr, out TableColumnNames columnName))
            return new TableColumnInfo(TableSectionNames.None, TableColumnNames.None);

        TableColumnInfo tableColumnInfo = new(TableSectionNames.None, columnName);
        
        switch (columnName) {
            case TableColumnNames.IdColumn:
            case TableColumnNames.OrderIssueColumn:
            case TableColumnNames.OrderManagerColumn:
            case TableColumnNames.OrderDateColumn:
            case TableColumnNames.DeliveryDateColumn:
            case TableColumnNames.NumberOfDaysColumn:
            case TableColumnNames.ProductTypeColumn:
            case TableColumnNames.ProductCostColumn:
                return tableColumnInfo with { TableSectionName = TableSectionNames.ViewOrderMain };
            case TableColumnNames.DocConstPlannedDateColumn:
            case TableColumnNames.DocConstFIOColumn:
            case TableColumnNames.DocConstDateColumn:
                return tableColumnInfo with { TableSectionName = TableSectionNames.ViewDocConst };
            case TableColumnNames.DocTechPlannedDateColumn:
            case TableColumnNames.DocTechFIOColumn:
            case TableColumnNames.DocTechDateColumn:
                return tableColumnInfo with { TableSectionName = TableSectionNames.ViewDocTech };
            case TableColumnNames.SupplyPlannedDateColumn:
            case TableColumnNames.SupplyFIOColumn:
            case TableColumnNames.SupplyDateColumn:
            case TableColumnNames.SupplyRequiredAmountColumn:
                return tableColumnInfo with { TableSectionName = TableSectionNames.ViewSupply };
            case TableColumnNames.SawCenterPlannedDateColumn:
            case TableColumnNames.SawCenterFIOColumn:
            case TableColumnNames.SawCenterDateColumn:
            case TableColumnNames.SawCenterAreaOfLCBOrMDFColumn:
            case TableColumnNames.SawCenterAreaOfLHDFColumn:
                return tableColumnInfo with { TableSectionName = TableSectionNames.ViewSawCenter };
            case TableColumnNames.EdgePlannedDateColumn:
            case TableColumnNames.EdgeFIOColumn:
            case TableColumnNames.EdgeDateColumn:
            case TableColumnNames.EdgeAreaOfLCBOrMDFColumn:
                return tableColumnInfo with { TableSectionName = TableSectionNames.ViewEdge };
            case TableColumnNames.AdditivePlannedDateColumn:
            case TableColumnNames.AdditiveFIOColumn:
            case TableColumnNames.AdditiveDateColumn:
            case TableColumnNames.AdditiveAreaOfLCBOrMDFColumn:
                return tableColumnInfo with { TableSectionName = TableSectionNames.ViewAdditive };
            case TableColumnNames.MillingPlannedDateColumn:
            case TableColumnNames.MillingFIOColumn:
            case TableColumnNames.MillingDateColumn:
            case TableColumnNames.MillingAreaOfMDFColumn:
                return tableColumnInfo with { TableSectionName = TableSectionNames.ViewMilling };
            case TableColumnNames.GrindingPlannedDateColumn:
            case TableColumnNames.GrindingFIOColumn:
            case TableColumnNames.GrindingDateColumn:
            case TableColumnNames.GrindingAreaOfMDFColumn:
                return tableColumnInfo with { TableSectionName = TableSectionNames.ViewGrinding };
            case TableColumnNames.PressPlannedDateColumn:
            case TableColumnNames.PressFIOColumn:
            case TableColumnNames.PressDateColumn:
            case TableColumnNames.PressAreaOfMDFColumn:
                return tableColumnInfo with { TableSectionName = TableSectionNames.ViewPress };
            case TableColumnNames.AssemblingPlannedDateColumn:
            case TableColumnNames.AssemblingFIOColumn:
            case TableColumnNames.AssemblingDateColumn:
            case TableColumnNames.AssemblingAreaOfLCBOrMDFColumn:
                return tableColumnInfo with { TableSectionName = TableSectionNames.ViewAssembling };
            case TableColumnNames.PackingPlannedDateColumn:
            case TableColumnNames.PackingFIOColumn:
            case TableColumnNames.PackingDateColumn:
            case TableColumnNames.PackingAreaOfLCBOrMDFColumn:
                return tableColumnInfo with { TableSectionName = TableSectionNames.ViewPacking };
            case TableColumnNames.EquipmentPlannedDateColumn:
            case TableColumnNames.EquipmentFIOColumn:
            case TableColumnNames.EquipmentDateColumn:
                return tableColumnInfo with { TableSectionName = TableSectionNames.ViewEquipment };
            case TableColumnNames.ShipmentPlannedDateColumn:
            case TableColumnNames.ShipmentFIOColumn:
            case TableColumnNames.ShipmentDateColumn:
                return tableColumnInfo with { TableSectionName = TableSectionNames.ViewShipment };
            case TableColumnNames.NoteColumn:
                return tableColumnInfo with { TableSectionName = TableSectionNames.Note };
            case TableColumnNames.MountingIsNeedColumn:
            case TableColumnNames.MountingPlannedDateColumn:
                return tableColumnInfo with { TableSectionName = TableSectionNames.ViewMounting };
            case TableColumnNames.None:
            default:
                return tableColumnInfo;
        }
	}

	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
	{
		throw new NotImplementedException();
	}
}