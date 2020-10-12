namespace SoloMatchmaking {
    partial class Notification {
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
            this.lbNotifMajor = new System.Windows.Forms.Label();
            this.lbNotifMinor = new System.Windows.Forms.Label();
            this.tmrExit = new System.Windows.Forms.Timer(this.components);
            this.pbIcon = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // lbNotifMajor
            // 
            this.lbNotifMajor.AutoSize = true;
            this.lbNotifMajor.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNotifMajor.Location = new System.Drawing.Point(12, 19);
            this.lbNotifMajor.Name = "lbNotifMajor";
            this.lbNotifMajor.Size = new System.Drawing.Size(271, 19);
            this.lbNotifMajor.TabIndex = 0;
            this.lbNotifMajor.Text = "{GAMENAME} rules deactivated";
            // 
            // lbNotifMinor
            // 
            this.lbNotifMinor.AutoSize = true;
            this.lbNotifMinor.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNotifMinor.Location = new System.Drawing.Point(54, 54);
            this.lbNotifMinor.Name = "lbNotifMinor";
            this.lbNotifMinor.Size = new System.Drawing.Size(220, 16);
            this.lbNotifMinor.TabIndex = 1;
            this.lbNotifMinor.Text = "{GAMENAME} is will now matchmake";
            // 
            // tmrExit
            // 
            this.tmrExit.Enabled = true;
            this.tmrExit.Interval = 2500;
            this.tmrExit.Tick += new System.EventHandler(this.tmrExit_Tick);
            // 
            // pbIcon
            // 
            this.pbIcon.Location = new System.Drawing.Point(16, 47);
            this.pbIcon.Name = "pbIcon";
            this.pbIcon.Size = new System.Drawing.Size(32, 32);
            this.pbIcon.TabIndex = 2;
            this.pbIcon.TabStop = false;
            // 
            // Notification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 100);
            this.Controls.Add(this.lbNotifMinor);
            this.Controls.Add(this.lbNotifMajor);
            this.Controls.Add(this.pbIcon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Notification";
            this.Opacity = 0D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Notification";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.Load += new System.EventHandler(this.Notification_Load);
            this.Shown += new System.EventHandler(this.Notification_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbNotifMajor;
        private System.Windows.Forms.Label lbNotifMinor;
        private System.Windows.Forms.Timer tmrExit;
        private System.Windows.Forms.PictureBox pbIcon;
    }
}