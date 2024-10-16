﻿
/* 

    www.mbnq.pl 2024 
    https://mbnq.pl/
    mbnq00 on gmail

*/

using System.ComponentModel;
using System.Diagnostics;
using System.Management;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace redunDancer
{
    public partial class mbRedunDancerMain
    {
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
                LogPingResult($"Current LocalIP: {currentIP}", true);

                // Determine if current IP matches Setting A or B
                if (IsSameNetwork(currentIP, mbIPTextBoxA.Text))
                {
                    useSettingA = true;
                    ActiveACheckBox.Checked = true;
                    ActiveBCheckBox.Checked = false;
                    LogPingResult("Using Setting A based on current IP.", true);
                }
                else if (IsSameNetwork(currentIP, mbIPTextBoxB.Text))
                {
                    useSettingA = false;
                    ActiveACheckBox.Checked = false;
                    ActiveBCheckBox.Checked = true;
                    LogPingResult("Using Setting B based on current IP.", true);
                }
                else
                {
                    useSettingA = true;
                    ActiveACheckBox.Checked = true;
                    ActiveBCheckBox.Checked = false;
                    LogPingResult("LocalIP not match A nor B. Setting to A as def.", true);
                }
            }
            else
            {
                LogPingResult("Unable to detect current LocalIP.", true);
            }
        }
        private string? GetCurrentIPAddress()
        {
            string? adapterName = GetSelectedAdapterName(useSettingA);

            if (adapterName == null) return null;

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
                        mbCurrentGlobalIP = ip.Address.ToString();
                        return ip.Address.ToString();
                    }
                }
            }
            return null;
        }
        private bool IsSameNetwork(string ip1, string ip2)
        {
            if (string.IsNullOrWhiteSpace(ip1) || string.IsNullOrWhiteSpace(ip2)) return false;

            string network1 = ip1.Substring(0, ip1.LastIndexOf('.'));
            string network2 = ip2.Substring(0, ip2.LastIndexOf('.'));
            return network1 == network2;
        }
        private void PingWorker_DoWork(object? sender, DoWorkEventArgs e)
        {
            int postSwitchDelayMultiplier = 1;

            while (pingWorker != null && !pingWorker.CancellationPending)
            {

                string ipAddress = useSettingA ? mbDNS1TextBox.Text : mbDNS2TextBox.Text;

                int maxPing;
                int interval;
                int retryCount;

                if (!int.TryParse(mbMaxPingTextBox.Text, out maxPing))
                {
                    maxPing = 100; // def
                }

                if (!int.TryParse(mbTestPingIntervalTextBox.Text, out interval))
                {
                    interval = 1; // def
                }
                interval *= 1000; // to ms

                if (!int.TryParse(mbTestPingRetryCountTextBox.Text, out retryCount))
                {
                    retryCount = 3; // def
                }

                string? currentIP = GetCurrentIPAddress();
                if (currentIP != null) notifyIcon.Text = "redunDancer " + "(" + currentIP + ")";

                try
                {
                    using (Ping ping = new Ping())
                    {
                        PingReply reply = ping.Send(ipAddress);
                        if (reply.Status == IPStatus.Success && reply.RoundtripTime <= maxPing)
                        {
                            consecutiveFailures = 0;
                            LogPingResult($"{ipAddress}: {reply.RoundtripTime}ms | IP:{currentIP}", false);
                            mbPingPbar.Value = (int)Math.Min(reply.RoundtripTime, mbPingPbar.Maximum);
                        }
                        else
                        {
                            consecutiveFailures++;
                            LogPingResult($"{ipAddress} failed or exceeded max ping:{(reply.Status == IPStatus.Success ? reply.RoundtripTime.ToString() : "N/A")} ms | IP:{currentIP}", true);
                            mbPingPbar.Value = mbPingPbar.Maximum;
                        }
                    }
                }
                catch (Exception ex)
                {
                    consecutiveFailures++;
                    LogPingResult($"Ping to {ipAddress} failed:{ex.Message} | IP:{currentIP}", true);
                }

                if (consecutiveFailures >= retryCount)
                {
                    SwitchSettings();
                    PopUpNotification("redunDancer", "Switching network.", 5000);
                    consecutiveFailures = 0;
                    postSwitchDelayMultiplier = 2;
                }

                mbRetryPbar.Value = consecutiveFailures;
                SleepWithCancellation(interval * postSwitchDelayMultiplier);

                if (postSwitchDelayMultiplier > 1) postSwitchDelayMultiplier = 1;
            }
        }
        private void LogPingResult(string message, bool isImportant = true)
        {
            if (importantMessagesOnly)
            {
                if (mbPingLogTextBox.InvokeRequired)
                {
                    mbPingLogTextBox.Invoke(new Action(() =>
                    {
                        if (mbPingLogCheckBox.Checked && isImportant)
                        {
                            mbPingLogTextBox.AppendText($"{DateTime.UtcNow.ToString("HH:mm:ss")}: {message}\r\n");
                        }
                    }));
                }
                else
                {
                    if (mbPingLogCheckBox.Checked && isImportant)
                    {
                        mbPingLogTextBox.AppendText($"{DateTime.UtcNow.ToString("HH:mm:ss")}: {message}\r\n");
                    }
                }
            }
            else
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
        }
        private void SleepWithCancellation(int milliseconds)
        {
            int sleepInterval = 100;
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

        private void ApplySettings(string ip, string mask, string gateway)
        {
            LogPingResult($"Applying settings: IP={ip}, Mask={mask}, Gateway={gateway}", true);
            SetNetworkSettings(ip, mask, gateway);

            // determine if we are using DHCP and update the corresponding checkbox
            bool isUsingDHCP = string.IsNullOrWhiteSpace(ip) || string.IsNullOrWhiteSpace(mask) || string.IsNullOrWhiteSpace(gateway);

            if (useSettingA)
            {
                Invoke(new Action(() =>
                {
                    checkBoxDhcpA.Checked = isUsingDHCP;
                    checkBoxDhcpA.Enabled = false;
                }));
            }
            else
            {
                Invoke(new Action(() =>
                {
                    checkBoxDhcpB.Checked = isUsingDHCP;
                    checkBoxDhcpB.Enabled = false;
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
                    LogPingResult("Failed to retrieve network adapter.", true);
                    PopUpNotification("redunDancer", "Failed to retrieve network adapter.", 5000);
                    return;
                }

                if (string.IsNullOrWhiteSpace(ip) || string.IsNullOrWhiteSpace(mask) || string.IsNullOrWhiteSpace(gateway))
                {
                    SetDHCP(adapterName);
                    Task.Delay(2000).Wait();
                    GetIPSettings(adapterName, useSettingA, false);
                }
                else
                {
                    // static IP settings
                    string setIPCmd = $"interface ip set address name=\"{adapterName}\" static {ip} {mask} {gateway} 1";
                    string setDNSCmd1 = $"interface ip set dnsservers name=\"{adapterName}\" static {mbDNS1TextBox.Text} primary";
                    string setDNSCmd2 = $"interface ip add dnsservers name=\"{adapterName}\" address={mbDNS2TextBox.Text} index=2";

                    RunNetshCommand(setIPCmd);
                    RunNetshCommand(setDNSCmd1);
                    RunNetshCommand(setDNSCmd2);

                    LogPingResult($"Network settings applied to {adapterName}: IP={ip}, Mask={mask}, Gateway={gateway}, DNS1={mbDNS1TextBox.Text}, DNS2={mbDNS2TextBox.Text}", true);
                }
            }
            catch (Exception ex)
            {
                LogPingResult($"Error applying network settings: {ex.Message}", true);
                PopUpNotification("redunDancer", "Error applying network settings!", 5000);
            }
        }

        private void SetDHCP(string adapterName)
        {
            string dhcpIPCmd = $"interface ip set address name=\"{adapterName}\" dhcp";
            string dhcpDNSCmd = $"interface ip set dnsservers name=\"{adapterName}\" dhcp";
            RunNetshCommand(dhcpIPCmd);
            RunNetshCommand(dhcpDNSCmd);
            LogPingResult($"Set network settings to DHCP on adapter {adapterName}.", true);
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

                    LogPingResult($"Obtained IP settings: IP={ip}, Mask={mask}, Gateway={gateway}", true);

                    // determine if DHCP is being used
                    bool isUsingDHCP = string.IsNullOrWhiteSpace(ip) || string.IsNullOrWhiteSpace(mask) || string.IsNullOrWhiteSpace(gateway);

                    if (isSettingA)
                    {
                        Invoke(new Action(() =>
                        {
                            checkBoxDhcpA.Checked = isUsingDHCP;
                            checkBoxDhcpA.Enabled = false;
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
                            checkBoxDhcpB.Enabled = false;
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
                    LogPingResult("Failed to obtain IP settings.", true);
                    PopUpNotification("redunDancer", "Failed to obtain IP settings.", 5000);
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
            LogPingResult($"Running netsh command: {command}", true);

            ProcessStartInfo psi = new ProcessStartInfo("netsh", command)
            {
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true,
                Verb = "runas" // run as admin
            };

            using (Process? process = Process.Start(psi))
            {
                process.WaitForExit();
                string output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();

                if (!string.IsNullOrEmpty(output))
                {
                    LogPingResult(output, false);
                }

                if (!string.IsNullOrEmpty(error))
                {
                    LogPingResult($"Error: {error}", true);
                }
            }
        }

    }
}