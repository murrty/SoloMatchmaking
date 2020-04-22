using NetFwTypeLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoloMatchmaking {
    public partial class frmMain : Form {
        public static string destinyPorts = Configuration.Default.DestinyPorts;
        public static string[] destinyNames = Configuration.Default.DestinyNames.Split(',');
        public static string rockstarPorts = Configuration.Default.RockstarPorts;
        public static string[] rockstarNames = Configuration.Default.RockstarNames.Split(',');
        public static readonly int[] ruleProtocol = { 6, 17 }; // tcp, udp
        // Ranges are separated by a comma

        bool DestinyRulesCreated = false;   // if the rules for d2 were created
        bool DestinyRulesActive = false;    // if the rules for d2 are active
        bool DestinyHotkeyActive = false;   // if the hotkey for d2 is active

        bool RockstarRulesCreated = false;  // if the rules for r* were created
        bool RockstarRulesActive = false;   // if the rules for r* are active
        bool RockstarHotkeyActive = false;  // if the hotkey for r* is active

        bool isAdmin = false;               // if running elevated
        bool skipOneChange = false;         // Skip LocationChanged event once, required for now
        bool locationChanged = false;       // if the form moved at all
        bool OpeningCMS = false;            // if the context menu strip is being opened for language

        KeyboardHook destinyHook;
        KeyboardHook rockstarHook;
        Language lang = Language.GetLanguageInstance();

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);
        void destinyHook_KeyPressed(object sender, KeyPressedEventArgs e) {
            if (chkEnableDestinyHotkey.Checked) {
                toggleRule(1);
            }
        }
        void rockstarHook_KeyPressed(object sender, KeyPressedEventArgs e) {
            if (chkEnableRockstarHotkey.Checked) {
                toggleRule(2);
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
            if (Configuration.Default.LastPosX != -99999999 & Configuration.Default.LastPosY != -99999999) {
                this.Location = new Point(Configuration.Default.LastPosX, Configuration.Default.LastPosY);
            }

            bool Debug = false;
            for (int i = 0; i < Environment.GetCommandLineArgs().Length; i++) {
                if (Environment.GetCommandLineArgs()[i] == "-debug")
                    Debug = true;
            }
            if (!Debug)
                tabMain.TabPages.RemoveAt(2);
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
                Configuration.Default.LastPosX = this.Location.X;
                Configuration.Default.LastPosY = this.Location.Y;
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
                tabMain.TabPages[2].Text = lang.tabDebug;
            }
            lbCurrentLanguageShort.Text = lang.CurrentLanguageShort;
            ttMain.SetToolTip(this.lbCurrentLanguageShort, lang.CurrentLanguageLong + " (" + lang.CurrentLanguageShort + ")\n" + lang.CurrentLanguageHint);
            tsmiSelectLanguage.Text = lang.tsmiSelectLanguage;
            if (DestinyRulesActive) {
                lbDestiny.Text = lang.lbDestinyOn;
            }
            else {
                lbDestiny.Text = lang.lbDestinyOff;
            }
            if (RockstarRulesActive) {
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
            loadConfiguration();

            chkEnableDestinyHotkey.Checked = Configuration.Default.EnableDestinyHotkeys;
            chkEnableRockstarHotkey.Checked = Configuration.Default.EnableRockstarHotkeys;
        }
        void loadConfiguration() {
            destinyPorts = Configuration.Default.DestinyPorts;
            destinyNames = Configuration.Default.DestinyNames.Split(',');
            rockstarPorts = Configuration.Default.RockstarPorts;
            rockstarNames = Configuration.Default.RockstarNames.Split(',');
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
                Type firewallType = Type.GetTypeFromProgID("HNetCfg.FwPolicy2");
                INetFwPolicy2 fwPolicy = (INetFwPolicy2)Activator.CreateInstance(firewallType);

                bool DestinyRuleExists = false;
                bool RockstarRuleExists = false;

                foreach (INetFwRule FoundRule in fwPolicy.Rules) {
                    for (int i = 0; i < destinyNames.Length; i++) {
                        if (FoundRule.Name.IndexOf(destinyNames[i]) != -1) {
                            DestinyRuleExists = true;
                            //DestinyRuleActive = FoundRule.Enabled; // TODO: Fix duplicate rules problem
                            break;
                        }
                    }
                    for (int i = 0; i < rockstarNames.Length; i++) {
                        if (FoundRule.Name.IndexOf(rockstarNames[i]) != -1) {
                            RockstarRuleExists = true;
                            //RockstarRuleActive = FoundRule.Enabled; // TODO: Fix duplicate rules problem
                            break;
                        }
                    }
                }

                if (DestinyRuleExists) {
                    DestinyRulesActive = DestinyRuleExists;
                    DestinyRulesCreated = DestinyRuleExists;
                    lbDestiny.Text = lang.lbDestinyOn;
                    btnToggleDestiny.Text = lang.btnToggleDestinyOn;
                }
                else {
                    DestinyRulesActive = DestinyRuleExists;
                    DestinyRulesCreated = DestinyRuleExists;
                    lbDestiny.Text = lang.lbDestinyOff;
                    btnToggleDestiny.Text = lang.btnToggleDestinyOff;
                }
                if (RockstarRuleExists) {
                    RockstarRulesActive = RockstarRuleExists;
                    RockstarRulesCreated = RockstarRuleExists;
                    lbRockstar.Text = lang.lbRockstarOn;
                    btnToggleRockstar.Text = lang.btnToggleRockstarOn;
                }
                else {
                    RockstarRulesActive = RockstarRuleExists;
                    RockstarRulesCreated = RockstarRuleExists;
                    lbRockstar.Text = lang.lbRockstarOff;
                    btnToggleRockstar.Text = lang.btnToggleRockstarOff;
                }

                lbDestinyRulesActive.Text = "DestinyRulesActive = " + DestinyRulesActive.ToString();
                lbRockstarRulesActive.Text = "RockstarRulesActive = " + RockstarRulesActive.ToString();

            }
            catch (Exception ex) {
                reportError(ex);
            }
        }
        void toggleRule(int Game) {
            if (!isAdmin) {
                return;
            }
            try {
                switch (Game) {
                    case 1:
                        if (!DestinyRulesActive) {
                            if (CreateDestinyRules()) {
                                lbDestiny.Text = lang.lbDestinyOn;
                                btnToggleDestiny.Text = lang.btnToggleDestinyOn;
                                System.Media.SystemSounds.Exclamation.Play();
                            }
                        }
                        else {
                            if (DeleteDestinyRules()) {
                                lbDestiny.Text = lang.lbDestinyOff;
                                btnToggleDestiny.Text = lang.btnToggleDestinyOff;
                                System.Media.SystemSounds.Asterisk.Play();
                            }
                        }
                        break;
                    case 2:
                        if (!RockstarRulesActive) {
                            if (CreateRockstarRules()) {
                                lbRockstar.Text = lang.lbRockstarOn;
                                btnToggleRockstar.Text = lang.btnToggleRockstarOn;
                                System.Media.SystemSounds.Exclamation.Play();
                            }
                        }
                        else {
                            if (DeleteRockstarRules()) {
                                lbRockstar.Text = lang.lbRockstarOff;
                                btnToggleRockstar.Text = lang.btnToggleRockstarOff;
                                lbRockstar.Text = lang.lbRockstarOff;
                                btnToggleRockstar.Text = lang.btnToggleRockstarOff;
                                System.Media.SystemSounds.Asterisk.Play();
                            }
                        }
                        break;
                    default: return;
                }

                lbDestinyRulesActive.Text = "DestinyRulesActive = " + DestinyRulesActive.ToString();
                lbRockstarRulesActive.Text = "RockstarRulesActive = " + RockstarRulesActive.ToString();
            }
            catch (Exception ex) {
                reportError(ex);
            }
            
        }
        bool deleteRules(int Game) {
            try {
                bool deleted = false;
                if (DestinyRulesCreated) { if (DeleteDestinyRules()) { deleted = true; } }
                if (RockstarRulesCreated) { if (DeleteRockstarRules()) { deleted = true; } }

                return deleted;
            }
            catch (Exception ex) {
                reportError(ex);
                return false;
            }
        }

        bool CreateDestinyRules() {
            if (Program.IsDebugging) {
                if (string.IsNullOrEmpty(Configuration.Default.Destiny2Program) || !File.Exists(Configuration.Default.Destiny2Program)) {
                    MessageBox.Show("Destiny 2 application was not specified, please specify it.");
                    using (OpenFileDialog ofd = new OpenFileDialog()) {
                        ofd.Title = "Open destiny2.exe";
                        ofd.Filter = "Destiny 2 (destiny2.exe)|destiny2.exe";
                        if (ofd.ShowDialog() == DialogResult.OK) {
                            Configuration.Default.Destiny2Program = ofd.FileName;
                            Configuration.Default.Save();
                        }
                        else {
                            return false;
                        }
                    }
                }
            }

            try {
                INetFwRule2 outTCP = (INetFwRule2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FWRule"));
                outTCP.Name = destinyNames[0];
                //outTCP.ApplicationName = Configuration.Default.Destiny2Program;
                outTCP.Description = "Blocks certain ports from connecting to block anyone from matchmaking in Destiny 2";
                outTCP.Profiles = (int)NET_FW_PROFILE_TYPE2_.NET_FW_PROFILE2_ALL;
                outTCP.Action = NET_FW_ACTION_.NET_FW_ACTION_BLOCK;
                outTCP.Direction = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_OUT;
                outTCP.Protocol = ruleProtocol[0];
                outTCP.RemotePorts = destinyPorts;
                outTCP.InterfaceTypes = "All";
                outTCP.Enabled = true;
                Console.WriteLine("Destiny 2 outTCP created");

                INetFwRule2 outUDP = (INetFwRule2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FWRule"));
                outUDP.Name = destinyNames[1];
                //outUDP.ApplicationName = Configuration.Default.Destiny2Program;
                outUDP.Description = "Blocks certain ports from connecting to block anyone from matchmaking in Destiny 2";
                outUDP.Profiles = (int)NET_FW_PROFILE_TYPE2_.NET_FW_PROFILE2_ALL;
                outUDP.Action = NET_FW_ACTION_.NET_FW_ACTION_BLOCK;
                outUDP.Direction = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_OUT;
                outUDP.Protocol = ruleProtocol[1];
                outUDP.RemotePorts = destinyPorts;
                outUDP.InterfaceTypes = "All";
                outUDP.Enabled = true;
                Console.WriteLine("Destiny 2 outUDP created");

                INetFwRule2 inTCP = (INetFwRule2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FWRule"));
                inTCP.Name = destinyNames[2];
                //inTCP.ApplicationName = Configuration.Default.Destiny2Program;
                inTCP.Description = "Blocks certain ports from connecting to block anyone from matchmaking in Destiny 2";
                inTCP.Profiles = (int)NET_FW_PROFILE_TYPE2_.NET_FW_PROFILE2_ALL;
                inTCP.Action = NET_FW_ACTION_.NET_FW_ACTION_BLOCK;
                inTCP.Direction = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_IN;
                inTCP.Protocol = ruleProtocol[0];
                inTCP.RemotePorts = destinyPorts;
                inTCP.InterfaceTypes = "All";
                inTCP.Enabled = true;
                Console.WriteLine("Destiny 2 inTCP created");

                INetFwRule2 inUDP = (INetFwRule2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FWRule"));
                inUDP.Name = destinyNames[3];
                //inUDP.ApplicationName = Configuration.Default.Destiny2Program;
                inUDP.Description = "Blocks certain ports from connecting to block anyone from matchmaking in Destiny 2";
                inUDP.Profiles = (int)NET_FW_PROFILE_TYPE2_.NET_FW_PROFILE2_ALL;
                inUDP.Action = NET_FW_ACTION_.NET_FW_ACTION_BLOCK;
                inUDP.Direction = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_IN;
                inUDP.Protocol = ruleProtocol[1];
                inUDP.RemotePorts = destinyPorts;
                inUDP.InterfaceTypes = "All";
                inUDP.Enabled = true;
                Console.WriteLine("Destiny 2 inUDP created");

                Console.WriteLine("called firewallPolicy");
                INetFwPolicy2 firewallPolicy = (INetFwPolicy2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwPolicy2"));
                firewallPolicy.Rules.Add(outTCP);
                Console.WriteLine("Destiny 2 added outTCP to the firewall");
                firewallPolicy.Rules.Add(outUDP);
                Console.WriteLine("Destiny 2 added outUDP to the firewall");
                firewallPolicy.Rules.Add(inTCP);
                Console.WriteLine("Destiny 2 added inTCP to the firewall");
                firewallPolicy.Rules.Add(inUDP);
                Console.WriteLine("Destiny 2 added inUDP to the firewall");

                DestinyRulesCreated = true;
                DestinyRulesActive = true;

                return true;
            }
            catch (Exception ex) {
                reportError(ex);
                return false;
            }
        }
        bool DeleteDestinyRules() {
            try {
                Type firewallType = Type.GetTypeFromProgID("HNetCfg.FwPolicy2");
                INetFwPolicy2 fwPolicy = (INetFwPolicy2)Activator.CreateInstance(firewallType);

                fwPolicy.Rules.Remove(destinyNames[0]);
                Console.WriteLine("Destiny 2 outTCP has been removed");
                fwPolicy.Rules.Remove(destinyNames[1]);
                Console.WriteLine("Destiny 2 outUDP has been removed");
                fwPolicy.Rules.Remove(destinyNames[2]);
                Console.WriteLine("Destiny 2 inTCP has been removed");
                fwPolicy.Rules.Remove(destinyNames[3]);
                Console.WriteLine("Destiny 2 inUDP has been removed");

                DestinyRulesCreated = false;
                DestinyRulesActive = false;

                lbDestinyRulesActive.Text = "DestinyRulesActive = " + DestinyRulesActive.ToString();

                return true;
            }
            catch (Exception ex) {
                reportError(ex);
                return false;
            }
        }

        bool CreateRockstarRules() {
            try {
                INetFwRule2 outUDP = (INetFwRule2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FWRule"));
                outUDP.Name = rockstarNames[0];
                outUDP.Description = "Blocks certain ports from connecting to block anyone from matchmaking in Destiny 2";
                outUDP.Profiles = (int)NET_FW_PROFILE_TYPE2_.NET_FW_PROFILE2_ALL;
                outUDP.Action = NET_FW_ACTION_.NET_FW_ACTION_BLOCK;
                outUDP.Direction = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_OUT;
                outUDP.Protocol = ruleProtocol[1];
                outUDP.LocalPorts = rockstarPorts;
                if (lbRockstarRanges.Items.Count > 0) {
                    outUDP.RemoteAddresses = getRockstarRange(lbRockstarRanges);
                }
                outUDP.InterfaceTypes = "All";
                outUDP.Enabled = true;
                Console.WriteLine("Rockstar outUDP created");

                INetFwRule2 inUDP = (INetFwRule2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FWRule"));
                inUDP.Name = rockstarNames[1];
                inUDP.Description = "Blocks certain ports from connecting to block anyone from matchmaking in Destiny 2";
                inUDP.Profiles = (int)NET_FW_PROFILE_TYPE2_.NET_FW_PROFILE2_ALL;
                inUDP.Action = NET_FW_ACTION_.NET_FW_ACTION_BLOCK;
                inUDP.Direction = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_IN;
                inUDP.Protocol = ruleProtocol[1];
                inUDP.LocalPorts = rockstarPorts;
                if (lbRockstarRanges.Items.Count > 0) {
                    outUDP.RemoteAddresses = getRockstarRange(lbRockstarRanges);
                }
                inUDP.InterfaceTypes = "All";
                inUDP.Enabled = true;
                Console.WriteLine("Rockstar inUDP created");


                Console.WriteLine("called firewallPolicy");
                INetFwPolicy2 firewallPolicy = (INetFwPolicy2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwPolicy2"));
                firewallPolicy.Rules.Add(outUDP);
                Console.WriteLine("Rockstar added outUDP to the firewall");
                firewallPolicy.Rules.Add(inUDP);
                Console.WriteLine("Rockstar added outUDP to the firewall");

                RockstarRulesCreated = true;
                RockstarRulesActive = true;

                return true;
            }
            catch (Exception ex) {
                reportError(ex);
                return false;
            }
        }
        bool DeleteRockstarRules() {
            try {
                Type firewallType = Type.GetTypeFromProgID("HNetCfg.FwPolicy2");
                INetFwPolicy2 fwPolicy = (INetFwPolicy2)Activator.CreateInstance(firewallType);

                fwPolicy.Rules.Remove(rockstarNames[0]);
                Console.WriteLine("Rockstar outTCP has been removed");
                fwPolicy.Rules.Remove(rockstarNames[1]);
                Console.WriteLine("Rockstar inTCP has been removed");

                RockstarRulesCreated = false;
                RockstarRulesActive = false;

                lbRockstarRulesActive.Text = "RockstarRulesActive = " + RockstarRulesActive.ToString();

                return true;
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
    }
}