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
		private const string tmpFile = "tmp.xls";

		public void writeToTmpFile(DataTable dt){
			HSSFWorkbook workbook = new HSSFWorkbook();
			ISheet sheet = workbook.CreateSheet();

			IRow row;

			for (int i = 0; i < dt.Rows.Count; i++) {
				row = sheet.CreateRow(i);

				int j = 0;
				foreach (DataColumn col in dt.Columns) {
					ICell cell = row.CreateCell(j++);
					cell.SetCellValue(dt.Rows[i][col.Caption].ToString());
				}
			}

			FileStream file = new FileStream(tmpFile, FileMode.Create);
			workbook.Write(file);
			file.Close();
		}
	}
}
