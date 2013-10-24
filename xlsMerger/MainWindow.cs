using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
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
