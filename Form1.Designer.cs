﻿namespace redunDancer
{
    partial class mbForm1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            mbIPTextBoxA = new TextBox();
            mbMaskTextBoxA = new TextBox();
            mbGatewayTextBoxA = new TextBox();
            mbIPTextBoxB = new TextBox();
            mbMaskTextBoxB = new TextBox();
            mbGatewayTextBoxB = new TextBox();
            mbDNS1TextBox = new TextBox();
            mbDNS2TextBox = new TextBox();
            IPLabel = new Label();
            MaskLabel = new Label();
            GatewayLabel = new Label();
            DNS1Label = new Label();
            DNS2Label = new Label();
            ActiveACheckBox = new CheckBox();
            ActiveBCheckBox = new CheckBox();
            mbMaxPingTextBox = new TextBox();
            MaxPingLabel = new Label();
            mbPingLogTextBox = new TextBox();
            mbButtonRun = new Button();
            mbButtonStop = new Button();
            mbTestPingIntervalTextBox = new TextBox();
            PingIntervalLabel = new Label();
            mbTestPingRetryCountTextBox = new TextBox();
            PingRetryCountLabel = new Label();
            mbPingLogCheckBox = new CheckBox();
            mbRetryPbar = new ProgressBar();
            mbPingPbar = new ProgressBar();
            checkBoxDhcpA = new CheckBox();
            checkBoxDhcpB = new CheckBox();
            mbAlwaysOnTopCheckBox = new CheckBox();
            mbAutoStartCheckBox = new CheckBox();
            dummyLabelMin = new Label();
            dummyLabelMax = new Label();
            DeviceSelectDropDownA = new ComboBox();
            DeviceSelectDropDownB = new ComboBox();
            SuspendLayout();
            // 
            // mbIPTextBoxA
            // 
            mbIPTextBoxA.Location = new Point(12, 48);
            mbIPTextBoxA.Name = "mbIPTextBoxA";
            mbIPTextBoxA.Size = new Size(198, 27);
            mbIPTextBoxA.TabIndex = 1;
            mbIPTextBoxA.Text = "192.168.4.128";
            // 
            // mbMaskTextBoxA
            // 
            mbMaskTextBoxA.Location = new Point(12, 81);
            mbMaskTextBoxA.Name = "mbMaskTextBoxA";
            mbMaskTextBoxA.Size = new Size(198, 27);
            mbMaskTextBoxA.TabIndex = 1;
            mbMaskTextBoxA.Text = "255.255.255.0";
            // 
            // mbGatewayTextBoxA
            // 
            mbGatewayTextBoxA.Location = new Point(12, 114);
            mbGatewayTextBoxA.Name = "mbGatewayTextBoxA";
            mbGatewayTextBoxA.Size = new Size(198, 27);
            mbGatewayTextBoxA.TabIndex = 1;
            mbGatewayTextBoxA.Text = "192.168.4.1";
            // 
            // mbIPTextBoxB
            // 
            mbIPTextBoxB.Location = new Point(381, 47);
            mbIPTextBoxB.Name = "mbIPTextBoxB";
            mbIPTextBoxB.Size = new Size(198, 27);
            mbIPTextBoxB.TabIndex = 1;
            // 
            // mbMaskTextBoxB
            // 
            mbMaskTextBoxB.Location = new Point(381, 84);
            mbMaskTextBoxB.Name = "mbMaskTextBoxB";
            mbMaskTextBoxB.Size = new Size(198, 27);
            mbMaskTextBoxB.TabIndex = 1;
            // 
            // mbGatewayTextBoxB
            // 
            mbGatewayTextBoxB.Location = new Point(381, 117);
            mbGatewayTextBoxB.Name = "mbGatewayTextBoxB";
            mbGatewayTextBoxB.Size = new Size(198, 27);
            mbGatewayTextBoxB.TabIndex = 1;
            // 
            // mbDNS1TextBox
            // 
            mbDNS1TextBox.Location = new Point(227, 215);
            mbDNS1TextBox.Name = "mbDNS1TextBox";
            mbDNS1TextBox.Size = new Size(125, 27);
            mbDNS1TextBox.TabIndex = 2;
            mbDNS1TextBox.Text = "8.8.8.8";
            // 
            // mbDNS2TextBox
            // 
            mbDNS2TextBox.Location = new Point(227, 248);
            mbDNS2TextBox.Name = "mbDNS2TextBox";
            mbDNS2TextBox.Size = new Size(125, 27);
            mbDNS2TextBox.TabIndex = 2;
            mbDNS2TextBox.Text = "8.8.4.4";
            // 
            // IPLabel
            // 
            IPLabel.AutoSize = true;
            IPLabel.Location = new Point(234, 54);
            IPLabel.Name = "IPLabel";
            IPLabel.Size = new Size(118, 20);
            IPLabel.TabIndex = 3;
            IPLabel.Text = "<- IP Address ->";
            // 
            // MaskLabel
            // 
            MaskLabel.AutoSize = true;
            MaskLabel.Location = new Point(227, 86);
            MaskLabel.Name = "MaskLabel";
            MaskLabel.Size = new Size(133, 20);
            MaskLabel.TabIndex = 3;
            MaskLabel.Text = "<- Subnet Mask ->";
            // 
            // GatewayLabel
            // 
            GatewayLabel.AutoSize = true;
            GatewayLabel.Location = new Point(216, 117);
            GatewayLabel.Name = "GatewayLabel";
            GatewayLabel.Size = new Size(159, 20);
            GatewayLabel.TabIndex = 3;
            GatewayLabel.Text = "<- Default Gateway ->";
            // 
            // DNS1Label
            // 
            DNS1Label.AutoSize = true;
            DNS1Label.Location = new Point(174, 218);
            DNS1Label.Name = "DNS1Label";
            DNS1Label.Size = new Size(47, 20);
            DNS1Label.TabIndex = 3;
            DNS1Label.Text = "DNS1";
            // 
            // DNS2Label
            // 
            DNS2Label.AutoSize = true;
            DNS2Label.Location = new Point(174, 251);
            DNS2Label.Name = "DNS2Label";
            DNS2Label.Size = new Size(47, 20);
            DNS2Label.TabIndex = 3;
            DNS2Label.Text = "DNS2";
            // 
            // ActiveACheckBox
            // 
            ActiveACheckBox.AutoSize = true;
            ActiveACheckBox.Checked = true;
            ActiveACheckBox.CheckState = CheckState.Checked;
            ActiveACheckBox.Location = new Point(12, 21);
            ActiveACheckBox.Name = "ActiveACheckBox";
            ActiveACheckBox.Size = new Size(41, 24);
            ActiveACheckBox.TabIndex = 4;
            ActiveACheckBox.Text = "A";
            ActiveACheckBox.UseVisualStyleBackColor = true;
            // 
            // ActiveBCheckBox
            // 
            ActiveBCheckBox.AutoSize = true;
            ActiveBCheckBox.Location = new Point(538, 21);
            ActiveBCheckBox.Name = "ActiveBCheckBox";
            ActiveBCheckBox.RightToLeft = RightToLeft.Yes;
            ActiveBCheckBox.Size = new Size(40, 24);
            ActiveBCheckBox.TabIndex = 4;
            ActiveBCheckBox.Text = "B";
            ActiveBCheckBox.TextAlign = ContentAlignment.TopLeft;
            ActiveBCheckBox.UseVisualStyleBackColor = true;
            // 
            // mbMaxPingTextBox
            // 
            mbMaxPingTextBox.Location = new Point(213, 335);
            mbMaxPingTextBox.Name = "mbMaxPingTextBox";
            mbMaxPingTextBox.Size = new Size(168, 27);
            mbMaxPingTextBox.TabIndex = 2;
            mbMaxPingTextBox.Text = "100";
            // 
            // MaxPingLabel
            // 
            MaxPingLabel.AutoSize = true;
            MaxPingLabel.Location = new Point(137, 338);
            MaxPingLabel.Name = "MaxPingLabel";
            MaxPingLabel.Size = new Size(70, 20);
            MaxPingLabel.TabIndex = 3;
            MaxPingLabel.Text = "Max Ping";
            // 
            // mbPingLogTextBox
            // 
            mbPingLogTextBox.Location = new Point(612, 48);
            mbPingLogTextBox.Multiline = true;
            mbPingLogTextBox.Name = "mbPingLogTextBox";
            mbPingLogTextBox.ReadOnly = true;
            mbPingLogTextBox.ScrollBars = ScrollBars.Both;
            mbPingLogTextBox.Size = new Size(332, 415);
            mbPingLogTextBox.TabIndex = 5;
            // 
            // mbButtonRun
            // 
            mbButtonRun.Location = new Point(12, 434);
            mbButtonRun.Name = "mbButtonRun";
            mbButtonRun.Size = new Size(94, 29);
            mbButtonRun.TabIndex = 7;
            mbButtonRun.Text = "Run";
            mbButtonRun.UseVisualStyleBackColor = true;
            // 
            // mbButtonStop
            // 
            mbButtonStop.Location = new Point(112, 434);
            mbButtonStop.Name = "mbButtonStop";
            mbButtonStop.Size = new Size(94, 29);
            mbButtonStop.TabIndex = 7;
            mbButtonStop.Text = "Stop";
            mbButtonStop.UseVisualStyleBackColor = true;
            // 
            // mbTestPingIntervalTextBox
            // 
            mbTestPingIntervalTextBox.Location = new Point(213, 302);
            mbTestPingIntervalTextBox.Name = "mbTestPingIntervalTextBox";
            mbTestPingIntervalTextBox.Size = new Size(168, 27);
            mbTestPingIntervalTextBox.TabIndex = 2;
            mbTestPingIntervalTextBox.Text = "1";
            // 
            // PingIntervalLabel
            // 
            PingIntervalLabel.AutoSize = true;
            PingIntervalLabel.Location = new Point(100, 305);
            PingIntervalLabel.Name = "PingIntervalLabel";
            PingIntervalLabel.Size = new Size(111, 20);
            PingIntervalLabel.TabIndex = 3;
            PingIntervalLabel.Text = "Ping Interval (s)";
            // 
            // mbTestPingRetryCountTextBox
            // 
            mbTestPingRetryCountTextBox.Location = new Point(213, 368);
            mbTestPingRetryCountTextBox.Name = "mbTestPingRetryCountTextBox";
            mbTestPingRetryCountTextBox.Size = new Size(168, 27);
            mbTestPingRetryCountTextBox.TabIndex = 2;
            mbTestPingRetryCountTextBox.Text = "3";
            // 
            // PingRetryCountLabel
            // 
            PingRetryCountLabel.AutoSize = true;
            PingRetryCountLabel.Location = new Point(88, 371);
            PingRetryCountLabel.Name = "PingRetryCountLabel";
            PingRetryCountLabel.Size = new Size(119, 20);
            PingRetryCountLabel.TabIndex = 3;
            PingRetryCountLabel.Text = "Ping Retry Count";
            // 
            // mbPingLogCheckBox
            // 
            mbPingLogCheckBox.AutoSize = true;
            mbPingLogCheckBox.Checked = true;
            mbPingLogCheckBox.CheckState = CheckState.Checked;
            mbPingLogCheckBox.Location = new Point(612, 21);
            mbPingLogCheckBox.Name = "mbPingLogCheckBox";
            mbPingLogCheckBox.Size = new Size(56, 24);
            mbPingLogCheckBox.TabIndex = 8;
            mbPingLogCheckBox.Text = "Log";
            mbPingLogCheckBox.UseVisualStyleBackColor = true;
            // 
            // mbRetryPbar
            // 
            mbRetryPbar.Location = new Point(387, 368);
            mbRetryPbar.Name = "mbRetryPbar";
            mbRetryPbar.Size = new Size(168, 27);
            mbRetryPbar.TabIndex = 9;
            // 
            // mbPingPbar
            // 
            mbPingPbar.Location = new Point(387, 335);
            mbPingPbar.Name = "mbPingPbar";
            mbPingPbar.Size = new Size(168, 27);
            mbPingPbar.TabIndex = 9;
            // 
            // checkBoxDhcpA
            // 
            checkBoxDhcpA.AutoSize = true;
            checkBoxDhcpA.Enabled = false;
            checkBoxDhcpA.Location = new Point(59, 21);
            checkBoxDhcpA.Name = "checkBoxDhcpA";
            checkBoxDhcpA.Size = new Size(70, 24);
            checkBoxDhcpA.TabIndex = 10;
            checkBoxDhcpA.Text = "DHCP";
            checkBoxDhcpA.UseVisualStyleBackColor = true;
            // 
            // checkBoxDhcpB
            // 
            checkBoxDhcpB.AutoSize = true;
            checkBoxDhcpB.Enabled = false;
            checkBoxDhcpB.Location = new Point(462, 21);
            checkBoxDhcpB.Name = "checkBoxDhcpB";
            checkBoxDhcpB.RightToLeft = RightToLeft.Yes;
            checkBoxDhcpB.Size = new Size(70, 24);
            checkBoxDhcpB.TabIndex = 10;
            checkBoxDhcpB.Text = "DHCP";
            checkBoxDhcpB.UseVisualStyleBackColor = true;
            // 
            // mbAlwaysOnTopCheckBox
            // 
            mbAlwaysOnTopCheckBox.AutoSize = true;
            mbAlwaysOnTopCheckBox.Checked = true;
            mbAlwaysOnTopCheckBox.CheckState = CheckState.Checked;
            mbAlwaysOnTopCheckBox.Location = new Point(316, 437);
            mbAlwaysOnTopCheckBox.Name = "mbAlwaysOnTopCheckBox";
            mbAlwaysOnTopCheckBox.Size = new Size(127, 24);
            mbAlwaysOnTopCheckBox.TabIndex = 11;
            mbAlwaysOnTopCheckBox.Text = "Always on Top";
            mbAlwaysOnTopCheckBox.UseVisualStyleBackColor = true;
            // 
            // mbAutoStartCheckBox
            // 
            mbAutoStartCheckBox.AutoSize = true;
            mbAutoStartCheckBox.Checked = true;
            mbAutoStartCheckBox.CheckState = CheckState.Checked;
            mbAutoStartCheckBox.Location = new Point(216, 437);
            mbAutoStartCheckBox.Name = "mbAutoStartCheckBox";
            mbAutoStartCheckBox.Size = new Size(94, 24);
            mbAutoStartCheckBox.TabIndex = 11;
            mbAutoStartCheckBox.Text = "AutoStart";
            mbAutoStartCheckBox.UseVisualStyleBackColor = true;
            // 
            // dummyLabelMin
            // 
            dummyLabelMin.AutoSize = true;
            dummyLabelMin.Enabled = false;
            dummyLabelMin.Location = new Point(387, 312);
            dummyLabelMin.Margin = new Padding(0);
            dummyLabelMin.Name = "dummyLabelMin";
            dummyLabelMin.Size = new Size(42, 20);
            dummyLabelMin.TabIndex = 12;
            dummyLabelMin.Text = "| min";
            // 
            // dummyLabelMax
            // 
            dummyLabelMax.AutoSize = true;
            dummyLabelMax.Enabled = false;
            dummyLabelMax.Location = new Point(510, 312);
            dummyLabelMax.Margin = new Padding(0);
            dummyLabelMax.Name = "dummyLabelMax";
            dummyLabelMax.Size = new Size(45, 20);
            dummyLabelMax.TabIndex = 12;
            dummyLabelMax.Text = "max |";
            // 
            // DeviceSelectDropDownA
            // 
            DeviceSelectDropDownA.FormattingEnabled = true;
            DeviceSelectDropDownA.Location = new Point(8, 150);
            DeviceSelectDropDownA.Name = "DeviceSelectDropDownA";
            DeviceSelectDropDownA.Size = new Size(199, 28);
            DeviceSelectDropDownA.TabIndex = 13;
            // 
            // DeviceSelectDropDownB
            // 
            DeviceSelectDropDownB.FormattingEnabled = true;
            DeviceSelectDropDownB.Location = new Point(381, 150);
            DeviceSelectDropDownB.Name = "DeviceSelectDropDownB";
            DeviceSelectDropDownB.Size = new Size(199, 28);
            DeviceSelectDropDownB.TabIndex = 13;
            // 
            // mbForm1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(956, 475);
            Controls.Add(DeviceSelectDropDownB);
            Controls.Add(DeviceSelectDropDownA);
            Controls.Add(dummyLabelMax);
            Controls.Add(dummyLabelMin);
            Controls.Add(mbAutoStartCheckBox);
            Controls.Add(mbAlwaysOnTopCheckBox);
            Controls.Add(checkBoxDhcpB);
            Controls.Add(checkBoxDhcpA);
            Controls.Add(mbPingPbar);
            Controls.Add(mbRetryPbar);
            Controls.Add(mbPingLogCheckBox);
            Controls.Add(mbButtonStop);
            Controls.Add(mbButtonRun);
            Controls.Add(mbPingLogTextBox);
            Controls.Add(ActiveBCheckBox);
            Controls.Add(ActiveACheckBox);
            Controls.Add(PingRetryCountLabel);
            Controls.Add(PingIntervalLabel);
            Controls.Add(MaxPingLabel);
            Controls.Add(DNS2Label);
            Controls.Add(DNS1Label);
            Controls.Add(GatewayLabel);
            Controls.Add(MaskLabel);
            Controls.Add(IPLabel);
            Controls.Add(mbTestPingRetryCountTextBox);
            Controls.Add(mbTestPingIntervalTextBox);
            Controls.Add(mbMaxPingTextBox);
            Controls.Add(mbDNS2TextBox);
            Controls.Add(mbDNS1TextBox);
            Controls.Add(mbGatewayTextBoxB);
            Controls.Add(mbGatewayTextBoxA);
            Controls.Add(mbMaskTextBoxB);
            Controls.Add(mbMaskTextBoxA);
            Controls.Add(mbIPTextBoxB);
            Controls.Add(mbIPTextBoxA);
            Name = "mbForm1";
            Text = "redunDancer";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox mbIPTextBoxA;
        private TextBox mbMaskTextBoxA;
        private TextBox mbGatewayTextBoxA;
        private TextBox mbIPTextBoxB;
        private TextBox mbMaskTextBoxB;
        private TextBox mbGatewayTextBoxB;
        private TextBox mbDNS1TextBox;
        private TextBox mbDNS2TextBox;
        private Label IPLabel;
        private Label MaskLabel;
        private Label GatewayLabel;
        private Label DNS1Label;
        private Label DNS2Label;
        private CheckBox ActiveACheckBox;
        private CheckBox ActiveBCheckBox;
        private TextBox mbMaxPingTextBox;
        private Label MaxPingLabel;
        private TextBox mbPingLogTextBox;
        private Button mbButtonRun;
        private Button mbButtonStop;
        private TextBox mbTestPingIntervalTextBox;
        private Label PingIntervalLabel;
        private TextBox mbTestPingRetryCountTextBox;
        private Label PingRetryCountLabel;
        private CheckBox mbPingLogCheckBox;
        private ProgressBar mbRetryPbar;
        private ProgressBar mbPingPbar;
        private CheckBox checkBoxDhcpA;
        private CheckBox checkBoxDhcpB;
        private CheckBox mbAlwaysOnTopCheckBox;
        private CheckBox mbAutoStartCheckBox;
        private Label dummyLabelMin;
        private Label dummyLabelMax;
        private ComboBox DeviceSelectDropDownA;
        private ComboBox DeviceSelectDropDownB;
    }
}
