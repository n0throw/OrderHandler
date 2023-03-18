using System;
using System.IO;

namespace OrderHandler.UI.Core;

public static class Utilities {
    public static string? GetTempExcelPath() {
        string exePath = AppDomain.CurrentDomain.BaseDirectory;
        string filePath = Path.Combine(exePath, "Doc\\ExcelTemp.xlsx");

        if (!File.Exists(filePath))
            return null;
        return filePath;
    }

    public static bool CheckRole(TableSectionNames tableSection, string roleName) =>
        true;
}
