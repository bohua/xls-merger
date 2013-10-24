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

		private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{

		}

		private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
		{

		}

		private void button1_Click_1(object sender, EventArgs e)
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
					MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
				}
			}
			/*
			sheetReader.init(@"Xls\上海工具公司11390_20.xls");
			DataTable dt = sheetReader.ConvertToDataTable();
			dataSet1.Tables.Add(dt);

			dataGridView1.DataSource = dataSet1.Tables[0];
			for (int i = 0; i < dataGridView1.Columns.Count; i++)
			{
				dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
			}*/
		}
	}
}
