using System.Speech.Synthesis;
using System.Windows.Forms;

namespace SoloMatchmaking {
    public partial class frmSettings : Form {
        SpeechSynthesizer synth = new SpeechSynthesizer();

        public frmSettings() {
            InitializeComponent();
            LoadConfiguration();
        }

        private void LoadConfiguration() {
            numSynthSpeed.Value = Configuration.Default.SynthSpeed;
            numSynthVolume.Value = Configuration.Default.SynthVolume;

            txtDestinyName.Text = Configuration.Default.DestinyName;
            txtDestinyPorts.Text = Configuration.Default.DestinyPorts;
            chkDestinyBlockLocal.Checked = Configuration.Default.DestinyBlockLocalPorts;
            chkDestinyBlockRemote.Checked = Configuration.Default.DestinyBlockRemotePorts;
            chkDestinySpecifyApplication.Checked = Configuration.Default.DestinySpecifyApplication;
            txtDestinyExecutable.Text = Configuration.Default.DestinyExecutable;

            txtRockstarName.Text = Configuration.Default.RockstarName;
            txtRockstarPorts.Text = Configuration.Default.RockstarPorts;
        }
        private void SaveConfiguration() {
            Configuration.Default.SynthSpeed = (int)numSynthSpeed.Value;
            Configuration.Default.SynthVolume = (int)numSynthVolume.Value;

            Configuration.Default.DestinyName = txtDestinyName.Text;
            Configuration.Default.DestinyPorts = txtDestinyPorts.Text;
            Configuration.Default.DestinyBlockLocalPorts = chkDestinyBlockLocal.Checked;
            Configuration.Default.DestinyBlockRemotePorts = chkDestinyBlockRemote.Checked;
            Configuration.Default.DestinySpecifyApplication = chkDestinySpecifyApplication.Checked;
            Configuration.Default.DestinyExecutable = txtDestinyExecutable.Text;

            Configuration.Default.RockstarName = txtRockstarName.Text;
            Configuration.Default.RockstarPorts = txtRockstarPorts.Text;
            Configuration.Default.Save();
        }

        private void btnSave_Click(object sender, System.EventArgs e) {
            SaveConfiguration();
            this.DialogResult = DialogResult.OK;
        }
        private void btnCancel_Click(object sender, System.EventArgs e) {
            this.DialogResult = DialogResult.Cancel;
        }

        #region General
        private void btnTestSpeech_Click(object sender, System.EventArgs e) {
            synth.Rate = (int)numSynthSpeed.Value;
            synth.Volume = (int)numSynthVolume.Value;
            synth.Speak("This is a test of the speech synthesizer.");
        }
        private void btnGeneralResetToDefault_Click(object sender, System.EventArgs e) {
            numSynthSpeed.Value = -2;
            numSynthVolume.Value = 50;
        }
        #endregion
        #region Destiny
        private void btnBrowseDestinyExecutable_Click(object sender, System.EventArgs e) {
            using (OpenFileDialog ofd = new OpenFileDialog()) {
                ofd.Title = "Select destiny2.exe";
                ofd.Filter = "Destiny 2 Executable (destiny2.exe)|destiny2.exe";
                ofd.Multiselect = false;
                if (ofd.ShowDialog() == DialogResult.OK) {
                    txtDestinyExecutable.Text = ofd.FileName;
                }
            }
        }
        private void chkDestinySpecifyApplication_CheckedChanged(object sender, System.EventArgs e) {
            btnBrowseDestinyExecutable.Enabled = chkDestinySpecifyApplication.Checked;
        }
        private void btnDestinyResetToDefault_Click(object sender, System.EventArgs e) {
            txtDestinyName.Text = "Destiny2Solo";
            txtDestinyPorts.Text = "27000-27200,3097";
            chkDestinyBlockLocal.Checked = false;
            chkDestinyBlockRemote.Checked = true;
            chkDestinySpecifyApplication.Checked = false;
            txtDestinyExecutable.Clear();
        }
        #endregion
        #region Rockstar
        private void btnRockstarResetToDefault_Click(object sender, System.EventArgs e) {
            txtRockstarName.Text = "RockstarSolo";
            txtRockstarPorts.Text = "6672";
        }
        #endregion
    }
}
