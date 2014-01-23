using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace XlsMerger
{
    public partial class RegistryForm : Form
    {
        public RegistryForm()
        {
            InitializeComponent();
            cTxtRegKey.ReadOnly = true;
        }
        
        private void RegistryForm_Load(object sender, EventArgs e)
        {
            cTxtRegKey.Text = Program.registry.RegNum;
        }

        private void cBtn_Trial_Click(object sender, EventArgs e)
        {
            MessageBox.Show("试用版将受到功能限制，欢迎购买正版","试用版");
            Program.systemRegistryStatus = Program.SystemRegistryStatus.NotRegisted;
            this.Close();
        }

        private void cBtn_Registry_Click(object sender, EventArgs e)
        {
            if (!Program.registry.checkPass(cTxtPassword.Text))
            {
                MessageBox.Show("您的注册名或密码不正确！请与供应商联系！", "体统提示");
            }
            else {
                Program.registry.regist();
                MessageBox.Show("注册成功！欢迎试用！", "注册成功");
                Program.systemRegistryStatus = Program.SystemRegistryStatus.Registed;
                this.Close();
            }
        }

        private void RegistryForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void cTxtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) {
                this.cBtn_Registry_Click(null, null);
            }
        }
    }
}
