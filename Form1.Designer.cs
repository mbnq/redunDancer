namespace redunDancer
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
            dummyLabelMin = new Label();
            dummyLabelMax = new Label();
            DeviceSelectDropDownA = new ComboBox();
            DeviceSelectDropDownB = new ComboBox();
            networkDevicesLabel = new Label();
            mbButtonSaveToFileAs = new Button();
            SuspendLayout();
            // 
            // mbIPTextBoxA
            // 
            mbIPTextBoxA.Location = new Point(8, 48);
            mbIPTextBoxA.MaxLength = 15;
            mbIPTextBoxA.Name = "mbIPTextBoxA";
            mbIPTextBoxA.Size = new Size(198, 27);
            mbIPTextBoxA.TabIndex = 1;
            mbIPTextBoxA.Text = "192.168.4.128";
            // 
            // mbMaskTextBoxA
            // 
            mbMaskTextBoxA.Location = new Point(8, 81);
            mbMaskTextBoxA.MaxLength = 15;
            mbMaskTextBoxA.Name = "mbMaskTextBoxA";
            mbMaskTextBoxA.Size = new Size(198, 27);
            mbMaskTextBoxA.TabIndex = 1;
            mbMaskTextBoxA.Text = "255.255.255.0";
            // 
            // mbGatewayTextBoxA
            // 
            mbGatewayTextBoxA.Location = new Point(8, 114);
            mbGatewayTextBoxA.MaxLength = 15;
            mbGatewayTextBoxA.Name = "mbGatewayTextBoxA";
            mbGatewayTextBoxA.Size = new Size(198, 27);
            mbGatewayTextBoxA.TabIndex = 1;
            mbGatewayTextBoxA.Text = "192.168.4.1";
            // 
            // mbIPTextBoxB
            // 
            mbIPTextBoxB.Location = new Point(380, 48);
            mbIPTextBoxB.MaxLength = 15;
            mbIPTextBoxB.Name = "mbIPTextBoxB";
            mbIPTextBoxB.Size = new Size(198, 27);
            mbIPTextBoxB.TabIndex = 1;
            // 
            // mbMaskTextBoxB
            // 
            mbMaskTextBoxB.Location = new Point(380, 81);
            mbMaskTextBoxB.MaxLength = 15;
            mbMaskTextBoxB.Name = "mbMaskTextBoxB";
            mbMaskTextBoxB.Size = new Size(198, 27);
            mbMaskTextBoxB.TabIndex = 1;
            // 
            // mbGatewayTextBoxB
            // 
            mbGatewayTextBoxB.Location = new Point(380, 114);
            mbGatewayTextBoxB.MaxLength = 15;
            mbGatewayTextBoxB.Name = "mbGatewayTextBoxB";
            mbGatewayTextBoxB.Size = new Size(198, 27);
            mbGatewayTextBoxB.TabIndex = 1;
            // 
            // mbDNS1TextBox
            // 
            mbDNS1TextBox.Location = new Point(227, 215);
            mbDNS1TextBox.MaxLength = 15;
            mbDNS1TextBox.Name = "mbDNS1TextBox";
            mbDNS1TextBox.Size = new Size(125, 27);
            mbDNS1TextBox.TabIndex = 2;
            mbDNS1TextBox.Text = "8.8.8.8";
            // 
            // mbDNS2TextBox
            // 
            mbDNS2TextBox.Location = new Point(227, 248);
            mbDNS2TextBox.MaxLength = 15;
            mbDNS2TextBox.Name = "mbDNS2TextBox";
            mbDNS2TextBox.Size = new Size(125, 27);
            mbDNS2TextBox.TabIndex = 2;
            mbDNS2TextBox.Text = "8.8.4.4";
            // 
            // IPLabel
            // 
            IPLabel.AutoSize = true;
            IPLabel.Location = new Point(234, 51);
            IPLabel.Name = "IPLabel";
            IPLabel.Size = new Size(118, 20);
            IPLabel.TabIndex = 3;
            IPLabel.Text = "<- IP Address ->";
            // 
            // MaskLabel
            // 
            MaskLabel.AutoSize = true;
            MaskLabel.Location = new Point(227, 84);
            MaskLabel.Name = "MaskLabel";
            MaskLabel.Size = new Size(133, 20);
            MaskLabel.TabIndex = 3;
            MaskLabel.Text = "<- Subnet Mask ->";
            // 
            // GatewayLabel
            // 
            GatewayLabel.AutoSize = true;
            GatewayLabel.Location = new Point(212, 117);
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
            ActiveBCheckBox.Location = new Point(539, 21);
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
            mbMaxPingTextBox.Location = new Point(206, 338);
            mbMaxPingTextBox.MaxLength = 3;
            mbMaxPingTextBox.Name = "mbMaxPingTextBox";
            mbMaxPingTextBox.Size = new Size(168, 27);
            mbMaxPingTextBox.TabIndex = 2;
            mbMaxPingTextBox.Text = "100";
            // 
            // MaxPingLabel
            // 
            MaxPingLabel.AutoSize = true;
            MaxPingLabel.Location = new Point(130, 341);
            MaxPingLabel.Name = "MaxPingLabel";
            MaxPingLabel.Size = new Size(70, 20);
            MaxPingLabel.TabIndex = 3;
            MaxPingLabel.Text = "Max Ping";
            // 
            // mbPingLogTextBox
            // 
            mbPingLogTextBox.BackColor = SystemColors.ActiveBorder;
            mbPingLogTextBox.Font = new Font("Lucida Console", 9F, FontStyle.Regular, GraphicsUnit.Point, 238);
            mbPingLogTextBox.ForeColor = Color.Black;
            mbPingLogTextBox.Location = new Point(587, 48);
            mbPingLogTextBox.Multiline = true;
            mbPingLogTextBox.Name = "mbPingLogTextBox";
            mbPingLogTextBox.ReadOnly = true;
            mbPingLogTextBox.ScrollBars = ScrollBars.Both;
            mbPingLogTextBox.Size = new Size(394, 415);
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
            mbButtonStop.Location = new Point(113, 434);
            mbButtonStop.Name = "mbButtonStop";
            mbButtonStop.Size = new Size(94, 29);
            mbButtonStop.TabIndex = 7;
            mbButtonStop.Text = "Stop";
            mbButtonStop.UseVisualStyleBackColor = true;
            // 
            // mbTestPingIntervalTextBox
            // 
            mbTestPingIntervalTextBox.Location = new Point(206, 305);
            mbTestPingIntervalTextBox.MaxLength = 4;
            mbTestPingIntervalTextBox.Name = "mbTestPingIntervalTextBox";
            mbTestPingIntervalTextBox.Size = new Size(168, 27);
            mbTestPingIntervalTextBox.TabIndex = 2;
            mbTestPingIntervalTextBox.Text = "1";
            // 
            // PingIntervalLabel
            // 
            PingIntervalLabel.AutoSize = true;
            PingIntervalLabel.Location = new Point(93, 308);
            PingIntervalLabel.Name = "PingIntervalLabel";
            PingIntervalLabel.Size = new Size(111, 20);
            PingIntervalLabel.TabIndex = 3;
            PingIntervalLabel.Text = "Ping Interval (s)";
            // 
            // mbTestPingRetryCountTextBox
            // 
            mbTestPingRetryCountTextBox.Location = new Point(206, 371);
            mbTestPingRetryCountTextBox.MaxLength = 3;
            mbTestPingRetryCountTextBox.Name = "mbTestPingRetryCountTextBox";
            mbTestPingRetryCountTextBox.Size = new Size(168, 27);
            mbTestPingRetryCountTextBox.TabIndex = 2;
            mbTestPingRetryCountTextBox.Text = "4";
            // 
            // PingRetryCountLabel
            // 
            PingRetryCountLabel.AutoSize = true;
            PingRetryCountLabel.Location = new Point(81, 374);
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
            mbPingLogCheckBox.Location = new Point(587, 21);
            mbPingLogCheckBox.Name = "mbPingLogCheckBox";
            mbPingLogCheckBox.Size = new Size(56, 24);
            mbPingLogCheckBox.TabIndex = 8;
            mbPingLogCheckBox.Text = "Log";
            mbPingLogCheckBox.UseVisualStyleBackColor = true;
            // 
            // mbRetryPbar
            // 
            mbRetryPbar.Location = new Point(380, 371);
            mbRetryPbar.Name = "mbRetryPbar";
            mbRetryPbar.Size = new Size(168, 27);
            mbRetryPbar.TabIndex = 9;
            // 
            // mbPingPbar
            // 
            mbPingPbar.Location = new Point(380, 338);
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
            checkBoxDhcpA.Size = new Size(108, 24);
            checkBoxDhcpA.TabIndex = 10;
            checkBoxDhcpA.Text = "From DHCP";
            checkBoxDhcpA.UseVisualStyleBackColor = true;
            // 
            // checkBoxDhcpB
            // 
            checkBoxDhcpB.AutoSize = true;
            checkBoxDhcpB.Enabled = false;
            checkBoxDhcpB.Location = new Point(425, 21);
            checkBoxDhcpB.Name = "checkBoxDhcpB";
            checkBoxDhcpB.RightToLeft = RightToLeft.Yes;
            checkBoxDhcpB.Size = new Size(108, 24);
            checkBoxDhcpB.TabIndex = 10;
            checkBoxDhcpB.Text = "From DHCP";
            checkBoxDhcpB.UseVisualStyleBackColor = true;
            // 
            // mbAlwaysOnTopCheckBox
            // 
            mbAlwaysOnTopCheckBox.AutoSize = true;
            mbAlwaysOnTopCheckBox.Checked = true;
            mbAlwaysOnTopCheckBox.CheckState = CheckState.Checked;
            mbAlwaysOnTopCheckBox.Location = new Point(225, 439);
            mbAlwaysOnTopCheckBox.Name = "mbAlwaysOnTopCheckBox";
            mbAlwaysOnTopCheckBox.Size = new Size(127, 24);
            mbAlwaysOnTopCheckBox.TabIndex = 11;
            mbAlwaysOnTopCheckBox.Text = "Always on Top";
            mbAlwaysOnTopCheckBox.UseVisualStyleBackColor = true;
            // 
            // dummyLabelMin
            // 
            dummyLabelMin.AutoSize = true;
            dummyLabelMin.Enabled = false;
            dummyLabelMin.Location = new Point(380, 315);
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
            dummyLabelMax.Location = new Point(503, 315);
            dummyLabelMax.Margin = new Padding(0);
            dummyLabelMax.Name = "dummyLabelMax";
            dummyLabelMax.Size = new Size(45, 20);
            dummyLabelMax.TabIndex = 12;
            dummyLabelMax.Text = "max |";
            // 
            // DeviceSelectDropDownA
            // 
            DeviceSelectDropDownA.DropDownStyle = ComboBoxStyle.DropDownList;
            DeviceSelectDropDownA.FormattingEnabled = true;
            DeviceSelectDropDownA.Location = new Point(8, 150);
            DeviceSelectDropDownA.Name = "DeviceSelectDropDownA";
            DeviceSelectDropDownA.Size = new Size(199, 28);
            DeviceSelectDropDownA.TabIndex = 13;
            // 
            // DeviceSelectDropDownB
            // 
            DeviceSelectDropDownB.DropDownStyle = ComboBoxStyle.DropDownList;
            DeviceSelectDropDownB.FormattingEnabled = true;
            DeviceSelectDropDownB.Location = new Point(380, 150);
            DeviceSelectDropDownB.Name = "DeviceSelectDropDownB";
            DeviceSelectDropDownB.Size = new Size(199, 28);
            DeviceSelectDropDownB.TabIndex = 13;
            // 
            // networkDevicesLabel
            // 
            networkDevicesLabel.AutoSize = true;
            networkDevicesLabel.Location = new Point(217, 153);
            networkDevicesLabel.Name = "networkDevicesLabel";
            networkDevicesLabel.Size = new Size(154, 20);
            networkDevicesLabel.TabIndex = 3;
            networkDevicesLabel.Text = "<- Network Device ->";
            // 
            // mbButtonSaveToFileAs
            // 
            mbButtonSaveToFileAs.Location = new Point(903, 12);
            mbButtonSaveToFileAs.Name = "mbButtonSaveToFileAs";
            mbButtonSaveToFileAs.Size = new Size(78, 30);
            mbButtonSaveToFileAs.TabIndex = 14;
            mbButtonSaveToFileAs.Text = "Save Log";
            mbButtonSaveToFileAs.UseVisualStyleBackColor = true;
            mbButtonSaveToFileAs.Click += mbButtonSaveToFileAs_Click;
            // 
            // mbForm1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveBorder;
            ClientSize = new Size(993, 475);
            Controls.Add(mbButtonSaveToFileAs);
            Controls.Add(DeviceSelectDropDownB);
            Controls.Add(DeviceSelectDropDownA);
            Controls.Add(dummyLabelMax);
            Controls.Add(dummyLabelMin);
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
            Controls.Add(networkDevicesLabel);
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
            Text = "redunDancer (mbnq.pl)";
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
        private Label dummyLabelMin;
        private Label dummyLabelMax;
        private ComboBox DeviceSelectDropDownA;
        private ComboBox DeviceSelectDropDownB;
        private Label networkDevicesLabel;
        private Button mbButtonSaveToFileAs;
    }
}
