using System.Windows.Forms;

public class KeyLibrary {
        public static uint GetModifier(string inputKey) {
            switch (inputKey.ToLower()) {
                case "none": default: return 0;
                case "alt": return 1;
                case "control": case "ctrl": return 2;
                case "shift": return 4;
                case "win": return 8;
            }
        }

        public static Keys GetKey(string inputKey) {
            switch (inputKey.ToLower()) {
                case "":
                case "none":
                default: return Keys.None;

                // Mouse buttons \\
                case "lbutton": return Keys.LButton;    // Left mouse button
                case "mbutton": return Keys.MButton;    // Middle mouse button
                case "rbutton": return Keys.RButton;    // Right mouse button
                case "xbutton1": return Keys.XButton1;  // Mouse button 4?
                case "xbutton2": return Keys.XButton2;  // Mouse button 5?


                // Alphabet keys \\
                case "a": return Keys.A; // a
                case "b": return Keys.B; // b
                case "c": return Keys.C; // c
                case "d": return Keys.D; // d
                case "e": return Keys.E; // e
                case "f": return Keys.F; // f
                case "g": return Keys.G; // g
                case "h": return Keys.H; // h
                case "i": return Keys.I; // i
                case "j": return Keys.J; // j
                case "k": return Keys.K; // k
                case "l": return Keys.L; // l
                case "m": return Keys.M; // m
                case "n": return Keys.N; // n
                case "o": return Keys.O; // o
                case "p": return Keys.P; // p
                case "q": return Keys.Q; // q
                case "r": return Keys.R; // r
                case "s": return Keys.S; // s
                case "t": return Keys.T; // t
                case "u": return Keys.U; // u
                case "v": return Keys.V; // v
                case "w": return Keys.W; // w
                case "x": return Keys.X; // x
                case "y": return Keys.Y; // y
                case "z": return Keys.Z; // z


                // Numeral keys \\
                case "0": case "d0": return Keys.D0;    // 0
                case "1": case "d1": return Keys.D1;    // 1
                case "2": case "d2": return Keys.D2;    // 2
                case "3": case "d3": return Keys.D3;    // 3
                case "4": case "d4": return Keys.D4;    // 4
                case "5": case "d5": return Keys.D5;    // 5
                case "6": case "d6": return Keys.D6;    // 6
                case "7": case "d7": return Keys.D7;    // 7
                case "8": case "d8": return Keys.D8;    // 8
                case "9": case "d9": return Keys.D9;    // 9


                // Function keys \\
                case "f1": return Keys.F1;
                case "f2": return Keys.F2;
                case "f3": return Keys.F3;
                case "f4": return Keys.F4;
                case "f5": return Keys.F5;
                case "f6": return Keys.F6;
                case "f7": return Keys.F7;
                case "f8": return Keys.F8;
                case "f9": return Keys.F9;
                case "f10": return Keys.F10;
                case "f11": return Keys.F11;
                case "f12": return Keys.F12;
                case "f13": return Keys.F13; // Unused?
                case "f14": return Keys.F14; // Unused?
                case "f15": return Keys.F15; // Unused?
                case "f16": return Keys.F16; // Unused?
                case "f17": return Keys.F17; // Unused?
                case "f18": return Keys.F18; // Unused?
                case "f19": return Keys.F19; // Unused?
                case "f20": return Keys.F20; // Unused?
                case "f21": return Keys.F21; // Unused?
                case "f22": return Keys.F22; // Unused?
                case "f23": return Keys.F23; // Unused?
                case "f24": return Keys.F24; // Unused?


                // Numpad \\
                case "numlock": return Keys.NumLock;
                case "numpad0": case "num0": return Keys.NumPad0;                                   // 0 (Numpad)  
                case "numpad1": case "num1": return Keys.NumPad1;                                   // 1 (Numpad)  
                case "numpad2": case "num2": return Keys.NumPad2;                                   // 2 (Numpad)  
                case "numpad3": case "num3": return Keys.NumPad3;                                   // 3 (Numpad)  
                case "numpad4": case "num4": return Keys.NumPad4;                                   // 4 (Numpad)  
                case "numpad5": case "num5": return Keys.NumPad5;                                   // 5 (Numpad)  
                case "numpad6": case "num6": return Keys.NumPad6;                                   // 6 (Numpad)  
                case "numpad7": case "num7": return Keys.NumPad7;                                   // 7 (Numpad)  
                case "numpad8": case "num8": return Keys.NumPad8;                                   // 8 (Numpad)  
                case "numpad9": case "num9": return Keys.NumPad9;                                   // 9 (Numpad)
                case "numpaddivide": case "numdivide": case "divide": return Keys.Divide;           // / (Numpad)
                case "numpadmultiply": case "nummultiply": case "multiply": return Keys.Multiply;   // * (Numpad)
                case "numpadsubtract": case "numsubtract": case "subtract": return Keys.Subtract;   // - (Numpad)
                case "numpadadd": case "numadd": case "add": return Keys.Add;                       // + (Numpad)
                case "numpaddecimal": case "numdecimal": case "decimal": return Keys.Decimal;       // . (Numpad)
                case "return": return Keys.Return;                                                  // Enter (Numpad)?


                // Keyboard / OEM symbols (US) \\
                case "oemtilde": case "tilde": case "`": case "~": return Keys.Oemtilde;                                                                    // `~ / oem3
                case "oemminus": case "minus": case "-": case "underscore": case "_": return Keys.OemMinus;                                                 // -_
                case "oemplus": case "equals": case "=": case "plus": case "+": return Keys.Oemplus;                                                        // =+
                case "oemclosebrackets": case "closebrackets": case "closebracket": case "]": case "closebrace": case "}": return Keys.OemCloseBrackets;    // ]} / oem6
                case "oemopenbrackets": case "openbrackets": case "openbracket": case "[": case "openbrace": case "{": return Keys.OemOpenBrackets;          // [{ / oem4
                case "oembackslash": case "backslash": case "\\": return Keys.OemBackslash;                                                                 // \  / oem102
                case "oempipe": case "pipe": case "|": return Keys.OemPipe;                                                                                 // |  / oem5
                case "oemsemicolon": case "semicolon": case ";": case "colon": case ":": return Keys.OemSemicolon;                                          // ;: / oem1
                case "oemquotes": case "apostrophe": case "'": case "quotes": case "\"": return Keys.OemQuotes;                                             // '" / oem7
                case "oemcomma": case "comma": case ",": case "<": return Keys.Oemcomma;                                                                    // ,<
                case "oemperiod": case "period": case ".": case ">": return Keys.OemPeriod;                                                                 // .>
                case "oemquestion": case "question": case "?": case "forwardslash": case "/": return Keys.OemQuestion;                                                           // /? / oem2


                // Arrow keys
                case "up": case "uparrow": case "arrowup": return Keys.Up;              // Up
                case "down": case "downarrow": case "arrowdown": return Keys.Down;      // Down
                case "left": case "leftarrow": case "arrowleft": return Keys.Left;      // Left
                case "right": case "rightarrow": case "arrowright": return Keys.Right;  // Right


                // Nav + usability \\
                case "insert": case "ins": return Keys.Insert;      // Insert
                case "delete": case "del": return Keys.Delete;      // Delete
                case "home": return Keys.Home;                      // Home
                case "end": return Keys.End;                        // End
                case "next": return Keys.Next;                      // PageDown / Next
                case "pagedown": case "pgdn": return Keys.PageDown; // PageDown / Next
                case "pageup": case "pgup": return Keys.PageUp;     // PageUp / Prior
                case "prior": return Keys.Prior;                    // PageUp / Prior


                // Control keys \\
                case "control":
                case "ctrl": return Keys.Control;                                           // Control
                case "controlkey": return Keys.ControlKey;                                  // Control
                case "lcontrolkey": case "lcontrol": case "lctrl": return Keys.LControlKey; // Left control
                case "rcontrolkey": case "rcontrol": case "rctrl": return Keys.RControlKey; // Right control


                // Alt keys \\
                case "alt": return Keys.Alt;        // Alt
                case "menu": return Keys.Menu;      // Alt
                case "lmenu": return Keys.LMenu;    // Left alt
                case "rmenu": return Keys.RMenu;    // Right alt


                // Shift keys \\
                case "shift": return Keys.Shift;                        // Shift
                case "shiftkey": return Keys.ShiftKey;                  // Shift
                case "lshiftkey": case "lshift": return Keys.LShiftKey; // Left shift
                case "rshiftkey": case "rshift": return Keys.RShiftKey; // Right shift


                // Window keys \\
                case "lwin": return Keys.LWin;  // Left win
                case "rwin": return Keys.RWin;  // Left win


                // Context menu \\
                case "apps": return Keys.Apps;  // Context?


                // Utility keys \\
                case "back": return Keys.Back;                                              // Backspace
                case "capslock": return Keys.CapsLock;                                      // Capslock
                case "enter": return Keys.Enter;                                            // Enter
                case "escape": case "esc": return Keys.Escape;                              // Escape
                case "help": return Keys.Help;                                              // Help
                case "scroll": return Keys.Scroll;                                          // Scroll lock
                case "printscreen": case "prntscrn": case "prtsc": return Keys.PrintScreen; // Print screen
                case "space": return Keys.Space;                                            // Space bar
                case "tab": return Keys.Tab;                                                // Tab


                // Media keys \\
                case "medianexttrack": return Keys.MediaNextTrack;                          // Media next
                case "mediaplaypause": return Keys.MediaPlayPause;                          // Media Play/Pause
                case "mediaprevioustrack": return Keys.MediaPreviousTrack;                  // Media Previous
                case "mediastop": return Keys.MediaStop;                                    // Media Stop
                case "pause": return Keys.Pause;                                            // Media pause
                case "play": return Keys.Play;                                              // Media play
                case "volumedown": case "voldown": case "voldwn": return Keys.VolumeDown;   // Volume down
                case "volumemute": case "volmute": return Keys.VolumeMute;                  // Volume mute
                case "volumeup": case "volup": return Keys.VolumeUp;                        // Volume up
                case "selectmedia": return Keys.SelectMedia;                                // ???


                // Browser control keys
                case "browserback": return Keys.BrowserBack;                // Navigate back
                case "browserfavorites": return Keys.BrowserFavorites;      // Show bookmarked sites?
                case "browserforward": return Keys.BrowserForward;          // Navigate forward
                case "browserhome": return Keys.BrowserHome;                // Go to the home page
                case "browserrefresh": return Keys.BrowserRefresh;          // Refresh current page
                case "browsersearch": return Keys.BrowserSearch;            // Go to the search page
                case "browserstop": return Keys.BrowserStop;                // Stop the current page from finishing download


                // Special keys
                case "launchapplication1": case "application1": return Keys.LaunchApplication1; // Launch Selected Application 1
                case "launchapplication2": case "application2": return Keys.LaunchApplication2; // Launch Selected Application 2
                case "launchmail": case "mail": return Keys.LaunchMail;                         // Launch Mail Application
                case "zoom": return Keys.Zoom;                                                  // Zoom


                // OEM keys / Duplicates of above \\
                case "oem1": return Keys.Oem1;          // Semicolon
                case "oem2": return Keys.Oem2;          // Question
                case "oem3": return Keys.Oem3;          // Tilde
                case "oem4": return Keys.Oem4;          // OpenBracket
                case "oem5": return Keys.Oem5;          // Pipe / Vertical Bar 
                case "oem6": return Keys.Oem6;          // Close Bracket
                case "oem7": return Keys.Oem7;          // Quotes
                case "oem102": return Keys.Oem102;      // Backslash
                case "oem8": return Keys.Oem8;          // unspported?
                case "oemclear": return Keys.OemClear;  // unspported?


                // IME keys \\
                case "hanguelmode": return Keys.HanguelMode;    // Duplicate (Hanguel / Hangul / Kana)
                case "hangulmode": return Keys.HangulMode;      // Duplicate (Hanguel / Hangul / Kana)
                case "kanamode": return Keys.KanaMode;          // Duplicate (Hanguel / Hangul / Kana)
                case "kanjimode": return Keys.KanjiMode;        // Duplicate (Kanji / Hanja)
                case "hanjamode": return Keys.HanjaMode;        // Duplicate (Kanji / Hanja)
                case "finalmode": return Keys.FinalMode;        // Unknown
                case "junjamode": return Keys.JunjaMode;        // Unknown
                case "imeaccept": return Keys.IMEAccept;        // Unknown
                case "imeaceept": return Keys.IMEAceept;        // Unknown
                case "imeconvert": return Keys.IMEConvert;      // Unknown
                case "imemodeChange": return Keys.IMEModeChange;// Unknown
                case "imeoconvert": return Keys.IMENonconvert;  // Unknown


                // Unknown / undocumented / unsorted
                case "attn": return Keys.Attn;
                case "cancel": return Keys.Cancel;
                case "capital": return Keys.Capital;
                case "clear": return Keys.Clear;
                case "crsel": return Keys.Crsel;
                case "eraseeof": return Keys.EraseEof;
                case "execute": return Keys.Execute;
                case "exsel": return Keys.Exsel;
                case "keycode": return Keys.KeyCode;
                case "linefeed": return Keys.LineFeed;
                case "modifiers": return Keys.Modifiers;
                case "noname": return Keys.NoName;
                case "pa1": return Keys.Pa1;
                case "packet": return Keys.Packet;
                case "print": return Keys.Print;
                case "processkey": return Keys.ProcessKey;
                case "select":
                case "sel": return Keys.Select;
                case "separator": return Keys.Separator;
                case "sleep": return Keys.Sleep;
                case "snapshot": return Keys.Snapshot;

        }
    }
}