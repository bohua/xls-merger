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
        private List<string> importedInvoices = new List<string>();

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

		public DataTable ConvertToDataTable(FileStream file)
		{
            bool InvoiceRegistered = false;
			IWorkbook myWorkbook = new HSSFWorkbook(file);

			ISheet sheet = myWorkbook.GetSheetAt(0);
			System.Collections.IEnumerator rows = sheet.GetRowEnumerator();
			
			rows.MoveNext();
			headerCreator(rows);

			while (rows.MoveNext())
			{
				IRow row = (HSSFRow)rows.Current;
				DataRow dr = myDt.NewRow();

				for (int i = 0; i < row.LastCellNum; i++)
				{
					ICell cell = row.GetCell(i);
					if (cell == null)
					{
						dr[i] = null;
					}
					else
					{
                        if (!InvoiceRegistered && i == 1)
                        {
                            importedInvoices.Add(cell.ToString().Trim());
                            InvoiceRegistered = true;
                        }

						dr[i] = cell.ToString().Trim();
					}
				}
				myDt.Rows.Add(dr);
			}

			return myDt;
		}

		public DataTable getDataTable(){
			return myDt;
		}

        public List<string> getInvoiceList() {
            return importedInvoices;
        }

        public void setInvoiceList(string[] list) {
            importedInvoices.Clear();
            foreach (string str in list) {
                importedInvoices.Add(str);
            }
        }

        public void removeRowsByInvoice( string invoiceNumber) {
            List<DataRow> rowsToDelete = new List<DataRow>();

            foreach (DataRow row in myDt.Rows) {
                if (row[1].ToString().CompareTo(invoiceNumber) == 0) {
                    rowsToDelete.Add(row);
                }
            }

            foreach (DataRow row in rowsToDelete) {
                row.Delete();
            }

            importedInvoices.Remove(invoiceNumber);
        }
	}
}
