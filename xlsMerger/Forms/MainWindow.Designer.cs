﻿namespace XlsMerger
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("税票导入");
			System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("税票管理", new System.Windows.Forms.TreeNode[] {
            treeNode1});
			System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("入库单导入");
			System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("入库单管理", new System.Windows.Forms.TreeNode[] {
            treeNode3});
			System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("系统菜单", new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode4});
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
			this.dataSet1 = new System.Data.DataSet();
			this.panel1 = new System.Windows.Forms.Panel();
			this.treeView1 = new System.Windows.Forms.TreeView();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.cTabInvoiceManager = new System.Windows.Forms.TabControl();
			this.cTabPageInvoiceImport = new System.Windows.Forms.TabPage();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.panel2 = new System.Windows.Forms.Panel();
			this.cBtnDeleteDoc = new System.Windows.Forms.Button();
			this.cBtnImportEnd = new System.Windows.Forms.Button();
			this.cCbDocList = new System.Windows.Forms.ComboBox();
			this.cBtnExport = new System.Windows.Forms.Button();
			this.cBtnImportStart = new System.Windows.Forms.Button();
			this.cTabPageRukudan = new System.Windows.Forms.TabPage();
			this.panel5 = new System.Windows.Forms.Panel();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.dataGridView2 = new System.Windows.Forms.DataGridView();
			this.panel4 = new System.Windows.Forms.Panel();
			this.label3 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.cTxtboxRukuInvNum = new System.Windows.Forms.TextBox();
			this.cLabelJE = new System.Windows.Forms.Label();
			this.cLabelSE = new System.Windows.Forms.Label();
			this.cLabelJS = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.cTxtboxVerifier = new System.Windows.Forms.TextBox();
			this.cTxtboxRukuMaster = new System.Windows.Forms.TextBox();
			this.panel3 = new System.Windows.Forms.Panel();
			this.cBtnDelRuku = new System.Windows.Forms.Button();
			this.cBtnRukuEnd = new System.Windows.Forms.Button();
			this.cCbboxRuku = new System.Windows.Forms.ComboBox();
			this.cBtnRukuPrint = new System.Windows.Forms.Button();
			this.cBtnRukuStart = new System.Windows.Forms.Button();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
			this.panel1.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.cTabInvoiceManager.SuspendLayout();
			this.cTabPageInvoiceImport.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.panel2.SuspendLayout();
			this.cTabPageRukudan.SuspendLayout();
			this.panel5.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
			this.panel4.SuspendLayout();
			this.panel3.SuspendLayout();
			this.SuspendLayout();
			// 
			// dataSet1
			// 
			this.dataSet1.DataSetName = "NewDataSet";
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.treeView1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel1.Location = new System.Drawing.Point(0, 25);
			this.panel1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(198, 696);
			this.panel1.TabIndex = 0;
			// 
			// treeView1
			// 
			this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.treeView1.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.treeView1.Location = new System.Drawing.Point(0, 0);
			this.treeView1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.treeView1.Name = "treeView1";
			treeNode1.Name = "Node_Import_Invoice";
			treeNode1.Text = "税票导入";
			treeNode2.Name = "Node_InvoiceManager";
			treeNode2.Text = "税票管理";
			treeNode3.Name = "Node_Import_Ruku";
			treeNode3.Text = "入库单导入";
			treeNode4.Name = "Node_RukuManager";
			treeNode4.Text = "入库单管理";
			treeNode5.Name = "Node_Root";
			treeNode5.Text = "系统菜单";
			this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode5});
			this.treeView1.Size = new System.Drawing.Size(198, 696);
			this.treeView1.TabIndex = 0;
			this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.关于ToolStripMenuItem,
            this.退出ToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 3, 0, 3);
			this.menuStrip1.Size = new System.Drawing.Size(1006, 25);
			this.menuStrip1.TabIndex = 1;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// 关于ToolStripMenuItem
			// 
			this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
			this.关于ToolStripMenuItem.Size = new System.Drawing.Size(43, 19);
			this.关于ToolStripMenuItem.Text = "关于";
			this.关于ToolStripMenuItem.Click += new System.EventHandler(this.关于ToolStripMenuItem_Click);
			// 
			// 退出ToolStripMenuItem
			// 
			this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
			this.退出ToolStripMenuItem.Size = new System.Drawing.Size(43, 19);
			this.退出ToolStripMenuItem.Text = "退出";
			this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
			// 
			// cTabInvoiceManager
			// 
			this.cTabInvoiceManager.Controls.Add(this.cTabPageInvoiceImport);
			this.cTabInvoiceManager.Controls.Add(this.cTabPageRukudan);
			this.cTabInvoiceManager.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cTabInvoiceManager.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cTabInvoiceManager.Location = new System.Drawing.Point(198, 25);
			this.cTabInvoiceManager.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.cTabInvoiceManager.Name = "cTabInvoiceManager";
			this.cTabInvoiceManager.SelectedIndex = 0;
			this.cTabInvoiceManager.Size = new System.Drawing.Size(808, 696);
			this.cTabInvoiceManager.TabIndex = 2;
			this.cTabInvoiceManager.SelectedIndexChanged += new System.EventHandler(this.cTabInvoiceManager_SelectedIndexChanged);
			// 
			// cTabPageInvoiceImport
			// 
			this.cTabPageInvoiceImport.Controls.Add(this.groupBox1);
			this.cTabPageInvoiceImport.Controls.Add(this.panel2);
			this.cTabPageInvoiceImport.Location = new System.Drawing.Point(4, 30);
			this.cTabPageInvoiceImport.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.cTabPageInvoiceImport.Name = "cTabPageInvoiceImport";
			this.cTabPageInvoiceImport.Size = new System.Drawing.Size(800, 662);
			this.cTabPageInvoiceImport.TabIndex = 0;
			this.cTabPageInvoiceImport.Text = "税票导入";
			this.cTabPageInvoiceImport.UseVisualStyleBackColor = true;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.dataGridView1);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(0, 111);
			this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.groupBox1.Size = new System.Drawing.Size(800, 551);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "导入内容主体";
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridView1.Location = new System.Drawing.Point(3, 27);
			this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.RowTemplate.Height = 27;
			this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridView1.Size = new System.Drawing.Size(794, 519);
			this.dataGridView1.TabIndex = 0;
			this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.cBtnDeleteDoc);
			this.panel2.Controls.Add(this.cBtnImportEnd);
			this.panel2.Controls.Add(this.cCbDocList);
			this.panel2.Controls.Add(this.cBtnExport);
			this.panel2.Controls.Add(this.cBtnImportStart);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(800, 111);
			this.panel2.TabIndex = 0;
			// 
			// cBtnDeleteDoc
			// 
			this.cBtnDeleteDoc.Enabled = false;
			this.cBtnDeleteDoc.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cBtnDeleteDoc.Location = new System.Drawing.Point(487, 61);
			this.cBtnDeleteDoc.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.cBtnDeleteDoc.Name = "cBtnDeleteDoc";
			this.cBtnDeleteDoc.Size = new System.Drawing.Size(72, 35);
			this.cBtnDeleteDoc.TabIndex = 6;
			this.cBtnDeleteDoc.Text = "删除";
			this.cBtnDeleteDoc.UseVisualStyleBackColor = true;
			this.cBtnDeleteDoc.Click += new System.EventHandler(this.cBtnDeleteDoc_Click);
			// 
			// cBtnImportEnd
			// 
			this.cBtnImportEnd.Enabled = false;
			this.cBtnImportEnd.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cBtnImportEnd.Location = new System.Drawing.Point(168, 17);
			this.cBtnImportEnd.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.cBtnImportEnd.Name = "cBtnImportEnd";
			this.cBtnImportEnd.Size = new System.Drawing.Size(152, 35);
			this.cBtnImportEnd.TabIndex = 2;
			this.cBtnImportEnd.Text = "导入结束";
			this.cBtnImportEnd.UseVisualStyleBackColor = true;
			this.cBtnImportEnd.Click += new System.EventHandler(this.endImport);
			// 
			// cCbDocList
			// 
			this.cCbDocList.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cCbDocList.FormattingEnabled = true;
			this.cCbDocList.ItemHeight = 21;
			this.cCbDocList.Location = new System.Drawing.Point(14, 62);
			this.cCbDocList.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.cCbDocList.Name = "cCbDocList";
			this.cCbDocList.Size = new System.Drawing.Size(467, 29);
			this.cCbDocList.TabIndex = 4;
			// 
			// cBtnExport
			// 
			this.cBtnExport.Enabled = false;
			this.cBtnExport.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cBtnExport.Location = new System.Drawing.Point(350, 16);
			this.cBtnExport.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.cBtnExport.Name = "cBtnExport";
			this.cBtnExport.Size = new System.Drawing.Size(209, 35);
			this.cBtnExport.TabIndex = 3;
			this.cBtnExport.Text = "导出连续打印税票";
			this.cBtnExport.UseVisualStyleBackColor = true;
			this.cBtnExport.Click += new System.EventHandler(this.cBtnExport_Click);
			// 
			// cBtnImportStart
			// 
			this.cBtnImportStart.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cBtnImportStart.Location = new System.Drawing.Point(14, 16);
			this.cBtnImportStart.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.cBtnImportStart.Name = "cBtnImportStart";
			this.cBtnImportStart.Size = new System.Drawing.Size(122, 36);
			this.cBtnImportStart.TabIndex = 1;
			this.cBtnImportStart.Text = "导入开始";
			this.cBtnImportStart.UseVisualStyleBackColor = true;
			this.cBtnImportStart.Click += new System.EventHandler(this.startImport);
			// 
			// cTabPageRukudan
			// 
			this.cTabPageRukudan.Controls.Add(this.panel5);
			this.cTabPageRukudan.Controls.Add(this.panel4);
			this.cTabPageRukudan.Controls.Add(this.panel3);
			this.cTabPageRukudan.Location = new System.Drawing.Point(4, 30);
			this.cTabPageRukudan.Name = "cTabPageRukudan";
			this.cTabPageRukudan.Size = new System.Drawing.Size(800, 662);
			this.cTabPageRukudan.TabIndex = 1;
			this.cTabPageRukudan.Text = "入库单";
			this.cTabPageRukudan.UseVisualStyleBackColor = true;
			// 
			// panel5
			// 
			this.panel5.Controls.Add(this.groupBox2);
			this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel5.Location = new System.Drawing.Point(0, 69);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(800, 526);
			this.panel5.TabIndex = 5;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.dataGridView2);
			this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox2.Location = new System.Drawing.Point(0, 0);
			this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.groupBox2.Size = new System.Drawing.Size(800, 526);
			this.groupBox2.TabIndex = 4;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "导入内容主体";
			// 
			// dataGridView2
			// 
			this.dataGridView2.AllowUserToAddRows = false;
			this.dataGridView2.AllowUserToDeleteRows = false;
			this.dataGridView2.AllowUserToOrderColumns = true;
			this.dataGridView2.AllowUserToResizeRows = false;
			this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridView2.Location = new System.Drawing.Point(3, 27);
			this.dataGridView2.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.dataGridView2.Name = "dataGridView2";
			this.dataGridView2.ReadOnly = true;
			this.dataGridView2.RowHeadersVisible = false;
			this.dataGridView2.RowTemplate.Height = 27;
			this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridView2.Size = new System.Drawing.Size(794, 494);
			this.dataGridView2.TabIndex = 0;
			// 
			// panel4
			// 
			this.panel4.Controls.Add(this.label3);
			this.panel4.Controls.Add(this.label1);
			this.panel4.Controls.Add(this.cTxtboxRukuInvNum);
			this.panel4.Controls.Add(this.cLabelJE);
			this.panel4.Controls.Add(this.cLabelSE);
			this.panel4.Controls.Add(this.cLabelJS);
			this.panel4.Controls.Add(this.label2);
			this.panel4.Controls.Add(this.cTxtboxVerifier);
			this.panel4.Controls.Add(this.cTxtboxRukuMaster);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel4.Location = new System.Drawing.Point(0, 595);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(800, 67);
			this.panel4.TabIndex = 4;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(16, 35);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(62, 21);
			this.label3.TabIndex = 12;
			this.label3.Text = "发票号:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(271, 35);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(46, 21);
			this.label1.TabIndex = 11;
			this.label1.Text = "主管:";
			// 
			// cTxtboxRukuInvNum
			// 
			this.cTxtboxRukuInvNum.Location = new System.Drawing.Point(84, 31);
			this.cTxtboxRukuInvNum.Name = "cTxtboxRukuInvNum";
			this.cTxtboxRukuInvNum.Size = new System.Drawing.Size(159, 29);
			this.cTxtboxRukuInvNum.TabIndex = 10;
			this.cTxtboxRukuInvNum.Leave += new System.EventHandler(this.cTxtboxRukuMaster_Leave);
			// 
			// cLabelJE
			// 
			this.cLabelJE.AutoSize = true;
			this.cLabelJE.Dock = System.Windows.Forms.DockStyle.Right;
			this.cLabelJE.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
			this.cLabelJE.Location = new System.Drawing.Point(578, 0);
			this.cLabelJE.Name = "cLabelJE";
			this.cLabelJE.Size = new System.Drawing.Size(74, 21);
			this.cLabelJE.TabIndex = 9;
			this.cLabelJE.Text = "金额合计";
			this.cLabelJE.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// cLabelSE
			// 
			this.cLabelSE.AutoSize = true;
			this.cLabelSE.Dock = System.Windows.Forms.DockStyle.Right;
			this.cLabelSE.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
			this.cLabelSE.Location = new System.Drawing.Point(652, 0);
			this.cLabelSE.Name = "cLabelSE";
			this.cLabelSE.Size = new System.Drawing.Size(74, 21);
			this.cLabelSE.TabIndex = 7;
			this.cLabelSE.Text = "税额合计";
			this.cLabelSE.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// cLabelJS
			// 
			this.cLabelJS.AutoSize = true;
			this.cLabelJS.Dock = System.Windows.Forms.DockStyle.Right;
			this.cLabelJS.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
			this.cLabelJS.Location = new System.Drawing.Point(726, 0);
			this.cLabelJS.Name = "cLabelJS";
			this.cLabelJS.Size = new System.Drawing.Size(74, 21);
			this.cLabelJS.TabIndex = 5;
			this.cLabelJS.Text = "价税合计";
			this.cLabelJS.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(440, 35);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(46, 21);
			this.label2.TabIndex = 3;
			this.label2.Text = "验收:";
			// 
			// cTxtboxVerifier
			// 
			this.cTxtboxVerifier.Location = new System.Drawing.Point(491, 31);
			this.cTxtboxVerifier.Name = "cTxtboxVerifier";
			this.cTxtboxVerifier.Size = new System.Drawing.Size(88, 29);
			this.cTxtboxVerifier.TabIndex = 2;
			this.cTxtboxVerifier.Text = "李成伟";
			this.cTxtboxVerifier.Leave += new System.EventHandler(this.cTxtboxRukuMaster_Leave);
			// 
			// cTxtboxRukuMaster
			// 
			this.cTxtboxRukuMaster.Location = new System.Drawing.Point(319, 31);
			this.cTxtboxRukuMaster.Name = "cTxtboxRukuMaster";
			this.cTxtboxRukuMaster.Size = new System.Drawing.Size(90, 29);
			this.cTxtboxRukuMaster.TabIndex = 0;
			this.cTxtboxRukuMaster.Text = "沈洪伟";
			this.cTxtboxRukuMaster.Leave += new System.EventHandler(this.cTxtboxRukuMaster_Leave);
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.cBtnDelRuku);
			this.panel3.Controls.Add(this.cBtnRukuEnd);
			this.panel3.Controls.Add(this.cCbboxRuku);
			this.panel3.Controls.Add(this.cBtnRukuPrint);
			this.panel3.Controls.Add(this.cBtnRukuStart);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel3.Location = new System.Drawing.Point(0, 0);
			this.panel3.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(800, 69);
			this.panel3.TabIndex = 2;
			// 
			// cBtnDelRuku
			// 
			this.cBtnDelRuku.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cBtnDelRuku.Location = new System.Drawing.Point(488, 17);
			this.cBtnDelRuku.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.cBtnDelRuku.Name = "cBtnDelRuku";
			this.cBtnDelRuku.Size = new System.Drawing.Size(72, 35);
			this.cBtnDelRuku.TabIndex = 6;
			this.cBtnDelRuku.Text = "删除";
			this.cBtnDelRuku.UseVisualStyleBackColor = true;
			this.cBtnDelRuku.Click += new System.EventHandler(this.cBtnDelRuku_Click);
			// 
			// cBtnRukuEnd
			// 
			this.cBtnRukuEnd.Enabled = false;
			this.cBtnRukuEnd.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cBtnRukuEnd.Location = new System.Drawing.Point(566, 17);
			this.cBtnRukuEnd.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.cBtnRukuEnd.Name = "cBtnRukuEnd";
			this.cBtnRukuEnd.Size = new System.Drawing.Size(133, 35);
			this.cBtnRukuEnd.TabIndex = 2;
			this.cBtnRukuEnd.Text = "导入结束";
			this.cBtnRukuEnd.UseVisualStyleBackColor = true;
			this.cBtnRukuEnd.Click += new System.EventHandler(this.cBtnRukuEnd_Click);
			// 
			// cCbboxRuku
			// 
			this.cCbboxRuku.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cCbboxRuku.FormattingEnabled = true;
			this.cCbboxRuku.ItemHeight = 21;
			this.cCbboxRuku.Location = new System.Drawing.Point(142, 18);
			this.cCbboxRuku.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.cCbboxRuku.Name = "cCbboxRuku";
			this.cCbboxRuku.Size = new System.Drawing.Size(340, 29);
			this.cCbboxRuku.TabIndex = 4;
			// 
			// cBtnRukuPrint
			// 
			this.cBtnRukuPrint.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cBtnRukuPrint.Location = new System.Drawing.Point(705, 16);
			this.cBtnRukuPrint.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.cBtnRukuPrint.Name = "cBtnRukuPrint";
			this.cBtnRukuPrint.Size = new System.Drawing.Size(87, 35);
			this.cBtnRukuPrint.TabIndex = 3;
			this.cBtnRukuPrint.Text = "打印";
			this.cBtnRukuPrint.UseVisualStyleBackColor = true;
			this.cBtnRukuPrint.Click += new System.EventHandler(this.cBtnRukuPrint_Click);
			// 
			// cBtnRukuStart
			// 
			this.cBtnRukuStart.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cBtnRukuStart.Location = new System.Drawing.Point(14, 16);
			this.cBtnRukuStart.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.cBtnRukuStart.Name = "cBtnRukuStart";
			this.cBtnRukuStart.Size = new System.Drawing.Size(122, 36);
			this.cBtnRukuStart.TabIndex = 1;
			this.cBtnRukuStart.Text = "导入开始";
			this.cBtnRukuStart.UseVisualStyleBackColor = true;
			this.cBtnRukuStart.Click += new System.EventHandler(this.cBtnRukuStart_Click);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// MainWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1006, 721);
			this.Controls.Add(this.cTabInvoiceManager);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.menuStrip1);
			this.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.Name = "MainWindow";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "电子表格文档汇总编辑管理程序";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
			this.Load += new System.EventHandler(this.MainWindow_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
			this.panel1.ResumeLayout(false);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.cTabInvoiceManager.ResumeLayout(false);
			this.cTabPageInvoiceImport.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.panel2.ResumeLayout(false);
			this.cTabPageRukudan.ResumeLayout(false);
			this.panel5.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
			this.panel4.ResumeLayout(false);
			this.panel4.PerformLayout();
			this.panel3.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Data.DataSet dataSet1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.TabControl cTabInvoiceManager;
        private System.Windows.Forms.TabPage cTabPageInvoiceImport;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button cBtnDeleteDoc;
        private System.Windows.Forms.Button cBtnImportEnd;
        private System.Windows.Forms.ComboBox cCbDocList;
        private System.Windows.Forms.Button cBtnExport;
        private System.Windows.Forms.Button cBtnImportStart;
        private System.Windows.Forms.TabPage cTabPageRukudan;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button cBtnDelRuku;
        private System.Windows.Forms.Button cBtnRukuEnd;
        private System.Windows.Forms.ComboBox cCbboxRuku;
        private System.Windows.Forms.Button cBtnRukuPrint;
        private System.Windows.Forms.Button cBtnRukuStart;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label cLabelJE;
        private System.Windows.Forms.Label cLabelSE;
        private System.Windows.Forms.Label cLabelJS;
        private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox cTxtboxVerifier;
        private System.Windows.Forms.TextBox cTxtboxRukuMaster;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox cTxtboxRukuInvNum;
    }
}
