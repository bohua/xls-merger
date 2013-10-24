using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace XlsMerger
{
	public partial class MainWindow : Form
	{
		private SheetReader sheetReader = new SheetReader();
		private SheetWriter sheetWriter = new SheetWriter();
        //private BindingSource bs = new BindingSource();
        private const string tmpFile = @"tmp.xls";
        private const string metaFile = @"meta.data";
        private enum status { beforeImport, afterImport };
        private status globalSt = status.beforeImport;

        private void setStatus(status st) {
            if (st == status.beforeImport)
            {
                cBtnDeleteDoc.Enabled = false;
                cBtnExport.Enabled = false;
                cBtnImportEnd.Enabled = false;
            }
            else {
                cBtnDeleteDoc.Enabled = true;
                cBtnExport.Enabled = true;
                cBtnImportEnd.Enabled = true;
            }
        }

		public MainWindow()
		{
			InitializeComponent();
			dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dataGridView1.ReadOnly = true;
			dataGridView1.RowHeadersVisible = false;
			dataGridView1.AllowUserToResizeRows = false;
			dataGridView1.MultiSelect = true;
			dataGridView1.AllowUserToAddRows = false;
		}

        private void refreshInvoiceList() {
            cCbDocList.Items.Clear();
            foreach (string option in sheetReader.getInvoiceList())
            {
                cCbDocList.Items.Add(option);
            }

            if (cCbDocList.Items.Count > 0)
            {
                cCbDocList.SelectedIndex = 0;
                setStatus(status.afterImport);
            }
            else {
                cCbDocList.Text = "";
                setStatus(status.beforeImport);
            }
        }

		private void endImport(object sender, EventArgs e)
		{
            if (sheetWriter.writeToFile(sheetReader.getDataTable(), null)) {
                sheetWriter.saveMetaData(sheetReader.getInvoiceList());
                MessageBox.Show(@"数据保存成功！");
            }

		}

        private void startImport(object sender, EventArgs e)
        {
            Stream myStream = null;
            FileStream file = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = @"Xls\\";
            openFileDialog1.Filter = "txt files (*.xls)|*.xls|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null && (file = myStream as FileStream) != null)
                    {
                        using (file)
                        {
                            dataGridView1.DataSource = sheetReader.ConvertToDataTable(file);

                            for (int i = 0; i < dataGridView1.Columns.Count; i++)
                            {
                                dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(@"导入失败：" + ex.Message);
                }

                refreshInvoiceList();
            }
        }

        private void cBtnDeleteDoc_Click(object sender, EventArgs e)
        {
            sheetReader.removeRowsByInvoice(cCbDocList.SelectedItem.ToString());
            refreshInvoiceList();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string invoiceNumber = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString().Trim();

            if (cCbDocList.Items.Contains(invoiceNumber))
            {
                cCbDocList.SelectedItem = invoiceNumber;
            }
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(tmpFile))
                {
                    FileStream file = new FileStream(tmpFile, FileMode.Open);
                    using (file)
                    {
                        dataGridView1.DataSource = sheetReader.ConvertToDataTable(file);

                        for (int i = 0; i < dataGridView1.Columns.Count; i++)
                        {
                            dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                        }
                    }


                    if (File.Exists(metaFile))
                    {
                        string[] lines = File.ReadAllLines(metaFile);
                        sheetReader.setInvoiceList(lines);
                        refreshInvoiceList();
                    }

                    setStatus(status.afterImport);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"导入失败：" + ex.Message);
            }
        }

        private void cBtnExport_Click(object sender, EventArgs e)
        {
            Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.FileName = "连续打印税票.xls";
            saveFileDialog1.Filter = "xls files (*.xls)|*.xls|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    sheetWriter.writeToFile(sheetReader.getDataTable(), myStream);
                    myStream.Close();
                    MessageBox.Show(@"连续打印税票导出成功！");
                }
            }
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
	}
}
