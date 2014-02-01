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
        private WelcomeForm welcome;

        private SheetReader sheetReader = new SheetReader();
        private RukuSheetReader rukuSheetReader = new RukuSheetReader();
        private ChukuSheetReader chukuSheetReader = new ChukuSheetReader();

        private SheetWriter sheetWriter = new SheetWriter();
        private RukuSheetWriter rukuSheetWriter = new RukuSheetWriter();
        private ChukuSheetWriter chukuSheetWriter = new ChukuSheetWriter();

        private IniFile settings = new IniFile("Settings.ini");

        private RukuPrintSheet rukuPrintSheet = new RukuPrintSheet(new List<RukuSheet>(), "沈洪伟", "李成伟");
        private ChukuPrintSheet chukuPrintSheet = new ChukuPrintSheet(new List<ChukuSheet>(), "沈洪伟", "李成伟");
        //private BindingSource bs = new BindingSource();

        private enum status { beforeImport = 1, duringImport = 2, afterImport = 3 };
        private Enum globalSt;
        private Enum globalRukuSt;
        private Enum globalChukuSt;

        private void setStatus(status st)
        {
            if (st == status.beforeImport)
            {
                cBtnImportStart.Enabled = true;
                cBtnDeleteDoc.Enabled = false;
                cBtnExport.Enabled = false;
                cBtnImportEnd.Enabled = false;
                globalSt = status.beforeImport;
            }
            else if (st == status.duringImport)
            {
                cBtnImportStart.Enabled = true;
                cBtnDeleteDoc.Enabled = true;
                cBtnExport.Enabled = false;
                cBtnImportEnd.Enabled = true;
                globalSt = status.duringImport;
            }
            else
            {
                cBtnImportStart.Enabled = false;
                cBtnDeleteDoc.Enabled = false;
                cBtnExport.Enabled = true;
                cBtnImportEnd.Enabled = false;
                globalSt = status.afterImport;
            }
        }

        private void setStatusRuku(status st)
        {
            if (st == status.beforeImport)
            {
                cBtnRukuStart.Enabled = true;
                cBtnDelRuku.Enabled = false;
                cBtnRukuPrint.Enabled = false;
                cBtnRukuEnd.Enabled = false;
                globalRukuSt = status.beforeImport;
            }
            else if (st == status.duringImport)
            {
                cBtnRukuStart.Enabled = true;
                cBtnDelRuku.Enabled = true;
                cBtnRukuPrint.Enabled = false;
                cBtnRukuEnd.Enabled = true;
                globalRukuSt = status.duringImport;
            }
            else
            {
                cBtnRukuStart.Enabled = false;
                cBtnDelRuku.Enabled = false;
                cBtnRukuPrint.Enabled = true;
                cBtnRukuEnd.Enabled = false;
                globalRukuSt = status.afterImport;
            }
        }

        private void setStatusChuku(status st)
        {
            if (st == status.beforeImport)
            {
                cBtnChukuStart.Enabled = true;
                cBtnChukuDel.Enabled = false;
                cBtnChukuPrint.Enabled = false;
                cBtnChukuEnd.Enabled = false;
                globalChukuSt = status.beforeImport;
            }
            else if (st == status.duringImport)
            {
                cBtnChukuStart.Enabled = true;
                cBtnChukuDel.Enabled = true;
                cBtnChukuPrint.Enabled = false;
                cBtnChukuEnd.Enabled = true;
                globalChukuSt = status.duringImport;
            }
            else
            {
                cBtnChukuStart.Enabled = false;
                cBtnChukuDel.Enabled = false;
                cBtnChukuPrint.Enabled = true;
                cBtnChukuEnd.Enabled = false;
                globalChukuSt = status.afterImport;
            }
        }

        public MainWindow(WelcomeForm welcome)
        {
            this.welcome = welcome;
            InitializeComponent();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.MultiSelect = true;
            dataGridView1.AllowUserToAddRows = false;

            treeView1.ExpandAll();

            //Initialize ini settings
            if (!this.settings.KeyExists("OpenDirectory", "System")) { this.settings.Write("OpenDirectory", @"c:\", "System"); }
            if (!this.settings.KeyExists("SaveDirectory", "System")) { this.settings.Write("SaveDirectory", @"c:\", "System"); }

            //读取税票状态
            if (this.settings.KeyExists("ProcessStatus", "StateMachine"))
            {
                string st = this.settings.Read("ProcessStatus", "StateMachine");

                if (Enum.IsDefined(typeof(status), st))
                {
                    setStatus((status)Enum.Parse(typeof(status), st, true));
                }
            }
            else
            {
                setStatus(status.beforeImport);
            }

            //读取入库状态
            if (this.settings.KeyExists("ProcessStatus", "StateMachineRuku"))
            {
                string st = this.settings.Read("ProcessStatus", "StateMachineRuku");

                if (Enum.IsDefined(typeof(status), st))
                {
                    setStatusRuku((status)Enum.Parse(typeof(status), st, true));
                }
            }
            else
            {
                setStatusRuku(status.beforeImport);
            }

            //读取出库状态
            if (this.settings.KeyExists("ProcessStatus", "StateMachineChuku"))
            {
                string st = this.settings.Read("ProcessStatus", "StateMachineChuku");

                if (Enum.IsDefined(typeof(status), st))
                {
                    setStatusChuku((status)Enum.Parse(typeof(status), st, true));
                }
            }
            else
            {
                setStatusChuku(status.beforeImport);
            }
        }

        private void reloadData()
        {
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
            cCbDocList.Items.Clear();

            List<Invoice> invList = sheetReader.getInvoiceList();
            cCbDocList.DataSource = invList;
            cCbDocList.DisplayMember = "face";
        }

        private void endImport(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("导入结束，单据号不能删除！", "导入结束", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                setStatus(status.afterImport);
            }
        }

        private void startImport(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = this.settings.Read("OpenDirectory", "System");
            openFileDialog1.Filter = "Execel Sheets (*.xls)|*.xls|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.Multiselect = true;
            openFileDialog1.Title = "选择导入税票（可多选）";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //Update the lastOpend Directory
                this.settings.Write("OpenDirectory", Path.GetDirectoryName(openFileDialog1.FileName), "System");

                if (Program.systemRegistryStatus == Program.SystemRegistryStatus.NotRegisted)
                {
                    int imported = sheetReader.getInvoiceList().Count;
                    if (imported + openFileDialog1.FileNames.Length > 2)
                    {
                        MessageBox.Show("试用版只能导入最多两个文件！", "注册提示");
                        return;
                    }
                }

                foreach (string path in openFileDialog1.FileNames)
                {
                    DataTable importResult = sheetReader.importInvoiceFile(path);
                    if (importResult == null)
                    {
                        MessageBox.Show(@"税票[" + path + @"]导入失败，原因：可能是重复导入或文件已损坏!");
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

            //Update tmp files
            sheetWriter.writeToFile(sheetReader.getDataTable(), null);
            sheetWriter.saveMetaData(sheetReader.getInvoiceList());
            setStatus(status.duringImport);
        }

        private void cBtnDeleteDoc_Click(object sender, EventArgs e)
        {
            if (cCbDocList.Text == "")
            {
                MessageBox.Show(@"请正确选择要删除的单据号！");
                return;
            }

            Invoice deletedInv = (Invoice)cCbDocList.SelectedItem;
            DialogResult dialogResult = MessageBox.Show("确定要删除[" + deletedInv.face + "]？", "删除单据", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                sheetReader.removeRowsByInvoice(deletedInv);
                refreshInvoiceList();

                //Update tmp files
                sheetWriter.writeToFile(sheetReader.getDataTable(), null);
                sheetWriter.saveMetaData(sheetReader.getInvoiceList());
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            string invoiceNumber = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString().Trim();

            if (cCbDocList.Items.Contains(invoiceNumber))
            {
                cCbDocList.SelectedItem = invoiceNumber;
            }
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            reloadData();
            reloadRukuData();
            reloadChukuData();
            welcome.Close();
        }

        private void cBtnExport_Click(object sender, EventArgs e)
        {
            Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.InitialDirectory = this.settings.Read("SaveDirectory", "System");
            saveFileDialog1.FileName = "连续打印税票.xls";
            saveFileDialog1.Filter = "xls files (*.xls)|*.xls|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //Update the lastSaved Directory
                this.settings.Write("SaveDirectory", Path.GetDirectoryName(saveFileDialog1.FileName), "System");

                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    sheetWriter.writeToFile(sheetReader.getDataTable(), myStream);
                    myStream.Close();
                    MessageBox.Show(@"连续打印税票导出成功！");
                }
            }
            sheetReader.clearTmp();
            reloadData();
            setStatus(status.beforeImport);
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.settings.Write("ProcessStatus", this.globalSt.ToString(), "StateMachine");
            this.settings.Write("ProcessStatus", this.globalRukuSt.ToString(), "StateMachineRuku");
            this.settings.Write("ProcessStatus", this.globalChukuSt.ToString(), "StateMachineChuku");
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node = treeView1.SelectedNode;

            switch (node.Name)
            {
                case "Node_Import_Invoice":
                    {
                        cTabInvoiceManager.SelectedTab = cTabPageInvoiceImport;
                        break;
                    }

                case "Node_Import_Ruku":
                    {
                        cTabInvoiceManager.SelectedTab = cTabPageRukudan;
                        break;
                    }
            }
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutForm().ShowDialog();
        }

        private void cTabInvoiceManager_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cTabInvoiceManager.SelectedTab.Name)
            {
                case "cTabPageInvoiceImport":
                    {
                        treeView1.SelectedNode = treeView1.Nodes[0].Nodes[0].Nodes[0];
                        break;
                    }
                case "cTabPageRukudan":
                    {
                        treeView1.SelectedNode = treeView1.Nodes[0].Nodes[1].Nodes[0];
                        break;
                    }
            }
            treeView1.Focus();
        }

        #region 公共方法

        private string[] importFiles(string fileType)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = this.settings.Read("OpenDirectory", "System");
            openFileDialog1.Filter = "Execel Sheets (*.xls)|*.xls|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.Multiselect = true;
            openFileDialog1.Title = "选择单据（可多选）";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //Update the lastOpend Directory
                this.settings.Write("OpenDirectory", Path.GetDirectoryName(openFileDialog1.FileName), "System");

                if (Program.systemRegistryStatus == Program.SystemRegistryStatus.NotRegisted)
                {
                    int imported = 0;
                    switch (fileType)
                    {
                        case "invoice": imported = sheetReader.getInvoiceList().Count;
                            break;
                        case "ruku": imported = this.rukuPrintSheet.sheetList.Count;
                            break;
                        case "chuku": imported = this.chukuPrintSheet.sheetList.Count;
                            break;
                    }
                    if (imported + openFileDialog1.FileNames.Length > 2)
                    {
                        MessageBox.Show("试用版只能导入最多两个文件！", "注册提示");
                        return null;
                    }
                }

                return openFileDialog1.FileNames;
            }

            return null;
        }

        private void printDoc(string type)
        {
            var form = new PrintModeForm();
            var result = form.ShowDialog();

            if (result == DialogResult.OK)
            {
                string printMode = form.printMode;

                PrintHelper ph = new PrintHelper(this.settings);
                try
                {
                    //打印文档
                    if (type == "ruku")
                    {
                        ph.generatePrintDoc(this.rukuPrintSheet);
                    }
                    else
                    {
                        ph.generatePrintDoc(this.chukuPrintSheet);
                    }
                }
                catch (System.Runtime.InteropServices.COMException)
                {
                    MessageBox.Show(@"打印过程中遇到问题，可能是EXCEL安装不完全或不正确，请尝试重新安装正版OFFICE!");
                }
                catch (System.IO.FileNotFoundException)
                {
                    MessageBox.Show(@"打印过程中遇到问题，打印模板程序损坏或被删除，请重新安装本软件!");
                }
                catch (System.IO.IOException)
                {
                    MessageBox.Show(@"打印过程中遇到问题，打印模板程序正被其它程序调用，请关闭其它程序!");
                }

                if (printMode == "print")
                {
                    ph.PrintMyExcelFile();
                }
                else
                {
                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();

                    saveFileDialog1.InitialDirectory = this.settings.Read("SaveDirectory", "System");
                    saveFileDialog1.FileName = "打印单据.xls";
                    saveFileDialog1.Filter = "xls files (*.xls)|*.xls|All files (*.*)|*.*";
                    saveFileDialog1.FilterIndex = 1;

                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        //Update the lastSaved Directory
                        this.settings.Write("SaveDirectory", Path.GetDirectoryName(saveFileDialog1.FileName), "System");

                        ph.ExportMyExcelFileAsXls(saveFileDialog1.FileName);
                        MessageBox.Show(@"导出成功！");

                    }
                }

                DialogResult dialogResult = MessageBox.Show("要删除已打印过的单据文件么？", "删除原文件", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    if (type == "ruku")
                    {
                        this.rukuSheetReader.clearTmp(true);
                    }
                    else
                    {
                        this.chukuSheetReader.clearTmp(true);
                    }
                }
                else
                {
                    if (type == "ruku")
                    {
                        this.rukuSheetReader.clearTmp(false);
                    }
                    else
                    {
                        this.chukuSheetReader.clearTmp(false);
                    }
                }
            }
        }

        #endregion

        #region 入库单界面代码

        private void reloadRukuData()
        {
            RukuPrintSheet tmp = rukuSheetWriter.loadFromFile();

            if (tmp != null)
            {
                this.rukuPrintSheet = tmp;
                rukuSheetReader.setRukuList(tmp.sheetList);
            }
            refreshRukuList();
        }

        private void setRukuAmounts(string je, string se, string js)
        {
            cLabelJS_Ruku.Text = "金额合计:" + je + "      ";
            cLabelSE_Ruku.Text = "税额合计:" + se + "      ";
            cLabelJE_Ruku.Text = "价税合计:" + js + "      ";
        }

        private void refreshRukuList()
        {
            dataGridView2.DataSource = rukuSheetReader.getDataTable();
            for (int i = 0; i < dataGridView2.Columns.Count; i++)
            {
                dataGridView2.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            }

            cCbboxRuku.DataBindings.Clear();
            cCbboxRuku.DataSource = null;
            cCbboxRuku.Items.Clear();

            this.rukuPrintSheet.sheetList = rukuSheetReader.getRukuList();
            cCbboxRuku.DataSource = rukuPrintSheet.sheetList;
            cCbboxRuku.DisplayMember = "face";

            cTxtboxRukuMaster.Text = rukuPrintSheet.masterName;
            cTxtboxRukuVerifier.Text = rukuPrintSheet.verifierName;
            cTxtboxRukuInvNum.Text = rukuPrintSheet.invNum;

            setRukuAmounts(rukuPrintSheet.getJE(), rukuPrintSheet.getSE(), rukuPrintSheet.getJS());
        }

        private void cBtnRukuStart_Click(object sender, EventArgs e)
        {
            string[] rukuFiles = importFiles("ruku");

            if (rukuFiles == null)
            {
                return;
            }

            foreach (string path in rukuFiles)
            {
                DataTable importResult = rukuSheetReader.importRukuSheets(path);

                if (importResult == null)
                {
                    MessageBox.Show(@"单据[" + path + @"]导入失败，原因：可能是重复导入或文件已损坏!");
                }
            }

            refreshRukuList();

            //Update tmp files
            rukuSheetWriter.saveToFile(this.rukuPrintSheet);

            setStatusRuku(status.duringImport);
        }

        private void cBtnRukuPrint_Click(object sender, EventArgs e)
        {
            printDoc("ruku");

            reloadRukuData();

            setStatusRuku(status.beforeImport);
        }

        private void cBtnDelRuku_Click(object sender, EventArgs e)
        {
            if (cCbboxRuku.Text == "")
            {
                MessageBox.Show(@"请正确选择要删除的单据号！");
                return;
            }

            RukuSheet toDelete = (RukuSheet)cCbboxRuku.SelectedItem;
            DialogResult dialogResult = MessageBox.Show("确定要删除[" + toDelete.face + "]？", "删除单据", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                rukuSheetReader.removeSheet(toDelete);

                refreshRukuList();

                //Update tmp files
                rukuSheetWriter.saveToFile(this.rukuPrintSheet);
            }
        }

        private void cTxtboxRukuMaster_Leave(object sender, EventArgs e)
        {
            this.rukuPrintSheet.masterName = cTxtboxRukuMaster.Text;
            this.rukuPrintSheet.verifierName = cTxtboxRukuVerifier.Text;
            this.rukuPrintSheet.invNum = cTxtboxRukuInvNum.Text;
            rukuSheetWriter.saveToFile(this.rukuPrintSheet);
        }

        private void cBtnRukuEnd_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("导入结束，单据号将不能删除！", "导入结束", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                setStatusRuku(status.afterImport);
            }
        }

        #endregion

        #region 入库单界面代码

        private void setChukuAmounts(string je, string se, string js)
        {
            cLabelJS_Chuku.Text = "金额合计:" + je + "      ";
            cLabelSE_Chuku.Text = "税额合计:" + se + "      ";
            cLabelJE_Chuku.Text = "价税合计:" + js + "      ";
        }

        private void reloadChukuData()
        {
            ChukuPrintSheet tmp = chukuSheetWriter.loadFromFile();

            if (tmp != null)
            {
                this.chukuPrintSheet = tmp;
                chukuSheetReader.setChukuList(tmp.sheetList);
            }
            refreshChukuList();
        }

        private void refreshChukuList()
        {
            dataGridView3.DataSource = chukuSheetReader.getDataTable();
            for (int i = 0; i < dataGridView3.Columns.Count; i++)
            {
                dataGridView3.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            }

            cCbboxChuku.DataBindings.Clear();
            cCbboxChuku.DataSource = null;
            cCbboxChuku.Items.Clear();

            this.chukuPrintSheet.sheetList = chukuSheetReader.getChukuList();
            cCbboxChuku.DataSource = chukuPrintSheet.sheetList;
            cCbboxChuku.DisplayMember = "face";

            cTxtboxChukuMaster.Text = chukuPrintSheet.masterName;
            cTxtboxChukuVerifier.Text = chukuPrintSheet.verifierName;
            cTxtboxChukuInvNum.Text = chukuPrintSheet.invNum;

            setChukuAmounts(chukuPrintSheet.getJE(), chukuPrintSheet.getSE(), chukuPrintSheet.getJS());
        }

        private void cBtnChukuStart_Click(object sender, EventArgs e)
        {
            string[] chukuFiles = importFiles("chuku");

            if (chukuFiles == null)
            {
                return;
            }

            foreach (string path in chukuFiles)
            {
                DataTable importResult = chukuSheetReader.importChukuSheets(path);

                if (importResult == null)
                {
                    MessageBox.Show(@"单据[" + path + @"]导入失败，原因：可能是重复导入或文件已损坏!");
                }
            }

            refreshChukuList();

            //Update tmp files
            chukuSheetWriter.saveToFile(this.chukuPrintSheet);

            setStatusChuku(status.duringImport);
        }

        private void cBtnChukuDel_Click(object sender, EventArgs e)
        {
            if (cCbboxChuku.Text == "")
            {
                MessageBox.Show(@"请正确选择要删除的单据号！");
                return;
            }

            ChukuSheet toDelete = (ChukuSheet)cCbboxChuku.SelectedItem;
            DialogResult dialogResult = MessageBox.Show("确定要删除[" + toDelete.face + "]？", "删除单据", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                chukuSheetReader.removeSheet(toDelete);

                refreshChukuList();

                //Update tmp files
                chukuSheetWriter.saveToFile(this.chukuPrintSheet);
            }
        }

        private void cBtnChukuEnd_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("导入结束，单据号将不能删除！", "导入结束", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                setStatusChuku(status.afterImport);
            }
        }

        private void cBtnChukuPrint_Click(object sender, EventArgs e)
        {
            printDoc("chuku");

            reloadChukuData();

            setStatusChuku(status.beforeImport);
        }

        private void cTxtboxChukuMaster_Leave(object sender, EventArgs e)
        {
            this.chukuPrintSheet.masterName = cTxtboxChukuMaster.Text;
            this.chukuPrintSheet.verifierName = cTxtboxChukuVerifier.Text;
            this.chukuPrintSheet.invNum = cTxtboxChukuInvNum.Text;
            chukuSheetWriter.saveToFile(this.chukuPrintSheet);
        }

        #endregion
    }
}
