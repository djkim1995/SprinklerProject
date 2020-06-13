namespace SprinklerProject
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.tbInfo = new System.Windows.Forms.TextBox();
            this.rbtnGrayScale = new System.Windows.Forms.RadioButton();
            this.rbtnRGB = new System.Windows.Forms.RadioButton();
            this.rbtnBinary = new System.Windows.Forms.RadioButton();
            this.gbSettings = new System.Windows.Forms.GroupBox();
            this.cbHotColor = new System.Windows.Forms.ComboBox();
            this.lblHotColor = new System.Windows.Forms.Label();
            this.cbTLinearEnable = new System.Windows.Forms.ComboBox();
            this.lblTLinearEnable = new System.Windows.Forms.Label();
            this.cbRadEnable = new System.Windows.Forms.ComboBox();
            this.lblRadEnable = new System.Windows.Forms.Label();
            this.cbAgcCalcEnable = new System.Windows.Forms.ComboBox();
            this.lblAgcCalcEnable = new System.Windows.Forms.Label();
            this.cbAgcEnable = new System.Windows.Forms.ComboBox();
            this.lblAgcEnable = new System.Windows.Forms.Label();
            this.cbGainMode = new System.Windows.Forms.ComboBox();
            this.lblGainMode = new System.Windows.Forms.Label();
            this.cbFormat = new System.Windows.Forms.ComboBox();
            this.lblFormat = new System.Windows.Forms.Label();
            this.btnGainModeObj = new System.Windows.Forms.Button();
            this.gbTemperature = new System.Windows.Forms.GroupBox();
            this.tbMaxTemp = new System.Windows.Forms.TextBox();
            this.tbAvgTemp = new System.Windows.Forms.TextBox();
            this.tbMinTemp = new System.Windows.Forms.TextBox();
            this.lblMaxTemp = new System.Windows.Forms.Label();
            this.lblAvgTemp = new System.Windows.Forms.Label();
            this.lblMinTemp = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.SerialPort = new System.IO.Ports.SerialPort(this.components);
            this.Tab_MAIN = new System.Windows.Forms.TabControl();
            this.camPage = new System.Windows.Forms.TabPage();
            this.btnOpen = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.portPage = new System.Windows.Forms.TabPage();
            this.btnGetPort = new System.Windows.Forms.Button();
            this.cbCom = new System.Windows.Forms.ComboBox();
            this.lblCom = new System.Windows.Forms.Label();
            this.btnPortTab = new System.Windows.Forms.Button();
            this.btnCamTab = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.gbSettings.SuspendLayout();
            this.gbTemperature.SuspendLayout();
            this.Tab_MAIN.SuspendLayout();
            this.camPage.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.portPage.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(208, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(640, 488);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(107, 446);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(95, 48);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // tbInfo
            // 
            this.tbInfo.BackColor = System.Drawing.SystemColors.Window;
            this.tbInfo.Location = new System.Drawing.Point(6, 6);
            this.tbInfo.Multiline = true;
            this.tbInfo.Name = "tbInfo";
            this.tbInfo.ReadOnly = true;
            this.tbInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbInfo.Size = new System.Drawing.Size(196, 134);
            this.tbInfo.TabIndex = 2;
            // 
            // rbtnGrayScale
            // 
            this.rbtnGrayScale.AutoSize = true;
            this.rbtnGrayScale.Checked = true;
            this.rbtnGrayScale.Location = new System.Drawing.Point(13, 421);
            this.rbtnGrayScale.Name = "rbtnGrayScale";
            this.rbtnGrayScale.Size = new System.Drawing.Size(82, 16);
            this.rbtnGrayScale.TabIndex = 6;
            this.rbtnGrayScale.TabStop = true;
            this.rbtnGrayScale.Text = "GrayScale";
            this.rbtnGrayScale.UseVisualStyleBackColor = true;
            this.rbtnGrayScale.CheckedChanged += new System.EventHandler(this.rbtnGrayScale_CheckedChanged);
            // 
            // rbtnRGB
            // 
            this.rbtnRGB.AutoSize = true;
            this.rbtnRGB.Location = new System.Drawing.Point(116, 421);
            this.rbtnRGB.Name = "rbtnRGB";
            this.rbtnRGB.Size = new System.Drawing.Size(48, 16);
            this.rbtnRGB.TabIndex = 7;
            this.rbtnRGB.Text = "RGB";
            this.rbtnRGB.UseVisualStyleBackColor = true;
            this.rbtnRGB.CheckedChanged += new System.EventHandler(this.rbtnRGB_CheckedChanged);
            // 
            // rbtnBinary
            // 
            this.rbtnBinary.AutoSize = true;
            this.rbtnBinary.Location = new System.Drawing.Point(13, 399);
            this.rbtnBinary.Name = "rbtnBinary";
            this.rbtnBinary.Size = new System.Drawing.Size(91, 16);
            this.rbtnBinary.TabIndex = 8;
            this.rbtnBinary.Text = "BinaryScale";
            this.rbtnBinary.UseVisualStyleBackColor = true;
            this.rbtnBinary.CheckedChanged += new System.EventHandler(this.rbtnBinary_CheckedChanged);
            // 
            // gbSettings
            // 
            this.gbSettings.Controls.Add(this.cbHotColor);
            this.gbSettings.Controls.Add(this.lblHotColor);
            this.gbSettings.Controls.Add(this.cbTLinearEnable);
            this.gbSettings.Controls.Add(this.lblTLinearEnable);
            this.gbSettings.Controls.Add(this.cbRadEnable);
            this.gbSettings.Controls.Add(this.lblRadEnable);
            this.gbSettings.Controls.Add(this.cbAgcCalcEnable);
            this.gbSettings.Controls.Add(this.lblAgcCalcEnable);
            this.gbSettings.Controls.Add(this.cbAgcEnable);
            this.gbSettings.Controls.Add(this.lblAgcEnable);
            this.gbSettings.Controls.Add(this.cbGainMode);
            this.gbSettings.Controls.Add(this.lblGainMode);
            this.gbSettings.Controls.Add(this.cbFormat);
            this.gbSettings.Controls.Add(this.lblFormat);
            this.gbSettings.Location = new System.Drawing.Point(6, 146);
            this.gbSettings.Name = "gbSettings";
            this.gbSettings.Size = new System.Drawing.Size(196, 250);
            this.gbSettings.TabIndex = 9;
            this.gbSettings.TabStop = false;
            this.gbSettings.Text = "Settings";
            // 
            // cbHotColor
            // 
            this.cbHotColor.FormattingEnabled = true;
            this.cbHotColor.Items.AddRange(new object[] {
            "BLACK",
            "WHITE"});
            this.cbHotColor.Location = new System.Drawing.Point(106, 176);
            this.cbHotColor.Name = "cbHotColor";
            this.cbHotColor.Size = new System.Drawing.Size(84, 20);
            this.cbHotColor.TabIndex = 13;
            this.cbHotColor.SelectedIndexChanged += new System.EventHandler(this.cbHotColor_SelectedIndexChanged);
            // 
            // lblHotColor
            // 
            this.lblHotColor.AutoSize = true;
            this.lblHotColor.Location = new System.Drawing.Point(8, 179);
            this.lblHotColor.Name = "lblHotColor";
            this.lblHotColor.Size = new System.Drawing.Size(53, 12);
            this.lblHotColor.TabIndex = 12;
            this.lblHotColor.Text = "HotColor";
            // 
            // cbTLinearEnable
            // 
            this.cbTLinearEnable.FormattingEnabled = true;
            this.cbTLinearEnable.Items.AddRange(new object[] {
            "DISABLE",
            "ENABLE"});
            this.cbTLinearEnable.Location = new System.Drawing.Point(106, 150);
            this.cbTLinearEnable.Name = "cbTLinearEnable";
            this.cbTLinearEnable.Size = new System.Drawing.Size(84, 20);
            this.cbTLinearEnable.TabIndex = 11;
            this.cbTLinearEnable.SelectedIndexChanged += new System.EventHandler(this.cbTLinearEnable_SelectedIndexChanged);
            // 
            // lblTLinearEnable
            // 
            this.lblTLinearEnable.AutoSize = true;
            this.lblTLinearEnable.Location = new System.Drawing.Point(8, 153);
            this.lblTLinearEnable.Name = "lblTLinearEnable";
            this.lblTLinearEnable.Size = new System.Drawing.Size(87, 12);
            this.lblTLinearEnable.TabIndex = 10;
            this.lblTLinearEnable.Text = "TLinearEnable";
            // 
            // cbRadEnable
            // 
            this.cbRadEnable.FormattingEnabled = true;
            this.cbRadEnable.Items.AddRange(new object[] {
            "DISABLE",
            "ENABLE"});
            this.cbRadEnable.Location = new System.Drawing.Point(106, 124);
            this.cbRadEnable.Name = "cbRadEnable";
            this.cbRadEnable.Size = new System.Drawing.Size(84, 20);
            this.cbRadEnable.TabIndex = 9;
            this.cbRadEnable.SelectedIndexChanged += new System.EventHandler(this.cbRadEnable_SelectedIndexChanged);
            // 
            // lblRadEnable
            // 
            this.lblRadEnable.AutoSize = true;
            this.lblRadEnable.Location = new System.Drawing.Point(8, 127);
            this.lblRadEnable.Name = "lblRadEnable";
            this.lblRadEnable.Size = new System.Drawing.Size(66, 12);
            this.lblRadEnable.TabIndex = 8;
            this.lblRadEnable.Text = "RadEnable";
            // 
            // cbAgcCalcEnable
            // 
            this.cbAgcCalcEnable.FormattingEnabled = true;
            this.cbAgcCalcEnable.Items.AddRange(new object[] {
            "DISABLE",
            "ENABLE"});
            this.cbAgcCalcEnable.Location = new System.Drawing.Point(106, 98);
            this.cbAgcCalcEnable.Name = "cbAgcCalcEnable";
            this.cbAgcCalcEnable.Size = new System.Drawing.Size(84, 20);
            this.cbAgcCalcEnable.TabIndex = 7;
            this.cbAgcCalcEnable.SelectedIndexChanged += new System.EventHandler(this.cbAgcCalcEnable_SelectedIndexChanged);
            // 
            // lblAgcCalcEnable
            // 
            this.lblAgcCalcEnable.AutoSize = true;
            this.lblAgcCalcEnable.Location = new System.Drawing.Point(8, 101);
            this.lblAgcCalcEnable.Name = "lblAgcCalcEnable";
            this.lblAgcCalcEnable.Size = new System.Drawing.Size(92, 12);
            this.lblAgcCalcEnable.TabIndex = 6;
            this.lblAgcCalcEnable.Text = "AgcCalcEnable";
            // 
            // cbAgcEnable
            // 
            this.cbAgcEnable.FormattingEnabled = true;
            this.cbAgcEnable.Items.AddRange(new object[] {
            "DISABLE",
            "ENABLE"});
            this.cbAgcEnable.Location = new System.Drawing.Point(106, 72);
            this.cbAgcEnable.Name = "cbAgcEnable";
            this.cbAgcEnable.Size = new System.Drawing.Size(84, 20);
            this.cbAgcEnable.TabIndex = 5;
            this.cbAgcEnable.SelectedIndexChanged += new System.EventHandler(this.cbAgcEnable_SelectedIndexChanged);
            // 
            // lblAgcEnable
            // 
            this.lblAgcEnable.AutoSize = true;
            this.lblAgcEnable.Location = new System.Drawing.Point(8, 75);
            this.lblAgcEnable.Name = "lblAgcEnable";
            this.lblAgcEnable.Size = new System.Drawing.Size(66, 12);
            this.lblAgcEnable.TabIndex = 4;
            this.lblAgcEnable.Text = "AgcEnable";
            // 
            // cbGainMode
            // 
            this.cbGainMode.FormattingEnabled = true;
            this.cbGainMode.Items.AddRange(new object[] {
            "LOW",
            "HIGH"});
            this.cbGainMode.Location = new System.Drawing.Point(106, 46);
            this.cbGainMode.Name = "cbGainMode";
            this.cbGainMode.Size = new System.Drawing.Size(84, 20);
            this.cbGainMode.TabIndex = 3;
            this.cbGainMode.SelectedIndexChanged += new System.EventHandler(this.cbGainMode_SelectedIndexChanged);
            // 
            // lblGainMode
            // 
            this.lblGainMode.AutoSize = true;
            this.lblGainMode.Location = new System.Drawing.Point(8, 49);
            this.lblGainMode.Name = "lblGainMode";
            this.lblGainMode.Size = new System.Drawing.Size(63, 12);
            this.lblGainMode.TabIndex = 2;
            this.lblGainMode.Text = "GainMode";
            // 
            // cbFormat
            // 
            this.cbFormat.FormattingEnabled = true;
            this.cbFormat.Items.AddRange(new object[] {
            "RAW14",
            "RGB888"});
            this.cbFormat.Location = new System.Drawing.Point(106, 20);
            this.cbFormat.Name = "cbFormat";
            this.cbFormat.Size = new System.Drawing.Size(84, 20);
            this.cbFormat.TabIndex = 1;
            this.cbFormat.SelectedIndexChanged += new System.EventHandler(this.cbFormat_SelectedIndexChanged);
            // 
            // lblFormat
            // 
            this.lblFormat.AutoSize = true;
            this.lblFormat.Location = new System.Drawing.Point(8, 23);
            this.lblFormat.Name = "lblFormat";
            this.lblFormat.Size = new System.Drawing.Size(44, 12);
            this.lblFormat.TabIndex = 0;
            this.lblFormat.Text = "Format";
            // 
            // btnGainModeObj
            // 
            this.btnGainModeObj.Location = new System.Drawing.Point(854, 446);
            this.btnGainModeObj.Name = "btnGainModeObj";
            this.btnGainModeObj.Size = new System.Drawing.Size(111, 48);
            this.btnGainModeObj.TabIndex = 10;
            this.btnGainModeObj.Text = "GainModeObj";
            this.btnGainModeObj.UseVisualStyleBackColor = true;
            this.btnGainModeObj.Click += new System.EventHandler(this.btnGainModeObj_Click);
            // 
            // gbTemperature
            // 
            this.gbTemperature.Controls.Add(this.tbMaxTemp);
            this.gbTemperature.Controls.Add(this.tbAvgTemp);
            this.gbTemperature.Controls.Add(this.tbMinTemp);
            this.gbTemperature.Controls.Add(this.lblMaxTemp);
            this.gbTemperature.Controls.Add(this.lblAvgTemp);
            this.gbTemperature.Controls.Add(this.lblMinTemp);
            this.gbTemperature.Location = new System.Drawing.Point(854, 6);
            this.gbTemperature.Name = "gbTemperature";
            this.gbTemperature.Size = new System.Drawing.Size(316, 65);
            this.gbTemperature.TabIndex = 11;
            this.gbTemperature.TabStop = false;
            this.gbTemperature.Text = "Temperature(0~255)";
            // 
            // tbMaxTemp
            // 
            this.tbMaxTemp.Location = new System.Drawing.Point(230, 33);
            this.tbMaxTemp.Name = "tbMaxTemp";
            this.tbMaxTemp.Size = new System.Drawing.Size(80, 21);
            this.tbMaxTemp.TabIndex = 15;
            // 
            // tbAvgTemp
            // 
            this.tbAvgTemp.Location = new System.Drawing.Point(120, 33);
            this.tbAvgTemp.Name = "tbAvgTemp";
            this.tbAvgTemp.Size = new System.Drawing.Size(80, 21);
            this.tbAvgTemp.TabIndex = 14;
            // 
            // tbMinTemp
            // 
            this.tbMinTemp.Location = new System.Drawing.Point(7, 33);
            this.tbMinTemp.Name = "tbMinTemp";
            this.tbMinTemp.Size = new System.Drawing.Size(80, 21);
            this.tbMinTemp.TabIndex = 13;
            // 
            // lblMaxTemp
            // 
            this.lblMaxTemp.AutoSize = true;
            this.lblMaxTemp.Location = new System.Drawing.Point(228, 17);
            this.lblMaxTemp.Name = "lblMaxTemp";
            this.lblMaxTemp.Size = new System.Drawing.Size(30, 12);
            this.lblMaxTemp.TabIndex = 12;
            this.lblMaxTemp.Text = "Max";
            // 
            // lblAvgTemp
            // 
            this.lblAvgTemp.AutoSize = true;
            this.lblAvgTemp.Location = new System.Drawing.Point(118, 17);
            this.lblAvgTemp.Name = "lblAvgTemp";
            this.lblAvgTemp.Size = new System.Drawing.Size(51, 12);
            this.lblAvgTemp.TabIndex = 1;
            this.lblAvgTemp.Text = "Average";
            // 
            // lblMinTemp
            // 
            this.lblMinTemp.AutoSize = true;
            this.lblMinTemp.Location = new System.Drawing.Point(6, 17);
            this.lblMinTemp.Name = "lblMinTemp";
            this.lblMinTemp.Size = new System.Drawing.Size(26, 12);
            this.lblMinTemp.TabIndex = 0;
            this.lblMinTemp.Text = "Min";
            // 
            // Tab_MAIN
            // 
            this.Tab_MAIN.Controls.Add(this.camPage);
            this.Tab_MAIN.Controls.Add(this.portPage);
            this.Tab_MAIN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Tab_MAIN.Location = new System.Drawing.Point(0, 0);
            this.Tab_MAIN.Margin = new System.Windows.Forms.Padding(0);
            this.Tab_MAIN.Name = "Tab_MAIN";
            this.Tab_MAIN.SelectedIndex = 0;
            this.Tab_MAIN.Size = new System.Drawing.Size(1201, 541);
            this.Tab_MAIN.TabIndex = 12;
            // 
            // camPage
            // 
            this.camPage.BackColor = System.Drawing.Color.White;
            this.camPage.Controls.Add(this.btnOpen);
            this.camPage.Controls.Add(this.groupBox1);
            this.camPage.Controls.Add(this.tbInfo);
            this.camPage.Controls.Add(this.gbTemperature);
            this.camPage.Controls.Add(this.btnStart);
            this.camPage.Controls.Add(this.btnGainModeObj);
            this.camPage.Controls.Add(this.rbtnGrayScale);
            this.camPage.Controls.Add(this.gbSettings);
            this.camPage.Controls.Add(this.pictureBox1);
            this.camPage.Controls.Add(this.rbtnRGB);
            this.camPage.Controls.Add(this.rbtnBinary);
            this.camPage.Location = new System.Drawing.Point(4, 22);
            this.camPage.Margin = new System.Windows.Forms.Padding(0);
            this.camPage.Name = "camPage";
            this.camPage.Size = new System.Drawing.Size(1193, 515);
            this.camPage.TabIndex = 1;
            this.camPage.Text = "Camera";
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(6, 446);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(95, 48);
            this.btnOpen.TabIndex = 17;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView2);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(854, 77);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(316, 363);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Location";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Location = new System.Drawing.Point(6, 20);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(304, 193);
            this.dataGridView1.TabIndex = 0;
            // 
            // portPage
            // 
            this.portPage.BackColor = System.Drawing.Color.White;
            this.portPage.Controls.Add(this.btnGetPort);
            this.portPage.Controls.Add(this.cbCom);
            this.portPage.Controls.Add(this.lblCom);
            this.portPage.Location = new System.Drawing.Point(4, 22);
            this.portPage.Margin = new System.Windows.Forms.Padding(0);
            this.portPage.Name = "portPage";
            this.portPage.Size = new System.Drawing.Size(1193, 515);
            this.portPage.TabIndex = 0;
            this.portPage.Text = "Port";
            // 
            // btnGetPort
            // 
            this.btnGetPort.Location = new System.Drawing.Point(240, 34);
            this.btnGetPort.Name = "btnGetPort";
            this.btnGetPort.Size = new System.Drawing.Size(75, 30);
            this.btnGetPort.TabIndex = 2;
            this.btnGetPort.Text = "Get Port";
            this.btnGetPort.UseVisualStyleBackColor = true;
            this.btnGetPort.Click += new System.EventHandler(this.btnGetPort_Click);
            // 
            // cbCom
            // 
            this.cbCom.FormattingEnabled = true;
            this.cbCom.Location = new System.Drawing.Point(113, 40);
            this.cbCom.Name = "cbCom";
            this.cbCom.Size = new System.Drawing.Size(121, 20);
            this.cbCom.TabIndex = 1;
            // 
            // lblCom
            // 
            this.lblCom.AutoSize = true;
            this.lblCom.Location = new System.Drawing.Point(36, 43);
            this.lblCom.Name = "lblCom";
            this.lblCom.Size = new System.Drawing.Size(71, 12);
            this.lblCom.TabIndex = 0;
            this.lblCom.Text = "COM PORT";
            // 
            // btnPortTab
            // 
            this.btnPortTab.Location = new System.Drawing.Point(12, 179);
            this.btnPortTab.Name = "btnPortTab";
            this.btnPortTab.Size = new System.Drawing.Size(126, 56);
            this.btnPortTab.TabIndex = 13;
            this.btnPortTab.Text = "PORT";
            this.btnPortTab.UseVisualStyleBackColor = true;
            this.btnPortTab.Click += new System.EventHandler(this.btnMainTab_Click);
            // 
            // btnCamTab
            // 
            this.btnCamTab.Location = new System.Drawing.Point(12, 117);
            this.btnCamTab.Name = "btnCamTab";
            this.btnCamTab.Size = new System.Drawing.Size(126, 56);
            this.btnCamTab.TabIndex = 14;
            this.btnCamTab.Text = "CAMERA";
            this.btnCamTab.UseVisualStyleBackColor = true;
            this.btnCamTab.Click += new System.EventHandler(this.btnCamTab_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Tab_MAIN);
            this.panel1.Location = new System.Drawing.Point(147, 94);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1201, 541);
            this.panel1.TabIndex = 15;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView2.Location = new System.Drawing.Point(6, 222);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.Size = new System.Drawing.Size(304, 135);
            this.dataGridView2.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1357, 644);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCamTab);
            this.Controls.Add(this.btnPortTab);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.gbSettings.ResumeLayout(false);
            this.gbSettings.PerformLayout();
            this.gbTemperature.ResumeLayout(false);
            this.gbTemperature.PerformLayout();
            this.Tab_MAIN.ResumeLayout(false);
            this.camPage.ResumeLayout(false);
            this.camPage.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.portPage.ResumeLayout(false);
            this.portPage.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox tbInfo;
        private System.Windows.Forms.RadioButton rbtnGrayScale;
        private System.Windows.Forms.RadioButton rbtnRGB;
        private System.Windows.Forms.RadioButton rbtnBinary;
        private System.Windows.Forms.GroupBox gbSettings;
        private System.Windows.Forms.ComboBox cbFormat;
        private System.Windows.Forms.Label lblFormat;
        private System.Windows.Forms.ComboBox cbGainMode;
        private System.Windows.Forms.Label lblGainMode;
        private System.Windows.Forms.ComboBox cbAgcEnable;
        private System.Windows.Forms.Label lblAgcEnable;
        private System.Windows.Forms.ComboBox cbAgcCalcEnable;
        private System.Windows.Forms.Label lblAgcCalcEnable;
        private System.Windows.Forms.ComboBox cbRadEnable;
        private System.Windows.Forms.Label lblRadEnable;
        private System.Windows.Forms.ComboBox cbTLinearEnable;
        private System.Windows.Forms.Label lblTLinearEnable;
        private System.Windows.Forms.ComboBox cbHotColor;
        private System.Windows.Forms.Label lblHotColor;
        private System.Windows.Forms.Button btnGainModeObj;
        private System.Windows.Forms.GroupBox gbTemperature;
        private System.Windows.Forms.Label lblMinTemp;
        private System.Windows.Forms.Label lblMaxTemp;
        private System.Windows.Forms.Label lblAvgTemp;
        private System.Windows.Forms.TextBox tbMaxTemp;
        private System.Windows.Forms.TextBox tbAvgTemp;
        private System.Windows.Forms.TextBox tbMinTemp;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.IO.Ports.SerialPort SerialPort;
        private System.Windows.Forms.TabControl Tab_MAIN;
        private System.Windows.Forms.TabPage portPage;
        private System.Windows.Forms.TabPage camPage;
        private System.Windows.Forms.Button btnPortTab;
        private System.Windows.Forms.Button btnCamTab;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnGetPort;
        private System.Windows.Forms.ComboBox cbCom;
        private System.Windows.Forms.Label lblCom;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.DataGridView dataGridView2;
    }
}

