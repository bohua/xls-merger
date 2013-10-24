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
	}
}
