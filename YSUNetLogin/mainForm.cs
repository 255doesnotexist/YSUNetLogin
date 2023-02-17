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
using System.Runtime.CompilerServices;
using Newtonsoft.Json.Linq;

namespace YSUNetLogin
{
    public partial class MainForm : Form
    {
        private NetLogin netLogin = new NetLogin();
        private int loginType = 0; // 0校园网、1中国移动、2中国联通、3中国电信 
        Timer timerCheck = new Timer();
        private ListLogger logger = null;
        public MainForm()
        {
            InitializeComponent();
            logger = new ListLogger(listBoxMessage);
        }

        private void exitEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void LoginWithArgs(string un, string pw, int tp)
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                var res = await netLogin.LoginAsync(un, pw, tp);
                logger.InfoLog(res.Item1 ? "login succeed" : "login failed");

                if (res.Item1)
                {
                    logger.InfoLog(res.Item2);
                }
                else
                {
                    logger.ErrorLog(res.Item2);
                }

                LoginLogoutButtonSet();
            }
            catch (Exception ex)
            {
                logger.FatalLog(ex.Message);
            }

            this.Cursor = Cursors.Default;
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
                autoReconnectToolStripMenuItem.Checked =
                    jb.SelectToken("autoReconnect").ToObject<bool>();
            }
            catch (Exception ex)
            {
                autoReconnectToolStripMenuItem.Checked = false;
            }

            try
            {
                textBoxHttpTimeout.Text =
                    jb.SelectToken("httpTimeout").ToObject<string>();
                SetHttpClientTimeout(jb.SelectToken("httpTimeout").ToObject<double>());
            }
            catch (Exception ex)
            {
                textBoxHttpTimeout.Text = "3";
                SetHttpClientTimeout(3);
            }

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
                try
                {
                    // 无配置
                    if (netLogin.IsNetAuthorized())
                    {
                        textBoxUsername.Text = netLogin.GetUserId();
                        textBoxPassword.Text = netLogin.GetPassword();
                    }
                }
                catch (Exception ex2)
                {
                    logger.ErrorLog("information auto-filling failed");
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

            SetLoginType(loginType);
            LoginLogoutButtonSet();
            
            timerCheck.Tick += timerCheck_Tick;
            timerCheck.Start();
        }

        private async void SetLoginType(int type)
        {
            bool needRelogin = (type != loginType);

            loginType = type;

            if (needRelogin)
            {
                this.buttonLogout_Click(null, null);
                this.buttonLogin_Click(null, null);
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

        private bool GUILogined = false;
        private async void LoginLogoutButtonSet()
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                if (await netLogin.IsNetAuthorizedAsync())
                {
                    buttonLogin.Enabled = false;
                    buttonLogout.Enabled = true;

                    GUILogined = true;
                }
                else
                {
                    buttonLogin.Enabled = true;
                    buttonLogout.Enabled = false;

                    GUILogined = false;
                }
            }
            catch (Exception ex)
            {
                logger.FatalLog(ex.Message);
            }
            
            this.Cursor = Cursors.Default;
        }

        private async void buttonLogout_Click(object sender, EventArgs e)
        {
            try
            {
                var res = await netLogin.LogoutAsync();

                logger.InfoLog(res.Item1 ? "logout succeed" : "logout failed");

                if (res.Item1)
                {
                    logger.InfoLog(res.Item2);
                }
                else
                {
                    logger.ErrorLog(res.Item2);
                }

                LoginLogoutButtonSet();
            }
            catch (Exception ex)
            {
                logger.FatalLog(ex.Message);
            }
        }

        private async void refreshRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string msg = "";
            try
            {
                var jb = await netLogin.GetUserDataAsync();
                LoginLogoutButtonSet();

                netLogin.GetUserData();
                Clipboard.SetText(netLogin.GetUserData().ToString());

                msg = "json data copied to clipboard\n\n";
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
            }
            catch (Exception ex)
            {
                msg = "cannot connect to auth server\n\n";
                msg += ex.ToString();
            }

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
            jb.Add("autoReconnect", IsAutoReconnectEnabled());
            jb.Add("httpTimeout", textBoxHttpTimeout.Text);

            StreamWriter sw = new StreamWriter("config.json");
            sw.WriteLine(jb.ToString());
            sw.Close();
        }

        private void autoReconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            autoReconnectToolStripMenuItem.Checked = !autoReconnectToolStripMenuItem.Checked;
        }

        private bool IsAutoReconnectEnabled()
        {
            return autoReconnectToolStripMenuItem.Checked;
        }

        private DateTime lastTimerErrorTime = DateTime.MinValue;
        private void timerCheck_Tick(object sender, EventArgs e)
        {
            if (DateTime.Now - lastTimerErrorTime < TimeSpan.FromSeconds(1))
            {
                return;
            }

            try
            {
                if (!netLogin.IsNetAuthorized())
                {
                    if (GUILogined)
                    {
                        logger.WarnLog("unexpectedly disconnected");
                        LoginLogoutButtonSet();
                    }

                    if (IsAutoReconnectEnabled())
                    {
                        logger.InfoLog("try auto-reconnecting");
                        LoginWithUserInput();
                    }
                    
                }
            }
            catch (Exception ex)
            {
                logger.FatalLog(ex.Message);
                lastTimerErrorTime = DateTime.Now;
                logger.InfoLog("waiting for 1s since last fatal error");
            }
        }

        private void textBoxCheckFrequency_TextChanged(object sender, EventArgs e)
        {
            double freqTime = 15;
            double.TryParse(textBoxCheckInterval.Text, out freqTime);

            if (freqTime >= 0.5 && freqTime <= 3600 * 24)
            {
                timerCheck.Interval = (int)TimeSpan.FromSeconds(freqTime).TotalMilliseconds;
                timerCheck.Stop(); timerCheck.Start();
            }
            else
            {
                logger.ErrorLog("check interval must be in [0.5s, 24hr]");
            }

        }

        private void SetHttpClientTimeout(double timesp)
        {
            CommonUtils.HttpClientTimeout = TimeSpan.FromSeconds(timesp);
        }
        private void textBoxHttpTimeout_TextChanged(object sender, EventArgs e)
        {
            double timesp;
            double.TryParse(textBoxHttpTimeout.Text, out timesp);
            SetHttpClientTimeout(timesp);
        }
    }
}
