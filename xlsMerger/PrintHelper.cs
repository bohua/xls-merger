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
		private int page_num_page_size;
		private int page_num_interval;
		private int page_num_meta_headers;
		private int page_num_meta_foots;
		private int page_num_meta_rows;
		private int page_num_total_rows;
		private int page_num_total_rows_withinterval;
		private int row_data_height = 18;
		private int row_title_height = 30;

		public PrintHelper(IniFile ini) {
			//Initialize page settings
			if (!ini.KeyExists("page_num_page_size", "PrintLayout")) { ini.Write("page_num_page_size", @"16", "PrintLayout"); }
			if (!ini.KeyExists("page_num_interval", "PrintLayout")) { ini.Write("page_num_interval", @"4", "PrintLayout"); }
			if (!ini.KeyExists("page_num_meta_headers", "PrintLayout")) { ini.Write("page_num_meta_headers", @"6", "PrintLayout"); }
			if (!ini.KeyExists("page_num_meta_foots", "PrintLayout")) { ini.Write("page_num_meta_foots", @"3", "PrintLayout"); }

			this.page_num_page_size = int.Parse(ini.Read("page_num_page_size", "PrintLayout"));
			this.page_num_interval = int.Parse(ini.Read("page_num_interval", "PrintLayout"));
			this.page_num_meta_headers = int.Parse(ini.Read("page_num_meta_headers", "PrintLayout"));
			this.page_num_meta_foots = int.Parse(ini.Read("page_num_meta_foots", "PrintLayout"));
			this.page_num_meta_rows = page_num_meta_headers + page_num_meta_foots;
			this.page_num_total_rows = page_num_meta_rows + page_num_page_size;
			this.page_num_total_rows_withinterval = page_num_total_rows + page_num_interval;
		}

		private void generatePrintTempalte(string type) {
            string srcFilePath;
            string tmpFilePath;
            if (type == "ruku") {
                srcFilePath = Program.printTemplateRukuSrc;
                tmpFilePath = Program.printTemplateRuku;
            }else{
                srcFilePath = Program.printTemplateChukuSrc;
                tmpFilePath = Program.printTemplateChuku;
            }


            FileStream fs = new FileStream(srcFilePath, FileMode.Open, FileAccess.Read);
			HSSFWorkbook workbook = new HSSFWorkbook(fs);
			fs.Close();

			//插入行数
			for (int i = 1; i < page_num_page_size; i++)
			{
				CopyRow(workbook, (HSSFSheet)workbook.GetSheetAt(0), page_num_meta_headers, page_num_meta_headers + 1);
			}

			//重置行高
			workbook.GetSheetAt(0).GetRow(0).HeightInPoints = row_title_height;
			for (int i = 1; i < page_num_total_rows; i++)
			{
				workbook.GetSheetAt(0).GetRow(i).HeightInPoints = row_data_height;
			}

			//保存生成新的模板文件
            fs = new FileStream(tmpFilePath, FileMode.Create);
			workbook.Write(fs);
			fs.Close();
		}

		private void generateRukuPrintPage(RukuPrintSheet printSheet, HSSFWorkbook workbook)
		{
			int src, dst;
			int pageSize = page_num_page_size;

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
				for (int i = 0; i < (page_num_page_size + page_num_meta_rows); i++)
				{
					src = i;
					dst = (page_num_total_rows + page_num_interval) * curPage + src;

					CopyRow(workbook, worksheet, src, dst);

					if (src == 0)
					{
						worksheet.GetRow(dst).HeightInPoints = row_title_height;
					}
					else if (src < page_num_total_rows)
					{
						worksheet.GetRow(dst).HeightInPoints = row_data_height;
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

				//填写公司名称
				row = worksheet.GetRow(curPage * (page_num_total_rows + page_num_interval) + 3);
				row.GetCell(2).SetCellValue(printPages[curPage][0].rk_gfmc);

				//填写总金额
				row = worksheet.GetRow(curPage * (page_num_total_rows + page_num_interval) + page_num_total_rows - page_num_meta_foots);
				row.GetCell(6).SetCellValue(Math.Round(js,2).ToString());
				row.GetCell(2).SetCellValue(CurrencyBigNum.NumGetStr(System.Convert.ToDouble(Math.Round(js,2))));

				//填写日期
				row = worksheet.GetRow(curPage * (page_num_total_rows + page_num_interval) + 1);
				row.GetCell(5).SetCellValue(printPages[curPage][0].rk_rq);

				//填写单号
				row = worksheet.GetRow(curPage * (page_num_total_rows + page_num_interval));
				row.GetCell(5).SetCellValue("NO" + printPages[curPage][0].rk_dh);

				//填写发票号
				row = worksheet.GetRow(curPage * (page_num_total_rows + page_num_interval) + 3);
				row.GetCell(5).SetCellValue(printSheet.invNum);

				//填写姓名
				row = worksheet.GetRow(curPage * (page_num_total_rows + page_num_interval) + page_num_total_rows - 1);
				row.GetCell(3).SetCellValue("主管:" + printSheet.masterName);
				row.GetCell(5).SetCellValue("验收:" + printSheet.verifierName);
			}
		}

        private void generateChukuPrintPage(ChukuPrintSheet printSheet, HSSFWorkbook workbook)
        {
            int src, dst;
            int pageSize = page_num_page_size;

            List<List<Chuku>> printPages = new List<List<Chuku>>();
            foreach (ChukuSheet chukuSheet in printSheet.sheetList)
            {
                int totalRecordNum = chukuSheet.getRecords().Count;
                int pages = totalRecordNum % pageSize == 0 ? (totalRecordNum / pageSize) : (totalRecordNum / pageSize + 1);

                for (int i = 0; i < pages; i++)
                {
                    if (i * pageSize + pageSize > chukuSheet.getRecords().Count)
                    {
                        printPages.Add(chukuSheet.getRecords().GetRange(i * pageSize, chukuSheet.getRecords().Count - i * pageSize));
                    }
                    else
                    {
                        printPages.Add(chukuSheet.getRecords().GetRange(i * pageSize, pageSize));
                    }
                }
            }

            HSSFSheet worksheet = (HSSFSheet)workbook.GetSheetAt(0);

            for (int curPage = 1; curPage < printPages.Count; curPage++)
            {
                for (int i = 0; i < (page_num_page_size + page_num_meta_rows); i++)
                {
                    src = i;
                    dst = (page_num_total_rows + page_num_interval) * curPage + src;

                    CopyRow(workbook, worksheet, src, dst);

                    if (src == 0)
                    {
                        worksheet.GetRow(dst).HeightInPoints = row_title_height;
                    }
                    else if (src < page_num_total_rows)
                    {
                        worksheet.GetRow(dst).HeightInPoints = row_data_height;
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
                    row.GetCell(1).SetCellValue(printPages[curPage][i].ck_spmc);
                    row.GetCell(2).SetCellValue(printPages[curPage][i].ck_ggxh);
                    row.GetCell(3).SetCellValue(printPages[curPage][i].ck_dw);
                    row.GetCell(4).SetCellValue(printPages[curPage][i].ck_sl);
                    row.GetCell(5).SetCellValue(printPages[curPage][i].ck_dj);
                    row.GetCell(6).SetCellValue(printPages[curPage][i].ck_je);

                    js += decimal.Parse(printPages[curPage][i].ck_je);
                }

                //填写公司名称
                row = worksheet.GetRow(curPage * (page_num_total_rows + page_num_interval) + 3);
                row.GetCell(2).SetCellValue(printPages[curPage][0].ck_khmc);

                //填写总金额
                row = worksheet.GetRow(curPage * (page_num_total_rows + page_num_interval) + page_num_total_rows - page_num_meta_foots);
                row.GetCell(6).SetCellValue(Math.Round(js, 2).ToString());
                row.GetCell(2).SetCellValue(CurrencyBigNum.NumGetStr(System.Convert.ToDouble(Math.Round(js, 2))));

                //填写日期
                row = worksheet.GetRow(curPage * (page_num_total_rows + page_num_interval) + 1);
                row.GetCell(5).SetCellValue(printPages[curPage][0].ck_rq);

                //填写单号
                row = worksheet.GetRow(curPage * (page_num_total_rows + page_num_interval));
                row.GetCell(5).SetCellValue("NO" + printPages[curPage][0].ck_dh);

                //填写发票号
                row = worksheet.GetRow(curPage * (page_num_total_rows + page_num_interval) + 3);
                row.GetCell(5).SetCellValue(printSheet.invNum);

                //填写姓名
                row = worksheet.GetRow(curPage * (page_num_total_rows + page_num_interval) + page_num_total_rows - 1);
                row.GetCell(3).SetCellValue("主管:" + printSheet.masterName);
                row.GetCell(5).SetCellValue("验收:" + printSheet.verifierName);
            }
        }

        #region 公共接口

        public void generatePrintDoc(RukuPrintSheet printSheet)
        {
            generatePrintTempalte("ruku");

            FileStream fs = new FileStream(Program.printTemplateRuku, FileMode.Open, FileAccess.ReadWrite);
            HSSFWorkbook workbook = new HSSFWorkbook(fs);
            fs.Close();

            generateRukuPrintPage(printSheet, workbook);

            fs = new FileStream(Program.printDoc, FileMode.Create);
            workbook.Write(fs);
            fs.Close();
        }

        public void generatePrintDoc(ChukuPrintSheet printSheet)
        {
            generatePrintTempalte("chuku");

            FileStream fs = new FileStream(Program.printTemplateChuku, FileMode.Open, FileAccess.ReadWrite);
            HSSFWorkbook workbook = new HSSFWorkbook(fs);
            fs.Close();

            generateChukuPrintPage(printSheet, workbook);

            fs = new FileStream(Program.printDoc, FileMode.Create);
            workbook.Write(fs);
            fs.Close();
        }

		public void PrintMyExcelFile()
		{

			Application excelApp = new Application();
			//Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

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

        public void ExportMyExcelFileAsXls(string path) {
            File.Copy(Program.printDoc, path, true);        
        }

        #endregion

        #region LibFunc

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

        #endregion

    }
}
