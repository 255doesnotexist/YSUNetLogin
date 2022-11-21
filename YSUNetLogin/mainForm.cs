using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YSUNetLogin
{
    public partial class mainForm : Form
    {
        private NetLogin netLogin = new NetLogin();
        private int loginType = 0; // 0校园网、1中国移动、2中国联通、3中国电信
        public mainForm()
        {
            InitializeComponent();
        }

        private void exitEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            var res = netLogin.Login(textBoxUsername.Text, textBoxPassword.Text, loginType);
            listBoxMessage.Items.Add(res.Item1 ? "succeed" : "failed");
            listBoxMessage.Items.Add(res.Item2);
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            SetLoginType(0);
            string s = CommonUtils.HttpGet("http://auth.ysu.edu.cn", new string[] { });
        }

        private void SetLoginType(int type)
        {
            loginType = type;
            cERNETCToolStripMenuItem.Checked = false;
            chinaMobileMToolStripMenuItem.Checked = false;
            chinaUnicomUToolStripMenuItem.Checked = false;
            chinaTelecomTToolStripMenuItem.Checked = false;

            switch (type)
            {
                case 0:
                {
                    cERNETCToolStripMenuItem.Checked = true;
                    break;
                }
                case 1:
                {
                    chinaMobileMToolStripMenuItem.Checked = true;
                    break;
                }
                case 2:
                {
                    chinaUnicomUToolStripMenuItem.Checked = true;
                    break;
                }
                case 3:
                {
                    chinaTelecomTToolStripMenuItem.Checked = true;
                    break;
                }
            }
        }
        private void cERNETCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetLoginType(0);
        }

        private void chinaMobileMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetLoginType(1);
        }

        private void chinaUnicomUToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetLoginType(2);
        }

        private void chinaTelecomTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetLoginType(3);
        }
    }
}
