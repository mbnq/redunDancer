
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
        private bool checkboxesLocked = false;
        private bool initializing = true;
        private bool isConfigCorrect = false;
        private bool importantMessagesOnly = false;
        private bool silentRun = false;

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
            unblockSettings(true);

            silentRun = true; mbLoadButton_Click(this, EventArgs.Empty); silentRun = false;

            initializing = false;
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

        private void StartCheckboxLock()
        {
            if (int.TryParse(mbTestPingIntervalTextBox.Text, out int interval))
            {
                int lockDuration = interval * 5 * 1000; // Convert to milliseconds
                checkboxesLocked = true;
                ActiveACheckBox.Enabled = false;
                ActiveBCheckBox.Enabled = false;

                // Use System.Windows.Forms.Timer
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

            // Lock checkboxes after switching
            StartCheckboxLock();
        }
    }
}
