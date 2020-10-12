namespace SoloMatchmaking {
    partial class frmMain {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabDestiny = new System.Windows.Forms.TabPage();
            this.chkEnableDestinyHotkey = new System.Windows.Forms.CheckBox();
            this.lbDestinyHotkey = new System.Windows.Forms.Label();
            this.btnToggleDestiny = new System.Windows.Forms.Button();
            this.tabRockstar = new System.Windows.Forms.TabPage();
            this.chkEnableRockstarHotkey = new System.Windows.Forms.CheckBox();
            this.btnRemoveRockstarRange = new System.Windows.Forms.Button();
            this.btnAddRockstarRange = new System.Windows.Forms.Button();
            this.txtRockstarRange = new System.Windows.Forms.TextBox();
            this.lbRockstarRanges = new System.Windows.Forms.ListBox();
            this.lbRockstarHotkey = new System.Windows.Forms.Label();
            this.btnToggleRockstar = new System.Windows.Forms.Button();
            this.rtbRockstarInfo = new System.Windows.Forms.RichTextBox();
            this.tabConfiguration = new System.Windows.Forms.TabPage();
            this.rtbConfig = new System.Windows.Forms.RichTextBox();
            this.tabDebug = new System.Windows.Forms.TabPage();
            this.btnThrowError = new System.Windows.Forms.Button();
            this.lbIsAdmin = new System.Windows.Forms.Label();
            this.lbRockstarHotkeyActive = new System.Windows.Forms.Label();
            this.lbDestinyHotkeyActive = new System.Windows.Forms.Label();
            this.lbRockstarRulesActive = new System.Windows.Forms.Label();
            this.lbDestinyRulesActive = new System.Windows.Forms.Label();
            this.lbDestiny = new System.Windows.Forms.Label();
            this.lbRockstar = new System.Windows.Forms.Label();
            this.ttMain = new System.Windows.Forms.ToolTip(this.components);
            this.lbCurrentLanguageShort = new System.Windows.Forms.Label();
            this.cmsLanguageSelect = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiSelectLanguage = new System.Windows.Forms.ToolStripMenuItem();
            this.tscbLanguages = new System.Windows.Forms.ToolStripComboBox();
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.mSettings = new System.Windows.Forms.MenuItem();
            this.mGithub = new System.Windows.Forms.MenuItem();
            this.tabMain.SuspendLayout();
            this.tabDestiny.SuspendLayout();
            this.tabRockstar.SuspendLayout();
            this.tabConfiguration.SuspendLayout();
            this.tabDebug.SuspendLayout();
            this.cmsLanguageSelect.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabDestiny);
            this.tabMain.Controls.Add(this.tabRockstar);
            this.tabMain.Controls.Add(this.tabConfiguration);
            this.tabMain.Controls.Add(this.tabDebug);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 0);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(432, 273);
            this.tabMain.TabIndex = 0;
            // 
            // tabDestiny
            // 
            this.tabDestiny.Controls.Add(this.chkEnableDestinyHotkey);
            this.tabDestiny.Controls.Add(this.lbDestinyHotkey);
            this.tabDestiny.Controls.Add(this.btnToggleDestiny);
            this.tabDestiny.Location = new System.Drawing.Point(4, 22);
            this.tabDestiny.Name = "tabDestiny";
            this.tabDestiny.Padding = new System.Windows.Forms.Padding(3);
            this.tabDestiny.Size = new System.Drawing.Size(424, 247);
            this.tabDestiny.TabIndex = 0;
            this.tabDestiny.Text = "tabDestiny";
            this.tabDestiny.UseVisualStyleBackColor = true;
            // 
            // chkEnableDestinyHotkey
            // 
            this.chkEnableDestinyHotkey.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkEnableDestinyHotkey.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkEnableDestinyHotkey.Checked = true;
            this.chkEnableDestinyHotkey.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEnableDestinyHotkey.Enabled = false;
            this.chkEnableDestinyHotkey.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chkEnableDestinyHotkey.Location = new System.Drawing.Point(135, 51);
            this.chkEnableDestinyHotkey.Name = "chkEnableDestinyHotkey";
            this.chkEnableDestinyHotkey.Size = new System.Drawing.Size(160, 28);
            this.chkEnableDestinyHotkey.TabIndex = 2;
            this.chkEnableDestinyHotkey.Text = "chkEnableDestinyHotkey";
            this.chkEnableDestinyHotkey.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkEnableDestinyHotkey.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.chkEnableDestinyHotkey.UseVisualStyleBackColor = true;
            this.chkEnableDestinyHotkey.CheckedChanged += new System.EventHandler(this.chkEnableDestinyHotkey_CheckedChanged);
            // 
            // lbDestinyHotkey
            // 
            this.lbDestinyHotkey.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbDestinyHotkey.Location = new System.Drawing.Point(135, 136);
            this.lbDestinyHotkey.Name = "lbDestinyHotkey";
            this.lbDestinyHotkey.Size = new System.Drawing.Size(160, 24);
            this.lbDestinyHotkey.TabIndex = 1;
            this.lbDestinyHotkey.Text = "lbDestinyHotkey";
            this.lbDestinyHotkey.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ttMain.SetToolTip(this.lbDestinyHotkey, "ttMainChangeDestinyHotkey");
            this.lbDestinyHotkey.Click += new System.EventHandler(this.lbDestinyHotkey_Click);
            // 
            // btnToggleDestiny
            // 
            this.btnToggleDestiny.Enabled = false;
            this.btnToggleDestiny.Location = new System.Drawing.Point(135, 85);
            this.btnToggleDestiny.Name = "btnToggleDestiny";
            this.btnToggleDestiny.Size = new System.Drawing.Size(160, 48);
            this.btnToggleDestiny.TabIndex = 0;
            this.btnToggleDestiny.Text = "btnToggleDestiny";
            this.btnToggleDestiny.UseVisualStyleBackColor = true;
            this.btnToggleDestiny.Click += new System.EventHandler(this.btnToggleDestiny_Click);
            // 
            // tabRockstar
            // 
            this.tabRockstar.Controls.Add(this.chkEnableRockstarHotkey);
            this.tabRockstar.Controls.Add(this.btnRemoveRockstarRange);
            this.tabRockstar.Controls.Add(this.btnAddRockstarRange);
            this.tabRockstar.Controls.Add(this.txtRockstarRange);
            this.tabRockstar.Controls.Add(this.lbRockstarRanges);
            this.tabRockstar.Controls.Add(this.lbRockstarHotkey);
            this.tabRockstar.Controls.Add(this.btnToggleRockstar);
            this.tabRockstar.Controls.Add(this.rtbRockstarInfo);
            this.tabRockstar.Location = new System.Drawing.Point(4, 22);
            this.tabRockstar.Name = "tabRockstar";
            this.tabRockstar.Padding = new System.Windows.Forms.Padding(3);
            this.tabRockstar.Size = new System.Drawing.Size(424, 247);
            this.tabRockstar.TabIndex = 1;
            this.tabRockstar.Text = "tabRockstar";
            this.tabRockstar.UseVisualStyleBackColor = true;
            // 
            // chkEnableRockstarHotkey
            // 
            this.chkEnableRockstarHotkey.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkEnableRockstarHotkey.Checked = true;
            this.chkEnableRockstarHotkey.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEnableRockstarHotkey.Enabled = false;
            this.chkEnableRockstarHotkey.Location = new System.Drawing.Point(9, 135);
            this.chkEnableRockstarHotkey.Name = "chkEnableRockstarHotkey";
            this.chkEnableRockstarHotkey.Size = new System.Drawing.Size(145, 23);
            this.chkEnableRockstarHotkey.TabIndex = 7;
            this.chkEnableRockstarHotkey.Text = "chkEnableRockstarHotkey";
            this.chkEnableRockstarHotkey.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkEnableRockstarHotkey.UseVisualStyleBackColor = true;
            this.chkEnableRockstarHotkey.CheckedChanged += new System.EventHandler(this.chkEnableRockstarHotkey_CheckedChanged);
            // 
            // btnRemoveRockstarRange
            // 
            this.btnRemoveRockstarRange.Location = new System.Drawing.Point(194, 132);
            this.btnRemoveRockstarRange.Name = "btnRemoveRockstarRange";
            this.btnRemoveRockstarRange.Size = new System.Drawing.Size(56, 24);
            this.btnRemoveRockstarRange.TabIndex = 6;
            this.btnRemoveRockstarRange.Text = "btnRemoveRockstarRange";
            this.btnRemoveRockstarRange.UseVisualStyleBackColor = true;
            this.btnRemoveRockstarRange.Click += new System.EventHandler(this.btnRemoveRockstarRange_Click);
            // 
            // btnAddRockstarRange
            // 
            this.btnAddRockstarRange.Location = new System.Drawing.Point(194, 106);
            this.btnAddRockstarRange.Name = "btnAddRockstarRange";
            this.btnAddRockstarRange.Size = new System.Drawing.Size(56, 24);
            this.btnAddRockstarRange.TabIndex = 5;
            this.btnAddRockstarRange.Text = "btnAddRockstarRange";
            this.btnAddRockstarRange.UseVisualStyleBackColor = true;
            this.btnAddRockstarRange.Click += new System.EventHandler(this.btnAddRockstarRange_Click);
            // 
            // txtRockstarRange
            // 
            this.txtRockstarRange.Location = new System.Drawing.Point(9, 108);
            this.txtRockstarRange.MaxLength = 31;
            this.txtRockstarRange.Name = "txtRockstarRange";
            this.txtRockstarRange.Size = new System.Drawing.Size(179, 20);
            this.txtRockstarRange.TabIndex = 4;
            this.txtRockstarRange.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtRockstarRange.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRockstarRange_KeyPress);
            // 
            // lbRockstarRanges
            // 
            this.lbRockstarRanges.FormattingEnabled = true;
            this.lbRockstarRanges.Location = new System.Drawing.Point(9, 6);
            this.lbRockstarRanges.Name = "lbRockstarRanges";
            this.lbRockstarRanges.Size = new System.Drawing.Size(241, 95);
            this.lbRockstarRanges.TabIndex = 3;
            // 
            // lbRockstarHotkey
            // 
            this.lbRockstarHotkey.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbRockstarHotkey.Location = new System.Drawing.Point(34, 211);
            this.lbRockstarHotkey.Name = "lbRockstarHotkey";
            this.lbRockstarHotkey.Size = new System.Drawing.Size(188, 24);
            this.lbRockstarHotkey.TabIndex = 2;
            this.lbRockstarHotkey.Text = "lbRockstarHotkey";
            this.lbRockstarHotkey.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ttMain.SetToolTip(this.lbRockstarHotkey, "ttMainChangeRockstarHotkey");
            this.lbRockstarHotkey.Click += new System.EventHandler(this.lbRockstarHotkey_Click);
            // 
            // btnToggleRockstar
            // 
            this.btnToggleRockstar.Enabled = false;
            this.btnToggleRockstar.Location = new System.Drawing.Point(34, 160);
            this.btnToggleRockstar.Name = "btnToggleRockstar";
            this.btnToggleRockstar.Size = new System.Drawing.Size(188, 48);
            this.btnToggleRockstar.TabIndex = 1;
            this.btnToggleRockstar.Text = "btnToggleRockstar";
            this.btnToggleRockstar.UseVisualStyleBackColor = true;
            this.btnToggleRockstar.Click += new System.EventHandler(this.btnToggleRockstar_Click);
            // 
            // rtbRockstarInfo
            // 
            this.rtbRockstarInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbRockstarInfo.Location = new System.Drawing.Point(258, 6);
            this.rtbRockstarInfo.Name = "rtbRockstarInfo";
            this.rtbRockstarInfo.ReadOnly = true;
            this.rtbRockstarInfo.Size = new System.Drawing.Size(160, 236);
            this.rtbRockstarInfo.TabIndex = 0;
            this.rtbRockstarInfo.Text = "rtbRockstarInfo";
            // 
            // tabConfiguration
            // 
            this.tabConfiguration.Controls.Add(this.rtbConfig);
            this.tabConfiguration.Location = new System.Drawing.Point(4, 22);
            this.tabConfiguration.Name = "tabConfiguration";
            this.tabConfiguration.Padding = new System.Windows.Forms.Padding(3);
            this.tabConfiguration.Size = new System.Drawing.Size(424, 247);
            this.tabConfiguration.TabIndex = 3;
            this.tabConfiguration.Text = "Configuration";
            this.tabConfiguration.UseVisualStyleBackColor = true;
            // 
            // rtbConfig
            // 
            this.rtbConfig.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbConfig.Location = new System.Drawing.Point(6, 6);
            this.rtbConfig.Name = "rtbConfig";
            this.rtbConfig.ReadOnly = true;
            this.rtbConfig.Size = new System.Drawing.Size(412, 235);
            this.rtbConfig.TabIndex = 0;
            this.rtbConfig.Text = "";
            // 
            // tabDebug
            // 
            this.tabDebug.Controls.Add(this.btnThrowError);
            this.tabDebug.Controls.Add(this.lbIsAdmin);
            this.tabDebug.Controls.Add(this.lbRockstarHotkeyActive);
            this.tabDebug.Controls.Add(this.lbDestinyHotkeyActive);
            this.tabDebug.Controls.Add(this.lbRockstarRulesActive);
            this.tabDebug.Controls.Add(this.lbDestinyRulesActive);
            this.tabDebug.Location = new System.Drawing.Point(4, 22);
            this.tabDebug.Name = "tabDebug";
            this.tabDebug.Padding = new System.Windows.Forms.Padding(3);
            this.tabDebug.Size = new System.Drawing.Size(424, 247);
            this.tabDebug.TabIndex = 2;
            this.tabDebug.Text = "tabDebug";
            this.tabDebug.UseVisualStyleBackColor = true;
            // 
            // btnThrowError
            // 
            this.btnThrowError.Location = new System.Drawing.Point(306, 119);
            this.btnThrowError.Name = "btnThrowError";
            this.btnThrowError.Size = new System.Drawing.Size(75, 24);
            this.btnThrowError.TabIndex = 5;
            this.btnThrowError.Text = "Throw Error";
            this.btnThrowError.UseVisualStyleBackColor = true;
            this.btnThrowError.Click += new System.EventHandler(this.btnThrowError_Click);
            // 
            // lbIsAdmin
            // 
            this.lbIsAdmin.AutoSize = true;
            this.lbIsAdmin.Location = new System.Drawing.Point(282, 154);
            this.lbIsAdmin.Name = "lbIsAdmin";
            this.lbIsAdmin.Size = new System.Drawing.Size(62, 13);
            this.lbIsAdmin.TabIndex = 4;
            this.lbIsAdmin.Text = "IsAdmin = ?";
            // 
            // lbRockstarHotkeyActive
            // 
            this.lbRockstarHotkeyActive.AutoSize = true;
            this.lbRockstarHotkeyActive.Location = new System.Drawing.Point(282, 222);
            this.lbRockstarHotkeyActive.Name = "lbRockstarHotkeyActive";
            this.lbRockstarHotkeyActive.Size = new System.Drawing.Size(132, 13);
            this.lbRockstarHotkeyActive.TabIndex = 3;
            this.lbRockstarHotkeyActive.Text = "RockstarHotkeyActive = ?";
            // 
            // lbDestinyHotkeyActive
            // 
            this.lbDestinyHotkeyActive.AutoSize = true;
            this.lbDestinyHotkeyActive.Location = new System.Drawing.Point(282, 205);
            this.lbDestinyHotkeyActive.Name = "lbDestinyHotkeyActive";
            this.lbDestinyHotkeyActive.Size = new System.Drawing.Size(124, 13);
            this.lbDestinyHotkeyActive.TabIndex = 2;
            this.lbDestinyHotkeyActive.Text = "DestinyHotkeyActive = ?";
            // 
            // lbRockstarRulesActive
            // 
            this.lbRockstarRulesActive.AutoSize = true;
            this.lbRockstarRulesActive.Location = new System.Drawing.Point(282, 188);
            this.lbRockstarRulesActive.Name = "lbRockstarRulesActive";
            this.lbRockstarRulesActive.Size = new System.Drawing.Size(125, 13);
            this.lbRockstarRulesActive.TabIndex = 1;
            this.lbRockstarRulesActive.Text = "RockstarRulesActive = ?";
            // 
            // lbDestinyRulesActive
            // 
            this.lbDestinyRulesActive.AutoSize = true;
            this.lbDestinyRulesActive.Location = new System.Drawing.Point(282, 171);
            this.lbDestinyRulesActive.Name = "lbDestinyRulesActive";
            this.lbDestinyRulesActive.Size = new System.Drawing.Size(117, 13);
            this.lbDestinyRulesActive.TabIndex = 0;
            this.lbDestinyRulesActive.Text = "DestinyRulesActive = ?";
            // 
            // lbDestiny
            // 
            this.lbDestiny.Cursor = System.Windows.Forms.Cursors.Default;
            this.lbDestiny.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDestiny.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbDestiny.Location = new System.Drawing.Point(222, 279);
            this.lbDestiny.Name = "lbDestiny";
            this.lbDestiny.Size = new System.Drawing.Size(100, 13);
            this.lbDestiny.TabIndex = 1;
            this.lbDestiny.Text = "lbDestiny";
            this.lbDestiny.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbRockstar
            // 
            this.lbRockstar.Location = new System.Drawing.Point(326, 279);
            this.lbRockstar.Name = "lbRockstar";
            this.lbRockstar.Size = new System.Drawing.Size(100, 13);
            this.lbRockstar.TabIndex = 2;
            this.lbRockstar.Text = "lbRockstar";
            this.lbRockstar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ttMain
            // 
            this.ttMain.ShowAlways = true;
            // 
            // lbCurrentLanguageShort
            // 
            this.lbCurrentLanguageShort.AutoSize = true;
            this.lbCurrentLanguageShort.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbCurrentLanguageShort.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCurrentLanguageShort.Location = new System.Drawing.Point(1, 279);
            this.lbCurrentLanguageShort.Name = "lbCurrentLanguageShort";
            this.lbCurrentLanguageShort.Size = new System.Drawing.Size(135, 13);
            this.lbCurrentLanguageShort.TabIndex = 3;
            this.lbCurrentLanguageShort.Text = "lbCurrentLanguageShort";
            this.lbCurrentLanguageShort.Click += new System.EventHandler(this.lbCurrentLanguageShort_Click);
            // 
            // cmsLanguageSelect
            // 
            this.cmsLanguageSelect.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSelectLanguage,
            this.tscbLanguages});
            this.cmsLanguageSelect.Name = "cmsLanguageSelect";
            this.cmsLanguageSelect.Size = new System.Drawing.Size(205, 53);
            // 
            // tsmiSelectLanguage
            // 
            this.tsmiSelectLanguage.Enabled = false;
            this.tsmiSelectLanguage.Name = "tsmiSelectLanguage";
            this.tsmiSelectLanguage.Size = new System.Drawing.Size(204, 22);
            this.tsmiSelectLanguage.Text = "tsmiSelectNewLanguage";
            // 
            // tscbLanguages
            // 
            this.tscbLanguages.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tscbLanguages.Items.AddRange(new object[] {
            "en"});
            this.tscbLanguages.Name = "tscbLanguages";
            this.tscbLanguages.Size = new System.Drawing.Size(121, 23);
            this.tscbLanguages.SelectedIndexChanged += new System.EventHandler(this.tscbLanguages_SelectedIndexChanged);
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(0, 273);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Size = new System.Drawing.Size(432, 22);
            this.statusBar1.SizingGrip = false;
            this.statusBar1.TabIndex = 4;
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mSettings,
            this.mGithub});
            // 
            // mSettings
            // 
            this.mSettings.Index = 0;
            this.mSettings.Text = "Settings";
            this.mSettings.Click += new System.EventHandler(this.mSettings_Click);
            // 
            // mGithub
            // 
            this.mGithub.Index = 1;
            this.mGithub.Text = "Github";
            this.mGithub.Click += new System.EventHandler(this.mGithub_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(432, 295);
            this.Controls.Add(this.lbCurrentLanguageShort);
            this.Controls.Add(this.lbRockstar);
            this.Controls.Add(this.lbDestiny);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.statusBar1);
            this.MaximizeBox = false;
            this.Menu = this.mainMenu1;
            this.Name = "frmMain";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "frmMain";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.LocationChanged += new System.EventHandler(this.frmMain_LocationChanged);
            this.tabMain.ResumeLayout(false);
            this.tabDestiny.ResumeLayout(false);
            this.tabRockstar.ResumeLayout(false);
            this.tabRockstar.PerformLayout();
            this.tabConfiguration.ResumeLayout(false);
            this.tabDebug.ResumeLayout(false);
            this.tabDebug.PerformLayout();
            this.cmsLanguageSelect.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabDestiny;
        private System.Windows.Forms.TabPage tabRockstar;
        private System.Windows.Forms.RichTextBox rtbRockstarInfo;
        private System.Windows.Forms.TabPage tabDebug;
        private System.Windows.Forms.Button btnToggleDestiny;
        private System.Windows.Forms.Label lbDestinyHotkey;
        private System.Windows.Forms.Button btnToggleRockstar;
        private System.Windows.Forms.Label lbRockstarHotkey;
        private System.Windows.Forms.Label lbDestiny;
        private System.Windows.Forms.Label lbRockstar;
        private System.Windows.Forms.ListBox lbRockstarRanges;
        private System.Windows.Forms.TextBox txtRockstarRange;
        private System.Windows.Forms.Button btnAddRockstarRange;
        private System.Windows.Forms.Button btnRemoveRockstarRange;
        private System.Windows.Forms.CheckBox chkEnableDestinyHotkey;
        private System.Windows.Forms.CheckBox chkEnableRockstarHotkey;
        private System.Windows.Forms.Label lbDestinyRulesActive;
        private System.Windows.Forms.Label lbRockstarHotkeyActive;
        private System.Windows.Forms.Label lbDestinyHotkeyActive;
        private System.Windows.Forms.Label lbRockstarRulesActive;
        private System.Windows.Forms.Label lbIsAdmin;
        private System.Windows.Forms.Button btnThrowError;
        private System.Windows.Forms.ToolTip ttMain;
        private System.Windows.Forms.Label lbCurrentLanguageShort;
        private System.Windows.Forms.ContextMenuStrip cmsLanguageSelect;
        private System.Windows.Forms.ToolStripComboBox tscbLanguages;
        private System.Windows.Forms.ToolStripMenuItem tsmiSelectLanguage;
        private System.Windows.Forms.StatusBar statusBar1;
        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem mSettings;
        private System.Windows.Forms.MenuItem mGithub;
        private System.Windows.Forms.TabPage tabConfiguration;
        private System.Windows.Forms.RichTextBox rtbConfig;
    }
}

