using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoloMatchmaking {
    public partial class frmError : Form {
        public Exception reportedException;
        Language lang = new Language();
        public bool FromLanguage = false;

        public frmError() {
            InitializeComponent();
            loadLanguage();
        }

        void loadLanguage() {
            if (FromLanguage) {
                this.Text = "An exception occured";
                lbExceptionHeader.Text = "An exception has occured";
                lbExceptionDescription.Text = "Below is the error that occured. Feel free to open a new issue and report it.";
                rtbExceptionDetails.Text = "Feel free to copy + paste this entire text wall into a new issue on Github";
                btnExceptionGithub.Text = "Open Github";
                btnExceptionOk.Text = "OK";
            }
            else {
                if (Configuration.Default.LanguageFile == "") {
                    lang.LoadInternalEnglish();
                }
                else {
                    lang.LoadLanguage(Configuration.Default.LanguageFile);
                }
                this.Text = lang.frmError;
                lbExceptionHeader.Text = lang.lbExceptionHeader;
                lbExceptionDescription.Text = lang.lbExceptionDescription;
                btnExceptionGithub.Text = lang.btnExceptionGithub;
                btnExceptionOk.Text = lang.btnExceptionOk;
            }
        }

        private void frmError_Load(object sender, EventArgs e) {
            string outputBuffer = lang.rtbExceptionDetails + "\n\nVersion: " + Properties.Settings.Default.Version + "\nReported Exception: " + reportedException.ToString();
            rtbExceptionDetails.Text = outputBuffer;
            lbVersion.Text = "v" + Properties.Settings.Default.Version.ToString();
            System.Media.SystemSounds.Hand.Play();
        }

        private void btnOk_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.OK;
            this.Dispose();
        }

        private void btnGithub_Click(object sender, EventArgs e) {
            System.Diagnostics.Process.Start("https://github.com/murrty/SoloMatchmaking/issues");
        }

    }
}
