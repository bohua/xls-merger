namespace XlsMerger
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
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("系统菜单", new System.Windows.Forms.TreeNode[] {
            treeNode2});
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.cTabInvoiceManager.SuspendLayout();
            this.cTabPageInvoiceImport.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
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
            this.panel1.Location = new System.Drawing.Point(0, 29);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(198, 692);
            this.panel1.TabIndex = 0;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "Node2";
            treeNode1.Text = "税票导入";
            treeNode2.Name = "Node_InvoiceManager";
            treeNode2.Text = "税票管理";
            treeNode3.Name = "Node_Root";
            treeNode3.Text = "系统菜单";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3});
            this.treeView1.Size = new System.Drawing.Size(198, 692);
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
            this.menuStrip1.Size = new System.Drawing.Size(1006, 29);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(51, 23);
            this.关于ToolStripMenuItem.Text = "关于";
            this.关于ToolStripMenuItem.Click += new System.EventHandler(this.关于ToolStripMenuItem_Click);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(51, 23);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // cTabInvoiceManager
            // 
            this.cTabInvoiceManager.Controls.Add(this.cTabPageInvoiceImport);
            this.cTabInvoiceManager.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cTabInvoiceManager.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cTabInvoiceManager.Location = new System.Drawing.Point(198, 29);
            this.cTabInvoiceManager.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.cTabInvoiceManager.Name = "cTabInvoiceManager";
            this.cTabInvoiceManager.SelectedIndex = 0;
            this.cTabInvoiceManager.Size = new System.Drawing.Size(808, 692);
            this.cTabInvoiceManager.TabIndex = 2;
            // 
            // cTabPageInvoiceImport
            // 
            this.cTabPageInvoiceImport.Controls.Add(this.groupBox1);
            this.cTabPageInvoiceImport.Controls.Add(this.panel2);
            this.cTabPageInvoiceImport.Location = new System.Drawing.Point(4, 36);
            this.cTabPageInvoiceImport.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.cTabPageInvoiceImport.Name = "cTabPageInvoiceImport";
            this.cTabPageInvoiceImport.Size = new System.Drawing.Size(800, 652);
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
            this.groupBox1.Size = new System.Drawing.Size(800, 541);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "导入内容主体";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 32);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(794, 504);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
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
            this.cCbDocList.ItemHeight = 27;
            this.cCbDocList.Location = new System.Drawing.Point(14, 62);
            this.cCbDocList.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.cCbDocList.Name = "cCbDocList";
            this.cCbDocList.Size = new System.Drawing.Size(467, 35);
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
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 27F);
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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button cBtnExport;
        private System.Windows.Forms.Button cBtnImportEnd;
        private System.Windows.Forms.Button cBtnImportStart;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ComboBox cCbDocList;
        private System.Windows.Forms.Button cBtnDeleteDoc;
    }
}

