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

		private enum status { beforeImport, afterImport };
		private status globalSt = status.beforeImport;

		private void setStatus(status st)
		{
			if (st == status.beforeImport)
			{
				cBtnDeleteDoc.Enabled = false;
				cBtnExport.Enabled = false;
				cBtnImportEnd.Enabled = false;
				globalSt = status.beforeImport;
			}
			else
			{
				cBtnDeleteDoc.Enabled = true;
				cBtnExport.Enabled = true;
				cBtnImportEnd.Enabled = true;
				globalSt = status.afterImport;
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

			treeView1.ExpandAll();
		}

		private void reloadData() {
			dataGridView1.DataSource = sheetReader.loadTmpFile();

			for (int i = 0; i < dataGridView1.Columns.Count; i++)
			{
				dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
			}

			refreshInvoiceList();
		}

		private void refreshInvoiceList()
		{
			cCbDocList.DataBindings.Clear();
			cCbDocList.DataSource = null;

			cCbDocList.DataSource = sheetReader.getInvoiceList();
			cCbDocList.DisplayMember = "invoiceNumber";

			if (sheetReader.getInvoiceList().Count == 0)
			{
				setStatus(status.beforeImport);
			}
			else
			{
				setStatus(status.afterImport);
			}
		}

		private void endImport(object sender, EventArgs e)
		{
			if (sheetWriter.writeToFile(sheetReader.getDataTable(), null))
			{
				sheetWriter.saveMetaData(sheetReader.getInvoiceList());
				MessageBox.Show(@"数据保存成功！");
			}
		}

		private void startImport(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog1 = new OpenFileDialog();

			openFileDialog1.InitialDirectory = @"Xls\\";
			openFileDialog1.Filter = "Execel Sheets (*.xls)|*.xls|All files (*.*)|*.*";
			openFileDialog1.FilterIndex = 1;
			openFileDialog1.RestoreDirectory = true;
			openFileDialog1.Multiselect = true;
			openFileDialog1.Title = "选择导入税票（可多选）";

			if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				foreach (string path in openFileDialog1.FileNames)
				{
					DataTable importResult = sheetReader.importInvoiceFile(path);
					if (importResult == null)
					{
						MessageBox.Show(@"导入[" + path + @"]失败!");
					}
					else
					{
						dataGridView1.DataSource = importResult;
					}
				}

				for (int i = 0; i < dataGridView1.Columns.Count; i++)
				{
					dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
				}
				refreshInvoiceList();
			}
		}

		private void cBtnDeleteDoc_Click(object sender, EventArgs e)
		{
			if (cCbDocList.Text == "")
			{
				MessageBox.Show(@"请正确选择要删除的单据号！");
				return;
			}
			sheetReader.removeRowsByInvoice((Invoice)cCbDocList.SelectedItem);
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
			reloadData();
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
			sheetReader.clearTmp();
			reloadData();
		}

		private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
		{
			DialogResult dialogResult = MessageBox.Show("退出前要保存当前税票么？", "保存", MessageBoxButtons.YesNoCancel);
			if (dialogResult == DialogResult.Yes)
			{
				endImport(null, null);
			}
			else if (dialogResult == DialogResult.Cancel)
			{
				e.Cancel = true;
			}
		}

		private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
		{
		}
	}
}
