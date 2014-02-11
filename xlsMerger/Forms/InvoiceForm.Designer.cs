namespace XlsMerger.Forms
{
    partial class InvoiceForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvoiceForm));
			this.cListboxDj = new System.Windows.Forms.ListBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.cBtnReturn = new System.Windows.Forms.Button();
			this.cBtnSave = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.cTxtInvoiceNr = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.cTxtRq = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.cTxtDjh = new System.Windows.Forms.TextBox();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// cListboxDj
			// 
			this.cListboxDj.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cListboxDj.Font = new System.Drawing.Font("SimSun", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.cListboxDj.FormattingEnabled = true;
			this.cListboxDj.ItemHeight = 18;
			this.cListboxDj.Location = new System.Drawing.Point(0, 0);
			this.cListboxDj.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.cListboxDj.Name = "cListboxDj";
			this.cListboxDj.Size = new System.Drawing.Size(774, 416);
			this.cListboxDj.TabIndex = 0;
			this.cListboxDj.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.cBtnReturn);
			this.panel1.Controls.Add(this.cBtnSave);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.cTxtInvoiceNr);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.cTxtRq);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.cTxtDjh);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
			this.panel1.Location = new System.Drawing.Point(323, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(451, 416);
			this.panel1.TabIndex = 0;
			// 
			// cBtnReturn
			// 
			this.cBtnReturn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cBtnReturn.Location = new System.Drawing.Point(306, 349);
			this.cBtnReturn.Name = "cBtnReturn";
			this.cBtnReturn.Size = new System.Drawing.Size(115, 39);
			this.cBtnReturn.TabIndex = 16;
			this.cBtnReturn.Text = "返回";
			this.cBtnReturn.UseVisualStyleBackColor = true;
			// 
			// cBtnSave
			// 
			this.cBtnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.cBtnSave.Location = new System.Drawing.Point(173, 349);
			this.cBtnSave.Name = "cBtnSave";
			this.cBtnSave.Size = new System.Drawing.Size(115, 39);
			this.cBtnSave.TabIndex = 15;
			this.cBtnSave.Text = "保存";
			this.cBtnSave.UseVisualStyleBackColor = true;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("SimSun", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label3.Location = new System.Drawing.Point(18, 279);
			this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(85, 19);
			this.label3.TabIndex = 14;
			this.label3.Text = "发票号：";
			// 
			// cTxtInvoiceNr
			// 
			this.cTxtInvoiceNr.Font = new System.Drawing.Font("SimSun", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.cTxtInvoiceNr.Location = new System.Drawing.Point(132, 276);
			this.cTxtInvoiceNr.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.cTxtInvoiceNr.Name = "cTxtInvoiceNr";
			this.cTxtInvoiceNr.Size = new System.Drawing.Size(289, 28);
			this.cTxtInvoiceNr.TabIndex = 13;
			this.cTxtInvoiceNr.Leave += new System.EventHandler(this.cTxtInvoiceNr_Leave);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("SimSun", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label2.Location = new System.Drawing.Point(18, 76);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(66, 19);
			this.label2.TabIndex = 12;
			this.label2.Text = "日期：";
			// 
			// cTxtRq
			// 
			this.cTxtRq.Font = new System.Drawing.Font("SimSun", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.cTxtRq.Location = new System.Drawing.Point(132, 73);
			this.cTxtRq.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.cTxtRq.Name = "cTxtRq";
			this.cTxtRq.ReadOnly = true;
			this.cTxtRq.Size = new System.Drawing.Size(289, 28);
			this.cTxtRq.TabIndex = 11;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("SimSun", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label1.Location = new System.Drawing.Point(18, 32);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(85, 19);
			this.label1.TabIndex = 10;
			this.label1.Text = "单据号：";
			// 
			// cTxtDjh
			// 
			this.cTxtDjh.Font = new System.Drawing.Font("SimSun", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.cTxtDjh.Location = new System.Drawing.Point(132, 29);
			this.cTxtDjh.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.cTxtDjh.Name = "cTxtDjh";
			this.cTxtDjh.ReadOnly = true;
			this.cTxtDjh.Size = new System.Drawing.Size(289, 28);
			this.cTxtDjh.TabIndex = 9;
			// 
			// InvoiceForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(774, 416);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.cListboxDj);
			this.Font = new System.Drawing.Font("SimSun", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "InvoiceForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "设置打印发票号";
			this.TopMost = true;
			this.Load += new System.EventHandler(this.InvoiceForm_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

		private System.Windows.Forms.ListBox cListboxDj;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button cBtnReturn;
		private System.Windows.Forms.Button cBtnSave;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox cTxtInvoiceNr;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox cTxtRq;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox cTxtDjh;
    }
}