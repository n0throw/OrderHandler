namespace OrderHandler.UI.Core.FilesExtensions.Excel; 

public record struct ExcelFileInfo(ExcelVersion ExcelVersion, bool FillInfoSheet = false);