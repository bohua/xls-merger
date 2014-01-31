using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System.Data;

namespace XlsMerger
{
	class RukuSheetWriter : SheetWriter
	{
		/*
				  public void saveToFile(DataTable dt, ){
			 FileStream file = new FileStream(Program.tmpRukuFile, FileMode.Create);

			 writeToFile(dt, file);
		 }
		 private void saveMetaToFile(List<RukuSheet> meta)
		 {
			using (System.IO.StreamWriter file = new System.IO.StreamWriter(Program.metaRukuFile))
			{
				foreach (RukuSheet sheet in meta)
				{
					file.WriteLine(string.Format("{0}\t{1}\t{2}", sheet.sheetId, sheet.filePath, sheet.je_total));
				}
			}
		 }
		 */

		public void saveToFile(RukuPrintSheet printSheet)
		{
			RukuToSerialize objectToSerialize = new RukuToSerialize();
			Serializer serializer = new Serializer();
			//save the car list to a file          
			objectToSerialize.RukuPrintSheet = printSheet;
			serializer.SerializeRukuObject(Program.tmpRukuFile, objectToSerialize);
		}

		public RukuPrintSheet loadFromFile()
		{
			RukuToSerialize objectToSerialize = new RukuToSerialize();
			Serializer serializer = new Serializer();
			objectToSerialize = serializer.DeSerializeRukuObject(Program.tmpRukuFile);
			if (objectToSerialize == null)
			{
				return null;
			}
			return objectToSerialize.RukuPrintSheet;
		}
	}
}
