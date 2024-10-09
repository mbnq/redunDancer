
/* 

    www.mbnq.pl 2024 
    https://mbnq.pl/
    mbnq00 on gmail

*/

using System.ComponentModel;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Management;
using System.Net;
using System.Diagnostics.Eventing.Reader;

namespace redunDancer
{
    public partial class mbForm1 : Form
    {
        private BackgroundWorker? pingWorker;
        private bool useSettingA;
        private int consecutiveFailures = 0;
        private bool checkboxesLocked = false;
        private bool initializing = true;
        private bool isConfigCorrect = false;

        public mbForm1()
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

            LogPingResult($"Settings validated correctly: {isConfigCorrect}");
        }

        private void InitializePingWorker()
        {
            pingWorker = new BackgroundWorker();
            pingWorker.DoWork += PingWorker_DoWork;
            pingWorker.WorkerSupportsCancellation = true;
        }
        private void InitializeNetworkDevices()
        {
            DeviceSelectDropDownA.Items.Clear();
            DeviceSelectDropDownA.Items.Add("Windows Default");
            DeviceSelectDropDownB.Items.Clear();
            DeviceSelectDropDownB.Items.Add("Windows Default");

            var networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();

            // populate the dropdowns (ni = network interface)

            foreach (var ni in networkInterfaces)
            {
                string deviceName = ni.Name;
                DeviceSelectDropDownA.Items.Add(deviceName);
                DeviceSelectDropDownB.Items.Add(deviceName);
            }

            // "Windows Default" as the init option
            DeviceSelectDropDownA.SelectedIndex = 0;
            DeviceSelectDropDownB.SelectedIndex = 0;
        }
        private void DetectCurrentIP()
        {
            string? currentIP = GetCurrentIPAddress();
            if (currentIP != null)
            {
                LogPingResult($"Current LocalIP: {currentIP}");

                // Determine if current IP matches Setting A or B
                if (IsSameNetwork(currentIP, mbIPTextBoxA.Text))
                {
                    useSettingA = true;
                    ActiveACheckBox.Checked = true;
                    ActiveBCheckBox.Checked = false;
                    LogPingResult("Using Setting A based on current IP.");
                }
                else if (IsSameNetwork(currentIP, mbIPTextBoxB.Text))
                {
                    useSettingA = false;
                    ActiveACheckBox.Checked = false;
                    ActiveBCheckBox.Checked = true;
                    LogPingResult("Using Setting B based on current IP.");
                }
                else
                {
                    // Default to Setting A if no match
                    useSettingA = true;
                    ActiveACheckBox.Checked = true;
                    ActiveBCheckBox.Checked = false;
                    LogPingResult("LocalIP not match A nor B. Setting to A as def.");
                }
            }
            else
            {
                LogPingResult("Unable to detect current LocalIP.");
            }
        }
        private string? GetCurrentIPAddress()
        {
            string? adapterName = GetSelectedAdapterName(useSettingA);

            if (adapterName == null)
                return null;

            NetworkInterface? ni = NetworkInterface.GetAllNetworkInterfaces()
                .FirstOrDefault(n => n.Name == adapterName);

            if (ni != null && ni.OperationalStatus == OperationalStatus.Up &&
                ni.NetworkInterfaceType != NetworkInterfaceType.Loopback &&
                ni.Supports(NetworkInterfaceComponent.IPv4))
            {
                foreach (UnicastIPAddressInformation ip in ni.GetIPProperties().UnicastAddresses)
                {
                    if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
                    {
                        return ip.Address.ToString();
                    }
                }
            }
            return null;
        }
        private bool IsSameNetwork(string ip1, string ip2)
        {
            if (string.IsNullOrWhiteSpace(ip1) || string.IsNullOrWhiteSpace(ip2))
                return false;

            string network1 = ip1.Substring(0, ip1.LastIndexOf('.'));
            string network2 = ip2.Substring(0, ip2.LastIndexOf('.'));
            return network1 == network2;
        }
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
                    mbPingLogTextBox.AppendText($"{DateTime.UtcNow.ToString("HH:mm:ss")}: Ping worker started.\r\n");

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
                    mbPingLogTextBox.AppendText($"{DateTime.UtcNow.ToString("HH:mm:ss")}: Ping worker stopping...\r\n");
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
                mbPingLogTextBox.AppendText($"{DateTime.UtcNow.ToString("HH:mm:ss")}: Ping worker stopping...\r\n");
            }
        }
        private void PingWorker_DoWork(object? sender, DoWorkEventArgs e)
        {
            int postSwitchDelayMultiplier = 1;

            while (pingWorker != null && !pingWorker.CancellationPending)
            {
                // Get the IP, ping settings, and retry count from textboxes
                string ipAddress = useSettingA ? mbDNS1TextBox.Text : mbDNS2TextBox.Text;

                // Parse values safely, handle exceptions
                int maxPing;
                int interval;
                int retryCount;

                if (!int.TryParse(mbMaxPingTextBox.Text, out maxPing))
                {
                    maxPing = 100; // Default value
                }

                if (!int.TryParse(mbTestPingIntervalTextBox.Text, out interval))
                {
                    interval = 1; // Default value
                }
                interval *= 1000; // Convert to milliseconds

                if (!int.TryParse(mbTestPingRetryCountTextBox.Text, out retryCount))
                {
                    retryCount = 3; // Default value
                }

                string? currentIP = GetCurrentIPAddress();

                try
                {
                    using (Ping ping = new Ping())
                    {
                        PingReply reply = ping.Send(ipAddress);
                        if (reply.Status == IPStatus.Success && reply.RoundtripTime <= maxPing)
                        {
                            consecutiveFailures = 0;
                            LogPingResult($"{ipAddress}: {reply.RoundtripTime}ms | IP:{currentIP}");
                            mbPingPbar.Value = (int)Math.Min(reply.RoundtripTime, mbPingPbar.Maximum);
                        }
                        else
                        {
                            consecutiveFailures++;
                            LogPingResult($"{ipAddress} failed or exceeded max ping:{(reply.Status == IPStatus.Success ? reply.RoundtripTime.ToString() : "N/A")} ms | IP:{currentIP}");
                            mbPingPbar.Value = mbPingPbar.Maximum;
                        }
                    }
                }
                catch (Exception ex)
                {
                    consecutiveFailures++;
                    LogPingResult($"Ping to {ipAddress} failed:{ex.Message} | IP:{currentIP}");
                }

                if (consecutiveFailures >= retryCount)
                {
                    SwitchSettings();
                    consecutiveFailures = 0;
                    postSwitchDelayMultiplier = 2; // Double the delay after switching
                }

                mbRetryPbar.Value = consecutiveFailures;
                SleepWithCancellation(interval * postSwitchDelayMultiplier);

                // Reset the multiplier back to 1 after the extended delay
                if (postSwitchDelayMultiplier > 1)
                {
                    postSwitchDelayMultiplier = 1;
                }
            }
        }
        private void LogPingResult(string message)
        {
            if (mbPingLogTextBox.InvokeRequired)
            {
                mbPingLogTextBox.Invoke(new Action(() =>
                {
                    if (mbPingLogCheckBox.Checked)
                    {
                        mbPingLogTextBox.AppendText($"{DateTime.UtcNow.ToString("HH:mm:ss")}: {message}\r\n");
                    }
                }));
            }
            else
            {
                if (mbPingLogCheckBox.Checked)
                {
                    mbPingLogTextBox.AppendText($"{DateTime.UtcNow.ToString("HH:mm:ss")}: {message}\r\n");
                }
            }
        }
        private void SleepWithCancellation(int milliseconds)
        {
            int sleepInterval = 100; // Sleep in 100ms intervals
            int elapsed = 0;
            while (elapsed < milliseconds)
            {
                if (pingWorker != null && pingWorker.CancellationPending)
                {
                    return;
                }
                Thread.Sleep(sleepInterval);
                elapsed += sleepInterval;
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
        private void ApplySettings(string ip, string mask, string gateway)
        {
            LogPingResult($"Applying settings: IP={ip}, Mask={mask}, Gateway={gateway}");
            SetNetworkSettings(ip, mask, gateway);

            // Determine if we are using DHCP and update the corresponding checkbox
            bool isUsingDHCP = string.IsNullOrWhiteSpace(ip) || string.IsNullOrWhiteSpace(mask) || string.IsNullOrWhiteSpace(gateway);

            if (useSettingA)
            {
                Invoke(new Action(() =>
                {
                    checkBoxDhcpA.Checked = isUsingDHCP;
                    checkBoxDhcpA.Enabled = false; // Disable to show it's an indicator
                }));
            }
            else
            {
                Invoke(new Action(() =>
                {
                    checkBoxDhcpB.Checked = isUsingDHCP;
                    checkBoxDhcpB.Enabled = false; // Disable to show it's an indicator
                }));
            }
        }
        private void SetNetworkSettings(string ip, string mask, string gateway)
        {
            try
            {
                string? adapterName = GetNetshInterfaceName(useSettingA);

                if (adapterName == null)
                {
                    LogPingResult("Failed to retrieve network adapter.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(ip) || string.IsNullOrWhiteSpace(mask) || string.IsNullOrWhiteSpace(gateway))
                {
                    // Set to DHCP
                    SetDHCP(adapterName);
                    Task.Delay(2000).Wait();
                    GetIPSettings(adapterName, useSettingA, false);
                }
                else
                {
                    // Set static IP settings
                    string setIPCmd = $"interface ip set address name=\"{adapterName}\" static {ip} {mask} {gateway} 1";
                    string setDNSCmd1 = $"interface ip set dnsservers name=\"{adapterName}\" static {mbDNS1TextBox.Text} primary";
                    string setDNSCmd2 = $"interface ip add dnsservers name=\"{adapterName}\" address={mbDNS2TextBox.Text} index=2";

                    RunNetshCommand(setIPCmd);
                    RunNetshCommand(setDNSCmd1);
                    RunNetshCommand(setDNSCmd2);

                    LogPingResult($"Network settings applied to {adapterName}: IP={ip}, Mask={mask}, Gateway={gateway}, DNS1={mbDNS1TextBox.Text}, DNS2={mbDNS2TextBox.Text}");
                }
            }
            catch (Exception ex)
            {
                LogPingResult($"Error applying network settings: {ex.Message}");
            }
        }

        private void SetDHCP(string adapterName)
        {
            string dhcpIPCmd = $"interface ip set address name=\"{adapterName}\" dhcp";
            string dhcpDNSCmd = $"interface ip set dnsservers name=\"{adapterName}\" dhcp";
            RunNetshCommand(dhcpIPCmd);
            RunNetshCommand(dhcpDNSCmd);
            LogPingResult($"Set network settings to DHCP on adapter {adapterName}.");
        }

        private void GetIPSettings(string adapterName, bool isSettingA, bool populateTextBoxes)
        {
            NetworkInterface? adapter = NetworkInterface.GetAllNetworkInterfaces()
                .FirstOrDefault(ni => GetNetshInterfaceNameById(ni.Id) == adapterName);

            if (adapter != null)
            {
                var ipProperties = adapter.GetIPProperties();
                var unicastAddress = ipProperties.UnicastAddresses
                    .FirstOrDefault(ua => ua.Address.AddressFamily == AddressFamily.InterNetwork);

                if (unicastAddress != null)
                {
                    string ip = unicastAddress.Address.ToString();
                    string mask = unicastAddress.IPv4Mask.ToString();
                    string gateway = ipProperties.GatewayAddresses
                        .FirstOrDefault()?.Address.ToString() ?? "";

                    LogPingResult($"Obtained IP settings: IP={ip}, Mask={mask}, Gateway={gateway}");

                    // Determine if DHCP is being used
                    bool isUsingDHCP = string.IsNullOrWhiteSpace(ip) || string.IsNullOrWhiteSpace(mask) || string.IsNullOrWhiteSpace(gateway);

                    // Update the checkboxes for DHCP
                    if (isSettingA)
                    {
                        Invoke(new Action(() =>
                        {
                            checkBoxDhcpA.Checked = isUsingDHCP;
                            checkBoxDhcpA.Enabled = false; // Disable to show it's an indicator
                            if (populateTextBoxes)
                            {
                                mbIPTextBoxA.Text = ip;
                                mbMaskTextBoxA.Text = mask;
                                mbGatewayTextBoxA.Text = gateway;
                            }
                        }));
                    }
                    else
                    {
                        Invoke(new Action(() =>
                        {
                            checkBoxDhcpB.Checked = isUsingDHCP;
                            checkBoxDhcpB.Enabled = false; // Disable to show it's an indicator
                            if (populateTextBoxes)
                            {
                                mbIPTextBoxB.Text = ip;
                                mbMaskTextBoxB.Text = mask;
                                mbGatewayTextBoxB.Text = gateway;
                            }
                        }));
                    }
                }
                else
                {
                    LogPingResult("Failed to obtain IP settings.");
                }
            }
        }

        private string? GetDefaultAdapterName()
        {
            foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (ni.OperationalStatus == OperationalStatus.Up &&
                    ni.NetworkInterfaceType != NetworkInterfaceType.Loopback &&
                    ni.Supports(NetworkInterfaceComponent.IPv4))
                {
                    return GetNetshInterfaceNameById(ni.Id);
                }
            }
            return null;
        }

        private string? GetSelectedAdapterName(bool isSettingA)
        {
            string? selectedAdapter = null;

            if (isSettingA)
            {
                if (DeviceSelectDropDownA.InvokeRequired)
                {
                    DeviceSelectDropDownA.Invoke(new MethodInvoker(delegate
                    {
                        selectedAdapter = DeviceSelectDropDownA.SelectedItem?.ToString();
                    }));
                }
                else
                {
                    selectedAdapter = DeviceSelectDropDownA.SelectedItem?.ToString();
                }
            }
            else
            {
                if (DeviceSelectDropDownB.InvokeRequired)
                {
                    DeviceSelectDropDownB.Invoke(new MethodInvoker(delegate
                    {
                        selectedAdapter = DeviceSelectDropDownB.SelectedItem?.ToString();
                    }));
                }
                else
                {
                    selectedAdapter = DeviceSelectDropDownB.SelectedItem?.ToString();
                }
            }

            if (string.IsNullOrEmpty(selectedAdapter) || selectedAdapter == "Windows Default")
            {
                return GetDefaultAdapterName();
            }
            else
            {
                return selectedAdapter;
            }
        }

        private string? GetNetshInterfaceName(bool isSettingA)
        {
            string? adapterName = GetSelectedAdapterName(isSettingA);
            if (adapterName == null)
                return null;

            return GetNetshInterfaceNameByAdapterName(adapterName);
        }

        private string? GetNetshInterfaceNameByAdapterName(string adapterName)
        {
            NetworkInterface? ni = NetworkInterface.GetAllNetworkInterfaces()
                .FirstOrDefault(n => n.Name == adapterName);

            if (ni != null)
            {
                return GetNetshInterfaceNameById(ni.Id);
            }
            return null;
        }

        private string? GetNetshInterfaceNameById(string adapterId)
        {
            string query = $"SELECT * FROM Win32_NetworkAdapter WHERE GUID = '{adapterId}'";
            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(query))
            {
                foreach (ManagementObject obj in searcher.Get())
                {
                    string? netConnectionID = obj["NetConnectionID"]?.ToString();
                    if (!string.IsNullOrEmpty(netConnectionID))
                    {
                        return netConnectionID;
                    }
                }
            }
            return null;
        }

        private void RunNetshCommand(string command)
        {
            LogPingResult($"Running netsh command: {command}");

            ProcessStartInfo psi = new ProcessStartInfo("netsh", command)
            {
                RedirectStandardOutput = true,
                RedirectStandardError = true, // Capture errors
                UseShellExecute = false,
                CreateNoWindow = true,
                Verb = "runas" // Run as administrator
            };

            using (Process process = Process.Start(psi))
            {
                process.WaitForExit();
                string output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();

                if (!string.IsNullOrEmpty(output))
                {
                    LogPingResult(output);
                }

                if (!string.IsNullOrEmpty(error))
                {
                    LogPingResult($"Error: {error}");
                }
            }
        }

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
    }
}
