using System;

// TODO: Better language handling

namespace SoloMatchmaking {
    public class Language {
        public string CurrentLanguageShort = string.Empty;
        public string CurrentLanguageLong = string.Empty;

        // Globally used
        public string HotkeyToggle = string.Empty;
        public string HotkeyDisabled = string.Empty;
        public string HotkeyUnavailable = string.Empty;

        // frmMain
        public string frmMainAdmin = string.Empty;
        public string frmMain = string.Empty;
        public string lbDestinyOff = string.Empty;
        public string lbDestinyOn = string.Empty;
        public string lbRockstarOff = string.Empty;
        public string lbRockstarOn = string.Empty;
        public string tsmiSelectLanguage = string.Empty;

        // frmMain / tabMain
        public string tabDestiny = string.Empty;
        public string tabRockstar = string.Empty;
        public string tabDebug = string.Empty;

        // frmMain / tabMain / tabDestiny
        public string chkEnableDestinyHotkey = string.Empty;
        public string btnToggleDestinyOff = string.Empty;
        public string btnToggleDestinyOn = string.Empty;
        public string ttMainChangeDestinyHotkey = string.Empty;

        // frmMain / tabMain / tabRockstar
        public string chkEnableRockstarHotkey = string.Empty;
        public string btnAddRockstarRange = string.Empty;
        public string btnRemoveRockstarRange = string.Empty;
        public string txtRockstarRange = string.Empty;
        public string btnToggleRockstarOff = string.Empty;
        public string btnToggleRockstarOn = string.Empty;
        public string ttMainChangeRockstarHotkey = string.Empty;
        public string rtbRockstarInfo = string.Empty;

        // frmError
        public string frmError = string.Empty;
        public string lbExceptionHeader = string.Empty;
        public string lbExceptionDescription = string.Empty;
        public string rtbExceptionDetails = string.Empty;
        public string btnExceptionGithub = string.Empty;
        public string btnExceptionOk = string.Empty;

        // frmNewHotkey
        public string frmNewHotkey = string.Empty;
        public string lbNewHotkeyHeader = string.Empty;
        public string lbNewHotkeyDescription = string.Empty;
        public string lbNewHotkeyModifier = string.Empty;
        public string lbNewHotkeyKey = string.Empty;
        public string btnNewHotkeyResetToDefault = string.Empty;
        public string btnNewHotkeyCancel = string.Empty;
        public string btnNewHotkeySave = string.Empty;


        public bool LoadInternalEnglish() {
            CurrentLanguageShort = "en-i";
            CurrentLanguageLong = "English (Internal)";

            // Globally used
            HotkeyToggle = "to toggle";
            HotkeyDisabled = "Hotkey disabled";
            HotkeyUnavailable = "Hotkey unavailable (not admin)";

            // frmMain
            frmMainAdmin = "Solo Matchmaking";
            frmMain = "Solo Matchmaking (Not running as Admin)";
            lbDestinyOff = "Destiny 2 off";
            lbDestinyOn = "Destiny 2 on";
            lbRockstarOff = "Rockstar off";
            lbRockstarOn = "Rockstar on";
            tsmiSelectLanguage = "Select language";

            // frmMain / tabMain
            tabDestiny = "Destiny 2";
            tabRockstar = "Rockstar Games";
            tabDebug = "Debug";

            // frmMain / tabMain / tabDestiny
            chkEnableDestinyHotkey = "Enable Destiny 2 hotkey";
            btnToggleDestinyOff = "Activate Destiny 2 rules";
            btnToggleDestinyOn = "Deactive Destiny 2 rules";
            ttMainChangeDestinyHotkey = "Click here to change the hotkey for Destiny 2";

            // frmMain / tabMain / tabRockstar
            chkEnableRockstarHotkey = "Enable Rockstar Games hotkey";
            btnAddRockstarRange = "Add";
            btnRemoveRockstarRange = "Remove";
            txtRockstarRange = "1.1.1.1-255.255.255.255";
            btnToggleRockstarOff = "Active Rockstar rules";
            btnToggleRockstarOn = "Deactive Rockstar rules";
            ttMainChangeRockstarHotkey = "Click here to change the hotkey for Rockstar Games";
            rtbRockstarInfo = "For GTA 5:\n" +
                              "- Activate Rules\n" +
                              "- Load into a Lobby\n" +
                              "- Deactivate Rules\n" +
                              "- Invite friends\n" +
                              "- Reactive rules\n" +
                              "\n" +
                              "For RDR 2:\n" +
                              "- Join Elimination Series\n" +
                              "- Return to Free Roam\n" +
                              "- Load into Change Appearance (L -> Online Options -> Change Appearance)\n" +
                              "- Activate rules\n" +
                              "- Return to Free Roam\n" +
                              "- Disable rules after a while to invite non whitelisted players";

            // frmError
            frmError = "An exception occured";
            lbExceptionHeader = "An exception has occured";
            lbExceptionDescription = "Below is the error that occured. Feel free to open a new issue and report it.";
            rtbExceptionDetails = "Feel free to copy + paste this entire text wall into a new issue on Github";
            btnExceptionGithub = "Open Github";
            btnExceptionOk = "OK";

            // frmNewHotkey
            frmNewHotkey = "New hotkey";
            lbNewHotkeyHeader = "New hotkey";
            lbNewHotkeyDescription = "Specify a new hotkey for";
            lbNewHotkeyModifier = "Modifier";
            lbNewHotkeyKey = "Key";
            btnNewHotkeyResetToDefault = "Reset to Default";
            btnNewHotkeyCancel = "Cancel";
            btnNewHotkeySave = "Save";
            return true;
        }
        public bool LoadLanguage(string lang) {
            if (System.IO.File.Exists(Environment.CurrentDirectory + "\\lang\\" + lang + ".ini")) {
                try {
                    string[] ReadFile = System.IO.File.ReadAllLines(Environment.CurrentDirectory + "\\lang\\" + lang + ".ini");

                    for (int i = 0; i < ReadFile.Length; i++) {
                        string ReadLine = ReadFile[i];
                        if (ReadLine.StartsWith("//") || ReadLine.Trim(' ') == (""))
                            continue;

                        if (ReadLine.StartsWith("[") & ReadLine.EndsWith("]")) {
                            CurrentLanguageLong = ReadLine.Trim('[').Trim(']');
                            continue;
                        }

                        else if (ReadLine.StartsWith("CurrentLanguageShort")) {
                            CurrentLanguageShort = ReadLine.Split('=')[1];
                            continue;
                        }


                        else if (ReadLine.StartsWith("HotkeyToggle")) {
                            HotkeyToggle = ReadLine.Split('=')[1];
                            continue;
                        }
                        else if (ReadLine.StartsWith("HotkeyDisabled")) {
                            HotkeyDisabled = ReadLine.Split('=')[1];
                            continue;
                        }
                        else if (ReadLine.StartsWith("HotkeyUnavailable")) {
                            HotkeyUnavailable = ReadLine.Split('=')[1];
                            continue;
                        }


                        else if (ReadLine.StartsWith("frmMainAdmin")) {
                            frmMainAdmin = ReadLine.Split('=')[1];
                            continue;
                        }
                        else if (ReadLine.StartsWith("frmMain")) {
                            frmMain = ReadLine.Split('=')[1];
                            continue;
                        }
                        else if (ReadLine.StartsWith("lbDestinyOff")) {
                            lbDestinyOff = ReadLine.Split('=')[1];
                            continue;
                        }
                        else if (ReadLine.StartsWith("lbDestinyOn")) {
                            lbDestinyOn = ReadLine.Split('=')[1];
                            continue;
                        }
                        else if (ReadLine.StartsWith("lbRockstarOff")) {
                            lbRockstarOff = ReadLine.Split('=')[1];
                            continue;
                        }
                        else if (ReadLine.StartsWith("lbRockstarOn")) {
                            lbRockstarOn = ReadLine.Split('=')[1];
                            continue;
                        }
                        else if (ReadLine.StartsWith("tsmiSelectLanguage")) {
                            tsmiSelectLanguage = ReadLine.Split('=')[1];
                            continue;
                        }


                        else if (ReadLine.StartsWith("tabDestiny")) {
                            tabDestiny = ReadLine.Split('=')[1];
                            continue;
                        }
                        else if (ReadLine.StartsWith("tabRockstar")) {
                            tabRockstar = ReadLine.Split('=')[1];
                            continue;
                        }
                        else if (ReadLine.StartsWith("tabDebug")) {
                            tabDebug = ReadLine.Split('=')[1];
                            continue;
                        }


                        else if (ReadLine.StartsWith("chkEnableDestiny")) {
                            chkEnableDestinyHotkey = ReadLine.Split('=')[1];
                            continue;
                        }
                        else if (ReadLine.StartsWith("btnToggleDestinyOff")) {
                            btnToggleDestinyOff = ReadLine.Split('=')[1];
                            continue;
                        }
                        else if (ReadLine.StartsWith("btnToggleDestinyOn")) {
                            btnToggleDestinyOn = ReadLine.Split('=')[1];
                            continue;
                        }
                        else if (ReadLine.StartsWith("ttMainChangeDestinyHotkey")) {
                            ttMainChangeDestinyHotkey = ReadLine.Split('=')[1];
                            continue;
                        }

                        else if (ReadLine.StartsWith("chkEnableRockstar")) {
                            chkEnableRockstarHotkey = ReadLine.Split('=')[1];
                            continue;
                        }
                        else if (ReadLine.StartsWith("btnAddRockstarRange")) {
                            btnAddRockstarRange = ReadLine.Split('=')[1];
                            continue;
                        }
                        else if (ReadLine.StartsWith("btnRemoveRockstarRange")) {
                            btnRemoveRockstarRange = ReadLine.Split('=')[1];
                            continue;
                        }
                        else if (ReadLine.StartsWith("txtRockstarRange")) {
                            txtRockstarRange = ReadLine.Split('=')[1];
                            continue;
                        }
                        else if (ReadLine.StartsWith("btnToggleRockstarOff")) {
                            btnToggleRockstarOff = ReadLine.Split('=')[1];
                            continue;
                        }
                        else if (ReadLine.StartsWith("btnToggleRockstarOn")) {
                            btnToggleRockstarOn = ReadLine.Split('=')[1];
                            continue;
                        }
                        else if (ReadLine.StartsWith("ttMainChangeRockstarHotkey")) {
                            ttMainChangeRockstarHotkey = ReadLine.Split('=')[1];
                            continue;
                        }
                        else if (ReadLine.StartsWith("rtbRockstarInfo")) {
                            rtbRockstarInfo = ReadLine.Split('=')[1];
                            continue;
                        }


                        else if (ReadLine.StartsWith("frmError")) {
                            frmError = ReadLine.Split('=')[1];
                            continue;
                        }
                        else if (ReadLine.StartsWith("lbExceptionHeader")) {
                            lbExceptionHeader = ReadLine.Split('=')[1];
                            continue;
                        }
                        else if (ReadLine.StartsWith("lbExceptionDescription")) {
                            lbExceptionDescription = ReadLine.Split('=')[1];
                            continue;
                        }
                        else if (ReadLine.StartsWith("rtbExceptionDetails")) {
                            rtbExceptionDetails = ReadLine.Split('=')[1];
                            continue;
                        }
                        else if (ReadLine.StartsWith("btnExceptionGithub")) {
                            btnExceptionGithub = ReadLine.Split('=')[1];
                            continue;
                        }
                        else if (ReadLine.StartsWith("btnExceptionOk")) {
                            btnExceptionOk = ReadLine.Split('=')[1];
                            continue;
                        }


                        else if (ReadLine.StartsWith("frmNewHotkey")) {
                            frmNewHotkey = ReadLine.Split('=')[1];
                            continue;
                        }
                        else if (ReadLine.StartsWith("lbNewHotkeyHeader")) {
                            lbNewHotkeyHeader = ReadLine.Split('=')[1];
                            continue;
                        }
                        else if (ReadLine.StartsWith("lbNewHotkeyDescription")) {
                            lbNewHotkeyDescription = ReadLine.Split('=')[1];
                            continue;
                        }
                        else if (ReadLine.StartsWith("lbNewHotkeyModifier")) {
                            lbNewHotkeyModifier = ReadLine.Split('=')[1];
                            continue;
                        }
                        else if (ReadLine.StartsWith("lbNewHotkeyKey")) {
                            lbNewHotkeyKey = ReadLine.Split('=')[1];
                            continue;
                        }
                        else if (ReadLine.StartsWith("btnNewHotkeyResetToDefault")) {
                            btnNewHotkeyResetToDefault = ReadLine.Split('=')[1];
                            continue;
                        }
                        else if (ReadLine.StartsWith("btnNewHotkeyCancel")) {
                            btnNewHotkeyCancel = ReadLine.Split('=')[1];
                            continue;
                        }
                        else if (ReadLine.StartsWith("btnNewHotkeySave")) {
                            btnNewHotkeySave = ReadLine.Split('=')[1];
                            continue;
                        }
                    }
                    return true;
                }
                catch (Exception ex) {
                    frmError error = new frmError();
                    error.reportedException = ex;
                    error.FromLanguage = true;
                    error.ShowDialog();
                    return false;
                }
            }
            else {
                return false;
            }
        }
    }
}
