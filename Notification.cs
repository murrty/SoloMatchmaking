using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoloMatchmaking {
    public partial class Notification : Form {
        public string RulesName = string.Empty;
        public bool RulesActivated = false;

        public Bitmap NotificationIcon = null;
        private bool FormHasShown = false;

        public Notification() {
            InitializeComponent();
        }

        private void Notification_Shown(object sender, EventArgs e) {
            tmrExit.Start();
            FadeIn(this, 10);
        }

        private void tmrExit_Tick(object sender, EventArgs e) {
            if (!FormHasShown) {
                FormHasShown = true;
            }
            else {
                tmrExit.Stop();
                FadeOut(this, 10);
            }
        }

        private void Notification_Load(object sender, EventArgs e) {
            int PrimaryWidth = Convert.ToInt16(Screen.PrimaryScreen.Bounds.Width);
            int PrimaryHeight = Convert.ToInt16(Screen.PrimaryScreen.Bounds.Height);
            Point NotifLocation = new Point(PrimaryWidth - (10 + this.Width), PrimaryHeight - (10 + this.Height));

            this.Location = NotifLocation;
            this.TopMost = true;
            if (RulesActivated) {
                lbNotifMajor.Text = RulesName + " rules activated";
                lbNotifMinor.Text = RulesName + " is blocked from matchmaking";
            }
            else {
                lbNotifMajor.Text = RulesName + " rules deactivated";
                lbNotifMinor.Text = RulesName + " is will now matchmake";
            }
            if (NotificationIcon != null) {
                NotificationIcon.MakeTransparent();
                pbIcon.Image = NotificationIcon;
                pbIcon.BackColor = Color.FromKnownColor(KnownColor.Control);
                
            }
        }

        private async void FadeIn(Form o, int interval = 80) {
            //Object is not fully invisible. Fade it in
            while (o.Opacity < 1.0) {
                await Task.Delay(interval);
                o.Opacity += 0.05;
            }
            o.Opacity = 1; //make fully visible       
        }

        private async void FadeOut(Form o, int interval = 80) {
            //Object is fully visible. Fade it out
            while (o.Opacity > 0.0) {
                await Task.Delay(interval);
                o.Opacity -= 0.05;
            }
            o.Opacity = 0; //make fully invisible
            this.Dispose();
        }
    }
}
