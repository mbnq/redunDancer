namespace redunDancer
{
    partial class mbRedunDancerMain
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
            mbSaveButton = new Button();
            mbLoadButton = new Button();
            mbPingLogImportantOnlyCheckBox = new CheckBox();
            mbNotificationsCheckBox = new CheckBox();
            mbHideLogBoxButton = new Button();
            mbAutostartCheckbox = new CheckBox();
            SuspendLayout();
            // 
            // mbIPTextBoxA
            // 
            mbIPTextBoxA.BackColor = Color.White;
            mbIPTextBoxA.BorderStyle = BorderStyle.FixedSingle;
            mbIPTextBoxA.Location = new Point(17, 48);
            mbIPTextBoxA.MaxLength = 15;
            mbIPTextBoxA.Name = "mbIPTextBoxA";
            mbIPTextBoxA.Size = new Size(198, 27);
            mbIPTextBoxA.TabIndex = 1;
            mbIPTextBoxA.Text = "192.168.4.128";
            // 
            // mbMaskTextBoxA
            // 
            mbMaskTextBoxA.BackColor = Color.White;
            mbMaskTextBoxA.BorderStyle = BorderStyle.FixedSingle;
            mbMaskTextBoxA.Location = new Point(17, 81);
            mbMaskTextBoxA.MaxLength = 15;
            mbMaskTextBoxA.Name = "mbMaskTextBoxA";
            mbMaskTextBoxA.Size = new Size(198, 27);
            mbMaskTextBoxA.TabIndex = 1;
            mbMaskTextBoxA.Text = "255.255.255.0";
            // 
            // mbGatewayTextBoxA
            // 
            mbGatewayTextBoxA.BackColor = Color.White;
            mbGatewayTextBoxA.BorderStyle = BorderStyle.FixedSingle;
            mbGatewayTextBoxA.Location = new Point(17, 114);
            mbGatewayTextBoxA.MaxLength = 15;
            mbGatewayTextBoxA.Name = "mbGatewayTextBoxA";
            mbGatewayTextBoxA.Size = new Size(198, 27);
            mbGatewayTextBoxA.TabIndex = 1;
            mbGatewayTextBoxA.Text = "192.168.4.1";
            // 
            // mbIPTextBoxB
            // 
            mbIPTextBoxB.BackColor = Color.White;
            mbIPTextBoxB.BorderStyle = BorderStyle.FixedSingle;
            mbIPTextBoxB.Location = new Point(389, 48);
            mbIPTextBoxB.MaxLength = 15;
            mbIPTextBoxB.Name = "mbIPTextBoxB";
            mbIPTextBoxB.Size = new Size(198, 27);
            mbIPTextBoxB.TabIndex = 1;
            // 
            // mbMaskTextBoxB
            // 
            mbMaskTextBoxB.BackColor = Color.White;
            mbMaskTextBoxB.BorderStyle = BorderStyle.FixedSingle;
            mbMaskTextBoxB.Location = new Point(389, 81);
            mbMaskTextBoxB.MaxLength = 15;
            mbMaskTextBoxB.Name = "mbMaskTextBoxB";
            mbMaskTextBoxB.Size = new Size(198, 27);
            mbMaskTextBoxB.TabIndex = 1;
            // 
            // mbGatewayTextBoxB
            // 
            mbGatewayTextBoxB.BackColor = Color.White;
            mbGatewayTextBoxB.BorderStyle = BorderStyle.FixedSingle;
            mbGatewayTextBoxB.Location = new Point(389, 114);
            mbGatewayTextBoxB.MaxLength = 15;
            mbGatewayTextBoxB.Name = "mbGatewayTextBoxB";
            mbGatewayTextBoxB.Size = new Size(198, 27);
            mbGatewayTextBoxB.TabIndex = 1;
            // 
            // mbDNS1TextBox
            // 
            mbDNS1TextBox.BackColor = Color.White;
            mbDNS1TextBox.BorderStyle = BorderStyle.FixedSingle;
            mbDNS1TextBox.Location = new Point(17, 154);
            mbDNS1TextBox.MaxLength = 15;
            mbDNS1TextBox.Name = "mbDNS1TextBox";
            mbDNS1TextBox.Size = new Size(199, 27);
            mbDNS1TextBox.TabIndex = 2;
            mbDNS1TextBox.Text = "8.8.8.8";
            // 
            // mbDNS2TextBox
            // 
            mbDNS2TextBox.BackColor = Color.White;
            mbDNS2TextBox.BorderStyle = BorderStyle.FixedSingle;
            mbDNS2TextBox.Location = new Point(389, 154);
            mbDNS2TextBox.MaxLength = 15;
            mbDNS2TextBox.Name = "mbDNS2TextBox";
            mbDNS2TextBox.Size = new Size(199, 27);
            mbDNS2TextBox.TabIndex = 2;
            mbDNS2TextBox.Text = "8.8.4.4";
            // 
            // IPLabel
            // 
            IPLabel.AutoSize = true;
            IPLabel.BackColor = Color.Transparent;
            IPLabel.Font = new Font("Microsoft Sans Serif", 7.8F);
            IPLabel.Location = new Point(263, 53);
            IPLabel.Name = "IPLabel";
            IPLabel.Size = new Size(73, 16);
            IPLabel.TabIndex = 3;
            IPLabel.Text = "IP Address";
            // 
            // MaskLabel
            // 
            MaskLabel.AutoSize = true;
            MaskLabel.BackColor = Color.Transparent;
            MaskLabel.Font = new Font("Microsoft Sans Serif", 7.8F);
            MaskLabel.Location = new Point(259, 86);
            MaskLabel.Name = "MaskLabel";
            MaskLabel.Size = new Size(85, 16);
            MaskLabel.TabIndex = 3;
            MaskLabel.Text = "Subnet Mask";
            // 
            // GatewayLabel
            // 
            GatewayLabel.AutoSize = true;
            GatewayLabel.BackColor = Color.Transparent;
            GatewayLabel.Font = new Font("Microsoft Sans Serif", 7.8F);
            GatewayLabel.Location = new Point(250, 119);
            GatewayLabel.Name = "GatewayLabel";
            GatewayLabel.Size = new Size(105, 16);
            GatewayLabel.TabIndex = 3;
            GatewayLabel.Text = "Default Gateway";
            // 
            // DNS1Label
            // 
            DNS1Label.AutoSize = true;
            DNS1Label.BackColor = Color.Transparent;
            DNS1Label.Font = new Font("Microsoft Sans Serif", 7.8F);
            DNS1Label.Location = new Point(250, 159);
            DNS1Label.Name = "DNS1Label";
            DNS1Label.Size = new Size(101, 16);
            DNS1Label.TabIndex = 3;
            DNS1Label.Text = "DNS (Common)";
            // 
            // ActiveACheckBox
            // 
            ActiveACheckBox.AutoSize = true;
            ActiveACheckBox.BackColor = Color.Transparent;
            ActiveACheckBox.Checked = true;
            ActiveACheckBox.CheckState = CheckState.Checked;
            ActiveACheckBox.FlatStyle = FlatStyle.Flat;
            ActiveACheckBox.Location = new Point(17, 10);
            ActiveACheckBox.Name = "ActiveACheckBox";
            ActiveACheckBox.Size = new Size(37, 24);
            ActiveACheckBox.TabIndex = 4;
            ActiveACheckBox.Text = "A";
            ActiveACheckBox.UseVisualStyleBackColor = false;
            // 
            // ActiveBCheckBox
            // 
            ActiveBCheckBox.AutoSize = true;
            ActiveBCheckBox.BackColor = Color.Transparent;
            ActiveBCheckBox.FlatStyle = FlatStyle.Flat;
            ActiveBCheckBox.Location = new Point(549, 10);
            ActiveBCheckBox.Name = "ActiveBCheckBox";
            ActiveBCheckBox.RightToLeft = RightToLeft.Yes;
            ActiveBCheckBox.Size = new Size(36, 24);
            ActiveBCheckBox.TabIndex = 4;
            ActiveBCheckBox.Text = "B";
            ActiveBCheckBox.TextAlign = ContentAlignment.TopLeft;
            ActiveBCheckBox.UseVisualStyleBackColor = false;
            // 
            // mbMaxPingTextBox
            // 
            mbMaxPingTextBox.BackColor = Color.White;
            mbMaxPingTextBox.BorderStyle = BorderStyle.FixedSingle;
            mbMaxPingTextBox.Location = new Point(118, 322);
            mbMaxPingTextBox.MaxLength = 3;
            mbMaxPingTextBox.Name = "mbMaxPingTextBox";
            mbMaxPingTextBox.Size = new Size(49, 27);
            mbMaxPingTextBox.TabIndex = 2;
            mbMaxPingTextBox.Text = "100";
            // 
            // MaxPingLabel
            // 
            MaxPingLabel.AutoSize = true;
            MaxPingLabel.BackColor = Color.Transparent;
            MaxPingLabel.Font = new Font("Microsoft Sans Serif", 7.8F);
            MaxPingLabel.Location = new Point(50, 327);
            MaxPingLabel.Name = "MaxPingLabel";
            MaxPingLabel.Size = new Size(62, 16);
            MaxPingLabel.TabIndex = 3;
            MaxPingLabel.Text = "Max Ping";
            // 
            // mbPingLogTextBox
            // 
            mbPingLogTextBox.BackColor = SystemColors.ControlLight;
            mbPingLogTextBox.BorderStyle = BorderStyle.FixedSingle;
            mbPingLogTextBox.Font = new Font("Lucida Console", 9F, FontStyle.Regular, GraphicsUnit.Point, 238);
            mbPingLogTextBox.ForeColor = Color.Black;
            mbPingLogTextBox.Location = new Point(611, 48);
            mbPingLogTextBox.Multiline = true;
            mbPingLogTextBox.Name = "mbPingLogTextBox";
            mbPingLogTextBox.ReadOnly = true;
            mbPingLogTextBox.ScrollBars = ScrollBars.Both;
            mbPingLogTextBox.Size = new Size(359, 445);
            mbPingLogTextBox.TabIndex = 5;
            // 
            // mbButtonRun
            // 
            mbButtonRun.BackColor = Color.Transparent;
            mbButtonRun.FlatStyle = FlatStyle.Flat;
            mbButtonRun.Font = new Font("Microsoft Sans Serif", 7.8F);
            mbButtonRun.Location = new Point(17, 462);
            mbButtonRun.Name = "mbButtonRun";
            mbButtonRun.Size = new Size(94, 32);
            mbButtonRun.TabIndex = 7;
            mbButtonRun.Text = "Run";
            mbButtonRun.UseVisualStyleBackColor = false;
            // 
            // mbButtonStop
            // 
            mbButtonStop.BackColor = Color.Transparent;
            mbButtonStop.FlatStyle = FlatStyle.Flat;
            mbButtonStop.Font = new Font("Microsoft Sans Serif", 7.8F);
            mbButtonStop.Location = new Point(118, 462);
            mbButtonStop.Name = "mbButtonStop";
            mbButtonStop.Size = new Size(94, 32);
            mbButtonStop.TabIndex = 7;
            mbButtonStop.Text = "Stop";
            mbButtonStop.UseVisualStyleBackColor = false;
            // 
            // mbTestPingIntervalTextBox
            // 
            mbTestPingIntervalTextBox.BackColor = Color.White;
            mbTestPingIntervalTextBox.BorderStyle = BorderStyle.FixedSingle;
            mbTestPingIntervalTextBox.Location = new Point(118, 285);
            mbTestPingIntervalTextBox.MaxLength = 4;
            mbTestPingIntervalTextBox.Name = "mbTestPingIntervalTextBox";
            mbTestPingIntervalTextBox.Size = new Size(49, 27);
            mbTestPingIntervalTextBox.TabIndex = 2;
            mbTestPingIntervalTextBox.Text = "1";
            // 
            // PingIntervalLabel
            // 
            PingIntervalLabel.AutoSize = true;
            PingIntervalLabel.BackColor = Color.Transparent;
            PingIntervalLabel.Font = new Font("Microsoft Sans Serif", 7.8F);
            PingIntervalLabel.Location = new Point(14, 290);
            PingIntervalLabel.Name = "PingIntervalLabel";
            PingIntervalLabel.Size = new Size(98, 16);
            PingIntervalLabel.TabIndex = 3;
            PingIntervalLabel.Text = "Ping Interval (s)";
            // 
            // mbTestPingRetryCountTextBox
            // 
            mbTestPingRetryCountTextBox.BackColor = Color.White;
            mbTestPingRetryCountTextBox.BorderStyle = BorderStyle.FixedSingle;
            mbTestPingRetryCountTextBox.Location = new Point(118, 360);
            mbTestPingRetryCountTextBox.MaxLength = 3;
            mbTestPingRetryCountTextBox.Name = "mbTestPingRetryCountTextBox";
            mbTestPingRetryCountTextBox.Size = new Size(49, 27);
            mbTestPingRetryCountTextBox.TabIndex = 2;
            mbTestPingRetryCountTextBox.Text = "4";
            // 
            // PingRetryCountLabel
            // 
            PingRetryCountLabel.AutoSize = true;
            PingRetryCountLabel.BackColor = Color.Transparent;
            PingRetryCountLabel.Font = new Font("Microsoft Sans Serif", 7.8F);
            PingRetryCountLabel.Location = new Point(6, 365);
            PingRetryCountLabel.Name = "PingRetryCountLabel";
            PingRetryCountLabel.Size = new Size(106, 16);
            PingRetryCountLabel.TabIndex = 3;
            PingRetryCountLabel.Text = "Ping Retry Count";
            // 
            // mbPingLogCheckBox
            // 
            mbPingLogCheckBox.AutoSize = true;
            mbPingLogCheckBox.BackColor = Color.Transparent;
            mbPingLogCheckBox.Checked = true;
            mbPingLogCheckBox.CheckState = CheckState.Checked;
            mbPingLogCheckBox.FlatStyle = FlatStyle.Flat;
            mbPingLogCheckBox.Font = new Font("Microsoft Sans Serif", 7.8F);
            mbPingLogCheckBox.Location = new Point(611, 17);
            mbPingLogCheckBox.Name = "mbPingLogCheckBox";
            mbPingLogCheckBox.Size = new Size(48, 20);
            mbPingLogCheckBox.TabIndex = 8;
            mbPingLogCheckBox.Text = "Log";
            mbPingLogCheckBox.UseVisualStyleBackColor = false;
            // 
            // mbRetryPbar
            // 
            mbRetryPbar.ForeColor = Color.Red;
            mbRetryPbar.Location = new Point(200, 360);
            mbRetryPbar.Name = "mbRetryPbar";
            mbRetryPbar.Size = new Size(386, 27);
            mbRetryPbar.TabIndex = 9;
            // 
            // mbPingPbar
            // 
            mbPingPbar.Location = new Point(200, 322);
            mbPingPbar.Name = "mbPingPbar";
            mbPingPbar.Size = new Size(386, 27);
            mbPingPbar.TabIndex = 9;
            // 
            // checkBoxDhcpA
            // 
            checkBoxDhcpA.AutoSize = true;
            checkBoxDhcpA.BackColor = Color.Transparent;
            checkBoxDhcpA.Enabled = false;
            checkBoxDhcpA.FlatStyle = FlatStyle.Flat;
            checkBoxDhcpA.Font = new Font("Microsoft Sans Serif", 7.8F);
            checkBoxDhcpA.Location = new Point(153, 19);
            checkBoxDhcpA.Name = "checkBoxDhcpA";
            checkBoxDhcpA.Size = new Size(63, 20);
            checkBoxDhcpA.TabIndex = 10;
            checkBoxDhcpA.Text = "DHCP";
            checkBoxDhcpA.UseVisualStyleBackColor = false;
            // 
            // checkBoxDhcpB
            // 
            checkBoxDhcpB.AutoSize = true;
            checkBoxDhcpB.BackColor = Color.Transparent;
            checkBoxDhcpB.Enabled = false;
            checkBoxDhcpB.FlatStyle = FlatStyle.Flat;
            checkBoxDhcpB.Font = new Font("Microsoft Sans Serif", 7.8F);
            checkBoxDhcpB.Location = new Point(389, 20);
            checkBoxDhcpB.Name = "checkBoxDhcpB";
            checkBoxDhcpB.RightToLeft = RightToLeft.Yes;
            checkBoxDhcpB.Size = new Size(63, 20);
            checkBoxDhcpB.TabIndex = 10;
            checkBoxDhcpB.Text = "DHCP";
            checkBoxDhcpB.UseVisualStyleBackColor = false;
            // 
            // mbAlwaysOnTopCheckBox
            // 
            mbAlwaysOnTopCheckBox.AutoSize = true;
            mbAlwaysOnTopCheckBox.BackColor = Color.Transparent;
            mbAlwaysOnTopCheckBox.Checked = true;
            mbAlwaysOnTopCheckBox.CheckState = CheckState.Checked;
            mbAlwaysOnTopCheckBox.FlatAppearance.CheckedBackColor = Color.Transparent;
            mbAlwaysOnTopCheckBox.FlatStyle = FlatStyle.Flat;
            mbAlwaysOnTopCheckBox.Font = new Font("Microsoft Sans Serif", 7.8F);
            mbAlwaysOnTopCheckBox.Location = new Point(118, 432);
            mbAlwaysOnTopCheckBox.Name = "mbAlwaysOnTopCheckBox";
            mbAlwaysOnTopCheckBox.Size = new Size(114, 20);
            mbAlwaysOnTopCheckBox.TabIndex = 11;
            mbAlwaysOnTopCheckBox.Text = "Always on Top";
            mbAlwaysOnTopCheckBox.UseVisualStyleBackColor = false;
            mbAlwaysOnTopCheckBox.CheckedChanged += mbAlwaysOnTopCheckBox_CheckedChanged;
            // 
            // dummyLabelMin
            // 
            dummyLabelMin.AutoSize = true;
            dummyLabelMin.Enabled = false;
            dummyLabelMin.Font = new Font("Microsoft Sans Serif", 7.8F);
            dummyLabelMin.Location = new Point(200, 296);
            dummyLabelMin.Margin = new Padding(0);
            dummyLabelMin.Name = "dummyLabelMin";
            dummyLabelMin.Size = new Size(34, 16);
            dummyLabelMin.TabIndex = 12;
            dummyLabelMin.Text = "| min";
            // 
            // dummyLabelMax
            // 
            dummyLabelMax.AutoSize = true;
            dummyLabelMax.Enabled = false;
            dummyLabelMax.Font = new Font("Microsoft Sans Serif", 7.8F);
            dummyLabelMax.Location = new Point(549, 296);
            dummyLabelMax.Margin = new Padding(0);
            dummyLabelMax.Name = "dummyLabelMax";
            dummyLabelMax.Size = new Size(38, 16);
            dummyLabelMax.TabIndex = 12;
            dummyLabelMax.Text = "max |";
            // 
            // DeviceSelectDropDownA
            // 
            DeviceSelectDropDownA.DropDownStyle = ComboBoxStyle.DropDownList;
            DeviceSelectDropDownA.FormattingEnabled = true;
            DeviceSelectDropDownA.Location = new Point(17, 193);
            DeviceSelectDropDownA.Name = "DeviceSelectDropDownA";
            DeviceSelectDropDownA.Size = new Size(199, 28);
            DeviceSelectDropDownA.TabIndex = 13;
            // 
            // DeviceSelectDropDownB
            // 
            DeviceSelectDropDownB.DropDownStyle = ComboBoxStyle.DropDownList;
            DeviceSelectDropDownB.FormattingEnabled = true;
            DeviceSelectDropDownB.Location = new Point(389, 193);
            DeviceSelectDropDownB.Name = "DeviceSelectDropDownB";
            DeviceSelectDropDownB.Size = new Size(199, 28);
            DeviceSelectDropDownB.TabIndex = 13;
            // 
            // networkDevicesLabel
            // 
            networkDevicesLabel.AutoSize = true;
            networkDevicesLabel.BackColor = Color.Transparent;
            networkDevicesLabel.Font = new Font("Microsoft Sans Serif", 7.8F);
            networkDevicesLabel.Location = new Point(253, 199);
            networkDevicesLabel.Name = "networkDevicesLabel";
            networkDevicesLabel.Size = new Size(102, 16);
            networkDevicesLabel.TabIndex = 3;
            networkDevicesLabel.Text = "Network Device";
            // 
            // mbButtonSaveToFileAs
            // 
            mbButtonSaveToFileAs.BackColor = Color.Transparent;
            mbButtonSaveToFileAs.FlatStyle = FlatStyle.Flat;
            mbButtonSaveToFileAs.Font = new Font("Microsoft Sans Serif", 7.8F);
            mbButtonSaveToFileAs.Location = new Point(876, 10);
            mbButtonSaveToFileAs.Name = "mbButtonSaveToFileAs";
            mbButtonSaveToFileAs.Size = new Size(94, 32);
            mbButtonSaveToFileAs.TabIndex = 14;
            mbButtonSaveToFileAs.Text = "Save Log";
            mbButtonSaveToFileAs.UseVisualStyleBackColor = false;
            mbButtonSaveToFileAs.Click += mbButtonSaveToFileAs_Click;
            // 
            // mbSaveButton
            // 
            mbSaveButton.BackColor = Color.Transparent;
            mbSaveButton.FlatStyle = FlatStyle.Flat;
            mbSaveButton.Font = new Font("Microsoft Sans Serif", 7.8F);
            mbSaveButton.Location = new Point(492, 462);
            mbSaveButton.Name = "mbSaveButton";
            mbSaveButton.Size = new Size(94, 32);
            mbSaveButton.TabIndex = 15;
            mbSaveButton.Text = "Save";
            mbSaveButton.UseVisualStyleBackColor = false;
            mbSaveButton.Click += mbSaveButton_Click;
            // 
            // mbLoadButton
            // 
            mbLoadButton.BackColor = Color.Transparent;
            mbLoadButton.FlatStyle = FlatStyle.Flat;
            mbLoadButton.Font = new Font("Microsoft Sans Serif", 7.8F);
            mbLoadButton.Location = new Point(392, 462);
            mbLoadButton.Name = "mbLoadButton";
            mbLoadButton.Size = new Size(94, 32);
            mbLoadButton.TabIndex = 15;
            mbLoadButton.Text = "Load";
            mbLoadButton.UseVisualStyleBackColor = false;
            mbLoadButton.Click += mbLoadButton_Click;
            // 
            // mbPingLogImportantOnlyCheckBox
            // 
            mbPingLogImportantOnlyCheckBox.AutoSize = true;
            mbPingLogImportantOnlyCheckBox.BackColor = Color.Transparent;
            mbPingLogImportantOnlyCheckBox.FlatStyle = FlatStyle.Flat;
            mbPingLogImportantOnlyCheckBox.Font = new Font("Microsoft Sans Serif", 7.8F);
            mbPingLogImportantOnlyCheckBox.Location = new Point(665, 17);
            mbPingLogImportantOnlyCheckBox.Name = "mbPingLogImportantOnlyCheckBox";
            mbPingLogImportantOnlyCheckBox.Size = new Size(110, 20);
            mbPingLogImportantOnlyCheckBox.TabIndex = 8;
            mbPingLogImportantOnlyCheckBox.Text = "Important Only";
            mbPingLogImportantOnlyCheckBox.UseVisualStyleBackColor = false;
            mbPingLogImportantOnlyCheckBox.CheckedChanged += mbPingLogImportantOnlyCheckBox_CheckedChanged;
            // 
            // mbNotificationsCheckBox
            // 
            mbNotificationsCheckBox.AutoSize = true;
            mbNotificationsCheckBox.BackColor = Color.Transparent;
            mbNotificationsCheckBox.Checked = true;
            mbNotificationsCheckBox.CheckState = CheckState.Checked;
            mbNotificationsCheckBox.FlatAppearance.CheckedBackColor = Color.Transparent;
            mbNotificationsCheckBox.FlatStyle = FlatStyle.Flat;
            mbNotificationsCheckBox.Font = new Font("Microsoft Sans Serif", 7.8F);
            mbNotificationsCheckBox.Location = new Point(238, 432);
            mbNotificationsCheckBox.Name = "mbNotificationsCheckBox";
            mbNotificationsCheckBox.Size = new Size(98, 20);
            mbNotificationsCheckBox.TabIndex = 18;
            mbNotificationsCheckBox.Text = "Notifications";
            mbNotificationsCheckBox.UseVisualStyleBackColor = false;
            mbNotificationsCheckBox.CheckedChanged += mbNotificationsCheckBox_CheckedChanged;
            // 
            // mbHideLogBoxButton
            // 
            mbHideLogBoxButton.BackColor = Color.Transparent;
            mbHideLogBoxButton.FlatStyle = FlatStyle.Flat;
            mbHideLogBoxButton.Font = new Font("Arial", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 238);
            mbHideLogBoxButton.Location = new Point(552, 245);
            mbHideLogBoxButton.Name = "mbHideLogBoxButton";
            mbHideLogBoxButton.Size = new Size(39, 29);
            mbHideLogBoxButton.TabIndex = 19;
            mbHideLogBoxButton.Text = "<<";
            mbHideLogBoxButton.UseVisualStyleBackColor = false;
            mbHideLogBoxButton.Click += mbHideLogBoxButton_Click;
            // 
            // mbAutostartCheckbox
            // 
            mbAutostartCheckbox.AutoSize = true;
            mbAutostartCheckbox.BackColor = Color.Transparent;
            mbAutostartCheckbox.FlatAppearance.CheckedBackColor = Color.Transparent;
            mbAutostartCheckbox.FlatStyle = FlatStyle.Flat;
            mbAutostartCheckbox.Font = new Font("Microsoft Sans Serif", 7.8F);
            mbAutostartCheckbox.Location = new Point(17, 432);
            mbAutostartCheckbox.Name = "mbAutostartCheckbox";
            mbAutostartCheckbox.Size = new Size(89, 20);
            mbAutostartCheckbox.TabIndex = 21;
            mbAutostartCheckbox.Text = "Start on Init";
            mbAutostartCheckbox.UseVisualStyleBackColor = false;
            // 
            // mbRedunDancerMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(982, 503);
            Controls.Add(mbAutostartCheckbox);
            Controls.Add(mbHideLogBoxButton);
            Controls.Add(mbNotificationsCheckBox);
            Controls.Add(mbLoadButton);
            Controls.Add(mbSaveButton);
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
            Controls.Add(mbPingLogImportantOnlyCheckBox);
            Controls.Add(mbPingLogCheckBox);
            Controls.Add(mbButtonStop);
            Controls.Add(mbButtonRun);
            Controls.Add(mbPingLogTextBox);
            Controls.Add(ActiveBCheckBox);
            Controls.Add(ActiveACheckBox);
            Controls.Add(PingRetryCountLabel);
            Controls.Add(PingIntervalLabel);
            Controls.Add(MaxPingLabel);
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
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "mbRedunDancerMain";
            SizeGripStyle = SizeGripStyle.Hide;
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
        private Button mbSaveButton;
        private Button mbLoadButton;
        private CheckBox mbPingLogImportantOnlyCheckBox;
        private CheckBox mbNotificationsCheckBox;
        private Button mbHideLogBoxButton;
        private CheckBox mbAutostartCheckbox;
    }
}
