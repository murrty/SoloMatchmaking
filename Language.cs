using System;

namespace SoloMatchmaking {
    public class Language {
        #region Variables
        private static Language LangInstance = new Language();
        private static volatile string LoadedFileString = null;

        // Language identifier
        private static volatile string CurrentLanguageLongString = "CurrentLanguageLong";               // ID 0
        private static volatile string CurrentLanguageShortString = "CurrentLanguageShort";             // ID 1
        private static volatile string CurrentLanguageHintString = "CurrentLanguageHint";               // ID 2

        // Globally used
        private static volatile string HotkeyToggleString = "HotkeyToggle";                             // ID 3
        private static volatile string HotkeyDisabledString = "HotkeyDisabled";                         // ID 4
        private static volatile string HotkeyUnavailableString = "HotkeyUnavailable";                   // ID 5

        // frmMain
        private static volatile string frmMainAdminString = "frmMainAdmin";                             // ID 6
        private static volatile string frmMainNoAdminString = "frmMain";                                       // ID 7
        private static volatile string lbDestinyOffString = "lbDestinyOff";                             // ID 8
        private static volatile string lbDestinyOnString = "lbDestinyOn";                               // ID 9
        private static volatile string lbRockstarOffString = "lbRockstarOff";                           // ID 10
        private static volatile string lbRockstarOnString = "lbRockstarOn";                             // ID 11
        private static volatile string tsmiSelectLanguageString = "tsmiSelectLanguage";                 // ID 12

        // frmMain / tabMain
        private static volatile string tabDestinyString = "tabDestiny";                                 // ID 13
        private static volatile string tabRockstarString = "tabRockstar";                               // ID 14
        private static volatile string tabDebugString = "tabDebug";                                     // ID 15
        
        // frmMain / tabMain / tabDestiny
        private static volatile string chkEnableDestinyHotkeyString = "chkEnableDestinyHotkey";         // ID 16
        private static volatile string btnToggleDestinyOffString = "btnToggleDestinyOff";               // ID 17
        private static volatile string btnToggleDestinyOnString = "btnToggleDestinyOn";                 // ID 18
        private static volatile string ttMainChangeDestinyHotkeyString = "ttMainChangeDestinyHotkey";   // ID 19
        
        // frmMain / tabMain / tabRockstar
        private static volatile string chkEnableRockstarHotkeyString = "chkEnableRockstarHotkey";       // ID 20
        private static volatile string btnAddRockstarRangeString = "btnAddRockstarRange";               // ID 21
        private static volatile string btnRemoveRockstarRangeString = "btnRemoveRockstarRange";         // ID 22
        private static volatile string txtRockstarRangeString = "txtRockstarRange";                     // ID 23
        private static volatile string btnToggleRockstarOffString = "btnToggleRockstarOff";             // ID 24
        private static volatile string btnToggleRockstarOnString = "btnToggleRockstarOn";               // ID 25
        private static volatile string ttMainChangeRockstarHotkeyString = "ttMainChangeRockstarHotkey"; // ID 26
        private static volatile string rtbRockstarInfoString = "rtbRockstarInfo";                       // ID 27

        // frmException
        private static volatile string frmExceptionString = "frmException";                             // ID 28
        private static volatile string lbExceptionHeaderString = "lbExceptionHeader";                   // ID 29
        private static volatile string lbExceptionDescriptionString = "lbExceptionDescription";         // ID 30
        private static volatile string rtbExceptionDetailsString = "rtbExceptionDetails";               // ID 31
        private static volatile string btnExceptionGithubString = "btnExceptionGithub";                 // ID 32
        private static volatile string btnExceptionOkString = "btnExceptionOk";                         // ID 33

        // frmNewHotkey
        private static volatile string frmNewHotkeyString = "frmNewHotkey";                             // ID 34
        private static volatile string lbNewHotkeyHeaderString = "lbNewHotkeyHeader";                   // ID 35
        private static volatile string lbNewHotkeyDescriptionString = "lbNewHotkeyDescription";         // ID 36
        private static volatile string lbNewHotkeyModifierString = "lbNewHotkeyModifier";               // ID 37
        private static volatile string lbNewHotkeyKeyString = "lbNewHotkeyKey";                         // ID 38
        private static volatile string btnNewHotkeyResetToDefaultString = "btnNewHotkeyResetToDefault"; // ID 39
        private static volatile string btnNewHotkeyCancelString = "btnNewHotkeyCancel";                 // ID 40
        private static volatile string btnNewHotkeySaveString = "btnNewHotkeySave";                     // ID 41
        #endregion

        #region GetSetRadio
//////////////// Language identifier \\\\\\\\\\\\\\\\
        public string CurrentLanguageShort {
            get { return CurrentLanguageShortString; }
            private set { CurrentLanguageShortString = value; }
        }
        public string CurrentLanguageLong {
            get { return CurrentLanguageLongString; }
            private set { CurrentLanguageLongString = value; }
        }
        public string CurrentLanguageHint {
            get { return CurrentLanguageHintString; }
            private set { CurrentLanguageHintString = value; }
        }

//////////////// Globally used \\\\\\\\\\\\\\\\
        public string HotkeyToggle {
            get { return HotkeyToggleString; }
            private set { HotkeyToggleString = value; }
        }
        public string HotkeyDisabled {
            get { return HotkeyDisabledString; }
            private set { HotkeyDisabledString = value; }
        }
        public string HotkeyUnavailable {
            get { return HotkeyUnavailableString; }
            private set { HotkeyUnavailableString = value; }
        }

//////////////// frmMain \\\\\\\\\\\\\\\\
        public string frmMainAdmin {
            get { return frmMainAdminString; }
            private set { frmMainAdminString = value; }
        }
        public string frmMainNoAdmin {
            get { return frmMainNoAdminString; }
            private set { frmMainNoAdminString = value; }
        }
        public string lbDestinyOff {
            get { return lbDestinyOffString; }
            private set { lbDestinyOffString = value; }
        }
        public string lbDestinyOn {
            get { return lbDestinyOnString; }
            private set { lbDestinyOnString = value; }
        }
        public string lbRockstarOff {
            get { return lbRockstarOffString; }
            private set { lbRockstarOffString = value; }
        }
        public string lbRockstarOn {
            get { return lbRockstarOnString; }
            private set { lbRockstarOnString = value; }
        }
        public string tsmiSelectLanguage {
            get { return tsmiSelectLanguageString; }
            private set { tsmiSelectLanguageString = value; }
        }

//////////////// frmMain / tabMain \\\\\\\\\\\\\\\\
        public string tabDestiny {
            get { return tabDestinyString; }
            private set { tabDestinyString = value; }
        }
        public string tabRockstar {
            get { return tabRockstarString; }
            private set { tabRockstarString = value; }
        }
        public string tabDebug {
            get { return tabDebugString; }
            private set { tabDebugString = value; }
        }

//////////////// // frmMain / tabMain / tabDestiny \\\\\\\\\\\\\\\\
        public string chkEnableDestinyHotkey {
            get { return chkEnableDestinyHotkeyString; }
            private set { chkEnableDestinyHotkeyString = value; }
        }
        public string btnToggleDestinyOff {
            get { return btnToggleDestinyOffString; }
            private set { btnToggleDestinyOffString = value; }
        }
        public string btnToggleDestinyOn {
            get { return btnToggleDestinyOnString; }
            private set { btnToggleDestinyOnString = value; }
        }
        public string ttMainChangeDestinyHotkey {
            get { return ttMainChangeDestinyHotkeyString; }
            private set { ttMainChangeDestinyHotkeyString = value; }
        }

//////////////// // frmMain / tabMain / tabRockstar \\\\\\\\\\\\\\\\
        public string chkEnableRockstarHotkey {
            get { return chkEnableRockstarHotkeyString; }
            private set { chkEnableRockstarHotkeyString = value; }
        }
        public string btnAddRockstarRange {
            get { return btnAddRockstarRangeString; }
            private set { btnAddRockstarRangeString = value; }
        }
        public string btnRemoveRockstarRange {
            get { return btnRemoveRockstarRangeString; }
            private set { btnRemoveRockstarRangeString = value; }
        }
        public string txtRockstarRange {
            get { return txtRockstarRangeString; }
            private set { txtRockstarRangeString = value; }
        }
        public string btnToggleRockstarOff {
            get { return btnToggleRockstarOffString; }
            private set { btnToggleRockstarOffString = value; }
        }
        public string btnToggleRockstarOn {
            get { return btnToggleRockstarOnString; }
            private set { btnToggleRockstarOnString = value; }
        }
        public string ttMainChangeRockstarHotkey {
            get { return ttMainChangeRockstarHotkeyString; }
            private set { ttMainChangeRockstarHotkeyString = value; }
        }
        public string rtbRockstarInfo {
            get { return rtbRockstarInfoString; }
            private set { rtbRockstarInfoString = value; }
        }

//////////////// frmException \\\\\\\\\\\\\\\\
        public string frmException {
            get { return frmExceptionString; }
            private set { frmExceptionString = value; }
        }
        public string lbExceptionHeader {
            get { return lbExceptionHeaderString; }
            private set { lbExceptionHeaderString = value; }
        }
        public string lbExceptionDescription {
            get { return lbExceptionDescriptionString; }
            private set { lbExceptionDescriptionString = value; }
        }
        public string rtbExceptionDetails {
            get { return rtbExceptionDetailsString; }
            private set { rtbExceptionDetailsString = value; }
        }
        public string btnExceptionGithub {
            get { return btnExceptionGithubString; }
            private set { btnExceptionGithubString = value; }
        }
        public string btnExceptionOk {
            get { return btnExceptionOkString; }
            private set { btnExceptionOkString = value; }
        }

//////////////// frmNewHotkey \\\\\\\\\\\\\\\\
        public string frmNewHotkey {
            get { return frmNewHotkeyString; }
            private set { frmNewHotkeyString = value; }
        }
        public string lbNewHotkeyHeader {
            get { return lbNewHotkeyHeaderString; }
            private set { lbNewHotkeyHeaderString = value; }
        }
        public string lbNewHotkeyDescription {
            get { return lbNewHotkeyDescriptionString; }
            private set { lbNewHotkeyDescriptionString = value; }
        }
        public string lbNewHotkeyModifier {
            get { return lbNewHotkeyModifierString; }
            private set { lbNewHotkeyModifierString = value; }
        }
        public string lbNewHotkeyKey {
            get { return lbNewHotkeyKeyString; }
            private set { lbNewHotkeyKeyString = value; }
        }
        public string btnNewHotkeyResetToDefault {
            get { return btnNewHotkeyResetToDefaultString; }
            private set { btnNewHotkeyResetToDefaultString = value; }
        }
        public string btnNewHotkeyCancel {
            get { return btnNewHotkeyCancelString; }
            private set { btnNewHotkeyCancelString = value; }
        }
        public string btnNewHotkeySave {
            get { return btnNewHotkeySaveString; }
            private set { btnNewHotkeySaveString = value; }
        }

//////////////// Language class \\\\\\\\\\\\\\\\
        public string LoadedFile {
            get { return LoadedFileString; }
            private set { LoadedFileString = value; }
        }
        public static Language GetLanguageInstance() {
            return LangInstance;
        }
        #endregion

        #region Integrated English
        public static class InternalEnglish {
        // Language identifier
        public static readonly string CurrentLanguageLong = "English (Internal)";
        public static readonly string CurrentLanguageShort = "en-i";
        public static readonly string CurrentLanguageHint = "CurrentLanguageHint";

        // Globally used
        public static readonly string HotkeyToggle = "to toggle";
        public static readonly string HotkeyDisabled = "Hotkey disabled";
        public static readonly string HotkeyUnavailable = "Hotkey unavailable (not admin)";

        // frmMain
        public static readonly string frmMainAdmin = "Solo Matchmaking";
        public static readonly string frmMainNoAdmin = "Solo Matchmaking (not admin)";
        public static readonly string lbDestinyOff = "Destiny 2 off";
        public static readonly string lbDestinyOn = "Destiny 2 on";
        public static readonly string lbRockstarOff = "Rockstar off";
        public static readonly string lbRockstarOn = "Destiny 2 on";
        public static readonly string tsmiSelectLanguage = "Select language";

        // frmMain / tabMain
        public static readonly string tabDestiny = "Destiny 2";
        public static readonly string tabRockstar = "Rockstar Games";
        public static readonly string tabDebug = "Debug";

        // frmMain / tabMain / tabDestiny
        public static readonly string chkEnableDestinyHotkey = "Enable Destiny 2 hotkey";
        public static readonly string btnToggleDestinyOff = "Activate Destiny 2 rules";
        public static readonly string btnToggleDestinyOn = "Deactive Destiny 2 rules";
        public static readonly string ttMainChangeDestinyHotkey = "Click here to change the hotkey for Destiny 2";

        // frmMain / tabMain / tabRockstar
        public static readonly string chkEnableRockstarHotkey = "Enable Rockstar Games hotkey";
        public static readonly string btnAddRockstarRange = "Add";
        public static readonly string btnRemoveRockstarRange = "Remove";
        public static readonly string txtRockstarRange = "1.1.1.1-255.255.255.255";
        public static readonly string btnToggleRockstarOff = "Active Rockstar rules";
        public static readonly string btnToggleRockstarOn = "Deactive Rockstar rules";
        public static readonly string ttMainChangeRockstarHotkey = "Click here to change the hotkey for Rockstar Games";
        public static readonly string rtbRockstarInfo = "For GTA 5:\n" +
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

        // frmException
        public static readonly string frmException = "An exception occured";
        public static readonly string lbExceptionHeader = "An exception has occured";
        public static readonly string lbExceptionDescription = "Below is the error that occured. Feel free to open a new issue and report it.";
        public static readonly string rtbExceptionDetails = "Feel free to copy + paste this entire text wall into a new issue on Github";
        public static readonly string btnExceptionGithub = "Open Github";
        public static readonly string btnExceptionOk = "OK";

        // frmNewHotkey
        public static readonly string frmNewHotkey = "New hotkey";
        public static readonly string lbNewHotkeyHeader = "New hotkey";
        public static readonly string lbNewHotkeyDescription = "Specify a new hotkey for";
        public static readonly string lbNewHotkeyModifier = "Modifier";
        public static readonly string lbNewHotkeyKey = "Key";
        public static readonly string btnNewHotkeyResetToDefault = "Reset to Default";
        public static readonly string btnNewHotkeyCancel = "Cancel";
        public static readonly string btnNewHotkeySave = "Save";
    }

        public bool LoadInternalEnglish() {
            LoadedFile = null;

            CurrentLanguageLong = InternalEnglish.CurrentLanguageLong;
            CurrentLanguageShort = InternalEnglish.CurrentLanguageShort;
            CurrentLanguageHint = InternalEnglish.CurrentLanguageHint;

            // Globally used
            HotkeyToggle = InternalEnglish.HotkeyToggle;
            HotkeyDisabled = InternalEnglish.HotkeyDisabled;
            HotkeyUnavailable = InternalEnglish.HotkeyUnavailable;

            // frmMain
            frmMainAdmin = InternalEnglish.frmMainAdmin;
            frmMainNoAdmin = InternalEnglish.frmMainNoAdmin;
            lbDestinyOff = InternalEnglish.lbDestinyOff;
            lbDestinyOn = InternalEnglish.lbDestinyOn;
            lbRockstarOff = InternalEnglish.lbRockstarOff;
            lbRockstarOn = InternalEnglish.lbRockstarOn;
            tsmiSelectLanguage = InternalEnglish.tsmiSelectLanguage;

            // frmMain / tabMain
            tabDestiny = InternalEnglish.tabDestiny;
            tabRockstar = InternalEnglish.tabRockstar;
            tabDebug = InternalEnglish.tabDebug;

            // frmMain / tabMain / tabDestiny
            chkEnableDestinyHotkey = InternalEnglish.chkEnableDestinyHotkey;
            btnToggleDestinyOff = InternalEnglish.btnToggleDestinyOff;
            btnToggleDestinyOn = InternalEnglish.btnToggleDestinyOn;
            ttMainChangeDestinyHotkey = InternalEnglish.ttMainChangeDestinyHotkey;

            // frmMain / tabMain / tabRockstar
            chkEnableRockstarHotkey = InternalEnglish.chkEnableRockstarHotkey;
            btnAddRockstarRange = InternalEnglish.btnAddRockstarRange;
            btnRemoveRockstarRange = InternalEnglish.btnRemoveRockstarRange;
            txtRockstarRange = InternalEnglish.txtRockstarRange;
            btnToggleRockstarOff = InternalEnglish.btnToggleRockstarOff;
            btnToggleRockstarOn = InternalEnglish.btnToggleRockstarOn;
            ttMainChangeRockstarHotkey = InternalEnglish.ttMainChangeRockstarHotkey;
            rtbRockstarInfo = InternalEnglish.rtbRockstarInfo;

            // frmException
            frmException = InternalEnglish.frmException;
            lbExceptionHeader = InternalEnglish.lbExceptionHeader;
            lbExceptionDescription = InternalEnglish.lbExceptionDescription;
            rtbExceptionDetails = InternalEnglish.rtbExceptionDetails;
            btnExceptionGithub = InternalEnglish.btnExceptionGithub;
            btnExceptionOk = InternalEnglish.btnExceptionOk;

            // frmNewHotkey
            frmNewHotkey = InternalEnglish.frmNewHotkey;
            lbNewHotkeyHeader = InternalEnglish.lbNewHotkeyHeader;
            lbNewHotkeyDescription = InternalEnglish.lbNewHotkeyDescription;
            lbNewHotkeyModifier = InternalEnglish.lbNewHotkeyModifier;
            lbNewHotkeyKey = InternalEnglish.lbNewHotkeyKey;
            btnNewHotkeyResetToDefault = InternalEnglish.btnNewHotkeyResetToDefault;
            btnNewHotkeyCancel = InternalEnglish.btnNewHotkeyCancel;
            btnNewHotkeySave = InternalEnglish.btnNewHotkeySave;
            return true;
        }
        #endregion

        #region LoadLanguage
        public bool LoadLanguage(string LanguageFileName) {
            if (LanguageFileName == LoadedFile || LanguageFileName == null || LanguageFileName == string.Empty) { return false; }

            if (!LanguageFileName.EndsWith(".ini")) { LanguageFileName += ".ini"; }
            
            if (System.IO.File.Exists(Environment.CurrentDirectory + "\\lang\\" + LanguageFileName)) {
                try {
                    string[] ReadFile = System.IO.File.ReadAllLines(Environment.CurrentDirectory + "\\lang\\" + LanguageFileName);

                    for (int i = 0; i < ReadFile.Length; i++) {
                        string ReadLine = ReadFile[i];
                        string ReadControl = string.Empty;
                        if (ReadLine.StartsWith("//") || ReadLine.Trim(' ') == (""))
                            continue;

                        if (ReadLine.StartsWith("[") & ReadLine.EndsWith("]")) {
                            CurrentLanguageLong = ReadLine.Trim('[').Trim(']');
                            continue;
                        }
                        else {
                            if (ReadLine.Split('=').Length > 2) {
                                ReadControl = ReadLine.Split('=')[0];
                                string ReadLineBuffer = string.Empty;
                                for (int j = 1; j < ReadLine.Split('=').Length; j++) {
                                    ReadLineBuffer += ReadLine.Split('=')[j] + "=";
                                }
                                if (!ReadLine.EndsWith("=")) {
                                    ReadLineBuffer = ReadLineBuffer.TrimEnd('=');
                                }
                                else {
                                    ReadLineBuffer = ReadLineBuffer.Substring(0, ReadLineBuffer.Length - 1);
                                }
                                ReadLine = ReadLineBuffer;
                            }
                            else if (ReadLine.Split('=').Length < 2) {
                                continue;
                            }
                            else {
                                ReadControl = ReadLine.Split('=')[0];
                                ReadLine = ReadLine.Split('=')[1];
                            }
                        }

                        if (ReadLine.Contains("//")) {
                            int CountedForwardSlashes = 0;
                            int CountedLength = 0;
                            for (int j = 0; j < ReadLine.Length; j++) {
                                CountedLength++;
                                if (ReadLine[j] == '/') {
                                    CountedForwardSlashes++;
                                    if (CountedForwardSlashes == 2) { break; }
                                    continue;
                                }
                            }
                            CountedLength = CountedLength - 2;
                            ReadLine = ReadLine.Substring(0, CountedLength);
                        }

                        if (ReadControl == "CurrentLanguageShort") {
                            CurrentLanguageShort = ReadLine;
                            continue;
                        }
                        else if (ReadControl == "CurrentLanguageHint") {
                            CurrentLanguageHint = ReadLine;
                            continue;
                        }


                        else if (ReadControl == "HotkeyToggle") {
                            HotkeyToggle = ReadLine;
                            continue;
                        }
                        else if (ReadControl == "HotkeyDisabled") {
                            HotkeyDisabled = ReadLine;
                            continue;
                        }
                        else if (ReadControl == "HotkeyUnavailable") {
                            HotkeyUnavailable = ReadLine;
                            continue;
                        }


                        else if (ReadControl == "frmMainAdmin") {
                            frmMainAdmin = ReadLine;
                            continue;
                        }
                        else if (ReadControl == "frmMainNoAdmin") {
                            frmMainNoAdmin = ReadLine;
                            continue;
                        }
                        else if (ReadControl == "lbDestinyOff") {
                            lbDestinyOff = ReadLine;
                            continue;
                        }
                        else if (ReadControl == "lbDestinyOn") {
                            lbDestinyOn = ReadLine;
                            continue;
                        }
                        else if (ReadControl == "lbRockstarOff") {
                            lbRockstarOff = ReadLine;
                            continue;
                        }
                        else if (ReadControl == "lbRockstarOn") {
                            lbRockstarOn = ReadLine;
                            continue;
                        }
                        else if (ReadControl == "tsmiSelectLanguage") {
                            tsmiSelectLanguage = ReadLine;
                            continue;
                        }


                        else if (ReadControl == "tabDestiny") {
                            tabDestiny = ReadLine;
                            continue;
                        }
                        else if (ReadControl == "tabRockstar") {
                            tabRockstar = ReadLine;
                            continue;
                        }
                        else if (ReadControl == "tabDebug") {
                            tabDebug = ReadLine;
                            continue;
                        }


                        else if (ReadControl == "chkEnableDestinyHotkey") {
                            chkEnableDestinyHotkey = ReadLine;
                            continue;
                        }
                        else if (ReadControl == "btnToggleDestinyOff") {
                            btnToggleDestinyOff = ReadLine;
                            continue;
                        }
                        else if (ReadControl == "btnToggleDestinyOn") {
                            btnToggleDestinyOn = ReadLine;
                            continue;
                        }
                        else if (ReadControl == "ttMainChangeDestinyHotkey") {
                            ttMainChangeDestinyHotkey = ReadLine;
                            continue;
                        }

                        else if (ReadControl == "chkEnableRockstar") {
                            chkEnableRockstarHotkey = ReadLine;
                            continue;
                        }
                        else if (ReadControl == "btnAddRockstarRange") {
                            btnAddRockstarRange = ReadLine;
                            continue;
                        }
                        else if (ReadControl == "btnRemoveRockstarRange") {
                            btnRemoveRockstarRange = ReadLine;
                            continue;
                        }
                        else if (ReadControl == "txtRockstarRange") {
                            txtRockstarRange = ReadLine;
                            continue;
                        }
                        else if (ReadControl == "btnToggleRockstarOff") {
                            btnToggleRockstarOff = ReadLine;
                            continue;
                        }
                        else if (ReadControl == "btnToggleRockstarOn") {
                            btnToggleRockstarOn = ReadLine;
                            continue;
                        }
                        else if (ReadControl == "ttMainChangeRockstarHotkey") {
                            ttMainChangeRockstarHotkey = ReadLine;
                            continue;
                        }
                        else if (ReadControl == "rtbRockstarInfo") {
                            rtbRockstarInfo = ReadLine.Replace("\\n", "\n");
                            continue;
                        }


                        else if (ReadControl == "frmException") {
                            frmException = ReadLine;
                            continue;
                        }
                        else if (ReadControl == "lbExceptionHeader") {
                            lbExceptionHeader = ReadLine;
                            continue;
                        }
                        else if (ReadControl == "lbExceptionDescription") {
                            lbExceptionDescription = ReadLine;
                            continue;
                        }
                        else if (ReadControl == "rtbExceptionDetails") {
                            rtbExceptionDetails = ReadLine;
                            continue;
                        }
                        else if (ReadControl == "btnExceptionGithub") {
                            btnExceptionGithub = ReadLine;
                            continue;
                        }
                        else if (ReadControl == "btnExceptionOk") {
                            btnExceptionOk = ReadLine;
                            continue;
                        }


                        else if (ReadControl == "frmNewHotkey") {
                            frmNewHotkey = ReadLine;
                            continue;
                        }
                        else if (ReadControl == "lbNewHotkeyHeader") {
                            lbNewHotkeyHeader = ReadLine;
                            continue;
                        }
                        else if (ReadControl == "lbNewHotkeyDescription") {
                            lbNewHotkeyDescription = ReadLine;
                            continue;
                        }
                        else if (ReadControl == "lbNewHotkeyModifier") {
                            lbNewHotkeyModifier = ReadLine;
                            continue;
                        }
                        else if (ReadControl == "lbNewHotkeyKey") {
                            lbNewHotkeyKey = ReadLine;
                            continue;
                        }
                        else if (ReadControl == "btnNewHotkeyResetToDefault") {
                            btnNewHotkeyResetToDefault = ReadLine;
                            continue;
                        }
                        else if (ReadControl == "btnNewHotkeyCancel") {
                            btnNewHotkeyCancel = ReadLine;
                            continue;
                        }
                        else if (ReadControl == "btnNewHotkeySave") {
                            btnNewHotkeySave = ReadLine;
                            continue;
                        }
                    }
                    LoadedFile = LanguageFileName;

                    return true;
                }
                catch (Exception ex) {
                    frmException error = new frmException();
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

        public bool SetManualLanguage(string ControlName, string ReplacementString) {
            LoadedFile = null;

            switch (ControlName.ToLower()) {
                case "0": case "currentlanguagelongstring": case "currentlanguagelong":
                    CurrentLanguageLong = ReplacementString;
                    return true;
                case "1": case "currentlanguageshortstring": case "currentlanguageshort":
                    CurrentLanguageShort = ReplacementString;
                    return true;
                case "2": case "currentlanguagehintstring": case "currentlanguagehint":
                    CurrentLanguageHint = ReplacementString;
                    return true;


                case "3": case "hotkeytogglestring": case "hotkeytoggle":
                    HotkeyToggle = ReplacementString;
                    return true;
                case "4": case "hotkeydisabledstring": case "hotkeydisabled":
                    HotkeyDisabled = ReplacementString;
                    return true;
                case "5": case "hotkeyunavailablestring": case "hotkeyunavailable":
                    HotkeyUnavailable = ReplacementString;
                    return true;


                case "6": case "frmmainadminstring": case "frmmainadmin":
                    frmMainAdmin = ReplacementString;
                    return true;
                case "7": case "frmmainnoadminstring": case "frmmainnoadmin":
                    frmMainNoAdmin = ReplacementString;
                    return true;
                case "8": case "lbdestinyoffstring": case "lbdestinyoff":
                    lbDestinyOff = ReplacementString;
                    return true;
                case "9": case "lbdestinyonstring": case "lbdestinyon":
                    lbDestinyOn = ReplacementString;
                    return true;
                case "10": case "lbrockstaroffstring": case "lbrockstaroff":
                    lbRockstarOff = ReplacementString;
                    return true;
                case "11": case "lbrockstaronstring": case "lbrockstaron":
                    lbRockstarOn = ReplacementString;
                    return true;
                case "12": case "tsmiselectlanguagestring": case "tsmiselectlanguage":
                    tsmiSelectLanguage = ReplacementString;
                    return true;



                case "13": case "tabdestinystring": case "tabdestiny":
                    tabDestiny = ReplacementString;
                    return true;
                case "14": case "tabrockstarstring": case "tabrockstar":
                    tabRockstar = ReplacementString;
                    return true;
                case "15": case "tabdebugstring": case "tabdebug":
                    tabDebug = ReplacementString;
                    return true;



                case "16": case "chkenabledestinyhotkeystring": case "chkenabledestinyhotkey":
                    chkEnableDestinyHotkey = ReplacementString;
                    return true;
                case "17": case "btntoggledestinyoffstring": case "btntoggledestinyoff":
                    btnToggleDestinyOff = ReplacementString;
                    return true;
                case "18": case "btntoggledestinyonstring": case "btntoggledestinyon":
                    btnToggleDestinyOn = ReplacementString;
                    return true;
                case "19": case "ttmainchangedestinyhotkeystring": case "ttmainchangedestinyhotkey":
                    ttMainChangeDestinyHotkey = ReplacementString;
                    return true;



                case "20": case "chkenablerockstarhotkeystring": case "chkenablerockstarhotkey":
                    chkEnableDestinyHotkey = ReplacementString;
                    return true;
                case "21": case "btnaddrockstarrangestring": case "btnaddrockstarrange":
                    btnAddRockstarRange = ReplacementString;
                    return true;
                case "22": case "btnremoverockstarrangestring": case "btnremoverockstarrange":
                    btnRemoveRockstarRange = ReplacementString;
                    return true;
                case "23": case "txtrockstarrangestring": case "txtrockstarrange":
                    txtRockstarRange = ReplacementString;
                    return true;
                case "24": case "btntogglerockstaroffstring": case "btntogglerockstaroff":
                    btnToggleRockstarOff = ReplacementString;
                    return true;
                case "25": case "btntogglerockstaronstring": case "btntogglerockstaron":
                    btnToggleRockstarOn = ReplacementString;
                    return true;
                case "26": case "ttmainchangerockstarhotkeystring": case "ttmainchangerockstarhotkey":
                    ttMainChangeRockstarHotkey = ReplacementString;
                    return true;
                case "27": case "rtbrockstarinfostring": case "rtbrockstarinfo":
                    rtbRockstarInfo = ReplacementString;
                    return true;



                case "28": case "frmexceptionstring": case "frmexception":
                    frmException = ReplacementString;
                    return true;
                case "29": case "lbexceptionheaderstring": case "lbexceptionheader":
                    lbExceptionHeader = ReplacementString;
                    return true;
                case "30": case "lbexceptiondescriptionstring": case "lbexceptiondescription":
                    lbExceptionDescription = ReplacementString;
                    return true;
                case "31": case "rtbexceptiondetailsstring": case "rtbexceptiondetails":
                    rtbExceptionDetails = ReplacementString;
                    return true;
                case "32": case "btnexceptiongithubstring": case "btnexceptiongithub":
                    btnExceptionGithub = ReplacementString;
                    return true;
                case "33": case "btnexceptionokstring": case "btnexceptionok":
                    btnExceptionOk = ReplacementString;
                    return true;



                case "34": case "frmnewhotkeystring": case "frmnewhotkey":
                    frmNewHotkey = ReplacementString;
                    return true;
                case "35": case "lbnewhotkeyheaderstring": case "lbnewhotkeyheader":
                    lbNewHotkeyHeader = ReplacementString;
                    return true;
                case "36": case "lbnewhotkeydescriptionstring": case "lbnewhotkeydescription":
                    lbNewHotkeyDescription = ReplacementString;
                    return true;
                case "37": case "lbnewhotkeymodifierstring": case "lbnewhotkeymodifier":
                    lbNewHotkeyModifier = ReplacementString;
                    return true;
                case "38": case "lbnewhotkeykeystring": case "lbnewhotkeykey":
                    lbNewHotkeyKey = ReplacementString;
                    return true; 
                case "39": case "btnnewhotkeyresettodefaultstring": case "btnnewhotkeyresettodefault":
                    btnNewHotkeyResetToDefault = ReplacementString;
                    return true;
                case "40": case "btnnewhotkeycancelstring": case "btnnewhotkeycancel":
                    btnNewHotkeyCancel = ReplacementString;
                    return true;
                case "41": case "btnnewhotkeysavestring": case "btnnewhotkeysave":
                    btnNewHotkeySave = ReplacementString;
                    return true;

                default:
                    return false;
            }
        }
        #endregion
    }
}