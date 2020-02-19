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
    public partial class frmNewHotkey : Form {

        Language lang = Language.GetLanguageInstance();
        public int GameID = -1;
        public string OldModifier = null;
        public string OldKey = null;
        public string NewModifier = null;
        public string NewKey = null;
        public bool ResetToDefault = false;

        public frmNewHotkey() {
            InitializeComponent();
            loadLanguage();
        }
        void loadLanguage() {
            this.Text = lang.frmNewHotkey;
            lbNewHotkeyHeader.Text = lang.lbNewHotkeyHeader;
            lbNewHotkeyDescription.Text = lang.lbNewHotkeyDescription;
            lbNewHotkeyModifier.Text = lang.lbNewHotkeyModifier;
            lbNewHotkeyKey.Text = lang.lbNewHotkeyKey;
            btnNewHotkeyResetToDefault.Text = lang.btnNewHotkeyResetToDefault;
            btnNewHotkeyCancel.Text = lang.btnNewHotkeyCancel;
            btnNewHotkeySave.Text = lang.btnNewHotkeySave;
        }

        private void frmNewHotkey_Load(object sender, EventArgs e) {
            cbModifier.SelectedIndex = cbModifier.FindStringExact(OldModifier);
            cbKey.SelectedIndex = cbKey.FindStringExact(OldKey);
        }

        private void btnNewHotkeyResetToDefault_Click(object sender, EventArgs e) {
            switch (GameID) {
                case 1:
                    cbModifier.SelectedIndex = cbModifier.FindStringExact("Ctrl");
                    cbKey.SelectedIndex = cbKey.FindStringExact("F9");
                    break;
                case 2:
                    cbModifier.SelectedIndex = cbModifier.FindStringExact("Ctrl");
                    cbKey.SelectedIndex = cbKey.FindStringExact("F10");
                    break;
                default:
                    return;
            }
        }
        private void btnNewHotkeyCancel_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.Cancel;
        }
        private void btnNewHotkeySave_Click(object sender, EventArgs e) {
            NewModifier = cbModifier.GetItemText(cbModifier.SelectedItem);
            NewKey = cbKey.GetItemText(cbKey.SelectedItem);
            this.DialogResult = DialogResult.Yes;
        }

        private void cbModifier_SelectedIndexChanged(object sender, EventArgs e) {
            if (cbModifier.SelectedIndex == 0) {
                lbNewHotkeyPlus.ForeColor = Color.FromKnownColor(KnownColor.ControlDark);
                lbNewHotkeyModifier.ForeColor = Color.FromKnownColor(KnownColor.ControlDark);
            }
            else {
                lbNewHotkeyPlus.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
                lbNewHotkeyModifier.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
            }
        }
    }
}
