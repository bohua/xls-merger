using System;
using System.IO;
using System.Data;
using System.Collections.Generic;
using System.Text;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;

namespace XlsMerger
{
	class SheetReader
	{
		private DataTable myDt = new DataTable();
		private List<Invoice> importedInvoices = new List<Invoice>();

		private void pushImportedInvoice(Invoice inv) {
			if (!importedInvoices.Contains(inv)) {
				importedInvoices.Add(inv);
				//importedInvoices.Sort();
			}
		}

		private void headerCreator(System.Collections.IEnumerator rows)
		{
			if (myDt.Columns.Count == 0)
			{
				IRow headerRow = (HSSFRow)rows.Current;
				for (int j = 0; j < headerRow.LastCellNum; j++)
				{
					ICell header = headerRow.GetCell(j);
					myDt.Columns.Add(header.ToString().Trim());
				}
			}
		}

		public DataTable convertToDataTable(FileStream file, string filePath)
		{
			IWorkbook myWorkbook = new HSSFWorkbook(file);

			ISheet sheet = myWorkbook.GetSheetAt(0);
			System.Collections.IEnumerator rows = sheet.GetRowEnumerator();

			rows.MoveNext();
			headerCreator(rows);

			while (rows.MoveNext())
			{
				IRow row = (HSSFRow)rows.Current;
				DataRow dr = myDt.NewRow();
				InvoiceBuilder invBuilder = new InvoiceBuilder();

				for (int i = 0; i < row.LastCellNum; i++)
				{
					ICell cell = row.GetCell(i);
					if (cell == null)
					{
						dr[i] = null;
					}
					else
					{
                        //单据号
						if (i == 1 )
						{
							invBuilder.invoiceNumber = cell.ToString().Trim();
						}
                        //备注
						if (i == 8)
						{
							string[] memo = cell.ToString().Split('_');
							invBuilder.totalAmount = memo[0];
						}

						dr[i] = cell.ToString().Trim();
					}
				}
				myDt.Rows.Add(dr);

				invBuilder.filePath = filePath;
				pushImportedInvoice(invBuilder.build());
			}

			return myDt;
		}

		public DataTable getDataTable()
		{
			return myDt;
		}

		public List<Invoice> getInvoiceList()
		{
			return importedInvoices;
		}

		public List<Invoice> loadInvoiceList()
		{
			importedInvoices.Clear();

			if (File.Exists(Program.metaFile))
			{
                string[] lines = File.ReadAllLines(Program.metaFile);

				foreach (string line in lines)
				{
					string[] strs = line.Split('\t');
					InvoiceBuilder builder = new InvoiceBuilder();
					builder.invoiceNumber = strs[0];
					builder.filePath = strs[1];
					builder.totalAmount = strs[2];
					importedInvoices.Add(builder.build());
				}
			}

			return importedInvoices;
		}

		public void removeRowsByInvoice(Invoice inv)
		{
			List<DataRow> rowsToDelete = new List<DataRow>();

			foreach (DataRow row in myDt.Rows)
			{
				if (row[1].ToString().CompareTo(inv.invoiceNumber) == 0)
				{
					rowsToDelete.Add(row);
				}
			}

			foreach (DataRow row in rowsToDelete)
			{
				row.Delete();
			}

			importedInvoices.Remove(inv);
		}

		public DataTable importInvoiceFile(string path) {
            //Precheck file imported or not
            bool existedFile = false;
            foreach (Invoice inv in this.importedInvoices) {
                if (inv.hasFile(path)) {
                    existedFile = true;
                    break;
                }
            }
            if (existedFile) {
                return null;
            }

			FileStream file = null;

			try
			{
				if ((file = File.OpenRead(path)) != null)
				{
					using (file)
					{
						DataTable result = convertToDataTable(file, path);

						return result;
					}
				}
			}
			catch (Exception ex)
			{
			}
			return null;
		}

		public DataTable loadTmpFile() {
			try
			{
				if (File.Exists(Program.tmpFile))
				{
                    DataTable result = importInvoiceFile(Program.tmpFile);
					loadInvoiceList();
					return result;
				}
			}
			catch (Exception ex)
			{
			}
			return null;
		}

		public void clearTmp()
		{
			try
			{
                if (File.Exists(Program.tmpFile)) { File.Delete(Program.tmpFile); }
                if (File.Exists(Program.metaFile)) { File.Delete(Program.metaFile); }

				deleteImportedFiles();
				importedInvoices.Clear();
                myDt.Clear();
			}
			catch (Exception ex) {
			}
		}

		public void deleteImportedFiles()
		{
			foreach (Invoice inv in importedInvoices)
			{
				if (File.Exists(inv.filePath))
				{
					try
					{
						File.Delete(inv.filePath);
					}
					catch (Exception ex)
					{
					}
				}
			}
		}
	}
}
