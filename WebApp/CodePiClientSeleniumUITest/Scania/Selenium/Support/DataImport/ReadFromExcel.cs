using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace Scania.Selenium.Support.DataImport
{
    public class ReadFromExcel
    {
        public object[,] GetCell(string fileName, int worksheetNumber)
        {
            // ->>>>> int userRow, int userCol
            // Reference to Excel Application.
            Excel.Application xlApp = new Excel.Application();
            string startupPath = System.IO.Directory.GetCurrentDirectory();     
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(Path.GetFullPath(@"TestData\" + fileName));
            Excel.Worksheet xlWorksheet = (Excel.Worksheet)xlWorkbook.Sheets.get_Item(worksheetNumber);

            Excel.Range xlRange = xlWorksheet.UsedRange;

            object[,] valueArray = (object[,])xlRange.get_Value(Excel.XlRangeValueDataType.xlRangeValueDefault);

            // Cleanup
            xlWorkbook.Close(false);
            xlApp.Quit();

            // Manual disposal because of COM
            while (Marshal.ReleaseComObject(xlApp) != 0) { }
            while (Marshal.ReleaseComObject(xlWorkbook) != 0) { }
            while (Marshal.ReleaseComObject(xlRange) != 0) { }

            xlApp = null;
            xlWorkbook = null;
            xlRange = null;

            GC.Collect();
            GC.WaitForPendingFinalizers();

            return valueArray;
        }

    }
}
