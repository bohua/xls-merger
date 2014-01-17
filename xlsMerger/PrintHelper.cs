using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using System.Threading;     // For setting the Localization of the thread to fit
using System.Globalization; // the of the MS Excel localization, because of the MS bug
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using System.IO;

namespace XlsMerger
{
	class PrintHelper
	{
		private List<string> printDocs = new List<string>();

		public void generatePrintDoc(RukuPrintSheet printSheet)
		{
			FileStream fs = new FileStream(Program.printTemplateRuku, FileMode.Open, FileAccess.ReadWrite);
			HSSFWorkbook workbook = new HSSFWorkbook(fs);
			fs.Close();

			CopyRow(workbook, (HSSFSheet)workbook.GetSheetAt(0), 0, 17);

			fs = new FileStream(Program.printTemplateRuku, FileMode.Create);

			// save the changes
			workbook.Write(fs);
			fs.Close();
		}

		public void PrintMyExcelFile(RukuPrintSheet printSheet)
		{


			Application excelApp = new Application();
			Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

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

		/// <summary>
		/// HSSFRow Copy Command
		///
		/// Description:  Inserts a existing row into a new row, will automatically push down
		///               any existing rows.  Copy is done cell by cell and supports, and the
		///               command tries to copy all properties available (style, merged cells, values, etc...)
		/// </summary>
		/// <param name="workbook">Workbook containing the worksheet that will be changed</param>
		/// <param name="worksheet">WorkSheet containing rows to be copied</param>
		/// <param name="sourceRowNum">Source Row Number</param>
		/// <param name="destinationRowNum">Destination Row Number</param>
		private void CopyRow(HSSFWorkbook workbook, HSSFSheet worksheet, int sourceRowNum, int destinationRowNum)
		{
			// Get the source / new row
			IRow newRow = worksheet.GetRow(destinationRowNum);
			IRow sourceRow = worksheet.GetRow(sourceRowNum);

			// If the row exist in destination, push down all rows by 1 else create a new row
			if (newRow != null)
			{
				worksheet.ShiftRows(destinationRowNum, worksheet.LastRowNum, 1);
			}
			else
			{
				newRow = worksheet.CreateRow(destinationRowNum);
			}

			// Loop through source columns to add to new row
			for (int i = 0; i < sourceRow.LastCellNum; i++)
			{
				// Grab a copy of the old/new cell
				ICell oldCell = sourceRow.GetCell(i);
				ICell newCell = newRow.CreateCell(i);

				// If the old cell is null jump to next cell
				if (oldCell == null)
				{
					newCell = null;
					continue;
				}

				// Copy style from old cell and apply to new cell
				ICellStyle newCellStyle = workbook.CreateCellStyle();
				newCellStyle.CloneStyleFrom(oldCell.CellStyle); ;
				newCell.CellStyle = newCellStyle;

				// If there is a cell comment, copy
				if (newCell.CellComment != null) newCell.CellComment = oldCell.CellComment;

				// If there is a cell hyperlink, copy
				if (oldCell.Hyperlink != null) newCell.Hyperlink = oldCell.Hyperlink;

				// Set the cell data type
				newCell.SetCellType(oldCell.CellType);

				// Set the cell data value
				switch (oldCell.CellType)
				{
					case CellType.BLANK:
						newCell.SetCellValue(oldCell.StringCellValue);
						break;
					case CellType.BOOLEAN:
						newCell.SetCellValue(oldCell.BooleanCellValue);
						break;
					case CellType.ERROR:
						newCell.SetCellErrorValue(oldCell.ErrorCellValue);
						break;
					case CellType.FORMULA:
						newCell.SetCellFormula(oldCell.CellFormula);
						break;
					case CellType.NUMERIC:
						newCell.SetCellValue(oldCell.NumericCellValue);
						break;
					case CellType.STRING:
						newCell.SetCellValue(oldCell.RichStringCellValue);
						break;
					case CellType.Unknown:
						newCell.SetCellValue(oldCell.StringCellValue);
						break;
				}
			}

			// If there are are any merged regions in the source row, copy to new row
			for (int i = 0; i < worksheet.NumMergedRegions; i++)
			{
				CellRangeAddress cellRangeAddress = worksheet.GetMergedRegion(i);
				if (cellRangeAddress.FirstRow == sourceRow.RowNum)
				{
					CellRangeAddress newCellRangeAddress = new CellRangeAddress(newRow.RowNum,
																				(newRow.RowNum +
																				 (cellRangeAddress.FirstRow -
																				  cellRangeAddress.LastRow)),
																				cellRangeAddress.FirstColumn,
																				cellRangeAddress.LastColumn);
					worksheet.AddMergedRegion(newCellRangeAddress);
				}
			}

		}

	}
}
