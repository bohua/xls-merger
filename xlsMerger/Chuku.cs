﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace XlsMerger
{
	[Serializable()]
	public class Chuku : ISerializable
	{

		public string ck_dh { get; set; }
		public string ck_rq { get; set; }
		public string ck_khmc { get; set; }
		public string ck_fpp { get; set; }
		public string ck_spmc { get; set; }
		public string ck_ggxh { get; set; }
		public string ck_dw { get; set; }
		public string ck_sl { get; set; }
		public string ck_dj { get; set; }
		public string ck_se { get; set; }
		public string ck_je { get; set; }
		public string ck_xh { get; set; }
		public string ck_bz { get; set; }
		public string ck_fph { get; set; }

		public Chuku() { }

		public Chuku(SerializationInfo info, StreamingContext ctxt)
		{
			this.ck_dh = (string)info.GetValue("ck_dh", typeof(string));
			this.ck_rq = (string)info.GetValue("ck_rq", typeof(string));
			this.ck_khmc = (string)info.GetValue("ck_khmc", typeof(string));
			this.ck_fpp = (string)info.GetValue("ck_fpp", typeof(string));
			this.ck_spmc = (string)info.GetValue("ck_spmc", typeof(string));
			this.ck_ggxh = (string)info.GetValue("ck_ggxh", typeof(string));
			this.ck_dw = (string)info.GetValue("ck_dw", typeof(string));
			this.ck_sl = (string)info.GetValue("ck_sl", typeof(string));
			this.ck_dj = (string)info.GetValue("ck_dj", typeof(string));
			this.ck_se = (string)info.GetValue("ck_se", typeof(string));
			this.ck_je = (string)info.GetValue("ck_je", typeof(string));
			this.ck_xh = (string)info.GetValue("ck_xh", typeof(string));
			this.ck_bz = (string)info.GetValue("ck_bz", typeof(string));
			this.ck_fph = (string)info.GetValue("ck_fph", typeof(string));
		}

		public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
		{

			info.AddValue("ck_dh", this.ck_dh);
			info.AddValue("ck_rq", this.ck_rq);
			info.AddValue("ck_khmc", this.ck_khmc);
			info.AddValue("ck_fpp", this.ck_fpp);
			info.AddValue("ck_spmc", this.ck_spmc);
			info.AddValue("ck_ggxh", this.ck_ggxh);
			info.AddValue("ck_dw", this.ck_dw);
			info.AddValue("ck_sl", this.ck_sl);
			info.AddValue("ck_dj", this.ck_dj);
			info.AddValue("ck_se", this.ck_se);
			info.AddValue("ck_je", this.ck_je);
			info.AddValue("ck_xh", this.ck_xh);
			info.AddValue("ck_bz", this.ck_bz);
			info.AddValue("ck_fph", this.ck_fph);
		}
	}

	[Serializable()]
	public class ChukuSheet : IEquatable<ChukuSheet>, ISerializable, cInfDj
	{
		public string filePath { get; set; }
		public string face { get; set; }
		public string sheetId { get; set; }

		public string je_total { get; set; }
		public string se_total { get; set; }
		public string js_total { get; set; }

		private List<Chuku> records;

		public ChukuSheet()
		{
			records = new List<Chuku>();
		}

		public ChukuSheet(SerializationInfo info, StreamingContext ctxt)
		{
			this.filePath = (string)info.GetValue("filePath", typeof(string));
			this.face = (string)info.GetValue("face", typeof(string));
			this.sheetId = (string)info.GetValue("sheetId", typeof(string));
			this.je_total = (string)info.GetValue("je_total", typeof(string));
			this.se_total = (string)info.GetValue("se_total", typeof(string));
			this.js_total = (string)info.GetValue("js_total", typeof(string));
			this.records = (List<Chuku>)info.GetValue("records", typeof(List<Chuku>));
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
			this.sheetId = records[0].ck_dh;

			decimal je = 0m;
			decimal se = 0m;
			decimal js = 0m;

			int xh = 1;

			foreach (Chuku record in this.records)
			{
				decimal dj = decimal.Parse(record.ck_je);
				js += dj;
				je += dj / 1.17m;
				se += dj - dj / 1.17m;

				record.ck_xh = xh++.ToString();
			}
			this.je_total = Math.Round(je, 2).ToString();
			this.se_total = Math.Round(se, 2).ToString();
			this.js_total = Math.Round(js, 2).ToString();

			this.face = string.Format("单据号:{0}  金额:{1}", this.sheetId, this.js_total);
		}

		/********* Interface method implementation *********/
		public void setInvNum(string invNum)
		{
			for (int i = 0; i < records.Count; i++)
			{
				records[i].ck_fph = invNum;
			}
		}

		/********* Interface method implementation *********/
		public string getSheetId()
		{
			return sheetId;
		}

		/********* Interface method implementation *********/
		public string getDate()
		{
			return records[0].ck_rq;
		}

		/********* Interface method implementation *********/
		public string getInvNum()
		{
			return records[0].ck_fph;
		}

		public List<Chuku> getRecords()
		{
			return records;
		}

		public List<Chuku> Push(Chuku entry)
		{
			records.Add(entry);
			return records;
		}

		public bool Contains(Chuku entry)
		{
			return records.Contains(entry);
		}

		public bool hasFile(string filePath)
		{
			return this.filePath.Equals(filePath);
		}

		public bool Equals(ChukuSheet other)
		{
			if (this.sheetId == other.sheetId && this.filePath == other.filePath)
			{
				return true;
			}
			return false;
		}
	}

	[Serializable()]
	public class ChukuPrintSheet : ISerializable, cInfDjList
	{
		public List<ChukuSheet> sheetList;
		public string masterName { get; set; }
		public string verifierName { get; set; }
		public string invNum { get; set; }

		public ChukuPrintSheet()
		{

		}

		public ChukuPrintSheet(List<ChukuSheet> sheetList, string master_name, string verifier_name)
		{
			this.sheetList = sheetList;
			this.masterName = master_name;
			this.verifierName = verifier_name;
			this.invNum = "";
		}

		public ChukuPrintSheet(SerializationInfo info, StreamingContext ctxt)
		{
			this.sheetList = (List<ChukuSheet>)info.GetValue("sheet_list", typeof(List<ChukuSheet>));
			this.masterName = (string)info.GetValue("master_name", typeof(string));
			this.verifierName = (string)info.GetValue("verifier_name", typeof(string));
			this.invNum = (string)info.GetValue("inv_num", typeof(string));
		}
		public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
		{
			info.AddValue("sheet_list", this.sheetList);
			info.AddValue("master_name", this.masterName);
			info.AddValue("verifier_name", this.verifierName);
			info.AddValue("inv_num", this.invNum);
		}

		public string getJE()
		{
			decimal je = 0m;

			foreach (ChukuSheet sheet in this.sheetList)
			{
				je += decimal.Parse(sheet.je_total);
			}

			return je.ToString();
		}

		public string getSE()
		{
			decimal se = 0m;

			foreach (ChukuSheet sheet in this.sheetList)
			{
				se += decimal.Parse(sheet.se_total);
			}

			return se.ToString();
		}

		public string getJS()
		{
			decimal js = 0m;

			foreach (ChukuSheet sheet in this.sheetList)
			{
				js += decimal.Parse(sheet.js_total);
			}

			return js.ToString();
		}

		/********* Interface method implementation *********/
		public cInfDj getSheetAt(int index)
		{
			return sheetList[index];
		}

		/********* Interface method implementation *********/
		public int getSize()
		{
			return sheetList.Count;
		}
	}
}
