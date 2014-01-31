using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System.Data;

namespace XlsMerger
{
	class ChukuSheetWriter : SheetWriter
	{
		/*
				  public void saveToFile(DataTable dt, ){
			 FileStream file = new FileStream(Program.tmpChukuFile, FileMode.Create);

			 writeToFile(dt, file);
		 }
		 private void saveMetaToFile(List<ChukuSheet> meta)
		 {
			using (System.IO.StreamWriter file = new System.IO.StreamWriter(Program.metaChukuFile))
			{
				foreach (ChukuSheet sheet in meta)
				{
					file.WriteLine(string.Format("{0}\t{1}\t{2}", sheet.sheetId, sheet.filePath, sheet.je_total));
				}
			}
		 }
		 */

		public void saveToFile(ChukuPrintSheet printSheet)
		{
			ChukuToSerialize objectToSerialize = new ChukuToSerialize();
			Serializer serializer = new Serializer();
			//save the car list to a file          
			objectToSerialize.ChukuPrintSheet = printSheet;
			serializer.SerializeChukuObject(Program.tmpChukuFile, objectToSerialize);
		}

		public ChukuPrintSheet loadFromFile()
		{
			ChukuToSerialize objectToSerialize = new ChukuToSerialize();
			Serializer serializer = new Serializer();
			objectToSerialize = serializer.DeSerializeChukuObject(Program.tmpChukuFile);
			if (objectToSerialize == null)
			{
				return null;
			}
			return objectToSerialize.ChukuPrintSheet;
		}
	}
}
