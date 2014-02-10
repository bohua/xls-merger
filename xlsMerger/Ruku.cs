using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace XlsMerger
{
	[Serializable()]
	public class Ruku : ISerializable
	{

		public string rk_dh { get; set; }
		public string rk_gfmc { get; set; }
		public string rk_wzmc { get; set; }
		public string rk_dw { get; set; }
		public string rk_jhdj { get; set; }
		public string rk_jhsl { get; set; }
		public string rk_xsj { get; set; }
		public string rk_zk { get; set; }
		public string rk_jhje { get; set; }
		public string rk_bz { get; set; }

		public string rk_ggxh { get; set; }
		public string rk_rq { get; set; }

        public string rk_fph { get; set; }

		public Ruku() { }

		public Ruku(SerializationInfo info, StreamingContext ctxt)
		{
			this.rk_rq = (string)info.GetValue("rk_rq", typeof(string));
			this.rk_dh = (string)info.GetValue("rk_dh", typeof(string));
			this.rk_gfmc = (string)info.GetValue("rk_gfmc", typeof(string));
			this.rk_wzmc = (string)info.GetValue("rk_wzmc", typeof(string));
			this.rk_ggxh = (string)info.GetValue("rk_ggxh", typeof(string));
			this.rk_dw = (string)info.GetValue("rk_dw", typeof(string));
			this.rk_jhdj = (string)info.GetValue("rk_jhdj", typeof(string));
			this.rk_jhsl = (string)info.GetValue("rk_jhsl", typeof(string));
			this.rk_xsj = (string)info.GetValue("rk_xsj", typeof(string));
			this.rk_zk = (string)info.GetValue("rk_zk", typeof(string));
			this.rk_jhje = (string)info.GetValue("rk_jhje", typeof(string));
			this.rk_bz = (string)info.GetValue("rk_bz", typeof(string));
            this.rk_fph = (string)info.GetValue("rk_fph", typeof(string));
		}

		public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
		{

			info.AddValue("rk_rq", this.rk_rq);
			info.AddValue("rk_dh", this.rk_dh);
			info.AddValue("rk_gfmc", this.rk_gfmc);
			info.AddValue("rk_wzmc", this.rk_wzmc);
			info.AddValue("rk_ggxh", this.rk_ggxh);
			info.AddValue("rk_dw", this.rk_dw);
			info.AddValue("rk_jhdj", this.rk_jhdj);
			info.AddValue("rk_jhsl", this.rk_jhsl);
			info.AddValue("rk_xsj", this.rk_xsj);
			info.AddValue("rk_zk", this.rk_zk);
			info.AddValue("rk_jhje", this.rk_jhje);
			info.AddValue("rk_bz", this.rk_bz);
            info.AddValue("rk_fph", this.rk_fph);
		}

		/*
		public void init(){
			this.face = string.Format("单据号:{0}  金额:{1}", this.rk_dh, this.rk_jhje);
		}*/
	}

	[Serializable()]
	public class RukuSheet : IEquatable<RukuSheet>, ISerializable
	{
		public string filePath { get; set; }
		public string face { get; set; }
		public string sheetId { get; set; }

		public string je_total { get; set; }
		public string se_total { get; set; }
		public string js_total { get; set; }

		private List<Ruku> records;

		public RukuSheet()
		{
			records = new List<Ruku>();
		}

		public RukuSheet(SerializationInfo info, StreamingContext ctxt)
		{
			this.filePath = (string)info.GetValue("filePath", typeof(string));
			this.face = (string)info.GetValue("face", typeof(string));
			this.sheetId = (string)info.GetValue("sheetId", typeof(string));
			this.je_total = (string)info.GetValue("je_total", typeof(string));
			this.se_total = (string)info.GetValue("se_total", typeof(string));
			this.js_total = (string)info.GetValue("js_total", typeof(string));
			this.records = (List<Ruku>)info.GetValue("records", typeof(List<Ruku>));
		}
		public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
		{
			info.AddValue("filePath", this.filePath);
			info.AddValue("face", this.face);
			info.AddValue("sheetId", this.sheetId);
			info.AddValue("je_total", this.je_total);
			info.AddValue("se_total", this.se_total);
			info.AddValue("js_total", this.js_total);
			info.AddValue("records", this.records);
		}

		public void buildSheet()
		{
			this.sheetId = records[0].rk_dh;

			decimal je = 0m;
			decimal se = 0m;
			decimal js = 0m;
			foreach (Ruku record in this.records)
			{
				decimal dj = decimal.Parse(record.rk_jhje);
				js += dj;
				je += dj / 1.17m;
				se += dj - dj / 1.17m;
			}
			this.je_total = Math.Round(je, 2).ToString();
			this.se_total = Math.Round(se, 2).ToString();
			this.js_total = Math.Round(js, 2).ToString();

			this.face = string.Format("单据号:{0}  金额:{1}", this.sheetId, this.js_total);
		}

        public void setInvNum(string invNum) {
            for (int i = 0; i < records.Count; i++) {
                records[i].rk_fph = invNum;
            }
        }

		public List<Ruku> getRecords()
		{
			return records;
		}

		public List<Ruku> Push(Ruku entry)
		{
			records.Add(entry);
			return records;
		}

		public bool Contains(Ruku entry)
		{
			return records.Contains(entry);
		}

		public bool hasFile(string filePath)
		{
			return this.filePath.Equals(filePath);
		}

		public bool Equals(RukuSheet other)
		{
			if (this.sheetId == other.sheetId && this.filePath == other.filePath)
			{
				return true;
			}
			return false;
		}
	}

	[Serializable()]
	public class RukuPrintSheet : ISerializable
	{
		public List<RukuSheet> sheetList;
		public string masterName {get; set;}
		public string verifierName {get; set;}

		public RukuPrintSheet() {
		
		}

		public RukuPrintSheet(List<RukuSheet> sheetList, string master_name, string verifier_name) {
			this.sheetList = sheetList;
			this.masterName = master_name;
			this.verifierName = verifier_name;
		}
		
		public RukuPrintSheet(SerializationInfo info, StreamingContext ctxt)
		{
			this.sheetList = (List<RukuSheet>)info.GetValue("sheet_list", typeof(List<RukuSheet>));
			this.masterName = (string)info.GetValue("master_name", typeof(string));
			this.verifierName = (string)info.GetValue("verifier_name", typeof(string));
		}
		public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
		{
			info.AddValue("sheet_list", this.sheetList);
			info.AddValue("master_name", this.masterName);
			info.AddValue("verifier_name", this.verifierName);
		}

		/*
		public List<Ruku> getRecords() {
			List<Ruku> records = new List<Ruku>();

			foreach (RukuSheet sheet in this.sheetList) {
				foreach (Ruku ruku in sheet.getRecords()) {
					records.Add(ruku);
				}
			}

			return records;
		}
		 */
		
		public string getJE(){
			decimal je = 0m;

			foreach (RukuSheet sheet in this.sheetList) {
				je += decimal.Parse(sheet.je_total);
			}

			return je.ToString();
		}

		public string getSE()
		{
			decimal se = 0m;

			foreach (RukuSheet sheet in this.sheetList)
			{
				se += decimal.Parse(sheet.se_total);
			}

			return se.ToString();
		}

		public string getJS()
		{
			decimal js = 0m;

			foreach (RukuSheet sheet in this.sheetList)
			{
				js += decimal.Parse(sheet.js_total);
			}

			return js.ToString();
		}
	}
}
