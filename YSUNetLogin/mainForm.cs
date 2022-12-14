using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.IO;
using Newtonsoft.Json.Linq;

namespace YSUNetLogin
{
    public partial class MainForm : Form
    {
        private NetLogin netLogin = new NetLogin();
        private int loginType = 0; // 0校园网、1中国移动、2中国联通、3中国电信
        public MainForm()
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
            listBoxMessage.Items.Add(res.Item1 ? "login succeed" : "login failed");
            listBoxMessage.Items.Add(res.Item2);
            LoginLogoutButtonSet();
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader("config.json");
            JObject jb = JObject.Parse(sr.ReadToEnd());
            sr.Close();

            textBoxUsername.Text = jb.SelectToken("username").ToObject<string>();
            textBoxPassword.Text = jb.SelectToken("password").ToObject<string>();
            loginType = jb.SelectToken("loginType").ToObject<int>();

            SetLoginType(loginType);
            LoginLogoutButtonSet();
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

        private void LoginLogoutButtonSet()
        {
            if (netLogin.IsNetAuthorized())
            {
                buttonLogin.Enabled = false;
                buttonLogout.Enabled = true;
            }
            else
            {
                buttonLogin.Enabled = true;
                buttonLogout.Enabled = false;
            }
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            var res = netLogin.Logout();
            listBoxMessage.Items.Add(res.Item1 ? "logout succeed" : "logout failed");
            listBoxMessage.Items.Add(res.Item2);
            LoginLogoutButtonSet();
        }

        private void refreshRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var jb = netLogin.GetUserData();
            LoginLogoutButtonSet();
            MessageBox.Show(string.Format("username: {0}\nuserid: {1}\nisonline: {2}", netLogin.GetUsername(), netLogin.GetUserId(), netLogin.IsNetAuthorized()));
        }

        private void licenseSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.gnu.org/licenses/old-licenses/gpl-2.0.html");
        }

        private void aboutAToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form aboForm = new AboutBox();
            aboForm.ShowDialog();
        }

        private void saveSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            JObject jb = new JObject();
            jb.Add("username", textBoxUsername.Text);
            jb.Add("password", textBoxPassword.Text);
            jb.Add("loginType", loginType);

            StreamWriter sw = new StreamWriter("config.json");
            sw.WriteLine(jb.ToString());
            sw.Close();
        }
    }
}
