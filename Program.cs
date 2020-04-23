using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace SoloMatchmaking {
    static class Program {
        static readonly string Guid = "12e53a3e-e1de-46e9-a672-f44e32fecbc1";
        static Mutex mtx = new Mutex(true, "{SoloMatchmaking-12e53a3e-e1de-46e9-a672}");
        public const int HWND_BROADCAST = 0xffff;
        public static readonly int WM_SHOWFORM = RegisterWindowMessage("WM_SHOWFORM");
        [DllImport("user32")]
        public static extern bool PostMessage(IntPtr hwnd, int msg, IntPtr wparam, IntPtr lparam);
        [DllImport("user32")]
        public static extern int RegisterWindowMessage(string message);
        public static volatile bool IsDebugging = false;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
#if DEBUG
            IsDebugging = true;
#endif
            if (mtx.WaitOne(TimeSpan.Zero, true)) {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new frmMain());
            }
            else {
                PostMessage((IntPtr)HWND_BROADCAST, WM_SHOWFORM, IntPtr.Zero, IntPtr.Zero);
                Environment.Exit(0);
            }
        }
    }
}
