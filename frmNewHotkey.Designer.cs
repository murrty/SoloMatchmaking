namespace SoloMatchmaking {
    partial class frmNewHotkey {
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
            this.lbNewHotkeyDescription = new System.Windows.Forms.Label();
            this.lbNewHotkeyHeader = new System.Windows.Forms.Label();
            this.lbNewHotkeyModifier = new System.Windows.Forms.Label();
            this.cbModifier = new System.Windows.Forms.ComboBox();
            this.cbKey = new System.Windows.Forms.ComboBox();
            this.lbNewHotkeyKey = new System.Windows.Forms.Label();
            this.btnNewHotkeySave = new System.Windows.Forms.Button();
            this.btnNewHotkeyCancel = new System.Windows.Forms.Button();
            this.btnNewHotkeyResetToDefault = new System.Windows.Forms.Button();
            this.lbNewHotkeyPlus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbNewHotkeyDescription
            // 
            this.lbNewHotkeyDescription.AutoSize = true;
            this.lbNewHotkeyDescription.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNewHotkeyDescription.Location = new System.Drawing.Point(13, 40);
            this.lbNewHotkeyDescription.Name = "lbNewHotkeyDescription";
            this.lbNewHotkeyDescription.Size = new System.Drawing.Size(151, 17);
            this.lbNewHotkeyDescription.TabIndex = 3;
            this.lbNewHotkeyDescription.Text = "lbNewHotkeyDescription";
            // 
            // lbNewHotkeyHeader
            // 
            this.lbNewHotkeyHeader.AutoSize = true;
            this.lbNewHotkeyHeader.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNewHotkeyHeader.Location = new System.Drawing.Point(12, 9);
            this.lbNewHotkeyHeader.Name = "lbNewHotkeyHeader";
            this.lbNewHotkeyHeader.Size = new System.Drawing.Size(185, 25);
            this.lbNewHotkeyHeader.TabIndex = 2;
            this.lbNewHotkeyHeader.Text = "lbNewHotkeyHeader";
            // 
            // lbNewHotkeyModifier
            // 
            this.lbNewHotkeyModifier.AutoSize = true;
            this.lbNewHotkeyModifier.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNewHotkeyModifier.Location = new System.Drawing.Point(43, 70);
            this.lbNewHotkeyModifier.Name = "lbNewHotkeyModifier";
            this.lbNewHotkeyModifier.Size = new System.Drawing.Size(135, 17);
            this.lbNewHotkeyModifier.TabIndex = 4;
            this.lbNewHotkeyModifier.Text = "lbNewHotkeyModifier";
            // 
            // cbModifier
            // 
            this.cbModifier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbModifier.FormattingEnabled = true;
            this.cbModifier.Items.AddRange(new object[] {
            "None",
            "Alt",
            "Ctrl",
            "Shift",
            "Win"});
            this.cbModifier.Location = new System.Drawing.Point(58, 90);
            this.cbModifier.Name = "cbModifier";
            this.cbModifier.Size = new System.Drawing.Size(77, 21);
            this.cbModifier.TabIndex = 5;
            this.cbModifier.SelectedIndexChanged += new System.EventHandler(this.cbModifier_SelectedIndexChanged);
            // 
            // cbKey
            // 
            this.cbKey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbKey.FormattingEnabled = true;
            this.cbKey.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D",
            "E",
            "F",
            "G",
            "H",
            "I",
            "J",
            "K",
            "L",
            "M",
            "N",
            "O",
            "P",
            "Q",
            "R",
            "S",
            "T",
            "U",
            "V",
            "W",
            "X",
            "Y",
            "Z",
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "F1",
            "F2",
            "F3",
            "F4",
            "F5",
            "F6",
            "F7",
            "F8",
            "F9",
            "F10",
            "F11",
            "F12",
            "NumPad0",
            "NumPad1",
            "NumPad2",
            "NumPad3",
            "NumPad4",
            "NumPad5",
            "NumPad6",
            "NumPad7",
            "NumPad8",
            "NumPad9",
            "NumLock",
            "NumPadDivide",
            "NumPadMultiply",
            "NumPadSubtract",
            "NumPadAdd",
            "NumPadPeriod",
            "Tilde",
            "Minus",
            "Equals",
            "OpenBracket",
            "CloseBracket",
            "Backslash",
            "SemiColon",
            "Apostrophe",
            "Comma",
            "Period",
            "ForwardSlash",
            "UpArrow",
            "DownArrow",
            "LeftArrow",
            "RightArrow",
            "Insert",
            "Delete",
            "Home",
            "End",
            "Next",
            "PageDown",
            "PageUp"});
            this.cbKey.Location = new System.Drawing.Point(184, 90);
            this.cbKey.Name = "cbKey";
            this.cbKey.Size = new System.Drawing.Size(125, 21);
            this.cbKey.TabIndex = 7;
            // 
            // lbNewHotkeyKey
            // 
            this.lbNewHotkeyKey.AutoSize = true;
            this.lbNewHotkeyKey.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNewHotkeyKey.Location = new System.Drawing.Point(169, 70);
            this.lbNewHotkeyKey.Name = "lbNewHotkeyKey";
            this.lbNewHotkeyKey.Size = new System.Drawing.Size(106, 17);
            this.lbNewHotkeyKey.TabIndex = 6;
            this.lbNewHotkeyKey.Text = "lbNewHotkeyKey";
            // 
            // btnNewHotkeySave
            // 
            this.btnNewHotkeySave.Location = new System.Drawing.Point(265, 124);
            this.btnNewHotkeySave.Name = "btnNewHotkeySave";
            this.btnNewHotkeySave.Size = new System.Drawing.Size(75, 24);
            this.btnNewHotkeySave.TabIndex = 8;
            this.btnNewHotkeySave.Text = "btnNewHotkeySave";
            this.btnNewHotkeySave.UseVisualStyleBackColor = true;
            this.btnNewHotkeySave.Click += new System.EventHandler(this.btnNewHotkeySave_Click);
            // 
            // btnNewHotkeyCancel
            // 
            this.btnNewHotkeyCancel.Location = new System.Drawing.Point(184, 124);
            this.btnNewHotkeyCancel.Name = "btnNewHotkeyCancel";
            this.btnNewHotkeyCancel.Size = new System.Drawing.Size(75, 24);
            this.btnNewHotkeyCancel.TabIndex = 9;
            this.btnNewHotkeyCancel.Text = "btnNewHotkeyCancel";
            this.btnNewHotkeyCancel.UseVisualStyleBackColor = true;
            this.btnNewHotkeyCancel.Click += new System.EventHandler(this.btnNewHotkeyCancel_Click);
            // 
            // btnNewHotkeyResetToDefault
            // 
            this.btnNewHotkeyResetToDefault.Location = new System.Drawing.Point(12, 124);
            this.btnNewHotkeyResetToDefault.Name = "btnNewHotkeyResetToDefault";
            this.btnNewHotkeyResetToDefault.Size = new System.Drawing.Size(96, 24);
            this.btnNewHotkeyResetToDefault.TabIndex = 10;
            this.btnNewHotkeyResetToDefault.Text = "btnNewHotkeyResetToDefault";
            this.btnNewHotkeyResetToDefault.UseVisualStyleBackColor = true;
            this.btnNewHotkeyResetToDefault.Click += new System.EventHandler(this.btnNewHotkeyResetToDefault_Click);
            // 
            // lbNewHotkeyPlus
            // 
            this.lbNewHotkeyPlus.AutoSize = true;
            this.lbNewHotkeyPlus.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNewHotkeyPlus.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lbNewHotkeyPlus.Location = new System.Drawing.Point(149, 90);
            this.lbNewHotkeyPlus.Name = "lbNewHotkeyPlus";
            this.lbNewHotkeyPlus.Size = new System.Drawing.Size(21, 21);
            this.lbNewHotkeyPlus.TabIndex = 11;
            this.lbNewHotkeyPlus.Text = "+";
            // 
            // frmNewHotkey
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(352, 160);
            this.Controls.Add(this.lbNewHotkeyPlus);
            this.Controls.Add(this.btnNewHotkeyResetToDefault);
            this.Controls.Add(this.btnNewHotkeyCancel);
            this.Controls.Add(this.btnNewHotkeySave);
            this.Controls.Add(this.cbKey);
            this.Controls.Add(this.lbNewHotkeyKey);
            this.Controls.Add(this.cbModifier);
            this.Controls.Add(this.lbNewHotkeyModifier);
            this.Controls.Add(this.lbNewHotkeyDescription);
            this.Controls.Add(this.lbNewHotkeyHeader);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNewHotkey";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmNewHotkey";
            this.Load += new System.EventHandler(this.frmNewHotkey_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbNewHotkeyDescription;
        private System.Windows.Forms.Label lbNewHotkeyHeader;
        private System.Windows.Forms.Label lbNewHotkeyModifier;
        private System.Windows.Forms.ComboBox cbModifier;
        private System.Windows.Forms.ComboBox cbKey;
        private System.Windows.Forms.Label lbNewHotkeyKey;
        private System.Windows.Forms.Button btnNewHotkeySave;
        private System.Windows.Forms.Button btnNewHotkeyCancel;
        private System.Windows.Forms.Button btnNewHotkeyResetToDefault;
        private System.Windows.Forms.Label lbNewHotkeyPlus;

    }
}