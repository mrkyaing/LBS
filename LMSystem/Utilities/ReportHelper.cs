using OfficeOpenXml.Table;
using OfficeOpenXml;

namespace LMSystem.Utilities
{
    public static class ReportHelper
    {
        public static byte[] ExportToExcel<T>(IList<T> table, string exportFileName)
        {
            using ExcelPackage package = new ExcelPackage();
            ExcelWorksheet worksheet = package.Workbook.Worksheets.Add(exportFileName);
            worksheet.Cells["A1"].LoadFromCollection(table, true, TableStyles.Light1);
            return package.GetAsByteArray();
        }
    }
}
