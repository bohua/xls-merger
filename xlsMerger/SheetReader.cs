using System;
using System.IO;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;

namespace XlsMerger
{
    class SheetReader
    {
        private IWorkbook myWorkbook;

        public void init(string path){
            using (FileStream file = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                myWorkbook = new HSSFWorkbook(file);
            }
        }

        public DataTable ConvertToDataTable()
        {
            ISheet sheet = myWorkbook.GetSheetAt(0);
            System.Collections.IEnumerator rows = sheet.GetRowEnumerator();

      
            DataTable dt = new DataTable();

            rows.MoveNext();
            IRow headerRow = (HSSFRow)rows.Current;
            for (int j = 0; j < headerRow.LastCellNum; j++)
            {
                ICell header = headerRow.GetCell(j);
                dt.Columns.Add(header.ToString());
            }

            
            while (rows.MoveNext())
            {
                IRow row = (HSSFRow)rows.Current;
                DataRow dr = dt.NewRow();

                for (int i = 0; i < row.LastCellNum; i++)
                {
                    ICell cell = row.GetCell(i);


                    if (cell == null)
                    {
                        dr[i] = null;
                    }
                    else
                    {
                        dr[i] = cell.ToString();
                    }
                }
                dt.Rows.Add(dr);
            }
            
            return dt;
        }

    }
}
