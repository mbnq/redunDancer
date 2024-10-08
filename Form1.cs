using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace redunDancer
{
    public partial class mbForm1 : Form
    {
        private BackgroundWorker? pingWorker;
        private bool useSettingA;
        private int consecutiveFailures = 0;
        private bool checkboxesLocked = false;
        private bool initializing = true;

        public mbForm1()
        {
            initializing = true;
            InitializeComponent();
            InitializePingWorker();

            // Attach event handlers to the buttons and checkboxes
            mbButtonRun.Click += mbButtonRun_Click;
            mbButtonStop.Click += mbButtonStop_Click;
            ActiveACheckBox.CheckedChanged += ActiveACheckBox_CheckedChanged;
            ActiveBCheckBox.CheckedChanged += ActiveBCheckBox_CheckedChanged;

            // Detect current IP and set initial settings
            DetectCurrentIP();

            initializing = false; // Initialization complete
        }

        private void InitializePingWorker()
        {
            pingWorker = new BackgroundWorker();
            pingWorker.DoWork += PingWorker_DoWork;
            pingWorker.WorkerSupportsCancellation = true;
        }

        private void DetectCurrentIP()
        {
            string? currentIP = GetCurrentIPAddress();
            if (currentIP != null)
            {
                LogPingResult($"Current IP Address: {currentIP}");

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
                    LogPingResult("Current IP does not match Settings A or B. Defaulting to Setting A.");
                }
            }
            else
            {
                LogPingResult("Unable to detect current IP address.");
            }
        }

        private string? GetCurrentIPAddress()
        {
            foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (ni.OperationalStatus == OperationalStatus.Up &&
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
            }
            return null;
        }

        private bool IsSameNetwork(string ip1, string ip2)
        {
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
            if (pingWorker != null && !pingWorker.IsBusy)
            {
                consecutiveFailures = 0; // Reset failures
                mbPingLogTextBox.AppendText("Ping worker started.\r\n");
                pingWorker.RunWorkerAsync();
            }
        }

        private void mbButtonStop_Click(object? sender, EventArgs e)
        {
            if (pingWorker != null && pingWorker.IsBusy)
            {
                pingWorker.CancelAsync();
                mbPingLogTextBox.AppendText("Ping worker stopped.\r\n");
            }
        }

        private void PingWorker_DoWork(object? sender, DoWorkEventArgs e)
        {
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
                            LogPingResult($"Ping to {ipAddress} successful: {reply.RoundtripTime} ms | Current IP: {currentIP}");
                        }
                        else
                        {
                            consecutiveFailures++;
                            LogPingResult($"Ping to {ipAddress} failed or exceeded max ping: {(reply.Status == IPStatus.Success ? reply.RoundtripTime.ToString() : "N/A")} ms | Current IP: {currentIP}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    consecutiveFailures++;
                    LogPingResult($"Ping to {ipAddress} failed: {ex.Message} | Current IP: {currentIP}");
                }

                if (consecutiveFailures >= retryCount)
                {
                    SwitchSettings();
                    consecutiveFailures = 0;
                }

                Thread.Sleep(interval); // Pause between pings
            }
        }

        private void SwitchSettings()
        {
            useSettingA = !useSettingA;

            if (useSettingA && ActiveACheckBox.Checked)
            {
                ApplySettings(mbIPTextBoxA.Text, mbMaskTextBoxA.Text, mbGatewayTextBoxA.Text);
                ActiveACheckBox.Checked = true;
                ActiveBCheckBox.Checked = false;
            }
            else if (!useSettingA && ActiveBCheckBox.Checked)
            {
                ApplySettings(mbIPTextBoxB.Text, mbMaskTextBoxB.Text, mbGatewayTextBoxB.Text);
                ActiveACheckBox.Checked = false;
                ActiveBCheckBox.Checked = true;
            }
            else
            {
                LogPingResult("No active settings to switch to.");
            }

            // Lock checkboxes after switching
            StartCheckboxLock();
        }

        private void ApplySettings(string ip, string mask, string gateway)
        {
            LogPingResult($"Switched to settings: IP={ip}, Mask={mask}, Gateway={gateway}");
            SetNetworkSettings(ip, mask, gateway);
        }

        private void LogPingResult(string message)
        {
            if (mbPingLogTextBox.InvokeRequired)
            {
                mbPingLogTextBox.Invoke(new Action(() =>
                {
                    if (mbPingLogCheckBox.Checked)
                    {
                        mbPingLogTextBox.AppendText($"{DateTime.Now}: {message}\r\n");
                    }
                }));
            }
            else
            {
                if (mbPingLogCheckBox.Checked)
                {
                    mbPingLogTextBox.AppendText($"{DateTime.Now}: {message}\r\n");
                }
            }
        }

        private void SetNetworkSettings(string ip, string mask, string gateway)
        {
            try
            {
                string? adapterName = GetDefaultAdapterName();
                if (!string.IsNullOrEmpty(adapterName))
                {
                    // Build the netsh commands
                    string setIPCmd = $"interface ip set address name=\"{adapterName}\" source=static addr={ip} mask={mask} gateway={gateway} gwmetric=1";
                    string setDNSCmd1 = $"interface ip set dns name=\"{adapterName}\" source=static addr={mbDNS1TextBox.Text} register=PRIMARY";
                    string setDNSCmd2 = $"interface ip add dns name=\"{adapterName}\" addr={mbDNS2TextBox.Text} index=2";

                    RunNetshCommand(setIPCmd);
                    RunNetshCommand(setDNSCmd1);
                    RunNetshCommand(setDNSCmd2);

                    LogPingResult($"Network settings applied: IP={ip}, Mask={mask}, Gateway={gateway}, DNS1={mbDNS1TextBox.Text}, DNS2={mbDNS2TextBox.Text}");
                }
                else
                {
                    LogPingResult("Failed to retrieve network adapter.");
                }
            }
            catch (Exception ex)
            {
                LogPingResult($"Error applying network settings: {ex.Message}");
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
                    return ni.Name;
                }
            }
            return null;
        }

        private void RunNetshCommand(string command)
        {
            ProcessStartInfo psi = new ProcessStartInfo("netsh", command)
            {
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true,
                Verb = "runas" // Run as administrator
            };

            using (Process process = Process.Start(psi))
            {
                process.WaitForExit();
                string output = process.StandardOutput.ReadToEnd();
                LogPingResult(output);
            }
        }
    }
}
