using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderHandler.UI.Core;

internal static class Utilities
{
    internal static string? GetTempExcelPath()
    {
        string exePath = AppDomain.CurrentDomain.BaseDirectory;
        string filePath = Path.Combine(exePath, "Doc\\ExcelTemp.xlsx");

        if (!File.Exists(filePath))
            return null;

        return filePath;
    }

    internal static bool CheckRole(TableSectionNames tableSection, string roleName)
        => true;
}
