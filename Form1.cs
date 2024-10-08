using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Threading;
using System.Windows.Forms;

namespace redunDancer
{
    public partial class mbForm1 : Form
    {
        private BackgroundWorker pingWorker;
        private bool useSettingA = true;
        private int consecutiveFailures = 0;

        public mbForm1()
        {
            InitializeComponent();
            InitializePingWorker();

            // Attach event handlers to the buttons
            mbButtonRun.Click += mbButtonRun_Click;
            mbButtonStop.Click += mbButtonStop_Click;
        }

        private void InitializePingWorker()
        {
            pingWorker = new BackgroundWorker();
            pingWorker.DoWork += PingWorker_DoWork;
            pingWorker.WorkerSupportsCancellation = true;
        }

        private void mbButtonRun_Click(object sender, EventArgs e)
        {
            if (!pingWorker.IsBusy)
            {
                consecutiveFailures = 0; // Reset failures
                mbPingLogTextBox.AppendText("Ping worker started.\r\n");
                pingWorker.RunWorkerAsync();
            }
        }

        private void mbButtonStop_Click(object sender, EventArgs e)
        {
            if (pingWorker.IsBusy)
            {
                pingWorker.CancelAsync();
                mbPingLogTextBox.AppendText("Ping worker stopped.\r\n");
            }
        }

        private void PingWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (!pingWorker.CancellationPending)
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

                try
                {
                    using (Ping ping = new Ping())
                    {
                        PingReply reply = ping.Send(ipAddress);
                        if (reply.Status == IPStatus.Success && reply.RoundtripTime <= maxPing)
                        {
                            consecutiveFailures = 0;
                            LogPingResult($"Ping to {ipAddress} successful: {reply.RoundtripTime} ms");
                        }
                        else
                        {
                            consecutiveFailures++;
                            LogPingResult($"Ping to {ipAddress} failed or exceeded max ping: {(reply.Status == IPStatus.Success ? reply.RoundtripTime.ToString() : "N/A")} ms");
                        }
                    }
                }
                catch (Exception ex)
                {
                    consecutiveFailures++;
                    LogPingResult($"Ping to {ipAddress} failed: {ex.Message}");
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
            }
            else if (!useSettingA && ActiveBCheckBox.Checked)
            {
                ApplySettings(mbIPTextBoxB.Text, mbMaskTextBoxB.Text, mbGatewayTextBoxB.Text);
            }
            else
            {
                LogPingResult("No active settings to switch to.");
            }
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
                mbPingLogTextBox.Invoke(new Action(() => {
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
                string adapterName = GetDefaultAdapterName();
                if (!string.IsNullOrEmpty(adapterName))
                {
                    // Build the netsh command
                    string setIPCmd = $"interface ip set address name=\"{adapterName}\" source=static addr={ip} mask={mask} gateway={gateway} gwmetric=1";
                    string setDNScmd = $"interface ip set dns name=\"{adapterName}\" source=static addr={mbDNS1TextBox.Text}";

                    RunNetshCommand(setIPCmd);
                    RunNetshCommand(setDNScmd);

                    LogPingResult($"Network settings applied: IP={ip}, Mask={mask}, Gateway={gateway}");
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

        private string GetDefaultAdapterName()
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
