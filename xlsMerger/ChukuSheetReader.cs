using System;
using System.IO;
using System.Data;
using System.Collections.Generic;
using System.Text;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;

namespace XlsMerger
{
	class ChukuSheetReader
	{
		private List<ChukuSheet> importedChukuSheets = new List<ChukuSheet>();
		private DataTable myDt = new DataTable();
		private string[] headers = { "销售单日期", "销售单号", "客户名称", "序号", "商品名称", "规格型号", "单位", "数量", "单价", "金额", "税额", "备注", "发票号" };

		private void headerCreator(System.Collections.IEnumerator rows)
		{
			if (myDt.Columns.Count == 0)
			{
				/*if (rows == null)
				{*/
				for (int j = 0; j < headers.Length; j++)
				{
					DataColumn col = myDt.Columns.Add(headers[j]);
				}
				/*
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
				 * */
			}
		}

		private void readSheetFile(FileStream file, string filePath)
		{
			int xh = 1;
			IWorkbook myWorkbook = new HSSFWorkbook(file);

			ISheet sheet = myWorkbook.GetSheetAt(0);
			System.Collections.IEnumerator rows = sheet.GetRowEnumerator();

			rows.MoveNext();
			headerCreator(rows);

			ChukuSheet chukuSheet = new ChukuSheet();

			while (rows.MoveNext())
			{
				IRow row = (HSSFRow)rows.Current;
				Chuku entity = new Chuku();
				ICell cell;

				//销售单日期
				cell = row.GetCell(2);
				if (cell != null)
				{
					try
					{
						DateTime dt = cell.DateCellValue;
						entity.ck_rq = dt.Date.ToString("yyyy-MM-dd");
					}
					catch (Exception ex)
					{
						entity.ck_rq = cell.ToString().Trim();
					}
				}
				//销售单号
				cell = row.GetCell(1);
				if (cell != null)
				{
					entity.ck_dh = cell.ToString().Trim();
				}
				//客户名称
				cell = row.GetCell(4);
				if (cell != null)
				{
					entity.ck_khmc = cell.ToString().Trim();
				}
				//序号
				entity.ck_xh = xh++.ToString();
				//商品名称
				cell = row.GetCell(18);
				if (cell != null)
				{
					entity.ck_spmc = cell.ToString().Trim();
				}
				//规格型号
				cell = row.GetCell(19);
				if (cell != null)
				{
					entity.ck_ggxh = cell.ToString().Trim();
				}
				//单位
				cell = row.GetCell(20);
				if (cell != null)
				{
					entity.ck_dw = cell.ToString().Trim();
				}
				//数量
				cell = row.GetCell(21);
				if (cell != null)
				{
					entity.ck_sl = cell.ToString().Trim();
				}
				cell = row.GetCell(22);
				//金额
				if (cell != null)
				{
					entity.ck_je = cell.ToString().Trim();
					//单价
					if (entity.ck_sl != null && entity.ck_sl != "0")
					{
						entity.ck_dj = Math.Round(decimal.Parse(entity.ck_je) / decimal.Parse(entity.ck_sl), 2).ToString();
					}
					//税额
					entity.ck_se = Math.Round((decimal.Parse(entity.ck_je) / 1.17m * 0.17m), 2).ToString();
				}
				//备注
				cell = row.GetCell(8);
				if (cell != null)
				{
					entity.ck_bz = cell.ToString().Trim();
				}

				chukuSheet.Push(entity);
			}


			chukuSheet.filePath = filePath;
			chukuSheet.buildSheet();
			pushImportedEntity(chukuSheet);
		}
		private void pushImportedEntity(ChukuSheet sheet)
		{
			if (!importedChukuSheets.Contains(sheet))
			{
				importedChukuSheets.Add(sheet);
			}
		}
		private void convertToDT()
		{
			myDt.Clear();

			foreach (ChukuSheet sheet in this.importedChukuSheets)
			{
				List<Chuku> list = sheet.getRecords();

				if (list == null)
				{
					continue;
				}

				for (int i = 0; i < list.Count; i++)
				{
					DataRow dr = myDt.NewRow();
					dr[0] = list[i].ck_rq;
					dr[1] = list[i].ck_dh;
					dr[2] = list[i].ck_khmc;
					dr[3] = list[i].ck_xh;
					dr[4] = list[i].ck_spmc;
					dr[5] = list[i].ck_ggxh;
					dr[6] = list[i].ck_dw;
					dr[7] = list[i].ck_sl;
					dr[8] = list[i].ck_dj;
					dr[9] = list[i].ck_je;
					dr[10] = list[i].ck_se;
					dr[11] = list[i].ck_bz;
					dr[12] = list[i].ck_fph;

					myDt.Rows.Add(dr);
				}
			}
		}

		public DataTable importChukuSheets(string path)
		{
			//Precheck file imported or not
			bool existedFile = false;
			foreach (ChukuSheet sheet in this.importedChukuSheets)
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

		public List<ChukuSheet> getChukuList()
		{
			return importedChukuSheets;
		}

		/*
		public ChukuPrintSheet getChukuPrintSheet() {
			return new ChukuPrintSheet(importedChukuSheets, "", "");
		}
		*/

		public void setChukuList(List<ChukuSheet> list)
		{
			this.importedChukuSheets = list;
			headerCreator(null);
			convertToDT();
		}

		public void removeSheet(ChukuSheet sheet)
		{
			this.importedChukuSheets.Remove(sheet);
			this.convertToDT();
		}

		public void clearTmp(bool deleteImported)
		{
			if (deleteImported)
			{
				deleteSheets();
			}

			this.importedChukuSheets.Clear();
			myDt.Clear();
			deleteTmpFile();
		}

		private void deleteTmpFile()
		{
			if (File.Exists(Program.tmpChukuFile))
			{
				try
				{
					File.Delete(Program.tmpChukuFile);
				}
				catch (Exception ex)
				{
				}
			}
		}

		private void deleteSheets()
		{
			foreach (ChukuSheet sheet in importedChukuSheets)
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
