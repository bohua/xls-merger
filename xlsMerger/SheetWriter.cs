using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System.Data;

namespace XlsMerger
{
	class SheetWriter
	{
		private void writeHeader(ISheet sheet, DataTable dt)
		{
			IRow row = sheet.CreateRow(0);

			int j = 0;
			foreach (DataColumn col in dt.Columns)
			{
				ICell cell = row.CreateCell(j++);
				cell.SetCellValue(col.Caption);
			}
		}

		public bool writeToFile(DataTable dt, Stream stream)
		{
			HSSFWorkbook workbook = new HSSFWorkbook();
			ISheet sheet = workbook.CreateSheet();

			writeHeader(sheet, dt);

			IRow row;

			for (int i = 0; i < dt.Rows.Count; i++)
			{
				row = sheet.CreateRow(i + 1);

				int j = 0;
				foreach (DataColumn col in dt.Columns)
				{
					ICell cell = row.CreateCell(j++);
					cell.SetCellValue(dt.Rows[i][col.Caption].ToString());
				}
			}

			try
			{
				if (stream == null)
				{
                    FileStream file = new FileStream(Program.tmpFile, FileMode.Create);
					workbook.Write(file);
					file.Close();
				}
				else
				{
					workbook.Write(stream);
				}
			}
			catch (Exception)
			{
				return false;
			}

			return true;
		}

		public void saveMetaData(List<Invoice> meta)
		{
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(Program.metaFile))
			{
				foreach (Invoice inv in meta)
				{
					file.WriteLine(string.Format("{0}\t{1}\t{2}", inv.invoiceNumber, inv.filePath, inv.totalAmount));
				}
			}
		}
	}
}
