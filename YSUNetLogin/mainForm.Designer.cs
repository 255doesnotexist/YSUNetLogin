namespace YSUNetLogin
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.fileFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.channelCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cERNETCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chinaMobileMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chinaUnicomUToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chinaTelecomTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tokenTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshRToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoReconnectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.licenseSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutAToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageLogin = new System.Windows.Forms.TabPage();
            this.tableLayoutPanelLogin = new System.Windows.Forms.TableLayoutPanel();
            this.labelUsername = new System.Windows.Forms.Label();
            this.labelPassword = new System.Windows.Forms.Label();
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.listBoxMessage = new System.Windows.Forms.ListBox();
            this.buttonLogout = new System.Windows.Forms.Button();
            this.tabPageSettings = new System.Windows.Forms.TabPage();
            this.tableLayoutSettings = new System.Windows.Forms.TableLayoutPanel();
            this.labelCheckFrequency = new System.Windows.Forms.Label();
            this.textBoxCheckInterval = new System.Windows.Forms.TextBox();
            this.menuStripMain.SuspendLayout();
            this.tabControlMain.SuspendLayout();
            this.tabPageLogin.SuspendLayout();
            this.tableLayoutPanelLogin.SuspendLayout();
            this.tabPageSettings.SuspendLayout();
            this.tableLayoutSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStripMain
            // 
            this.menuStripMain.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStripMain.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileFToolStripMenuItem,
            this.channelCToolStripMenuItem,
            this.tokenTToolStripMenuItem,
            this.aboutAToolStripMenuItem});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(963, 39);
            this.menuStripMain.TabIndex = 0;
            this.menuStripMain.Text = "menuStrip1";
            // 
            // fileFToolStripMenuItem
            // 
            this.fileFToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveSToolStripMenuItem,
            this.exitEToolStripMenuItem});
            this.fileFToolStripMenuItem.Name = "fileFToolStripMenuItem";
            this.fileFToolStripMenuItem.Size = new System.Drawing.Size(102, 35);
            this.fileFToolStripMenuItem.Text = "File(&F)";
            // 
            // saveSToolStripMenuItem
            // 
            this.saveSToolStripMenuItem.Name = "saveSToolStripMenuItem";
            this.saveSToolStripMenuItem.Size = new System.Drawing.Size(231, 44);
            this.saveSToolStripMenuItem.Text = "Save(&S)";
            this.saveSToolStripMenuItem.Click += new System.EventHandler(this.saveSToolStripMenuItem_Click);
            // 
            // exitEToolStripMenuItem
            // 
            this.exitEToolStripMenuItem.Name = "exitEToolStripMenuItem";
            this.exitEToolStripMenuItem.Size = new System.Drawing.Size(231, 44);
            this.exitEToolStripMenuItem.Text = "Exit(&E)";
            this.exitEToolStripMenuItem.Click += new System.EventHandler(this.exitEToolStripMenuItem_Click);
            // 
            // channelCToolStripMenuItem
            // 
            this.channelCToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cERNETCToolStripMenuItem,
            this.chinaMobileMToolStripMenuItem,
            this.chinaUnicomUToolStripMenuItem,
            this.chinaTelecomTToolStripMenuItem});
            this.channelCToolStripMenuItem.Name = "channelCToolStripMenuItem";
            this.channelCToolStripMenuItem.Size = new System.Drawing.Size(160, 35);
            this.channelCToolStripMenuItem.Text = "Channel(&C)";
            // 
            // cERNETCToolStripMenuItem
            // 
            this.cERNETCToolStripMenuItem.Name = "cERNETCToolStripMenuItem";
            this.cERNETCToolStripMenuItem.Size = new System.Drawing.Size(346, 44);
            this.cERNETCToolStripMenuItem.Text = "CERNET(&C)";
            this.cERNETCToolStripMenuItem.Click += new System.EventHandler(this.cERNETCToolStripMenuItem_Click);
            // 
            // chinaMobileMToolStripMenuItem
            // 
            this.chinaMobileMToolStripMenuItem.Name = "chinaMobileMToolStripMenuItem";
            this.chinaMobileMToolStripMenuItem.Size = new System.Drawing.Size(346, 44);
            this.chinaMobileMToolStripMenuItem.Text = "China Mobile(&M)";
            this.chinaMobileMToolStripMenuItem.Click += new System.EventHandler(this.chinaMobileMToolStripMenuItem_Click);
            // 
            // chinaUnicomUToolStripMenuItem
            // 
            this.chinaUnicomUToolStripMenuItem.Name = "chinaUnicomUToolStripMenuItem";
            this.chinaUnicomUToolStripMenuItem.Size = new System.Drawing.Size(346, 44);
            this.chinaUnicomUToolStripMenuItem.Text = "China Unicom(&U)";
            this.chinaUnicomUToolStripMenuItem.Click += new System.EventHandler(this.chinaUnicomUToolStripMenuItem_Click);
            // 
            // chinaTelecomTToolStripMenuItem
            // 
            this.chinaTelecomTToolStripMenuItem.Name = "chinaTelecomTToolStripMenuItem";
            this.chinaTelecomTToolStripMenuItem.Size = new System.Drawing.Size(346, 44);
            this.chinaTelecomTToolStripMenuItem.Text = "China Telecom(&T)";
            this.chinaTelecomTToolStripMenuItem.Click += new System.EventHandler(this.chinaTelecomTToolStripMenuItem_Click);
            // 
            // tokenTToolStripMenuItem
            // 
            this.tokenTToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshRToolStripMenuItem,
            this.autoReconnectToolStripMenuItem});
            this.tokenTToolStripMenuItem.Name = "tokenTToolStripMenuItem";
            this.tokenTToolStripMenuItem.Size = new System.Drawing.Size(135, 35);
            this.tokenTToolStripMenuItem.Text = "Token(&T)";
            // 
            // refreshRToolStripMenuItem
            // 
            this.refreshRToolStripMenuItem.Name = "refreshRToolStripMenuItem";
            this.refreshRToolStripMenuItem.Size = new System.Drawing.Size(364, 44);
            this.refreshRToolStripMenuItem.Text = "Refresh Status(&S)";
            this.refreshRToolStripMenuItem.Click += new System.EventHandler(this.refreshRToolStripMenuItem_Click);
            // 
            // autoReconnectToolStripMenuItem
            // 
            this.autoReconnectToolStripMenuItem.Name = "autoReconnectToolStripMenuItem";
            this.autoReconnectToolStripMenuItem.Size = new System.Drawing.Size(364, 44);
            this.autoReconnectToolStripMenuItem.Text = "Auto Reconnect(&R)";
            this.autoReconnectToolStripMenuItem.Click += new System.EventHandler(this.autoReconnectToolStripMenuItem_Click);
            // 
            // aboutAToolStripMenuItem
            // 
            this.aboutAToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.licenseSToolStripMenuItem,
            this.aboutAToolStripMenuItem1});
            this.aboutAToolStripMenuItem.Name = "aboutAToolStripMenuItem";
            this.aboutAToolStripMenuItem.Size = new System.Drawing.Size(138, 35);
            this.aboutAToolStripMenuItem.Text = "About(&A)";
            // 
            // licenseSToolStripMenuItem
            // 
            this.licenseSToolStripMenuItem.Name = "licenseSToolStripMenuItem";
            this.licenseSToolStripMenuItem.Size = new System.Drawing.Size(269, 44);
            this.licenseSToolStripMenuItem.Text = "License(&S)";
            this.licenseSToolStripMenuItem.Click += new System.EventHandler(this.licenseSToolStripMenuItem_Click);
            // 
            // aboutAToolStripMenuItem1
            // 
            this.aboutAToolStripMenuItem1.Name = "aboutAToolStripMenuItem1";
            this.aboutAToolStripMenuItem1.Size = new System.Drawing.Size(269, 44);
            this.aboutAToolStripMenuItem1.Text = "About...(&A)";
            this.aboutAToolStripMenuItem1.Click += new System.EventHandler(this.aboutAToolStripMenuItem1_Click);
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabPageLogin);
            this.tabControlMain.Controls.Add(this.tabPageSettings);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Location = new System.Drawing.Point(0, 39);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(963, 287);
            this.tabControlMain.TabIndex = 1;
            // 
            // tabPageLogin
            // 
            this.tabPageLogin.Controls.Add(this.tableLayoutPanelLogin);
            this.tabPageLogin.Location = new System.Drawing.Point(8, 39);
            this.tabPageLogin.Name = "tabPageLogin";
            this.tabPageLogin.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLogin.Size = new System.Drawing.Size(947, 240);
            this.tabPageLogin.TabIndex = 0;
            this.tabPageLogin.Text = "Login";
            this.tabPageLogin.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelLogin
            // 
            this.tableLayoutPanelLogin.ColumnCount = 4;
            this.tableLayoutPanelLogin.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanelLogin.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelLogin.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelLogin.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanelLogin.Controls.Add(this.labelUsername, 0, 0);
            this.tableLayoutPanelLogin.Controls.Add(this.labelPassword, 0, 1);
            this.tableLayoutPanelLogin.Controls.Add(this.textBoxUsername, 1, 0);
            this.tableLayoutPanelLogin.Controls.Add(this.textBoxPassword, 1, 1);
            this.tableLayoutPanelLogin.Controls.Add(this.buttonLogin, 1, 2);
            this.tableLayoutPanelLogin.Controls.Add(this.listBoxMessage, 3, 0);
            this.tableLayoutPanelLogin.Controls.Add(this.buttonLogout, 2, 2);
            this.tableLayoutPanelLogin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelLogin.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanelLogin.Name = "tableLayoutPanelLogin";
            this.tableLayoutPanelLogin.RowCount = 4;
            this.tableLayoutPanelLogin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanelLogin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanelLogin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanelLogin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelLogin.Size = new System.Drawing.Size(941, 234);
            this.tableLayoutPanelLogin.TabIndex = 0;
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelUsername.Location = new System.Drawing.Point(3, 0);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(114, 60);
            this.labelUsername.TabIndex = 0;
            this.labelUsername.Text = "Username";
            this.labelUsername.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelPassword.Location = new System.Drawing.Point(3, 60);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(114, 60);
            this.labelPassword.TabIndex = 1;
            this.labelPassword.Text = "Password";
            this.labelPassword.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // textBoxUsername
            // 
            this.tableLayoutPanelLogin.SetColumnSpan(this.textBoxUsername, 2);
            this.textBoxUsername.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxUsername.Location = new System.Drawing.Point(123, 3);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(322, 35);
            this.textBoxUsername.TabIndex = 2;
            // 
            // textBoxPassword
            // 
            this.tableLayoutPanelLogin.SetColumnSpan(this.textBoxPassword, 2);
            this.textBoxPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxPassword.Location = new System.Drawing.Point(123, 63);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(322, 35);
            this.textBoxPassword.TabIndex = 3;
            // 
            // buttonLogin
            // 
            this.buttonLogin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonLogin.Location = new System.Drawing.Point(123, 123);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(158, 74);
            this.buttonLogin.TabIndex = 4;
            this.buttonLogin.Text = "Login";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // listBoxMessage
            // 
            this.listBoxMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxMessage.FormattingEnabled = true;
            this.listBoxMessage.ItemHeight = 24;
            this.listBoxMessage.Location = new System.Drawing.Point(451, 3);
            this.listBoxMessage.Name = "listBoxMessage";
            this.tableLayoutPanelLogin.SetRowSpan(this.listBoxMessage, 4);
            this.listBoxMessage.Size = new System.Drawing.Size(487, 228);
            this.listBoxMessage.TabIndex = 5;
            // 
            // buttonLogout
            // 
            this.buttonLogout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonLogout.Location = new System.Drawing.Point(287, 123);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(158, 74);
            this.buttonLogout.TabIndex = 6;
            this.buttonLogout.Text = "Logout";
            this.buttonLogout.UseVisualStyleBackColor = true;
            this.buttonLogout.Click += new System.EventHandler(this.buttonLogout_Click);
            // 
            // tabPageSettings
            // 
            this.tabPageSettings.Controls.Add(this.tableLayoutSettings);
            this.tabPageSettings.Location = new System.Drawing.Point(8, 39);
            this.tabPageSettings.Name = "tabPageSettings";
            this.tabPageSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSettings.Size = new System.Drawing.Size(947, 196);
            this.tabPageSettings.TabIndex = 1;
            this.tabPageSettings.Text = "Settings";
            this.tabPageSettings.UseVisualStyleBackColor = true;
            // 
            // tableLayoutSettings
            // 
            this.tableLayoutSettings.ColumnCount = 2;
            this.tableLayoutSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 360F));
            this.tableLayoutSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutSettings.Controls.Add(this.labelCheckFrequency, 0, 0);
            this.tableLayoutSettings.Controls.Add(this.textBoxCheckInterval, 1, 0);
            this.tableLayoutSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutSettings.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutSettings.Name = "tableLayoutSettings";
            this.tableLayoutSettings.RowCount = 2;
            this.tableLayoutSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutSettings.Size = new System.Drawing.Size(941, 190);
            this.tableLayoutSettings.TabIndex = 0;
            // 
            // labelCheckFrequency
            // 
            this.labelCheckFrequency.AutoSize = true;
            this.labelCheckFrequency.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelCheckFrequency.Location = new System.Drawing.Point(107, 0);
            this.labelCheckFrequency.Name = "labelCheckFrequency";
            this.labelCheckFrequency.Size = new System.Drawing.Size(250, 60);
            this.labelCheckFrequency.TabIndex = 0;
            this.labelCheckFrequency.Text = "Check Interval (sec)";
            // 
            // textBoxCheckInterval
            // 
            this.textBoxCheckInterval.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxCheckInterval.Location = new System.Drawing.Point(363, 3);
            this.textBoxCheckInterval.Name = "textBoxCheckInterval";
            this.textBoxCheckInterval.Size = new System.Drawing.Size(575, 35);
            this.textBoxCheckInterval.TabIndex = 1;
            this.textBoxCheckInterval.Text = "15";
            this.textBoxCheckInterval.TextChanged += new System.EventHandler(this.textBoxCheckFrequency_TextChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(963, 326);
            this.Controls.Add(this.tabControlMain);
            this.Controls.Add(this.menuStripMain);
            this.MainMenuStrip = this.menuStripMain;
            this.Name = "MainForm";
            this.Text = "YSUNetLogin";
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.tabControlMain.ResumeLayout(false);
            this.tabPageLogin.ResumeLayout(false);
            this.tableLayoutPanelLogin.ResumeLayout(false);
            this.tableLayoutPanelLogin.PerformLayout();
            this.tabPageSettings.ResumeLayout(false);
            this.tableLayoutSettings.ResumeLayout(false);
            this.tableLayoutSettings.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem fileFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tokenTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutAToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem licenseSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutAToolStripMenuItem1;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageLogin;
        private System.Windows.Forms.TabPage tabPageSettings;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelLogin;
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.ListBox listBoxMessage;
        private System.Windows.Forms.ToolStripMenuItem channelCToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cERNETCToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chinaMobileMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chinaUnicomUToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chinaTelecomTToolStripMenuItem;
        private System.Windows.Forms.Button buttonLogout;
        private System.Windows.Forms.ToolStripMenuItem refreshRToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveSToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutSettings;
        private System.Windows.Forms.Label labelCheckFrequency;
        private System.Windows.Forms.TextBox textBoxCheckInterval;
        private System.Windows.Forms.ToolStripMenuItem autoReconnectToolStripMenuItem;
    }
}

