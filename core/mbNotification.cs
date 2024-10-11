
/* 

    www.mbnq.pl 2024 
    https://mbnq.pl/
    mbnq00 on gmail

*/
using redunDancer;

public class mbNotificationForm : Form
{
    private Label mbTitleLabel, mbMessageLabel;

    public mbNotificationForm(string title, string message, int timeout = 3000)
    {

        this.Size = new Size(200, 100);
        this.StartPosition = FormStartPosition.Manual;
        this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
        this.TopMost = true;
        this.ShowInTaskbar = false;

        mbTitleLabel = new Label();
        mbTitleLabel.Text = title;
        mbTitleLabel.AutoSize = false;
        mbTitleLabel.TextAlign = ContentAlignment.MiddleCenter;
        mbTitleLabel.Dock = DockStyle.Top;
        mbTitleLabel.Font = new Font("Consolas", 12, FontStyle.Regular);
        mbTitleLabel.Height = 20;
        mbTitleLabel.BackColor = Color.Gray;

        mbMessageLabel = new Label();
        mbMessageLabel.Text = message;
        mbMessageLabel.AutoSize = false;
        mbMessageLabel.TextAlign = ContentAlignment.MiddleCenter;
        mbMessageLabel.Dock = DockStyle.Fill;
        mbMessageLabel.Font = new Font("Consolas", 12);

        // ---
        this.Controls.Add(mbTitleLabel);
        this.Controls.Add(mbMessageLabel);

        int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
        int screenHeight = Screen.PrimaryScreen.WorkingArea.Height;
        this.Location = new Point(screenWidth - this.Width - 10, screenHeight - this.Height - 10);

        this.Click += (s, e) => this.Hide();
        mbTitleLabel.Click += (s, e) => this.Hide();
        mbMessageLabel.Click += (s, e) => this.Hide();

        if (mbRedunDancerMain.showNotifications)
        {
            this.Show();
            mbKillWithDelay(timeout);
        }
    }

    private async void mbKillWithDelay(int timeout)
    {
        this.Opacity = 80;
        await Task.Delay(timeout);
        this.Close();
    }

    // ---
    protected override bool ShowWithoutActivation
    {
        get { return true; }
    }
    protected override CreateParams CreateParams
    {
        get
        {
            CreateParams cp = base.CreateParams;
            cp.ExStyle |= 0x08000000; // Prevents the window from activating
            return cp;
        }
    }
}
