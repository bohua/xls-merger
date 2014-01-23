using System;
using System.IO;
using System.Data;
using System.Collections.Generic;
using System.Text;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;

namespace XlsMerger
{
	class RukuSheetReader
	{
		private List<RukuSheet> importedRukuSheets = new List<RukuSheet>();
		private DataTable myDt = new DataTable();
		private string[] headers = { "进货单日期", "进货单号", "供方名称", "物资名称", "规格型号", "单位", "进货单价", "进货数量", "销售价", "折扣", "进货金额", "备注" };

		private void headerCreator(System.Collections.IEnumerator rows)
		{
			if (myDt.Columns.Count == 0)
			{
				if (rows == null)
				{
					for (int j = 0; j < headers.Length; j++)
					{
						DataColumn col = myDt.Columns.Add(headers[j]);
					}
				}
				else
				{
					IRow headerRow = (HSSFRow)rows.Current;
					for (int j = 0; j < headerRow.LastCellNum; j++)
					{
						ICell header = headerRow.GetCell(j);
						DataColumn col = myDt.Columns.Add(header.ToString().Trim());
					}
				}
			}
		}

		private void readSheetFile(FileStream file, string filePath)
		{
			IWorkbook myWorkbook = new HSSFWorkbook(file);

			ISheet sheet = myWorkbook.GetSheetAt(0);
			System.Collections.IEnumerator rows = sheet.GetRowEnumerator();

			rows.MoveNext();
			headerCreator(rows);

			RukuSheet rukuSheet = new RukuSheet();

			while (rows.MoveNext())
			{
				IRow row = (HSSFRow)rows.Current;
				Ruku entity = new Ruku();
				ICell cell;

				//进货单日期
				cell = row.GetCell(0);
				if (cell != null)
				{
					try
					{
						DateTime dt = cell.DateCellValue;
						entity.rk_rq = dt.Date.ToString("yyyy-MM-dd");
					}
					catch (Exception ex)
					{
						entity.rk_rq = cell.ToString().Trim();
					}
				}
				//进货单号
				cell = row.GetCell(1);
				if (cell != null)
				{
					entity.rk_dh = cell.ToString().Trim();
				}
				//供方名称
				cell = row.GetCell(2);
				if (cell != null)
				{
					entity.rk_gfmc = cell.ToString().Trim();
				}
				//物资名称
				cell = row.GetCell(3);
				if (cell != null)
				{
					entity.rk_wzmc = cell.ToString().Trim();
				}
				//规格型号
				cell = row.GetCell(4);
				if (cell != null)
				{
					entity.rk_ggxh = cell.ToString().Trim();
				}
				//单位
				cell = row.GetCell(5);
				if (cell != null)
				{
					entity.rk_dw = cell.ToString().Trim();
				}
				//进货单价
				cell = row.GetCell(6);
				if (cell != null)
				{
					entity.rk_jhdj = cell.ToString().Trim();
				}
				//进货数量
				cell = row.GetCell(7);
				if (cell != null)
				{
					entity.rk_jhsl = cell.ToString().Trim();
				}
				//销售价
				cell = row.GetCell(8);
				if (cell != null)
				{
					entity.rk_xsj = cell.ToString().Trim();
				}
				//折扣
				cell = row.GetCell(9);
				if (cell != null)
				{
					entity.rk_zk = cell.ToString().Trim();
				}
				//进货金额
				cell = row.GetCell(10);
				if (cell != null)
				{
					entity.rk_jhje = cell.ToString().Trim();
				}
				//备注
				cell = row.GetCell(11);
				if (cell != null)
				{
					entity.rk_bz = cell.ToString().Trim();
				}

				rukuSheet.Push(entity);
			}


			rukuSheet.filePath = filePath;
			rukuSheet.buildSheet();
			pushImportedEntity(rukuSheet);
		}
		private void pushImportedEntity(RukuSheet sheet)
		{
			if (!importedRukuSheets.Contains(sheet))
			{
				importedRukuSheets.Add(sheet);
			}
		}
		private void convertToDT()
		{
			myDt.Clear();

			foreach (RukuSheet sheet in this.importedRukuSheets)
			{
				List<Ruku> list = sheet.getRecords();

				if (list == null)
				{
					continue;
				}

				for (int i = 0; i < list.Count; i++)
				{
					DataRow dr = myDt.NewRow();
					dr[0] = list[i].rk_rq;
					dr[1] = list[i].rk_dh;
					dr[2] = list[i].rk_gfmc;
					dr[3] = list[i].rk_wzmc;
					dr[4] = list[i].rk_ggxh;
					dr[5] = list[i].rk_dw;
					dr[6] = list[i].rk_jhdj;
					dr[7] = list[i].rk_jhsl;
					dr[8] = list[i].rk_xsj;
					dr[9] = list[i].rk_zk;
					dr[10] = list[i].rk_jhje;
					dr[11] = list[i].rk_bz;

					myDt.Rows.Add(dr);
				}
			}
		}

		public DataTable importRukuSheets(string path)
		{
			//Precheck file imported or not
			bool existedFile = false;
			foreach (RukuSheet sheet in this.importedRukuSheets)
			{
				if (sheet.hasFile(path))
				{
					existedFile = true;
					break;
				}
			}
			if (existedFile)
			{
				return null;
			}

			FileStream file = null;

			try
			{
				if ((file = File.OpenRead(path)) != null)
				{
					using (file)
					{
						readSheetFile(file, path);
						convertToDT();

						return myDt;
					}
				}
			}
			catch (Exception ex)
			{
			}
			return null;
		}

		public DataTable getDataTable()
		{
			return myDt;
		}

		public List<RukuSheet> getRukuList()
		{
			return importedRukuSheets;
		}

		/*
		public RukuPrintSheet getRukuPrintSheet() {
			return new RukuPrintSheet(importedRukuSheets, "", "");
		}
		*/

		public void setRukuList(List<RukuSheet> list)
		{
			this.importedRukuSheets = list;
			headerCreator(null);
			convertToDT();
		}

		public void removeSheet(RukuSheet sheet)
		{
			this.importedRukuSheets.Remove(sheet);
			this.convertToDT();
		}

		public void clearTmp(bool deleteImported) {
			if (deleteImported)
			{
				deleteSheets();
			}

			this.importedRukuSheets.Clear();
			myDt.Clear();
			deleteTmpFile();
		}

		private void deleteTmpFile() {
			if (File.Exists(Program.tmpRukuFile))
			{
				try
				{
					File.Delete(Program.tmpRukuFile);
				}
				catch (Exception ex)
				{
				}
			}
		}

		private void deleteSheets() {
			foreach (RukuSheet sheet in importedRukuSheets)
			{
				if (File.Exists(sheet.filePath))
				{
					try
					{
						File.Delete(sheet.filePath);
					}
					catch (Exception ex)
					{
					}
				}
			}
		}
	}
}
