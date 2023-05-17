namespace OrderHandler.UI.Core;

record TableColumnInfo {
	public TableSectionNames TableSectionName { get; init; } 
	public TableColumnNames TableColumnName { get; init; }

	public TableColumnInfo(TableSectionNames tableSectionName, TableColumnNames tableColumnName) {
		TableSectionName = tableSectionName;
		TableColumnName = tableColumnName;
	}
}