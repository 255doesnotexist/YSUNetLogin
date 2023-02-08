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
        Timer timerCheck = new Timer();
        public MainForm()
        {
            InitializeComponent();
        }

        private void exitEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void LoginWithArgs(string un, string pw, int tp)
        {
            var res = await netLogin.LoginAsync(un, pw, tp);
            listBoxMessage.Items.Add(res.Item1 ? "login succeed" : "login failed");
            listBoxMessage.Items.Add(res.Item2);
            LoginLogoutButtonSet();
        }
        private void LoginWithUserInput()
        {
            LoginWithArgs(textBoxUsername.Text, textBoxPassword.Text, loginType);
            LoginLogoutButtonSet();
        }
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            LoginWithUserInput();
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            JObject jb = new JObject();
            try
            {
                StreamReader sr = new StreamReader("config.json");
                jb = JObject.Parse(sr.ReadToEnd());
                sr.Close();

                textBoxUsername.Text = jb.SelectToken("username").ToObject<string>();
                textBoxPassword.Text = jb.SelectToken("password").ToObject<string>();
                loginType = jb.SelectToken("loginType").ToObject<int>();
            }
            catch (Exception ex)
            {
                // 无配置
                if (netLogin.IsNetAuthorized())
                {
                    textBoxUsername.Text = netLogin.GetUserId();
                    textBoxPassword.Text = netLogin.GetPassword();
                }
            }

            try
            {
                textBoxCheckInterval.Text =
                    Convert.ToString(jb.SelectToken("checkInterval").ToObject<double>());
            }
            catch (Exception ex)
            {
                timerCheck.Interval = 15000;
            }

            try
            {
                autoReconnectToolStripMenuItem.Checked =
                    jb.SelectToken("autoReconnect").ToObject<bool>();
            }
            catch (Exception ex)
            {
                timerCheck.Interval = 15000;
            }

            SetLoginType(loginType);
            LoginLogoutButtonSet();


            timerCheck.Enabled = true;
            timerCheck.Tick += timerCheck_Tick;
        }

        private async void SetLoginType(int type)
        {
            bool needRelogin = (type != loginType);

            loginType = type;

            if (needRelogin)
            {
                string un = await netLogin.GetUserIdAsync();
                string pw = await netLogin.GetPasswordAsync();
                netLogin.Logout();
                LoginWithArgs(un,pw,loginType);
            }

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

        private async void LoginLogoutButtonSet()
        {
            if (await netLogin.IsNetAuthorizedAsync())
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

        private async void buttonLogout_Click(object sender, EventArgs e)
        {
            var res = await netLogin.LogoutAsync();
            listBoxMessage.Items.Add(res.Item1 ? "logout succeed" : "logout failed");
            listBoxMessage.Items.Add(res.Item2);
            LoginLogoutButtonSet();
        }

        private async void refreshRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var jb = await netLogin.GetUserDataAsync();
            LoginLogoutButtonSet();

            netLogin.GetUserData();
            Clipboard.SetText(netLogin.GetUserData().ToString());

            string msg = "json data copied to clipboard\n\n";
            msg += (string.Format("username: {0}\n", netLogin.GetUsername()));
            msg += (string.Format("userIndex: {0}\n", netLogin.GetUserIndex()));
            msg += (string.Format("userid: {0}\n", netLogin.GetUserId()));
            msg += (string.Format("userip: {0}\n", netLogin.GetUserIp()));
            msg += (string.Format("usermac: {0}\n", netLogin.GetUserMac()));
            msg += (string.Format("encrypted password: {0}\n", netLogin.GetPassword()));
            msg += (string.Format("isonline: {0}\n\n", netLogin.IsNetAuthorized()));

            BallInfo bi = new BallInfo(netLogin.GetBallInfo());

            msg += (string.Format("data package plan: {0}MB\n", bi.DataPackage / 1024 / 1024));
            msg += (string.Format("online device count: {0}\n", bi.OnlineDeviceCount));
            msg += (string.Format("money: {0}\n", bi.Money));
            msg += (string.Format("isp: {0}\n", bi.ISP));

            MessageBox.Show(msg);
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
            jb.Add("checkInterval", textBoxCheckInterval.Text);
            jb.Add("autoReconnect", IsAutoReconnect());

            StreamWriter sw = new StreamWriter("config.json");
            sw.WriteLine(jb.ToString());
            sw.Close();
        }

        private void autoReconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            autoReconnectToolStripMenuItem.Checked = !autoReconnectToolStripMenuItem.Checked;
        }

        private bool IsAutoReconnect()
        {
            return autoReconnectToolStripMenuItem.Checked;
        }

        private void timerCheck_Tick(object sender, EventArgs e)
        {
            if (!netLogin.IsNetAuthorized())
            { 
                listBoxMessage.Items.Add("unexpectedly disconnected");
                if (IsAutoReconnect())
                {
                    listBoxMessage.Items.Add("try auto-reconnecting");
                    LoginWithUserInput();
                }
            }
        }

        private void textBoxCheckFrequency_TextChanged(object sender, EventArgs e)
        {
            double freqTime = 15;
            double.TryParse(textBoxCheckInterval.Text, out freqTime);

            if (freqTime >= 0.5 && freqTime <= 3600 * 24)
            {
                timerCheck.Interval = Convert.ToInt32(freqTime * 1000);
            }
            else
            {
                listBoxMessage.Items.Add("check interval must be in [0.5s, 24hr]");
            }
        }
    }
}
