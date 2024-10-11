
/* 

    www.mbnq.pl 2024 
    https://mbnq.pl/
    mbnq00 on gmail

*/

namespace redunDancer
{
    public partial class mbRedunDancerMain
    {
        private void ActiveACheckBox_CheckedChanged(object? sender, EventArgs e)
        {
            if (initializing || checkboxesLocked) return;

            if (ActiveACheckBox.Checked)
            {
                ActiveBCheckBox.Checked = false;
                useSettingA = true;
                ApplySettings(mbIPTextBoxA.Text, mbMaskTextBoxA.Text, mbGatewayTextBoxA.Text);
                StartCheckboxLock();
            }
        }
        private void ActiveBCheckBox_CheckedChanged(object? sender, EventArgs e)
        {
            if (initializing || checkboxesLocked) return;

            if (ActiveBCheckBox.Checked)
            {
                ActiveACheckBox.Checked = false;
                useSettingA = false;
                ApplySettings(mbIPTextBoxB.Text, mbMaskTextBoxB.Text, mbGatewayTextBoxB.Text);
                StartCheckboxLock();
            }
        }
        private void mbPingLogImportantOnlyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (mbPingLogImportantOnlyCheckBox.Checked) { importantMessagesOnly = true; } else { importantMessagesOnly = false; };
        }
        private void mbNotificationsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (mbNotificationsCheckBox.Checked) { showNotifications = true; } else { showNotifications = false; };
        }
        private void mbButtonRun_Click(object? sender, EventArgs e)
        {

            InitializeMain();
            unblockSettings(false);
            checkIPSettings();

            if (isConfigCorrect)
            {
                if (pingWorker != null && !pingWorker.IsBusy)
                {
                    consecutiveFailures = 0; // Reset failures
                    mbPingLogTextBox.AppendText($"{DateTime.UtcNow.ToString("HH:mm:ss")}: Started...\r\n");

                    pingWorker.RunWorkerAsync();
                }
            }
            else
            {
                MessageBox.Show("IP settings are incorrect! Aborted.", "Warning");

                InitializeMain();
                unblockSettings(true);
                if (pingWorker != null && pingWorker.IsBusy)
                {
                    pingWorker.CancelAsync();
                    mbPingLogTextBox.AppendText($"{DateTime.UtcNow.ToString("HH:mm:ss")}: Stopping...\r\n");
                }
            };
        }
        private void mbButtonStop_Click(object? sender, EventArgs e)
        {
            InitializeMain();
            unblockSettings(true);
            if (pingWorker != null && pingWorker.IsBusy)
            {
                pingWorker.CancelAsync();
                mbPingLogTextBox.AppendText($"{DateTime.UtcNow.ToString("HH:mm:ss")}: Stopping...\r\n");
            }
        }
    }
}