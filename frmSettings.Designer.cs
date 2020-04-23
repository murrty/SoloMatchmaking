namespace SoloMatchmaking {
    partial class frmSettings {
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
            this.btnSave = new System.Windows.Forms.Button();
            this.tcMain = new System.Windows.Forms.TabControl();
            this.tabGeneral = new System.Windows.Forms.TabPage();
            this.btnGeneralResetToDefault = new System.Windows.Forms.Button();
            this.gbSpeech = new System.Windows.Forms.GroupBox();
            this.btnTestSpeech = new System.Windows.Forms.Button();
            this.lbSpeechSynthVolume = new System.Windows.Forms.Label();
            this.numSynthVolume = new System.Windows.Forms.NumericUpDown();
            this.numSynthSpeed = new System.Windows.Forms.NumericUpDown();
            this.lbSpeechSynthSpeed = new System.Windows.Forms.Label();
            this.tabDestiny = new System.Windows.Forms.TabPage();
            this.btnDestinyResetToDefault = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.chkDestinySpecifyApplication = new System.Windows.Forms.CheckBox();
            this.btnBrowseDestinyExecutable = new System.Windows.Forms.Button();
            this.lbDestinyPath = new System.Windows.Forms.Label();
            this.txtDestinyExecutable = new System.Windows.Forms.TextBox();
            this.lbDestinyName = new System.Windows.Forms.Label();
            this.txtDestinyName = new System.Windows.Forms.TextBox();
            this.lbDestinyPorts = new System.Windows.Forms.Label();
            this.txtDestinyPorts = new System.Windows.Forms.TextBox();
            this.tabRockstar = new System.Windows.Forms.TabPage();
            this.btnRockstarResetToDefault = new System.Windows.Forms.Button();
            this.lbRockstarNameSuffix = new System.Windows.Forms.Label();
            this.lbRockstarName = new System.Windows.Forms.Label();
            this.txtRockstarName = new System.Windows.Forms.TextBox();
            this.lbRockstarPorts = new System.Windows.Forms.Label();
            this.txtRockstarPorts = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.chkDestinyBlockLocal = new System.Windows.Forms.CheckBox();
            this.chkDestinyBlockRemote = new System.Windows.Forms.CheckBox();
            this.tcMain.SuspendLayout();
            this.tabGeneral.SuspendLayout();
            this.gbSpeech.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSynthVolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSynthSpeed)).BeginInit();
            this.tabDestiny.SuspendLayout();
            this.tabRockstar.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(244, 195);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tcMain
            // 
            this.tcMain.Controls.Add(this.tabGeneral);
            this.tcMain.Controls.Add(this.tabDestiny);
            this.tcMain.Controls.Add(this.tabRockstar);
            this.tcMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.tcMain.Location = new System.Drawing.Point(0, 0);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 0;
            this.tcMain.Size = new System.Drawing.Size(412, 193);
            this.tcMain.TabIndex = 1;
            // 
            // tabGeneral
            // 
            this.tabGeneral.Controls.Add(this.btnGeneralResetToDefault);
            this.tabGeneral.Controls.Add(this.gbSpeech);
            this.tabGeneral.Location = new System.Drawing.Point(4, 22);
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tabGeneral.Size = new System.Drawing.Size(404, 167);
            this.tabGeneral.TabIndex = 0;
            this.tabGeneral.Text = "General";
            this.tabGeneral.UseVisualStyleBackColor = true;
            // 
            // btnGeneralResetToDefault
            // 
            this.btnGeneralResetToDefault.Location = new System.Drawing.Point(302, 138);
            this.btnGeneralResetToDefault.Name = "btnGeneralResetToDefault";
            this.btnGeneralResetToDefault.Size = new System.Drawing.Size(96, 23);
            this.btnGeneralResetToDefault.TabIndex = 16;
            this.btnGeneralResetToDefault.Text = "Reset to Default";
            this.btnGeneralResetToDefault.UseVisualStyleBackColor = true;
            this.btnGeneralResetToDefault.Click += new System.EventHandler(this.btnGeneralResetToDefault_Click);
            // 
            // gbSpeech
            // 
            this.gbSpeech.Controls.Add(this.btnTestSpeech);
            this.gbSpeech.Controls.Add(this.lbSpeechSynthVolume);
            this.gbSpeech.Controls.Add(this.numSynthVolume);
            this.gbSpeech.Controls.Add(this.numSynthSpeed);
            this.gbSpeech.Controls.Add(this.lbSpeechSynthSpeed);
            this.gbSpeech.Location = new System.Drawing.Point(8, 6);
            this.gbSpeech.Name = "gbSpeech";
            this.gbSpeech.Size = new System.Drawing.Size(169, 75);
            this.gbSpeech.TabIndex = 0;
            this.gbSpeech.TabStop = false;
            this.gbSpeech.Text = "Speech Synthesizer";
            // 
            // btnTestSpeech
            // 
            this.btnTestSpeech.Location = new System.Drawing.Point(101, 27);
            this.btnTestSpeech.Name = "btnTestSpeech";
            this.btnTestSpeech.Size = new System.Drawing.Size(57, 23);
            this.btnTestSpeech.TabIndex = 4;
            this.btnTestSpeech.Text = "Test";
            this.btnTestSpeech.UseVisualStyleBackColor = true;
            this.btnTestSpeech.Click += new System.EventHandler(this.btnTestSpeech_Click);
            // 
            // lbSpeechSynthVolume
            // 
            this.lbSpeechSynthVolume.AutoSize = true;
            this.lbSpeechSynthVolume.Location = new System.Drawing.Point(6, 20);
            this.lbSpeechSynthVolume.Name = "lbSpeechSynthVolume";
            this.lbSpeechSynthVolume.Size = new System.Drawing.Size(42, 13);
            this.lbSpeechSynthVolume.TabIndex = 3;
            this.lbSpeechSynthVolume.Text = "Volume";
            this.lbSpeechSynthVolume.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // numSynthVolume
            // 
            this.numSynthVolume.Location = new System.Drawing.Point(49, 18);
            this.numSynthVolume.Name = "numSynthVolume";
            this.numSynthVolume.Size = new System.Drawing.Size(42, 20);
            this.numSynthVolume.TabIndex = 1;
            this.numSynthVolume.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // numSynthSpeed
            // 
            this.numSynthSpeed.Location = new System.Drawing.Point(49, 44);
            this.numSynthSpeed.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numSynthSpeed.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this.numSynthSpeed.Name = "numSynthSpeed";
            this.numSynthSpeed.Size = new System.Drawing.Size(42, 20);
            this.numSynthSpeed.TabIndex = 0;
            this.numSynthSpeed.TabStop = false;
            this.numSynthSpeed.Value = new decimal(new int[] {
            2,
            0,
            0,
            -2147483648});
            // 
            // lbSpeechSynthSpeed
            // 
            this.lbSpeechSynthSpeed.AutoSize = true;
            this.lbSpeechSynthSpeed.Location = new System.Drawing.Point(6, 46);
            this.lbSpeechSynthSpeed.Name = "lbSpeechSynthSpeed";
            this.lbSpeechSynthSpeed.Size = new System.Drawing.Size(38, 13);
            this.lbSpeechSynthSpeed.TabIndex = 2;
            this.lbSpeechSynthSpeed.Text = "Speed";
            this.lbSpeechSynthSpeed.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tabDestiny
            // 
            this.tabDestiny.Controls.Add(this.chkDestinyBlockRemote);
            this.tabDestiny.Controls.Add(this.chkDestinyBlockLocal);
            this.tabDestiny.Controls.Add(this.btnDestinyResetToDefault);
            this.tabDestiny.Controls.Add(this.label6);
            this.tabDestiny.Controls.Add(this.chkDestinySpecifyApplication);
            this.tabDestiny.Controls.Add(this.btnBrowseDestinyExecutable);
            this.tabDestiny.Controls.Add(this.lbDestinyPath);
            this.tabDestiny.Controls.Add(this.txtDestinyExecutable);
            this.tabDestiny.Controls.Add(this.lbDestinyName);
            this.tabDestiny.Controls.Add(this.txtDestinyName);
            this.tabDestiny.Controls.Add(this.lbDestinyPorts);
            this.tabDestiny.Controls.Add(this.txtDestinyPorts);
            this.tabDestiny.Location = new System.Drawing.Point(4, 22);
            this.tabDestiny.Name = "tabDestiny";
            this.tabDestiny.Padding = new System.Windows.Forms.Padding(3);
            this.tabDestiny.Size = new System.Drawing.Size(404, 167);
            this.tabDestiny.TabIndex = 1;
            this.tabDestiny.Text = "Destiny 2";
            this.tabDestiny.UseVisualStyleBackColor = true;
            // 
            // btnDestinyResetToDefault
            // 
            this.btnDestinyResetToDefault.Location = new System.Drawing.Point(302, 138);
            this.btnDestinyResetToDefault.Name = "btnDestinyResetToDefault";
            this.btnDestinyResetToDefault.Size = new System.Drawing.Size(96, 23);
            this.btnDestinyResetToDefault.TabIndex = 15;
            this.btnDestinyResetToDefault.Text = "Reset to Default";
            this.btnDestinyResetToDefault.UseVisualStyleBackColor = true;
            this.btnDestinyResetToDefault.Click += new System.EventHandler(this.btnDestinyResetToDefault_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(233, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(111, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "<In/Out><TCP/UDP>";
            // 
            // chkDestinySpecifyApplication
            // 
            this.chkDestinySpecifyApplication.AutoSize = true;
            this.chkDestinySpecifyApplication.Location = new System.Drawing.Point(11, 86);
            this.chkDestinySpecifyApplication.Name = "chkDestinySpecifyApplication";
            this.chkDestinySpecifyApplication.Size = new System.Drawing.Size(177, 17);
            this.chkDestinySpecifyApplication.TabIndex = 7;
            this.chkDestinySpecifyApplication.Text = "Specify destiny2.exe executable";
            this.chkDestinySpecifyApplication.UseVisualStyleBackColor = true;
            this.chkDestinySpecifyApplication.CheckedChanged += new System.EventHandler(this.chkDestinySpecifyApplication_CheckedChanged);
            // 
            // btnBrowseDestinyExecutable
            // 
            this.btnBrowseDestinyExecutable.Enabled = false;
            this.btnBrowseDestinyExecutable.Location = new System.Drawing.Point(361, 107);
            this.btnBrowseDestinyExecutable.Name = "btnBrowseDestinyExecutable";
            this.btnBrowseDestinyExecutable.Size = new System.Drawing.Size(30, 23);
            this.btnBrowseDestinyExecutable.TabIndex = 6;
            this.btnBrowseDestinyExecutable.Text = "...";
            this.btnBrowseDestinyExecutable.UseVisualStyleBackColor = true;
            this.btnBrowseDestinyExecutable.Click += new System.EventHandler(this.btnBrowseDestinyExecutable_Click);
            // 
            // lbDestinyPath
            // 
            this.lbDestinyPath.AutoSize = true;
            this.lbDestinyPath.Location = new System.Drawing.Point(8, 112);
            this.lbDestinyPath.Name = "lbDestinyPath";
            this.lbDestinyPath.Size = new System.Drawing.Size(29, 13);
            this.lbDestinyPath.TabIndex = 5;
            this.lbDestinyPath.Text = "Path";
            // 
            // txtDestinyExecutable
            // 
            this.txtDestinyExecutable.Location = new System.Drawing.Point(49, 109);
            this.txtDestinyExecutable.Name = "txtDestinyExecutable";
            this.txtDestinyExecutable.Size = new System.Drawing.Size(306, 20);
            this.txtDestinyExecutable.TabIndex = 4;
            // 
            // lbDestinyName
            // 
            this.lbDestinyName.AutoSize = true;
            this.lbDestinyName.Location = new System.Drawing.Point(8, 11);
            this.lbDestinyName.Name = "lbDestinyName";
            this.lbDestinyName.Size = new System.Drawing.Size(35, 13);
            this.lbDestinyName.TabIndex = 3;
            this.lbDestinyName.Text = "Name";
            // 
            // txtDestinyName
            // 
            this.txtDestinyName.Location = new System.Drawing.Point(49, 8);
            this.txtDestinyName.Name = "txtDestinyName";
            this.txtDestinyName.Size = new System.Drawing.Size(178, 20);
            this.txtDestinyName.TabIndex = 2;
            // 
            // lbDestinyPorts
            // 
            this.lbDestinyPorts.AutoSize = true;
            this.lbDestinyPorts.Location = new System.Drawing.Point(8, 37);
            this.lbDestinyPorts.Name = "lbDestinyPorts";
            this.lbDestinyPorts.Size = new System.Drawing.Size(31, 13);
            this.lbDestinyPorts.TabIndex = 1;
            this.lbDestinyPorts.Text = "Ports";
            // 
            // txtDestinyPorts
            // 
            this.txtDestinyPorts.Location = new System.Drawing.Point(49, 34);
            this.txtDestinyPorts.Name = "txtDestinyPorts";
            this.txtDestinyPorts.Size = new System.Drawing.Size(178, 20);
            this.txtDestinyPorts.TabIndex = 0;
            // 
            // tabRockstar
            // 
            this.tabRockstar.Controls.Add(this.btnRockstarResetToDefault);
            this.tabRockstar.Controls.Add(this.lbRockstarNameSuffix);
            this.tabRockstar.Controls.Add(this.lbRockstarName);
            this.tabRockstar.Controls.Add(this.txtRockstarName);
            this.tabRockstar.Controls.Add(this.lbRockstarPorts);
            this.tabRockstar.Controls.Add(this.txtRockstarPorts);
            this.tabRockstar.Location = new System.Drawing.Point(4, 22);
            this.tabRockstar.Name = "tabRockstar";
            this.tabRockstar.Padding = new System.Windows.Forms.Padding(3);
            this.tabRockstar.Size = new System.Drawing.Size(404, 167);
            this.tabRockstar.TabIndex = 2;
            this.tabRockstar.Text = "Rockstar";
            this.tabRockstar.UseVisualStyleBackColor = true;
            // 
            // btnRockstarResetToDefault
            // 
            this.btnRockstarResetToDefault.Location = new System.Drawing.Point(302, 138);
            this.btnRockstarResetToDefault.Name = "btnRockstarResetToDefault";
            this.btnRockstarResetToDefault.Size = new System.Drawing.Size(96, 23);
            this.btnRockstarResetToDefault.TabIndex = 14;
            this.btnRockstarResetToDefault.Text = "Reset to Default";
            this.btnRockstarResetToDefault.UseVisualStyleBackColor = true;
            this.btnRockstarResetToDefault.Click += new System.EventHandler(this.btnRockstarResetToDefault_Click);
            // 
            // lbRockstarNameSuffix
            // 
            this.lbRockstarNameSuffix.AutoSize = true;
            this.lbRockstarNameSuffix.Location = new System.Drawing.Point(233, 11);
            this.lbRockstarNameSuffix.Name = "lbRockstarNameSuffix";
            this.lbRockstarNameSuffix.Size = new System.Drawing.Size(85, 13);
            this.lbRockstarNameSuffix.TabIndex = 13;
            this.lbRockstarNameSuffix.Text = "<In/Out><UDP>";
            // 
            // lbRockstarName
            // 
            this.lbRockstarName.AutoSize = true;
            this.lbRockstarName.Location = new System.Drawing.Point(8, 11);
            this.lbRockstarName.Name = "lbRockstarName";
            this.lbRockstarName.Size = new System.Drawing.Size(35, 13);
            this.lbRockstarName.TabIndex = 12;
            this.lbRockstarName.Text = "Name";
            // 
            // txtRockstarName
            // 
            this.txtRockstarName.Location = new System.Drawing.Point(49, 8);
            this.txtRockstarName.Name = "txtRockstarName";
            this.txtRockstarName.Size = new System.Drawing.Size(178, 20);
            this.txtRockstarName.TabIndex = 11;
            // 
            // lbRockstarPorts
            // 
            this.lbRockstarPorts.AutoSize = true;
            this.lbRockstarPorts.Location = new System.Drawing.Point(8, 37);
            this.lbRockstarPorts.Name = "lbRockstarPorts";
            this.lbRockstarPorts.Size = new System.Drawing.Size(31, 13);
            this.lbRockstarPorts.TabIndex = 10;
            this.lbRockstarPorts.Text = "Ports";
            // 
            // txtRockstarPorts
            // 
            this.txtRockstarPorts.Location = new System.Drawing.Point(49, 34);
            this.txtRockstarPorts.Name = "txtRockstarPorts";
            this.txtRockstarPorts.Size = new System.Drawing.Size(178, 20);
            this.txtRockstarPorts.TabIndex = 9;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(325, 195);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // chkDestinyBlockLocal
            // 
            this.chkDestinyBlockLocal.AutoSize = true;
            this.chkDestinyBlockLocal.Location = new System.Drawing.Point(258, 42);
            this.chkDestinyBlockLocal.Name = "chkDestinyBlockLocal";
            this.chkDestinyBlockLocal.Size = new System.Drawing.Size(103, 17);
            this.chkDestinyBlockLocal.TabIndex = 16;
            this.chkDestinyBlockLocal.Text = "Block local ports";
            this.chkDestinyBlockLocal.UseVisualStyleBackColor = true;
            // 
            // chkDestinyBlockRemote
            // 
            this.chkDestinyBlockRemote.AutoSize = true;
            this.chkDestinyBlockRemote.Location = new System.Drawing.Point(258, 65);
            this.chkDestinyBlockRemote.Name = "chkDestinyBlockRemote";
            this.chkDestinyBlockRemote.Size = new System.Drawing.Size(113, 17);
            this.chkDestinyBlockRemote.TabIndex = 17;
            this.chkDestinyBlockRemote.Text = "Block remote ports";
            this.chkDestinyBlockRemote.UseVisualStyleBackColor = true;
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(412, 230);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.tcMain);
            this.Controls.Add(this.btnSave);
            this.MaximizeBox = false;
            this.Name = "frmSettings";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.tcMain.ResumeLayout(false);
            this.tabGeneral.ResumeLayout(false);
            this.gbSpeech.ResumeLayout(false);
            this.gbSpeech.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSynthVolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSynthSpeed)).EndInit();
            this.tabDestiny.ResumeLayout(false);
            this.tabDestiny.PerformLayout();
            this.tabRockstar.ResumeLayout(false);
            this.tabRockstar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TabControl tcMain;
        private System.Windows.Forms.TabPage tabGeneral;
        private System.Windows.Forms.TabPage tabDestiny;
        private System.Windows.Forms.TabPage tabRockstar;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox gbSpeech;
        private System.Windows.Forms.Button btnTestSpeech;
        private System.Windows.Forms.Label lbSpeechSynthVolume;
        private System.Windows.Forms.NumericUpDown numSynthVolume;
        private System.Windows.Forms.NumericUpDown numSynthSpeed;
        private System.Windows.Forms.Label lbSpeechSynthSpeed;
        private System.Windows.Forms.TextBox txtDestinyPorts;
        private System.Windows.Forms.Label lbDestinyName;
        private System.Windows.Forms.TextBox txtDestinyName;
        private System.Windows.Forms.Label lbDestinyPorts;
        private System.Windows.Forms.CheckBox chkDestinySpecifyApplication;
        private System.Windows.Forms.Button btnBrowseDestinyExecutable;
        private System.Windows.Forms.Label lbDestinyPath;
        private System.Windows.Forms.TextBox txtDestinyExecutable;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbRockstarNameSuffix;
        private System.Windows.Forms.Label lbRockstarName;
        private System.Windows.Forms.TextBox txtRockstarName;
        private System.Windows.Forms.Label lbRockstarPorts;
        private System.Windows.Forms.TextBox txtRockstarPorts;
        private System.Windows.Forms.Button btnGeneralResetToDefault;
        private System.Windows.Forms.Button btnDestinyResetToDefault;
        private System.Windows.Forms.Button btnRockstarResetToDefault;
        private System.Windows.Forms.CheckBox chkDestinyBlockRemote;
        private System.Windows.Forms.CheckBox chkDestinyBlockLocal;
    }
}