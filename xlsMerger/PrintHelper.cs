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
		private const int page_num_interval = 1;
		private const int page_num_meta_headers = 6;
		private const int page_num_meta_foots = 3;
		private const int page_num_meta_rows = page_num_meta_headers + page_num_meta_foots;
		private const int page_num_total_rows = 21;


		public void generatePrintDoc(RukuPrintSheet printSheet)
		{
			FileStream fs = new FileStream(Program.printTemplateRuku, FileMode.Open, FileAccess.ReadWrite);
			HSSFWorkbook workbook = new HSSFWorkbook(fs);
			fs.Close();

			generatePrintPage(printSheet, workbook);

			fs = new FileStream(Program.printDoc, FileMode.Create);

			// save the changes
			workbook.Write(fs);
			fs.Close();

			PrintMyExcelFile(printSheet);
		}



		private void generatePrintPage(RukuPrintSheet printSheet, HSSFWorkbook workbook)
		{
			int src, dst;
			int pageSize = printSheet.getPageSize();

			List<List<Ruku>> printPages = new List<List<Ruku>>();
			foreach (RukuSheet rukuSheet in printSheet.sheetList)
			{
				int totalRecordNum = rukuSheet.getRecords().Count;
				int pages = totalRecordNum % pageSize == 0 ? (totalRecordNum / pageSize) : (totalRecordNum / pageSize + 1);

				for (int i = 0; i < pages; i++)
				{
					if (i * pageSize + pageSize > rukuSheet.getRecords().Count)
					{
						printPages.Add(rukuSheet.getRecords().GetRange(i * pageSize, rukuSheet.getRecords().Count - i * pageSize));
					}
					else
					{
						printPages.Add(rukuSheet.getRecords().GetRange(i * pageSize, pageSize));
					}
				}
			}

			HSSFSheet worksheet = (HSSFSheet)workbook.GetSheetAt(0);

			for (int curPage = 1; curPage < printPages.Count; curPage++)
			{
				for (int i = 0; i < (printSheet.getPageSize() + page_num_meta_rows); i++)
				{
					src = i;
					dst = (printSheet.getPageSize() + page_num_meta_rows + page_num_interval) * curPage + src;

					CopyRow(workbook, worksheet, src, dst);

					if (src == 0)
					{
						worksheet.GetRow(dst).HeightInPoints = 30;
					}
					else if (src < 21)
					{
						worksheet.GetRow(dst).HeightInPoints = 18;
					}
				}

				if (curPage > 1 && curPage % 2 == 0)
				{
					worksheet.SetRowBreak((page_num_total_rows + page_num_interval) * curPage - 1);
				}
			}

			for (int curPage = 0; curPage < printPages.Count; curPage++)
			{
				IRow row;
				decimal js = 0m;

				for (int i = 0; i < printPages[curPage].Count; i++)
				{
					row = worksheet.GetRow(curPage * (page_num_total_rows + page_num_interval) + page_num_meta_headers + i);
					row.GetCell(0).SetCellValue(i + 1);
					row.GetCell(1).SetCellValue(printPages[curPage][i].rk_wzmc);
					row.GetCell(2).SetCellValue(printPages[curPage][i].rk_ggxh);
					row.GetCell(3).SetCellValue(printPages[curPage][i].rk_dw);
					row.GetCell(4).SetCellValue(printPages[curPage][i].rk_jhsl);
					row.GetCell(5).SetCellValue(printPages[curPage][i].rk_jhdj);
					row.GetCell(6).SetCellValue(printPages[curPage][i].rk_jhje);

					js += decimal.Parse(printPages[curPage][i].rk_jhje);
				}

				//填写总金额
				row = worksheet.GetRow(curPage * (page_num_total_rows + page_num_interval) + page_num_total_rows - page_num_meta_foots);
				row.GetCell(6).SetCellValue(Math.Round(js,2).ToString());
				row.GetCell(2).SetCellValue(CurrencyBigNum.NumGetStr(System.Convert.ToDouble(Math.Round(js,2))));

				//填写日期
				row = worksheet.GetRow(curPage * (page_num_total_rows + page_num_interval) + 1);
				row.GetCell(6).SetCellValue(printPages[curPage][0].rk_rq);

				//填写单号
				row = worksheet.GetRow(curPage * (page_num_total_rows + page_num_interval));
				row.GetCell(6).SetCellValue("N" + printPages[curPage][0].rk_dh);

				//填写发票号
				row = worksheet.GetRow(curPage * (page_num_total_rows + page_num_interval) + 3);
				row.GetCell(5).SetCellValue(printSheet.invNum);

				//填写姓名
				row = worksheet.GetRow(curPage * (page_num_total_rows + page_num_interval) + page_num_total_rows - 1);
				row.GetCell(4).SetCellValue("主管:" + printSheet.masterName);
				row.GetCell(5).SetCellValue("验收:" + printSheet.verifierName);
			}
		}

		public void PrintMyExcelFile(RukuPrintSheet printSheet)
		{
			Application excelApp = new Application();
			Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

			// Open the Workbook:
			Workbook wb = excelApp.Workbooks.Open(
				Program.printDoc,
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
					case CellType.Blank:
						newCell.SetCellValue(oldCell.StringCellValue);
						break;
					case CellType.Boolean:
						newCell.SetCellValue(oldCell.BooleanCellValue);
						break;
					case CellType.Error:
						newCell.SetCellErrorValue(oldCell.ErrorCellValue);
						break;
					case CellType.Formula:
						newCell.SetCellFormula(oldCell.CellFormula);
						break;
					case CellType.Numeric:
						newCell.SetCellValue(oldCell.NumericCellValue);
						break;
					case CellType.String:
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
