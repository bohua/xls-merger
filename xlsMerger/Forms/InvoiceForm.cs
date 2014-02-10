using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace XlsMerger.Forms
{
	public partial class InvoiceForm : Form
	{
		private cInfDjList sheetList;
		private List<KeyValuePair<cInfDj, string>> invMapper = new List<KeyValuePair<cInfDj, string>>();

		private bool hasMapping(cInfDj sheet)
		{
			for (int i = 0; i < this.invMapper.Count; i++)
			{
				if (this.invMapper[i].Key == sheet)
				{
					return true;
				}
			}
			return false;
		}

		private void initMapping()
		{
			for (int i = 0; i < this.sheetList.getSize(); i++)
			{
				updateMapping(this.sheetList.getSheetAt(i), this.sheetList.getSheetAt(i).getInvNum());
			}
		}

		private string getMapping(cInfDj sheet)
		{
			for (int i = 0; i < this.invMapper.Count; i++)
			{
				if (this.invMapper[i].Key == sheet)
				{
					return this.invMapper[i].Value;
				}
			}
			return "";
		}

		private void updateMapping(cInfDj sheet, string newVal)
		{
			for (int i = 0; i < this.invMapper.Count; i++)
			{
				if (this.invMapper[i].Key == sheet)
				{
					this.invMapper.RemoveAt(i);
					break;
				}
			}

			invMapper.Add(new KeyValuePair<cInfDj, string>(sheet, newVal));
		}

		public void applyUpdate()
		{
			for (int i = 0; i < this.invMapper.Count; i++)
			{
				this.invMapper[i].Key.setInvNum(this.invMapper[i].Value);
			}
		}

		public InvoiceForm(cInfDjList sheetList)
		{
			InitializeComponent();
			this.sheetList = sheetList;
			initMapping();
		}

		private void InvoiceForm_Load(object sender, EventArgs e)
		{
			if(sheetList.GetType() == typeof(RukuPrintSheet)){
				cListboxDj.DataSource = ((RukuPrintSheet)sheetList).sheetList;
			}else{
				cListboxDj.DataSource = ((ChukuPrintSheet)sheetList).sheetList;
			}

			//cListboxDj.DataSource = this.sheetList.getSheetList();
			cListboxDj.DisplayMember = @"face";
		}

		private void cInvoiceDjh_TextChanged(object sender, EventArgs e)
		{

		}

		private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			var sheet = this.sheetList.getSheetAt(cListboxDj.SelectedIndex);
			cTxtDjh.Text = sheet.getSheetId();
			cTxtRq.Text = sheet.getDate();
			cTxtInvoiceNr.Text = getMapping(sheet);
			cTxtInvoiceNr.Focus();
		}


		private void cTxtInvoiceNr_Leave(object sender, EventArgs e)
		{
			var sheet = this.sheetList.getSheetAt(cListboxDj.SelectedIndex);

			updateMapping(sheet, cTxtInvoiceNr.Text);
		}
	}
}
