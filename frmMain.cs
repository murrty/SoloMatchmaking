//using NetFwTypeLib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Speech.Synthesis;
using System.Windows.Forms;

namespace SoloMatchmaking {
    public partial class frmMain : Form {
        SpeechSynthesizer synth = new SpeechSynthesizer(); // voice synth for hotkeys
                
        bool DestinyHotkeyActive = false;   // if the hotkey for d2 is active
        bool RockstarHotkeyActive = false;  // if the hotkey for r* is active

        bool isAdmin = false;               // if running elevated
        bool skipOneChange = false;         // Skip LocationChanged event once, required for now
        bool locationChanged = false;       // if the form moved at all
        bool OpeningCMS = false;            // if the context menu strip is being opened for language

        KeyboardHook destinyHook;
        KeyboardHook rockstarHook;
        Language lang = Language.GetLanguageInstance();
        FirewallRules fwRules = FirewallRules.GetInstance();

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);
        void destinyHook_KeyPressed(object sender, KeyPressedEventArgs e) {
            if (chkEnableDestinyHotkey.Checked) {
                toggleRule(1, true);
            }
        }
        void rockstarHook_KeyPressed(object sender, KeyPressedEventArgs e) {
            if (chkEnableRockstarHotkey.Checked) {
                toggleRule(2, true);
            }
        }

        public frmMain() {
            InitializeComponent();
            loadSettings();
            checkAdmin();
            setLanguage();
            checkRules();
        }
        protected override void WndProc(ref Message m) {
            if (m.Msg == Program.WM_SHOWFORM) {
                this.Show();
                if (this.WindowState != FormWindowState.Normal)
                    this.WindowState = FormWindowState.Normal;
                this.Activate();
            }
            base.WndProc(ref m);
        }
        private void frmMain_Load(object sender, EventArgs e) {
            if (Configuration.Default.LastPos.X != -99999999 && Configuration.Default.LastPos.Y != -99999999) {
                this.Location = Configuration.Default.LastPos;
            }
        }
        private void frmMain_LocationChanged(object sender, EventArgs e) {
            if (!skipOneChange) {
                skipOneChange = true;
                return;
            }

            if (!locationChanged)
                locationChanged = true;
            this.LocationChanged -= new System.EventHandler(this.frmMain_LocationChanged);
        }
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e) {
            bool save = false;
            if (isAdmin) {
                disableHotkeys(0);
                //deleteRules();
            }
            if (Configuration.Default.EnableDestinyHotkeys != chkEnableDestinyHotkey.Checked) {
                Configuration.Default.EnableDestinyHotkeys = chkEnableDestinyHotkey.Checked;
                save = true;
            }
            if (Configuration.Default.EnableRockstarHotkeys != chkEnableRockstarHotkey.Checked) {
                Configuration.Default.EnableRockstarHotkeys = chkEnableRockstarHotkey.Checked;
                save = true;
            }
            if (locationChanged) {
                Configuration.Default.LastPos = new Point(this.Location.X, this.Location.Y);
                save = true;
            }

            if (save) {
                Configuration.Default.Save();
            }
        }

        private void chkEnableDestinyHotkey_CheckedChanged(object sender, EventArgs e) {
            if (chkEnableDestinyHotkey.Checked) {
                enableHotkeys(1);
            }
            else {
                disableHotkeys(1);
            }
        }
        private void btnToggleDestiny_Click(object sender, EventArgs e) {
            toggleRule(1);
        }

        private void chkEnableRockstarHotkey_CheckedChanged(object sender, EventArgs e) {
            if (chkEnableRockstarHotkey.Checked) {
                enableHotkeys(2);
            }
            else {
                disableHotkeys(2);
            }
        }
        private void txtRockstarRange_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == (char)22 && char.IsControl(e.KeyChar)) {
                if (Clipboard.ContainsText()) {
                    string input = Clipboard.GetText();
                    string output = string.Empty;
                    for (int i = 0; i < input.Length; i++) {
                        if (char.IsDigit(input[i]) || input[i] == '-' || input[i] == '.') {
                            output += input[i];
                        }
                    }
                    txtRockstarRange.AppendText(output);
                }
            }
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != (char)45 && e.KeyChar != (char)46) {
                e.Handled = true;
            }
        }
        private void btnAddRockstarRange_Click(object sender, EventArgs e) {
            if (txtRockstarRange.Text != string.Empty) {
                lbRockstarRanges.Items.Add(txtRockstarRange.Text);
                if (txtRockstarRange.Text.Split('-')[1] != "255.255.255.255") {
                    txtRockstarRange.Text = txtRockstarRange.Text.Split('-')[1] + "-255.255.255.255";
                }
                else {
                    txtRockstarRange.Clear();
                }
            }
        }
        private void btnRemoveRockstarRange_Click(object sender, EventArgs e) {
            if (lbRockstarRanges.SelectedIndex > -1) {
                lbRockstarRanges.Items.RemoveAt(lbRockstarRanges.SelectedIndex);
            }
        }
        private void btnToggleRockstar_Click(object sender, EventArgs e) {
            toggleRule(2);
        }

        void LoadLanguage(bool SkipFile = false) {
            if (!SkipFile) {
                if (Configuration.Default.LanguageFile == string.Empty) {
                    lang.LoadInternalEnglish();
                    tscbLanguages.ComboBox.SelectedIndex = 0;
                }
                else {
                    if (File.Exists(Environment.CurrentDirectory + "\\lang\\" + Configuration.Default.LanguageFile + ".ini")) {
                        lang.LoadLanguage(Environment.CurrentDirectory + "\\lang\\" + Configuration.Default.LanguageFile);
                        tscbLanguages.ComboBox.SelectedIndex = tscbLanguages.ComboBox.FindStringExact(Configuration.Default.LanguageFile);
                    }
                    else {
                        lang.LoadInternalEnglish();
                        tscbLanguages.ComboBox.SelectedIndex = 0;
                    }
                }
            }


        }
        void setLanguage(bool SkipFile = false) {
            if (!SkipFile) {
                if (Configuration.Default.LanguageFile == string.Empty) {
                    tscbLanguages.ComboBox.SelectedIndex = 0;
                }
                else {
                    if (File.Exists(Environment.CurrentDirectory + "\\lang\\" + Configuration.Default.LanguageFile + ".ini")) {
                        lang.LoadLanguage(Environment.CurrentDirectory + "\\lang\\" + Configuration.Default.LanguageFile);
                        tscbLanguages.ComboBox.SelectedIndex = tscbLanguages.ComboBox.FindStringExact(Configuration.Default.LanguageFile);
                    }
                    else {
                        tscbLanguages.ComboBox.SelectedIndex = 0;
                    }
                }
            }

            string bufferHotkey = "(";

            if (isAdmin) {
                this.Text = lang.frmMainAdmin;
            }
            else {
                this.Text = lang.frmMainNoAdmin;
                lbDestiny.ForeColor = Color.FromKnownColor(KnownColor.ControlDark);
                lbRockstar.ForeColor = Color.FromKnownColor(KnownColor.ControlDark);
            }


            tabMain.TabPages[0].Text = lang.tabDestiny;
            tabMain.TabPages[1].Text = lang.tabRockstar;
            if (tabMain.TabPages.Count > 2) {
                tabMain.TabPages[3].Text = lang.tabDebug;
            }
            lbCurrentLanguageShort.Text = lang.CurrentLanguageShort;
            ttMain.SetToolTip(this.lbCurrentLanguageShort, lang.CurrentLanguageLong + " (" + lang.CurrentLanguageShort + ")\n" + lang.CurrentLanguageHint);
            tsmiSelectLanguage.Text = lang.tsmiSelectLanguage;
            if (fwRules.Destiny2RulesActivated) {
                lbDestiny.Text = lang.lbDestinyOn;
            }
            else {
                lbDestiny.Text = lang.lbDestinyOff;
            }
            if (fwRules.RockstarGamesRulesActivated) {
                lbRockstar.Text = lang.lbRockstarOn;
            }
            else {
                lbRockstar.Text = lang.lbRockstarOff;
            }

            chkEnableDestinyHotkey.Text = lang.chkEnableDestinyHotkey;
            btnToggleDestiny.Text = lang.btnToggleDestinyOff;
            ttMain.SetToolTip(this.lbDestinyHotkey, lang.ttMainChangeDestinyHotkey);
            if (chkEnableDestinyHotkey.Checked) {
                if (Configuration.Default.DestinyHotkeyModifier != "None") {
                    bufferHotkey += Configuration.Default.DestinyHotkeyModifier + " + ";
                }
                bufferHotkey += Configuration.Default.DestinyHotkeyKey + ") " + lang.HotkeyToggle;
            }
            else {
                bufferHotkey = lang.HotkeyDisabled;
            }
            if (!isAdmin) { bufferHotkey = lang.HotkeyUnavailable; }
            lbDestinyHotkey.Text = bufferHotkey;

            bufferHotkey = "(";

            chkEnableRockstarHotkey.Text = lang.chkEnableRockstarHotkey;
            SendMessage(txtRockstarRange.Handle, 0x1501, 1, lang.txtRockstarRange);
            btnAddRockstarRange.Text = lang.btnAddRockstarRange;
            btnRemoveRockstarRange.Text = lang.btnRemoveRockstarRange;
            btnToggleRockstar.Text = lang.btnToggleRockstarOff;
            ttMain.SetToolTip(this.lbRockstarHotkey, lang.ttMainChangeRockstarHotkey);
            if (chkEnableRockstarHotkey.Checked) {
                if (Configuration.Default.RockstarHotkeyModifier != "None") {
                    bufferHotkey += Configuration.Default.RockstarHotkeyModifier + " + ";
                }
                bufferHotkey += Configuration.Default.RockstarHotkeyKey + ") " + lang.HotkeyToggle;
            }
            else {
                bufferHotkey = lang.HotkeyDisabled;
            }
            if (!isAdmin) { bufferHotkey = lang.HotkeyUnavailable; }
            lbRockstarHotkey.Text = bufferHotkey;
            rtbRockstarInfo.Text = lang.rtbRockstarInfo;

        }
        void checkAdmin() {
            WindowsIdentity wID = WindowsIdentity.GetCurrent();
            WindowsPrincipal pr = new WindowsPrincipal(wID);
            if (pr.IsInRole(WindowsBuiltInRole.Administrator)) {
                btnToggleDestiny.Enabled = true;
                btnToggleRockstar.Enabled = true;
                chkEnableDestinyHotkey.Enabled = true;
                chkEnableRockstarHotkey.Enabled = true;
                isAdmin = true;

                enableHotkeys(0);
            }
            lbIsAdmin.Text = "isAdmin = " + isAdmin.ToString();
        }
        void loadSettings() {
            fwRules.Destiny2Ports = Configuration.Default.DestinyPorts;
            fwRules.Destiny2RulesName = Configuration.Default.DestinyName;
            fwRules.RockstarGamesPorts = Configuration.Default.RockstarPorts;
            fwRules.RockstarGamesRulesName = Configuration.Default.RockstarName;

            chkEnableDestinyHotkey.Checked = Configuration.Default.EnableDestinyHotkeys;
            chkEnableRockstarHotkey.Checked = Configuration.Default.EnableRockstarHotkeys;

            // synth information
            synth.Volume = Configuration.Default.SynthVolume;
            synth.Rate = Configuration.Default.SynthSpeed;

            // debug information
            string DebugBuffer = "Configuration.settings";
            DebugBuffer += "\nSynthVolume = " + Configuration.Default.SynthVolume;
            DebugBuffer += "\nSynthSpeed = " + Configuration.Default.SynthSpeed;
            DebugBuffer += "\nLastPos = " + Configuration.Default.LastPos;

            DebugBuffer += "\n";

            DebugBuffer += "\nDestinyPorts = " + Configuration.Default.DestinyPorts;
            DebugBuffer += "\nDestinyName = " + Configuration.Default.DestinyName;
            DebugBuffer += "\nDestinyLocalPorts = " + Configuration.Default.DestinyBlockLocalPorts;
            DebugBuffer += "\nDestinyRemotePorts = " + Configuration.Default.DestinyBlockRemotePorts;
            DebugBuffer += "\nDestinySpecifyApplicatin = " + Configuration.Default.DestinySpecifyApplication;
            DebugBuffer += "\nDestinyExecutable = " + Configuration.Default.DestinyExecutable;
            DebugBuffer += "\nEnableDestinyHotkeys = " + Configuration.Default.EnableDestinyHotkeys;
            DebugBuffer += "\nDestinyHotkeyKey = " + Configuration.Default.DestinyHotkeyKey;
            DebugBuffer += "\nDestinyHotkeyModifier = " + Configuration.Default.DestinyHotkeyModifier;

            DebugBuffer += "\n";

            DebugBuffer += "\nRockstarPorts = " + Configuration.Default.RockstarPorts;
            DebugBuffer += "\nRockstarName = " + Configuration.Default.RockstarName;
            DebugBuffer += "\nEnableRockstarHotkeys = " + Configuration.Default.EnableRockstarHotkeys;
            DebugBuffer += "\nRockstarHotkeyKey = " + Configuration.Default.RockstarHotkeyKey;
            DebugBuffer += "\nRockstarHotkeyModifier = " + Configuration.Default.RockstarHotkeyModifier;

            rtbConfig.Text = DebugBuffer;
        }

        void throwError() {
            throw new Exception("Debug exception thrown, no need to panic nothing happened.");
        }
        private void btnThrowError_Click(object sender, EventArgs e) {
            try {
                throwError();
            }
            catch (Exception ex) {
                reportError(ex);
            }
        }

        string getRockstarRange(ListBox input) {
            string buffer = "";
            if (input.Items.Count > 0) {
                for (int i = 0; i < input.Items.Count; i++) {
                    buffer += input.GetItemText(input.Items[i]) + ",";
                }
                return buffer.Trim(',');
            }
            else { return "1.1.1.1-255.255.255.255"; }
        }

        void enableHotkeys(int game) {
            if (!isAdmin)
                return;
            
            string bufferHotkey = "(";

            switch (game) {
                case 1:
                    if (chkEnableDestinyHotkey.Checked) {
                        destinyHook = new KeyboardHook();
                        destinyHook.KeyPressed += new EventHandler<KeyPressedEventArgs>(destinyHook_KeyPressed);
                        destinyHook.RegisterHotKey(KeyLibrary.GetModifier(Configuration.Default.DestinyHotkeyModifier), (uint)KeyLibrary.GetKey(Configuration.Default.DestinyHotkeyKey));
                        DestinyHotkeyActive = true;
                        if (Configuration.Default.DestinyHotkeyModifier != "None") {
                            bufferHotkey += Configuration.Default.DestinyHotkeyModifier + " + ";
                        }
                        bufferHotkey += Configuration.Default.DestinyHotkeyKey + ") " + lang.HotkeyToggle;
                        lbDestinyHotkey.Text = bufferHotkey;
                    }
                    break;
                case 2:
                    if (chkEnableRockstarHotkey.Checked) {
                        rockstarHook = new KeyboardHook();
                        rockstarHook.KeyPressed += new EventHandler<KeyPressedEventArgs>(rockstarHook_KeyPressed);
                        rockstarHook.RegisterHotKey(KeyLibrary.GetModifier(Configuration.Default.RockstarHotkeyModifier), (uint)KeyLibrary.GetKey(Configuration.Default.RockstarHotkeyKey));
                        RockstarHotkeyActive = true;
                        if (Configuration.Default.RockstarHotkeyModifier != "None") {
                            bufferHotkey += Configuration.Default.RockstarHotkeyModifier + " + ";
                        }
                        bufferHotkey += Configuration.Default.RockstarHotkeyKey + ") " + lang.HotkeyToggle;
                        lbRockstarHotkey.Text = bufferHotkey;
                    }
                    break;
                case 0:
                    if (chkEnableDestinyHotkey.Checked) {
                        destinyHook = new KeyboardHook();
                        destinyHook.KeyPressed += new EventHandler<KeyPressedEventArgs>(destinyHook_KeyPressed);
                        destinyHook.RegisterHotKey(KeyLibrary.GetModifier(Configuration.Default.DestinyHotkeyModifier), (uint)KeyLibrary.GetKey(Configuration.Default.DestinyHotkeyKey));
                        DestinyHotkeyActive = true;
                        if (Configuration.Default.DestinyHotkeyModifier != "None") {
                            bufferHotkey += Configuration.Default.DestinyHotkeyModifier + " + ";
                        }
                        bufferHotkey += Configuration.Default.DestinyHotkeyKey + ") " + lang.HotkeyToggle;
                        lbDestinyHotkey.Text = bufferHotkey;
                    }

                    bufferHotkey = "(";

                    if (chkEnableRockstarHotkey.Checked) {
                        rockstarHook = new KeyboardHook();
                        rockstarHook.KeyPressed += new EventHandler<KeyPressedEventArgs>(rockstarHook_KeyPressed);
                        rockstarHook.RegisterHotKey(KeyLibrary.GetModifier(Configuration.Default.RockstarHotkeyModifier), (uint)KeyLibrary.GetKey(Configuration.Default.RockstarHotkeyKey));
                        RockstarHotkeyActive = true;
                        if (Configuration.Default.RockstarHotkeyModifier != "None") {
                            bufferHotkey += Configuration.Default.RockstarHotkeyModifier + " + ";
                        }
                        bufferHotkey += Configuration.Default.RockstarHotkeyKey + ") " + lang.HotkeyToggle;
                        lbRockstarHotkey.Text = bufferHotkey;
                    }
                    break;
            }

            lbDestinyHotkeyActive.Text = "DestinyHotkeyActive = " + DestinyHotkeyActive.ToString();
            lbRockstarHotkeyActive.Text = "RockstarHotkeyActive = " + RockstarHotkeyActive.ToString();
        }
        void disableHotkeys(int game) {
            if (!isAdmin)
                return;

            switch (game) {
                case 1:
                    if (DestinyHotkeyActive) {
                        destinyHook.Dispose();
                        DestinyHotkeyActive = false;
                        lbDestinyHotkey.Text = lang.HotkeyDisabled;
                    }
                    break;
                case 2:
                    if (RockstarHotkeyActive) {
                        rockstarHook.Dispose();
                        RockstarHotkeyActive = false;
                        lbRockstarHotkey.Text = lang.HotkeyDisabled;
                    }
                    break;
                case 0:
                    if (DestinyHotkeyActive) {
                        destinyHook.Dispose();
                        DestinyHotkeyActive = false;
                        lbDestinyHotkey.Text = lang.HotkeyDisabled;
                    }
                    if (RockstarHotkeyActive) {
                        rockstarHook.Dispose();
                        RockstarHotkeyActive = false;
                        lbRockstarHotkey.Text = lang.HotkeyDisabled;
                    }
                    break;
            }

            lbDestinyHotkeyActive.Text = "DestinyHotkeyActive = " + DestinyHotkeyActive.ToString();
            lbRockstarHotkeyActive.Text = "RockstarHotkeyActive = " + RockstarHotkeyActive.ToString();
        }

        void checkRules() {
            try {

                fwRules.CheckRules();

                if (
                fwRules.Destiny2OutTCPEnabled ||
                fwRules.Destiny2OutUDPEnabled ||
                fwRules.Destiny2InTCPEnabled ||
                fwRules.Destiny2InUDPEnabled
                    ) {
                      fwRules.Destiny2RulesActivated = true;
                      lbDestiny.Text = lang.lbDestinyOn;
                      btnToggleDestiny.Text = lang.btnToggleDestinyOn;
                }
                else {
                    lbDestiny.Text = lang.lbDestinyOff;
                    btnToggleDestiny.Text = lang.btnToggleDestinyOff;
                }

                if (
                fwRules.RockstarGamesOutUDPEnabled ||
                fwRules.RockstarGamesInUDPEnabled
                    ) {
                    fwRules.RockstarGamesRulesActivated = true;
                    lbRockstar.Text = lang.lbRockstarOn;
                    btnToggleRockstar.Text = lang.btnToggleRockstarOn;
                }
                else {
                    lbRockstar.Text = lang.lbRockstarOff;
                    btnToggleRockstar.Text = lang.btnToggleRockstarOff;
                }

                lbDestinyRulesActive.Text = "DestinyRulesActive = " + fwRules.Destiny2RulesActivated;
                lbRockstarRulesActive.Text = "RockstarRulesActive = " + fwRules.RockstarGamesRulesActivated;
            }
            catch (Exception ex) {
                reportError(ex);
            }
        }
        void toggleRule(int Game, bool Hotkey = false) {
            if (!isAdmin) {
                return;
            }
            try {
                switch (Game) {
                    case 1:
                        if (fwRules.Destiny2RulesActivated) {
                            if (fwRules.ToggleDestinyRules(false)) {
                                lbDestiny.Text = lang.lbDestinyOff;
                                btnToggleDestiny.Text = lang.btnToggleDestinyOff;
                                fwRules.Destiny2RulesActivated = false;
                                if (Hotkey) { synth.Speak("Destiny 2 rules de-activated."); }
                            }
                        }
                        else {
                            if (fwRules.ToggleDestinyRules(true)) {
                                lbDestiny.Text = lang.lbDestinyOn;
                                btnToggleDestiny.Text = lang.btnToggleDestinyOn;
                                fwRules.Destiny2RulesActivated = true;
                                if (Hotkey) { synth.Speak("Destiny 2 rules activated."); }
                            }
                        }
                        break;

                    case 2:
                        if (fwRules.RockstarGamesRulesActivated) {
                            if (fwRules.ToggleRockstarRules(false, getRockstarRange(lbRockstarRanges))) {
                                lbRockstar.Text = lang.lbRockstarOff;
                                btnToggleRockstar.Text = lang.btnToggleRockstarOff;
                                fwRules.RockstarGamesRulesActivated = false;
                                if (Hotkey) { synth.Speak("Rock Star Games rules de-activated."); }
                            }
                        }
                        else {
                            if (fwRules.ToggleRockstarRules(true, getRockstarRange(lbRockstarRanges))) {
                                lbRockstar.Text = lang.lbRockstarOn;
                                btnToggleRockstar.Text = lang.btnToggleRockstarOn;
                                fwRules.RockstarGamesRulesActivated = true;
                                if (Hotkey) { synth.Speak("Rock Star Games rules activated."); }
                            }
                        }
                        break;
                    default: return;
                }

                lbDestinyRulesActive.Text = "DestinyRulesActive = " + fwRules.Destiny2RulesActivated;
                lbRockstarRulesActive.Text = "RockstarRulesActive = " + fwRules.RockstarGamesRulesActivated;
            }
            catch (Exception ex) {
                reportError(ex);
            }
            
        }

        bool CreateDestinyRules() {
            try {
                if (fwRules.CreateDestinyRule(-1))
                    return true;
                else
                    return false;
            }
            catch (Exception ex) {
                reportError(ex);
                return false;
            }
        }
        bool DeleteDestinyRules() {
            try {
                if (fwRules.DeleteDestinyRules())
                    return true;
                else
                    return false;
            }
            catch (Exception ex) {
                reportError(ex);
                return false;
            }
        }

        bool CreateRockstarRules() {
            try {
                if (fwRules.CreateRockstarRule(-1, getRockstarRange(lbRockstarRanges)))
                    return true;
                else
                    return false;
            }
            catch (Exception ex) {
                reportError(ex);
                return false;
            }
        }
        bool DeleteRockstarRules() {
            try {
                if (fwRules.DeleteRockstarRules())
                    return true;
                else
                    return false;
            }
            catch (Exception ex) {
                reportError(ex);
                return false;
            }
        }

        void reportError(Exception exc) {
            frmException errorReport = new frmException();
            errorReport.reportedException = exc;
            errorReport.ShowDialog();
        }
        private void lbDestinyHotkey_Click(object sender, EventArgs e) {
            frmNewHotkey NewHotkey = new frmNewHotkey();
            NewHotkey.OldModifier = Configuration.Default.DestinyHotkeyModifier;
            NewHotkey.OldKey = Configuration.Default.DestinyHotkeyKey;
            NewHotkey.GameID = 1;
            if (NewHotkey.ShowDialog() == DialogResult.Yes) {
                Configuration.Default.DestinyHotkeyModifier = NewHotkey.NewModifier;
                Configuration.Default.DestinyHotkeyKey = NewHotkey.NewKey;
                Configuration.Default.Save();
                if (DestinyHotkeyActive) {
                    disableHotkeys(1);
                    enableHotkeys(1);
                }
            }
            NewHotkey.Dispose();
        }
        private void lbRockstarHotkey_Click(object sender, EventArgs e) {
            frmNewHotkey NewHotkey = new frmNewHotkey();
            NewHotkey.OldModifier = Configuration.Default.RockstarHotkeyModifier;
            NewHotkey.OldKey = Configuration.Default.RockstarHotkeyKey;
            NewHotkey.GameID = 2;
            if (NewHotkey.ShowDialog() == DialogResult.Yes) {
                Configuration.Default.RockstarHotkeyModifier = NewHotkey.NewModifier;
                Configuration.Default.RockstarHotkeyKey = NewHotkey.NewKey;
                Configuration.Default.Save();
                if (RockstarHotkeyActive) {
                    disableHotkeys(2);
                    enableHotkeys(2);
                }
            }
            NewHotkey.Dispose();
        }

        private void lbCurrentLanguageShort_Click(object sender, EventArgs e) {
            OpeningCMS = true;
            tscbLanguages.Items.Clear();
            tscbLanguages.Items.Add("English (Internal)");
            if (Directory.Exists(Environment.CurrentDirectory + "\\lang\\")) {
                List<string> Files = new List<string>();
                DirectoryInfo LangFolder = new DirectoryInfo(Environment.CurrentDirectory + "\\lang\\");
                FileInfo[] LangFiles = LangFolder.GetFiles("*.ini");
                foreach (FileInfo File in LangFiles) {
                    Files.Add(File.Name.Substring(0, File.Name.Length - 4));
                }
                tscbLanguages.Items.AddRange(Files.ToArray());
                if (Configuration.Default.LanguageFile == "") {
                    tscbLanguages.SelectedIndex = tscbLanguages.ComboBox.SelectedIndex = 0;
                }
                else {
                    tscbLanguages.SelectedIndex = tscbLanguages.ComboBox.FindStringExact(Configuration.Default.LanguageFile);
                }
            }
            cmsLanguageSelect.Show(MousePosition.X, MousePosition.Y + 20);
            OpeningCMS = false;
        }

        private void tscbLanguages_SelectedIndexChanged(object sender, EventArgs e) {
            if (OpeningCMS)
                return;

            if (tscbLanguages.ComboBox.SelectedIndex == 0) {
                Configuration.Default.LanguageFile = "";
                lang.LoadInternalEnglish();
                setLanguage(true);
                Configuration.Default.Save();
            }
            if (lang.LoadLanguage(Environment.CurrentDirectory + "\\lang\\" + tscbLanguages.ComboBox.GetItemText(tscbLanguages.ComboBox.SelectedItem))) {
                Configuration.Default.LanguageFile = tscbLanguages.ComboBox.GetItemText(tscbLanguages.ComboBox.SelectedItem);
                setLanguage(true);
                Configuration.Default.Save();
            }
            cmsLanguageSelect.Hide();
        }

        private void mSettings_Click(object sender, EventArgs e) {
            frmSettings settings = new frmSettings();
            settings.ShowDialog();
            settings.Dispose();
            loadSettings();
        }
        private void mGithub_Click(object sender, EventArgs e) {
            System.Diagnostics.Process.Start("https://github.com/murrty/SoloMatchmaking");
        }
    }
}