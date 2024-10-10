
/* 

    www.mbnq.pl 2024 
    https://mbnq.pl/
    mbnq00 on gmail

*/
public class mbNotificationForm : Form
{
    private Label mbTitleLabel, mbMessageLabel;

    public mbNotificationForm(string message, int timeout = 3000)
    {

        this.Size = new Size(200, 100);
        this.StartPosition = FormStartPosition.Manual;
        this.FormBorderStyle = FormBorderStyle.None;
        this.TopMost = true;
        this.ShowInTaskbar = false;

        mbMessageLabel = new Label();
        mbMessageLabel.Text = message;
        mbMessageLabel.AutoSize = false;
        mbMessageLabel.TextAlign = ContentAlignment.MiddleCenter;
        mbMessageLabel.Dock = DockStyle.Fill;
        mbMessageLabel.Font = new Font("Consolas", 12);

        // ---
        this.Controls.Add(mbMessageLabel);

        int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
        int screenHeight = Screen.PrimaryScreen.WorkingArea.Height;
        this.Location = new Point(screenWidth - this.Width - 10, screenHeight - this.Height - 10);

        this.Opacity = 0;
        this.Show();

        // ---
        mbStartWithFadeIn(timeout);
    }
    private async void mbStartWithFadeIn(int timeout)
    {
        while (this.Opacity < 1.0)
        {
            this.Opacity += 0.05;
            await Task.Delay(50);
        }
        await Task.Delay(timeout);
        mbFadeOut();
    }
    private async void mbFadeOut()
    {
        while (this.Opacity > 0.0)
        {
            this.Opacity -= 0.05;
            await Task.Delay(50);
        }
        this.Close();
    }
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
