
/* 

    www.mbnq.pl 2024 
    https://mbnq.pl/
    mbnq00 on gmail

*/

using System.Net;

namespace redunDancer
{
    public partial class mbRedunDancerMain
    {

        #region SaveLoad Logic
        private void mbButtonSaveToFileAs_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files (*.txt)|*.txt|Log files (*.log)|*.log|All files (*.*)|*.*";
            saveFileDialog.Title = "Save PingLog";
            saveFileDialog.FileName = "PingLog.txt";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    File.WriteAllText(saveFileDialog.FileName, mbPingLogTextBox.Text);
                    MessageBox.Show("Log saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Was not able to save logfile: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void mbSaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                checkIPSettings();
                if (isConfigCorrect)
                {
                    // strings
                    Properties.Settings.Default.mbIPTextBoxA = mbIPTextBoxA.Text;
                    Properties.Settings.Default.mbIPTextBoxB = mbIPTextBoxB.Text;
                    Properties.Settings.Default.mbMaskTextBoxA = mbMaskTextBoxA.Text;
                    Properties.Settings.Default.mbMaskTextBoxB = mbMaskTextBoxB.Text;
                    Properties.Settings.Default.mbGatewayTextBoxA = mbGatewayTextBoxA.Text;
                    Properties.Settings.Default.mbGatewayTextBoxB = mbGatewayTextBoxB.Text;
                    Properties.Settings.Default.DeviceSelectDropDownA = DeviceSelectDropDownA.Text;
                    Properties.Settings.Default.DeviceSelectDropDownB = DeviceSelectDropDownB.Text;
                    Properties.Settings.Default.mbDNS1TextBox = mbDNS1TextBox.Text;
                    Properties.Settings.Default.mbDNS2TextBox = mbDNS2TextBox.Text;
                    Properties.Settings.Default.mbTestPingIntervalTextBox = mbTestPingIntervalTextBox.Text;
                    Properties.Settings.Default.mbMaxPingTextBox = mbMaxPingTextBox.Text;
                    Properties.Settings.Default.mbTestPingRetryCountTextBox = mbTestPingRetryCountTextBox.Text;

                    // bools
                    Properties.Settings.Default.mbPingLogImportantOnlyCheckBox = mbPingLogImportantOnlyCheckBox.Checked;
                    Properties.Settings.Default.mbAlwaysOnTopCheckBox = mbAlwaysOnTopCheckBox.Checked;
                    Properties.Settings.Default.mbPingLogCheckBox = mbPingLogCheckBox.Checked;

                    Properties.Settings.Default.Save();
                    MessageBox.Show("Settings saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LogPingResult("Settings saved successfully.", true);
                }
                else
                {
                    MessageBox.Show("One or more IP addresses are invalid. Saving aborted!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LogPingResult("One or more IP addresses are invalid. Saving aborted!", true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving settings: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogPingResult("Error saving settings!", true);
            }
        }
        private void mbLoadButton_Click(object? sender, EventArgs e)
        {
            if (DoesSaveExists2())
            {
                try
                {
                    // strings
                    mbIPTextBoxA.Text = Properties.Settings.Default.mbIPTextBoxA;
                    mbIPTextBoxB.Text = Properties.Settings.Default.mbIPTextBoxB;
                    mbMaskTextBoxA.Text = Properties.Settings.Default.mbMaskTextBoxA;
                    mbMaskTextBoxB.Text = Properties.Settings.Default.mbMaskTextBoxB;
                    mbGatewayTextBoxA.Text = Properties.Settings.Default.mbGatewayTextBoxA;
                    mbGatewayTextBoxB.Text = Properties.Settings.Default.mbGatewayTextBoxB;
                    DeviceSelectDropDownA.Text = Properties.Settings.Default.DeviceSelectDropDownA;
                    DeviceSelectDropDownB.Text = Properties.Settings.Default.DeviceSelectDropDownB;
                    mbDNS1TextBox.Text = Properties.Settings.Default.mbDNS1TextBox;
                    mbDNS2TextBox.Text = Properties.Settings.Default.mbDNS2TextBox;
                    mbTestPingIntervalTextBox.Text = Properties.Settings.Default.mbTestPingIntervalTextBox;
                    mbMaxPingTextBox.Text = Properties.Settings.Default.mbMaxPingTextBox;
                    mbTestPingRetryCountTextBox.Text = Properties.Settings.Default.mbTestPingRetryCountTextBox;

                    // bools
                    mbPingLogImportantOnlyCheckBox.Checked = Properties.Settings.Default.mbPingLogImportantOnlyCheckBox;
                    mbAlwaysOnTopCheckBox.Checked = Properties.Settings.Default.mbAlwaysOnTopCheckBox;
                    mbPingLogCheckBox.Checked = Properties.Settings.Default.mbPingLogCheckBox;

                    if (!silentRun) MessageBox.Show("Settings loaded successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LogPingResult("Settings loaded successfully.", true);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading settings: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LogPingResult("Error loading settings!", true);
                }
            }
            else
            {
                if (!silentRun) MessageBox.Show("Could not find savefile. Loading aborted!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (!silentRun) LogPingResult("Could not find savefile. Loading aborted!", true);
            }
        }
        private bool DoesSaveExists2()
        {
            bool _isSaveOK = true;

            var saveEntries = new[]
            {
                Properties.Settings.Default.mbDNS1TextBox,
                Properties.Settings.Default.mbDNS1TextBox,
            };

            foreach (var text in saveEntries)
            {
                if (!IPAddress.TryParse(text, out _))
                {
                    _isSaveOK = false;
                    break;
                }
            }

            return _isSaveOK;
        }
        #endregion
    }
}