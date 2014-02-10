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
            this.cTxtDjh = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cTxtRq = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cTxtInvoiceNr = new System.Windows.Forms.TextBox();
            this.cBtnSave = new System.Windows.Forms.Button();
            this.cBtnReturn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cListboxDj
            // 
            this.cListboxDj.Dock = System.Windows.Forms.DockStyle.Left;
            this.cListboxDj.Font = new System.Drawing.Font("SimSun", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cListboxDj.FormattingEnabled = true;
            this.cListboxDj.ItemHeight = 23;
            this.cListboxDj.Location = new System.Drawing.Point(0, 0);
            this.cListboxDj.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cListboxDj.Name = "cListboxDj";
            this.cListboxDj.Size = new System.Drawing.Size(389, 416);
            this.cListboxDj.TabIndex = 0;
            this.cListboxDj.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // cTxtDjh
            // 
            this.cTxtDjh.Font = new System.Drawing.Font("SimSun", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cTxtDjh.Location = new System.Drawing.Point(526, 32);
            this.cTxtDjh.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cTxtDjh.Name = "cTxtDjh";
            this.cTxtDjh.ReadOnly = true;
            this.cTxtDjh.Size = new System.Drawing.Size(289, 34);
            this.cTxtDjh.TabIndex = 1;
            this.cTxtDjh.TextChanged += new System.EventHandler(this.cInvoiceDjh_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("SimSun", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(412, 35);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "单据号：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("SimSun", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(412, 79);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 24);
            this.label2.TabIndex = 4;
            this.label2.Text = "日期：";
            // 
            // cTxtRq
            // 
            this.cTxtRq.Font = new System.Drawing.Font("SimSun", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cTxtRq.Location = new System.Drawing.Point(526, 76);
            this.cTxtRq.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cTxtRq.Name = "cTxtRq";
            this.cTxtRq.ReadOnly = true;
            this.cTxtRq.Size = new System.Drawing.Size(289, 34);
            this.cTxtRq.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("SimSun", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(412, 282);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 24);
            this.label3.TabIndex = 6;
            this.label3.Text = "发票号：";
            // 
            // cTxtInvoiceNr
            // 
            this.cTxtInvoiceNr.Font = new System.Drawing.Font("SimSun", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cTxtInvoiceNr.Location = new System.Drawing.Point(526, 279);
            this.cTxtInvoiceNr.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cTxtInvoiceNr.Name = "cTxtInvoiceNr";
            this.cTxtInvoiceNr.Size = new System.Drawing.Size(289, 34);
            this.cTxtInvoiceNr.TabIndex = 5;
            this.cTxtInvoiceNr.Leave += new System.EventHandler(this.cTxtInvoiceNr_Leave);
            // 
            // cBtnSave
            // 
            this.cBtnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cBtnSave.Location = new System.Drawing.Point(567, 352);
            this.cBtnSave.Name = "cBtnSave";
            this.cBtnSave.Size = new System.Drawing.Size(115, 39);
            this.cBtnSave.TabIndex = 7;
            this.cBtnSave.Text = "保存";
            this.cBtnSave.UseVisualStyleBackColor = true;
            // 
            // cBtnReturn
            // 
            this.cBtnReturn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cBtnReturn.Location = new System.Drawing.Point(700, 352);
            this.cBtnReturn.Name = "cBtnReturn";
            this.cBtnReturn.Size = new System.Drawing.Size(115, 39);
            this.cBtnReturn.TabIndex = 8;
            this.cBtnReturn.Text = "返回";
            this.cBtnReturn.UseVisualStyleBackColor = true;
            // 
            // InvoiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 416);
            this.Controls.Add(this.cBtnReturn);
            this.Controls.Add(this.cBtnSave);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cTxtInvoiceNr);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cTxtRq);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cTxtDjh);
            this.Controls.Add(this.cListboxDj);
            this.Font = new System.Drawing.Font("SimSun", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InvoiceForm";
            this.Text = "设置打印发票号";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.InvoiceForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox cListboxDj;
        private System.Windows.Forms.TextBox cTxtDjh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox cTxtRq;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox cTxtInvoiceNr;
        private System.Windows.Forms.Button cBtnSave;
        private System.Windows.Forms.Button cBtnReturn;
    }
}