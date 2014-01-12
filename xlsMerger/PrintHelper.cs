using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

namespace XlsMerger
{
    class PrintHelper
    {

        public void PrintMyExcelFile()
        {
            Application excelApp = new Application();

            // Open the Workbook:
            Workbook wb = excelApp.Workbooks.Open(
                Program.printTemplateRuku,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing);

            // Get the first worksheet.
            // (Excel uses base 1 indexing, not base 0.)
            Worksheet ws = (Worksheet)wb.Worksheets[1];

            // Print out 1 copy to the default printer:
            ws.PrintOut(
                Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            

            // Cleanup:
            GC.Collect();
            GC.WaitForPendingFinalizers();

            Marshal.FinalReleaseComObject(ws);

            wb.Close(false, Type.Missing, Type.Missing);
            Marshal.FinalReleaseComObject(wb);

            excelApp.Quit();
            Marshal.FinalReleaseComObject(excelApp);
        }
    }
}
