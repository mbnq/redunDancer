
/* 

    www.mbnq.pl 2024 
    https://mbnq.pl/
    mbnq00 on gmail

*/

using System.ComponentModel;
using System.Net;

namespace redunDancer
{
    public partial class mbRedunDancerMain : Form
    {
        private BackgroundWorker? pingWorker;
        private bool useSettingA;
        private int consecutiveFailures = 0;
        public bool checkboxesLocked = false;
        public bool initializing = true;
        public bool isConfigCorrect = false;
        public bool importantMessagesOnly = false;
        public bool silentRun = false;
        public static bool showNotifications = true;
        public static bool mbLogBoxShown = true;
        public static int mbInitialWidth = 0;
        public static string mbCurrentGlobalIP = "";

        public mbRedunDancerMain()
        {
            initializing = true;

            InitializeComponent();
            InitializePingWorker();
            InitializeNetworkDevices();

            using (MemoryStream ms = new MemoryStream(Properties.Resources.mbRedunDancer)) { this.Icon = new Icon(ms); }

            mbButtonRun.Click += mbButtonRun_Click;
            mbButtonStop.Click += mbButtonStop_Click;
            ActiveACheckBox.CheckedChanged += ActiveACheckBox_CheckedChanged;
            ActiveBCheckBox.CheckedChanged += ActiveBCheckBox_CheckedChanged;

            DetectCurrentIP();
            InitializeMain();
            InitializeTray();
            unblockSettings(true);

            silentRun = true; mbLoadButton_Click(this, EventArgs.Empty); silentRun = false;

            mbInitialWidth = this.Width;
            mbLogBoxShowHide();

            MBBackgroundManager.SetBackgroundImage(this);

            initializing = false;

            if (mbAutostartCheckbox.Checked)
            {
                mbButtonRun_Click(this, EventArgs.Empty);
                this.WindowState = FormWindowState.Minimized;
            }
        }
        private void InitializeMain()
        {
            mbRetryPbar.Maximum = int.Parse(mbTestPingRetryCountTextBox.Text);
            mbRetryPbar.Value = 0;
            mbPingPbar.Maximum = int.Parse(mbMaxPingTextBox.Text);
            mbPingPbar.Value = 0;
            checkBoxDhcpA.Checked = false;
            checkBoxDhcpB.Checked = false;
            importantMessagesOnly = mbPingLogImportantOnlyCheckBox.Checked;

            this.TopMost = mbAlwaysOnTopCheckBox.Checked;
        }
        private void unblockSettings(bool unblock)
        {
            mbButtonRun.Enabled = unblock;
            mbIPTextBoxA.Enabled = unblock;
            mbIPTextBoxB.Enabled = unblock;
            mbMaskTextBoxA.Enabled = unblock;
            mbMaskTextBoxB.Enabled = unblock;
            mbGatewayTextBoxA.Enabled = unblock;
            mbGatewayTextBoxB.Enabled = unblock;
            mbDNS1TextBox.Enabled = unblock;
            mbDNS2TextBox.Enabled = unblock;
            mbMaxPingTextBox.Enabled = unblock;
            mbTestPingIntervalTextBox.Enabled = unblock;
            mbTestPingRetryCountTextBox.Enabled = unblock;
            DeviceSelectDropDownA.Enabled = unblock;
            DeviceSelectDropDownB.Enabled = unblock;
            mbLoadButton.Enabled = unblock;
            mbSaveButton.Enabled = unblock;
            contextMenuStartOption.Enabled = unblock;
        }
        private void checkIPSettings()
        {
            isConfigCorrect = true;

            var textBoxes = new[]
            {
                mbIPTextBoxA,
                mbIPTextBoxB,
                mbMaskTextBoxA,
                mbMaskTextBoxB,
                mbGatewayTextBoxA,
                mbGatewayTextBoxB,
                mbDNS1TextBox,
                mbDNS2TextBox
            };

            foreach (var textBox in textBoxes)
            {
                if (!string.IsNullOrWhiteSpace(textBox.Text) && !IPAddress.TryParse(textBox.Text, out _))
                {
                    isConfigCorrect = false;
                    break;
                }
            }

            LogPingResult($"Settings validated correctly: {isConfigCorrect}", true);
        }
        public void PopUpNotification(string title, string message, int timeout)
        {
            if (showNotifications)
            {
                mbNotificationForm notification = new mbNotificationForm(title, message, timeout);
                notification.Show(); 
            }
        }
        private void StartCheckboxLock()
        {
            if (int.TryParse(mbTestPingIntervalTextBox.Text, out int interval))
            {
                int lockDuration = interval * 5 * 1000; // to ms
                checkboxesLocked = true;
                ActiveACheckBox.Enabled = false;
                ActiveBCheckBox.Enabled = false;

                System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
                timer.Interval = lockDuration;
                timer.Tick += (s, e) =>
                {
                    checkboxesLocked = false;
                    ActiveACheckBox.Enabled = true;
                    ActiveBCheckBox.Enabled = true;
                    timer.Stop();
                    timer.Dispose();
                };
                timer.Start();
            }
        }
        private void SwitchSettings()
        {
            useSettingA = !useSettingA;

            if (useSettingA)
            {
                ApplySettings(mbIPTextBoxA.Text, mbMaskTextBoxA.Text, mbGatewayTextBoxA.Text);
                Invoke(new Action(() =>
                {
                    ActiveACheckBox.Checked = true;
                    ActiveBCheckBox.Checked = false;
                }));
            }
            else
            {
                ApplySettings(mbIPTextBoxB.Text, mbMaskTextBoxB.Text, mbGatewayTextBoxB.Text);
                Invoke(new Action(() =>
                {
                    ActiveACheckBox.Checked = false;
                    ActiveBCheckBox.Checked = true;
                }));
            }

            UpdateNotifyIconText();
            StartCheckboxLock();
        }
        public void mbLogBoxShowHide()
        {
            if (mbLogBoxShown)
            {
                this.Width = mbInitialWidth;
                mbHideLogBoxButton.Text = "<<";
            }
            else
            {
                this.Width = mbInitialWidth - (mbPingLogTextBox.Width + 14);
                mbHideLogBoxButton.Text = ">>";
            }
        }

    }
}
