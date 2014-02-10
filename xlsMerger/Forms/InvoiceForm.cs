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
        private RukuPrintSheet rukuPrintSheet;
        private List<KeyValuePair<RukuSheet, string>> invMapper = new List<KeyValuePair<RukuSheet,string>>();

        private bool hasMapping(RukuSheet sheet){
            for(int i=0; i<this.invMapper.Count; i++){
                if(this.invMapper[i].Key == sheet){
                    return true;
                }
            }
            return false;
        }

        private void initMapping(){
            for (int i = 0; i < this.rukuPrintSheet.sheetList.Count; i++){
                updateMapping(this.rukuPrintSheet.sheetList[i], this.rukuPrintSheet.sheetList[i].getRecords()[0].rk_fph);
            }          
        }

        private string getMapping(RukuSheet sheet) {
            for (int i = 0; i < this.invMapper.Count; i++)
            {
                if (this.invMapper[i].Key == sheet)
                {
                    return this.invMapper[i].Value;
                }
            }
            return "";
        }

        private void updateMapping(RukuSheet sheet, string newVal) {
            for (int i = 0; i < this.invMapper.Count; i++)
            {
                if (this.invMapper[i].Key == sheet)
                {
                    this.invMapper.RemoveAt(i);
                    break;
                }
            }

            invMapper.Add(new KeyValuePair<RukuSheet, string>(sheet, newVal));
        } 

        public void applyUpdate(){
            for (int i = 0; i < this.invMapper.Count; i++)
            {
                this.invMapper[i].Key.setInvNum(this.invMapper[i].Value);      
            }
        }

        public InvoiceForm(RukuPrintSheet rukuPrintSheet)
        {
            InitializeComponent();
            this.rukuPrintSheet = rukuPrintSheet;
            initMapping();
        }

        public RukuPrintSheet getUpdatedRukuPrintSheet()
        {
            return this.rukuPrintSheet;
        }

        private void InvoiceForm_Load(object sender, EventArgs e)
        {
            

            cListboxDj.DataSource = this.rukuPrintSheet.sheetList;
            cListboxDj.DisplayMember = @"face";  
        }

        private void cInvoiceDjh_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var sheet = this.rukuPrintSheet.sheetList[cListboxDj.SelectedIndex];
            cTxtDjh.Text = sheet.sheetId;
            cTxtRq.Text = sheet.getRecords()[0].rk_rq;
            cTxtInvoiceNr.Text = getMapping(sheet);
        }


        private void cTxtInvoiceNr_Leave(object sender, EventArgs e)
        {
            var sheet = this.rukuPrintSheet.sheetList[cListboxDj.SelectedIndex];

            updateMapping(sheet, cTxtInvoiceNr.Text);
        }
    }
}
