
/* 

    www.mbnq.pl 2024 
    https://mbnq.pl/
    mbnq00 on gmail

*/

namespace redunDancer
{
    public partial class mbRedunDancerMain : Form
    {
        private NotifyIcon notifyIcon = null!;
        private ContextMenuStrip contextMenu = null!;

        private void InitializeTray()
        {
            notifyIcon = new NotifyIcon();
            notifyIcon.Icon = this.Icon;
            notifyIcon.Visible = false;
            notifyIcon.Text = "redunDancer";

            contextMenu = new ContextMenuStrip();
            contextMenu.Items.Add("Show", null, ShowForm);
            contextMenu.Items.Add("Exit", null, ExitApplication);

            notifyIcon.ContextMenuStrip = contextMenu;

            this.Resize += mbRedunDancerMain_Resize;
            notifyIcon.DoubleClick += NotifyIcon_DoubleClick;
        }

        private void mbRedunDancerMain_Resize(object? sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized) HideToTray();
        }

        private void HideToTray()
        {
            this.Hide();
            notifyIcon.Visible = true;
        }
        private void ShowForm(object? sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon.Visible = false;
        }
        private void NotifyIcon_DoubleClick(object? sender, EventArgs e)
        {
            ShowForm(sender, e);
        }
        private void ExitApplication(object? sender, EventArgs e)
        {
            notifyIcon.Visible = false;
            Application.Exit();
        }
    }
}
