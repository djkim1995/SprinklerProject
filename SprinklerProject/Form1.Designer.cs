namespace SprinklerProject
{
    partial class Sprinkler
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Sprinkler));
            this.btnStart = new System.Windows.Forms.Button();
            this.tbInfo = new System.Windows.Forms.TextBox();
            this.rbtnGray = new System.Windows.Forms.RadioButton();
            this.rbtnRGB = new System.Windows.Forms.RadioButton();
            this.rbtnBinary = new System.Windows.Forms.RadioButton();
            this.gbSettings = new System.Windows.Forms.GroupBox();
            this.BTN_GET_SETTING = new System.Windows.Forms.Button();
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
            this.Panel_Cam = new System.Windows.Forms.Panel();
            this.btnOpen = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BTN_RESET_STATE = new System.Windows.Forms.Button();
            this.Panel_Icon = new System.Windows.Forms.Panel();
            this.PictureBox_Icon = new System.Windows.Forms.PictureBox();
            this.lblState = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.portPage = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TB_Com_MCU = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbCom_MCU = new System.Windows.Forms.ComboBox();
            this.BTN_Disconn_Com_MCU = new System.Windows.Forms.Button();
            this.btnGetPort_MCU = new System.Windows.Forms.Button();
            this.BTN_Conn_Com_MCU = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.LB_Conn_Cam = new System.Windows.Forms.Label();
            this.TB_CAM = new System.Windows.Forms.TextBox();
            this.lblCam = new System.Windows.Forms.Label();
            this.cbCam = new System.Windows.Forms.ComboBox();
            this.BTN_Disconn_Cam = new System.Windows.Forms.Button();
            this.btnGetCam = new System.Windows.Forms.Button();
            this.BTN_Conn_Cam = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.LB_Conn_Com = new System.Windows.Forms.Label();
            this.TB_Com = new System.Windows.Forms.TextBox();
            this.lblCom = new System.Windows.Forms.Label();
            this.cbCom = new System.Windows.Forms.ComboBox();
            this.BTN_Disconn_Com = new System.Windows.Forms.Button();
            this.btnGetPort = new System.Windows.Forms.Button();
            this.BTN_Conn_Com = new System.Windows.Forms.Button();
            this.btnPortTab = new System.Windows.Forms.Button();
            this.btnCamTab = new System.Windows.Forms.Button();
            this.Panel_Tabcontrol = new System.Windows.Forms.Panel();
            this.timer_SendSpot = new System.Windows.Forms.Timer(this.components);
            this.timer_ImgProcess = new System.Windows.Forms.Timer(this.components);
            this.timer_Setting = new System.Windows.Forms.Timer(this.components);
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.Panel_Line = new System.Windows.Forms.Panel();
            this.Panel_box = new System.Windows.Forms.Panel();
            this.PB_FIRE = new System.Windows.Forms.PictureBox();
            this.LB_FIRE_STATE = new System.Windows.Forms.Label();
            this.PB_Port_OFF_MCU = new System.Windows.Forms.PictureBox();
            this.LB_PortSTATE_MCU = new System.Windows.Forms.Label();
            this.btn_setting = new System.Windows.Forms.Button();
            this.btnFormat = new System.Windows.Forms.Button();
            this.PB_Port_OFF = new System.Windows.Forms.PictureBox();
            this.PB_Cam_OFF = new System.Windows.Forms.PictureBox();
            this.PB_Port_ON = new System.Windows.Forms.PictureBox();
            this.LB_PortSTATE = new System.Windows.Forms.Label();
            this.PB_Cam_ON = new System.Windows.Forms.PictureBox();
            this.LB_CAMSTATE = new System.Windows.Forms.Label();
            this.PictureBox_logo = new System.Windows.Forms.PictureBox();
            this.PB_Port_ON_MCU = new System.Windows.Forms.PictureBox();
            this.SerialPort_MCU = new System.IO.Ports.SerialPort(this.components);
            this.gbSettings.SuspendLayout();
            this.gbTemperature.SuspendLayout();
            this.Tab_MAIN.SuspendLayout();
            this.camPage.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.Panel_Icon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_Icon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.portPage.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.Panel_Tabcontrol.SuspendLayout();
            this.Panel_box.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PB_FIRE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Port_OFF_MCU)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Port_OFF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Cam_OFF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Port_ON)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Cam_ON)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_logo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Port_ON_MCU)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnStart.FlatAppearance.BorderSize = 0;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold);
            this.btnStart.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnStart.Location = new System.Drawing.Point(108, 457);
            this.btnStart.Margin = new System.Windows.Forms.Padding(0);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(94, 60);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "START";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // tbInfo
            // 
            this.tbInfo.BackColor = System.Drawing.SystemColors.Window;
            this.tbInfo.Location = new System.Drawing.Point(6, 29);
            this.tbInfo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbInfo.Multiline = true;
            this.tbInfo.Name = "tbInfo";
            this.tbInfo.ReadOnly = true;
            this.tbInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbInfo.Size = new System.Drawing.Size(196, 102);
            this.tbInfo.TabIndex = 2;
            // 
            // rbtnGray
            // 
            this.rbtnGray.AutoSize = true;
            this.rbtnGray.Checked = true;
            this.rbtnGray.Location = new System.Drawing.Point(14, 425);
            this.rbtnGray.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rbtnGray.Name = "rbtnGray";
            this.rbtnGray.Size = new System.Drawing.Size(49, 19);
            this.rbtnGray.TabIndex = 6;
            this.rbtnGray.TabStop = true;
            this.rbtnGray.Text = "Gray";
            this.rbtnGray.UseVisualStyleBackColor = true;
            this.rbtnGray.CheckedChanged += new System.EventHandler(this.rbtnGrayScale_CheckedChanged);
            // 
            // rbtnRGB
            // 
            this.rbtnRGB.AutoSize = true;
            this.rbtnRGB.Location = new System.Drawing.Point(149, 425);
            this.rbtnRGB.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rbtnRGB.Name = "rbtnRGB";
            this.rbtnRGB.Size = new System.Drawing.Size(47, 19);
            this.rbtnRGB.TabIndex = 7;
            this.rbtnRGB.Text = "RGB";
            this.rbtnRGB.UseVisualStyleBackColor = true;
            this.rbtnRGB.CheckedChanged += new System.EventHandler(this.rbtnRGB_CheckedChanged);
            // 
            // rbtnBinary
            // 
            this.rbtnBinary.AutoSize = true;
            this.rbtnBinary.Location = new System.Drawing.Point(75, 425);
            this.rbtnBinary.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rbtnBinary.Name = "rbtnBinary";
            this.rbtnBinary.Size = new System.Drawing.Size(58, 19);
            this.rbtnBinary.TabIndex = 8;
            this.rbtnBinary.Text = "Binary";
            this.rbtnBinary.UseVisualStyleBackColor = true;
            this.rbtnBinary.CheckedChanged += new System.EventHandler(this.rbtnBinary_CheckedChanged);
            // 
            // gbSettings
            // 
            this.gbSettings.BackColor = System.Drawing.Color.White;
            this.gbSettings.Controls.Add(this.BTN_GET_SETTING);
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
            this.gbSettings.Location = new System.Drawing.Point(6, 139);
            this.gbSettings.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbSettings.Name = "gbSettings";
            this.gbSettings.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbSettings.Size = new System.Drawing.Size(196, 286);
            this.gbSettings.TabIndex = 9;
            this.gbSettings.TabStop = false;
            this.gbSettings.Text = "Settings";
            // 
            // BTN_GET_SETTING
            // 
            this.BTN_GET_SETTING.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BTN_GET_SETTING.Enabled = false;
            this.BTN_GET_SETTING.FlatAppearance.BorderSize = 0;
            this.BTN_GET_SETTING.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_GET_SETTING.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold);
            this.BTN_GET_SETTING.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BTN_GET_SETTING.Location = new System.Drawing.Point(8, 229);
            this.BTN_GET_SETTING.Margin = new System.Windows.Forms.Padding(0);
            this.BTN_GET_SETTING.Name = "BTN_GET_SETTING";
            this.BTN_GET_SETTING.Size = new System.Drawing.Size(182, 39);
            this.BTN_GET_SETTING.TabIndex = 19;
            this.BTN_GET_SETTING.Text = "GET SETTING";
            this.BTN_GET_SETTING.UseVisualStyleBackColor = false;
            this.BTN_GET_SETTING.Click += new System.EventHandler(this.BTN_GET_SETTING_Click);
            // 
            // cbTLinearEnable
            // 
            this.cbTLinearEnable.FormattingEnabled = true;
            this.cbTLinearEnable.Items.AddRange(new object[] {
            "DISABLE",
            "ENABLE"});
            this.cbTLinearEnable.Location = new System.Drawing.Point(106, 188);
            this.cbTLinearEnable.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbTLinearEnable.Name = "cbTLinearEnable";
            this.cbTLinearEnable.Size = new System.Drawing.Size(84, 23);
            this.cbTLinearEnable.TabIndex = 11;
            this.cbTLinearEnable.SelectedIndexChanged += new System.EventHandler(this.cbTLinearEnable_SelectedIndexChanged);
            // 
            // lblTLinearEnable
            // 
            this.lblTLinearEnable.AutoSize = true;
            this.lblTLinearEnable.Location = new System.Drawing.Point(8, 191);
            this.lblTLinearEnable.Name = "lblTLinearEnable";
            this.lblTLinearEnable.Size = new System.Drawing.Size(80, 15);
            this.lblTLinearEnable.TabIndex = 10;
            this.lblTLinearEnable.Text = "TLinearEnable";
            // 
            // cbRadEnable
            // 
            this.cbRadEnable.FormattingEnabled = true;
            this.cbRadEnable.Items.AddRange(new object[] {
            "DISABLE",
            "ENABLE"});
            this.cbRadEnable.Location = new System.Drawing.Point(106, 155);
            this.cbRadEnable.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbRadEnable.Name = "cbRadEnable";
            this.cbRadEnable.Size = new System.Drawing.Size(84, 23);
            this.cbRadEnable.TabIndex = 9;
            this.cbRadEnable.SelectedIndexChanged += new System.EventHandler(this.cbRadEnable_SelectedIndexChanged);
            // 
            // lblRadEnable
            // 
            this.lblRadEnable.AutoSize = true;
            this.lblRadEnable.Location = new System.Drawing.Point(8, 159);
            this.lblRadEnable.Name = "lblRadEnable";
            this.lblRadEnable.Size = new System.Drawing.Size(62, 15);
            this.lblRadEnable.TabIndex = 8;
            this.lblRadEnable.Text = "RadEnable";
            // 
            // cbAgcCalcEnable
            // 
            this.cbAgcCalcEnable.FormattingEnabled = true;
            this.cbAgcCalcEnable.Items.AddRange(new object[] {
            "DISABLE",
            "ENABLE"});
            this.cbAgcCalcEnable.Location = new System.Drawing.Point(106, 122);
            this.cbAgcCalcEnable.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbAgcCalcEnable.Name = "cbAgcCalcEnable";
            this.cbAgcCalcEnable.Size = new System.Drawing.Size(84, 23);
            this.cbAgcCalcEnable.TabIndex = 7;
            this.cbAgcCalcEnable.SelectedIndexChanged += new System.EventHandler(this.cbAgcCalcEnable_SelectedIndexChanged);
            // 
            // lblAgcCalcEnable
            // 
            this.lblAgcCalcEnable.AutoSize = true;
            this.lblAgcCalcEnable.Location = new System.Drawing.Point(8, 126);
            this.lblAgcCalcEnable.Name = "lblAgcCalcEnable";
            this.lblAgcCalcEnable.Size = new System.Drawing.Size(86, 15);
            this.lblAgcCalcEnable.TabIndex = 6;
            this.lblAgcCalcEnable.Text = "AgcCalcEnable";
            // 
            // cbAgcEnable
            // 
            this.cbAgcEnable.FormattingEnabled = true;
            this.cbAgcEnable.Items.AddRange(new object[] {
            "DISABLE",
            "ENABLE"});
            this.cbAgcEnable.Location = new System.Drawing.Point(106, 90);
            this.cbAgcEnable.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbAgcEnable.Name = "cbAgcEnable";
            this.cbAgcEnable.Size = new System.Drawing.Size(84, 23);
            this.cbAgcEnable.TabIndex = 5;
            this.cbAgcEnable.SelectedIndexChanged += new System.EventHandler(this.cbAgcEnable_SelectedIndexChanged);
            // 
            // lblAgcEnable
            // 
            this.lblAgcEnable.AutoSize = true;
            this.lblAgcEnable.Location = new System.Drawing.Point(8, 94);
            this.lblAgcEnable.Name = "lblAgcEnable";
            this.lblAgcEnable.Size = new System.Drawing.Size(63, 15);
            this.lblAgcEnable.TabIndex = 4;
            this.lblAgcEnable.Text = "AgcEnable";
            // 
            // cbGainMode
            // 
            this.cbGainMode.FormattingEnabled = true;
            this.cbGainMode.Items.AddRange(new object[] {
            "LOW",
            "HIGH"});
            this.cbGainMode.Location = new System.Drawing.Point(106, 58);
            this.cbGainMode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbGainMode.Name = "cbGainMode";
            this.cbGainMode.Size = new System.Drawing.Size(84, 23);
            this.cbGainMode.TabIndex = 3;
            this.cbGainMode.SelectedIndexChanged += new System.EventHandler(this.cbGainMode_SelectedIndexChanged);
            // 
            // lblGainMode
            // 
            this.lblGainMode.AutoSize = true;
            this.lblGainMode.Location = new System.Drawing.Point(8, 61);
            this.lblGainMode.Name = "lblGainMode";
            this.lblGainMode.Size = new System.Drawing.Size(62, 15);
            this.lblGainMode.TabIndex = 2;
            this.lblGainMode.Text = "GainMode";
            // 
            // cbFormat
            // 
            this.cbFormat.FormattingEnabled = true;
            this.cbFormat.Items.AddRange(new object[] {
            "RAW14",
            "RGB888"});
            this.cbFormat.Location = new System.Drawing.Point(106, 25);
            this.cbFormat.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbFormat.Name = "cbFormat";
            this.cbFormat.Size = new System.Drawing.Size(84, 23);
            this.cbFormat.TabIndex = 1;
            this.cbFormat.SelectedIndexChanged += new System.EventHandler(this.cbFormat_SelectedIndexChanged);
            // 
            // lblFormat
            // 
            this.lblFormat.AutoSize = true;
            this.lblFormat.Location = new System.Drawing.Point(8, 29);
            this.lblFormat.Name = "lblFormat";
            this.lblFormat.Size = new System.Drawing.Size(45, 15);
            this.lblFormat.TabIndex = 0;
            this.lblFormat.Text = "Format";
            // 
            // btnGainModeObj
            // 
            this.btnGainModeObj.Location = new System.Drawing.Point(18, 506);
            this.btnGainModeObj.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnGainModeObj.Name = "btnGainModeObj";
            this.btnGainModeObj.Size = new System.Drawing.Size(108, 31);
            this.btnGainModeObj.TabIndex = 10;
            this.btnGainModeObj.Text = "GainModeObj";
            this.btnGainModeObj.UseVisualStyleBackColor = true;
            this.btnGainModeObj.Visible = false;
            this.btnGainModeObj.Click += new System.EventHandler(this.btnGainModeObj_Click);
            // 
            // gbTemperature
            // 
            this.gbTemperature.BackColor = System.Drawing.Color.White;
            this.gbTemperature.Controls.Add(this.tbMaxTemp);
            this.gbTemperature.Controls.Add(this.tbAvgTemp);
            this.gbTemperature.Controls.Add(this.tbMinTemp);
            this.gbTemperature.Controls.Add(this.lblMaxTemp);
            this.gbTemperature.Controls.Add(this.lblAvgTemp);
            this.gbTemperature.Controls.Add(this.lblMinTemp);
            this.gbTemperature.Location = new System.Drawing.Point(854, 29);
            this.gbTemperature.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbTemperature.Name = "gbTemperature";
            this.gbTemperature.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbTemperature.Size = new System.Drawing.Size(232, 81);
            this.gbTemperature.TabIndex = 11;
            this.gbTemperature.TabStop = false;
            this.gbTemperature.Text = "Temperature(0~255)";
            // 
            // tbMaxTemp
            // 
            this.tbMaxTemp.Location = new System.Drawing.Point(157, 41);
            this.tbMaxTemp.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbMaxTemp.Name = "tbMaxTemp";
            this.tbMaxTemp.Size = new System.Drawing.Size(50, 23);
            this.tbMaxTemp.TabIndex = 15;
            // 
            // tbAvgTemp
            // 
            this.tbAvgTemp.Location = new System.Drawing.Point(82, 41);
            this.tbAvgTemp.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbAvgTemp.Name = "tbAvgTemp";
            this.tbAvgTemp.Size = new System.Drawing.Size(50, 23);
            this.tbAvgTemp.TabIndex = 14;
            // 
            // tbMinTemp
            // 
            this.tbMinTemp.Location = new System.Drawing.Point(7, 41);
            this.tbMinTemp.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbMinTemp.Name = "tbMinTemp";
            this.tbMinTemp.Size = new System.Drawing.Size(50, 23);
            this.tbMinTemp.TabIndex = 13;
            // 
            // lblMaxTemp
            // 
            this.lblMaxTemp.AutoSize = true;
            this.lblMaxTemp.Location = new System.Drawing.Point(154, 21);
            this.lblMaxTemp.Name = "lblMaxTemp";
            this.lblMaxTemp.Size = new System.Drawing.Size(30, 15);
            this.lblMaxTemp.TabIndex = 12;
            this.lblMaxTemp.Text = "Max";
            // 
            // lblAvgTemp
            // 
            this.lblAvgTemp.AutoSize = true;
            this.lblAvgTemp.Location = new System.Drawing.Point(80, 21);
            this.lblAvgTemp.Name = "lblAvgTemp";
            this.lblAvgTemp.Size = new System.Drawing.Size(50, 15);
            this.lblAvgTemp.TabIndex = 1;
            this.lblAvgTemp.Text = "Average";
            // 
            // lblMinTemp
            // 
            this.lblMinTemp.AutoSize = true;
            this.lblMinTemp.Location = new System.Drawing.Point(6, 21);
            this.lblMinTemp.Name = "lblMinTemp";
            this.lblMinTemp.Size = new System.Drawing.Size(28, 15);
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
            this.Tab_MAIN.Size = new System.Drawing.Size(1100, 550);
            this.Tab_MAIN.TabIndex = 12;
            // 
            // camPage
            // 
            this.camPage.BackColor = System.Drawing.Color.White;
            this.camPage.Controls.Add(this.Panel_Cam);
            this.camPage.Controls.Add(this.btnOpen);
            this.camPage.Controls.Add(this.groupBox1);
            this.camPage.Controls.Add(this.tbInfo);
            this.camPage.Controls.Add(this.gbTemperature);
            this.camPage.Controls.Add(this.btnStart);
            this.camPage.Controls.Add(this.rbtnGray);
            this.camPage.Controls.Add(this.gbSettings);
            this.camPage.Controls.Add(this.pictureBox1);
            this.camPage.Controls.Add(this.rbtnRGB);
            this.camPage.Controls.Add(this.rbtnBinary);
            this.camPage.Location = new System.Drawing.Point(4, 24);
            this.camPage.Margin = new System.Windows.Forms.Padding(0);
            this.camPage.Name = "camPage";
            this.camPage.Size = new System.Drawing.Size(1092, 522);
            this.camPage.TabIndex = 1;
            this.camPage.Text = "Camera";
            // 
            // Panel_Cam
            // 
            this.Panel_Cam.BackColor = System.Drawing.SystemColors.Control;
            this.Panel_Cam.Location = new System.Drawing.Point(208, 29);
            this.Panel_Cam.Name = "Panel_Cam";
            this.Panel_Cam.Size = new System.Drawing.Size(640, 488);
            this.Panel_Cam.TabIndex = 18;
            // 
            // btnOpen
            // 
            this.btnOpen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(198)))), ((int)(((byte)(204)))));
            this.btnOpen.FlatAppearance.BorderSize = 0;
            this.btnOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpen.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold);
            this.btnOpen.ForeColor = System.Drawing.Color.White;
            this.btnOpen.Location = new System.Drawing.Point(7, 457);
            this.btnOpen.Margin = new System.Windows.Forms.Padding(0);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(94, 60);
            this.btnOpen.TabIndex = 17;
            this.btnOpen.Text = "OPEN";
            this.btnOpen.UseVisualStyleBackColor = false;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BTN_RESET_STATE);
            this.groupBox1.Controls.Add(this.Panel_Icon);
            this.groupBox1.Controls.Add(this.listView1);
            this.groupBox1.Location = new System.Drawing.Point(854, 118);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(232, 399);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Location";
            // 
            // BTN_RESET_STATE
            // 
            this.BTN_RESET_STATE.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BTN_RESET_STATE.FlatAppearance.BorderSize = 0;
            this.BTN_RESET_STATE.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_RESET_STATE.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold);
            this.BTN_RESET_STATE.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BTN_RESET_STATE.Location = new System.Drawing.Point(6, 346);
            this.BTN_RESET_STATE.Margin = new System.Windows.Forms.Padding(0);
            this.BTN_RESET_STATE.Name = "BTN_RESET_STATE";
            this.BTN_RESET_STATE.Size = new System.Drawing.Size(220, 46);
            this.BTN_RESET_STATE.TabIndex = 19;
            this.BTN_RESET_STATE.Text = "RESET";
            this.BTN_RESET_STATE.UseVisualStyleBackColor = false;
            this.BTN_RESET_STATE.Click += new System.EventHandler(this.BTN_RESET_STATE_Click);
            // 
            // Panel_Icon
            // 
            this.Panel_Icon.BackColor = System.Drawing.Color.White;
            this.Panel_Icon.Controls.Add(this.PictureBox_Icon);
            this.Panel_Icon.Controls.Add(this.lblState);
            this.Panel_Icon.Location = new System.Drawing.Point(6, 250);
            this.Panel_Icon.Name = "Panel_Icon";
            this.Panel_Icon.Size = new System.Drawing.Size(220, 93);
            this.Panel_Icon.TabIndex = 1;
            // 
            // PictureBox_Icon
            // 
            this.PictureBox_Icon.BackColor = System.Drawing.Color.Transparent;
            this.PictureBox_Icon.Image = global::SprinklerProject.Properties.Resources.icon_ready;
            this.PictureBox_Icon.InitialImage = global::SprinklerProject.Properties.Resources.icon_ready;
            this.PictureBox_Icon.Location = new System.Drawing.Point(151, 16);
            this.PictureBox_Icon.Name = "PictureBox_Icon";
            this.PictureBox_Icon.Size = new System.Drawing.Size(60, 60);
            this.PictureBox_Icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureBox_Icon.TabIndex = 2;
            this.PictureBox_Icon.TabStop = false;
            // 
            // lblState
            // 
            this.lblState.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.lblState.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblState.Font = new System.Drawing.Font("Consolas", 24F, System.Drawing.FontStyle.Bold);
            this.lblState.ForeColor = System.Drawing.Color.Black;
            this.lblState.Location = new System.Drawing.Point(0, 0);
            this.lblState.Margin = new System.Windows.Forms.Padding(0);
            this.lblState.Name = "lblState";
            this.lblState.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.lblState.Size = new System.Drawing.Size(220, 93);
            this.lblState.TabIndex = 1;
            this.lblState.Text = "READY";
            this.lblState.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(6, 25);
            this.listView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(220, 218);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "No.";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Start";
            this.columnHeader2.Width = 80;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "End";
            this.columnHeader3.Width = 80;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(208, 29);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(640, 488);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // portPage
            // 
            this.portPage.BackColor = System.Drawing.Color.White;
            this.portPage.Controls.Add(this.groupBox4);
            this.portPage.Controls.Add(this.groupBox3);
            this.portPage.Controls.Add(this.groupBox2);
            this.portPage.Location = new System.Drawing.Point(4, 24);
            this.portPage.Margin = new System.Windows.Forms.Padding(0);
            this.portPage.Name = "portPage";
            this.portPage.Size = new System.Drawing.Size(1092, 522);
            this.portPage.TabIndex = 0;
            this.portPage.Text = "Port";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.TB_Com_MCU);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.cbCom_MCU);
            this.groupBox4.Controls.Add(this.BTN_Disconn_Com_MCU);
            this.groupBox4.Controls.Add(this.btnGetPort_MCU);
            this.groupBox4.Controls.Add(this.BTN_Conn_Com_MCU);
            this.groupBox4.Location = new System.Drawing.Point(352, 32);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox4.Size = new System.Drawing.Size(292, 171);
            this.groupBox4.TabIndex = 13;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "MCU PORT";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 15);
            this.label1.TabIndex = 10;
            this.label1.Text = "Connected : ";
            // 
            // TB_Com_MCU
            // 
            this.TB_Com_MCU.Location = new System.Drawing.Point(83, 21);
            this.TB_Com_MCU.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TB_Com_MCU.Name = "TB_Com_MCU";
            this.TB_Com_MCU.ReadOnly = true;
            this.TB_Com_MCU.Size = new System.Drawing.Size(100, 23);
            this.TB_Com_MCU.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "COM PORT";
            // 
            // cbCom_MCU
            // 
            this.cbCom_MCU.FormattingEnabled = true;
            this.cbCom_MCU.Location = new System.Drawing.Point(83, 59);
            this.cbCom_MCU.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbCom_MCU.Name = "cbCom_MCU";
            this.cbCom_MCU.Size = new System.Drawing.Size(121, 23);
            this.cbCom_MCU.TabIndex = 1;
            // 
            // BTN_Disconn_Com_MCU
            // 
            this.BTN_Disconn_Com_MCU.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(198)))), ((int)(((byte)(195)))));
            this.BTN_Disconn_Com_MCU.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_Disconn_Com_MCU.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.BTN_Disconn_Com_MCU.ForeColor = System.Drawing.Color.White;
            this.BTN_Disconn_Com_MCU.Location = new System.Drawing.Point(159, 101);
            this.BTN_Disconn_Com_MCU.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BTN_Disconn_Com_MCU.Name = "BTN_Disconn_Com_MCU";
            this.BTN_Disconn_Com_MCU.Size = new System.Drawing.Size(126, 56);
            this.BTN_Disconn_Com_MCU.TabIndex = 9;
            this.BTN_Disconn_Com_MCU.Text = "Disconnect";
            this.BTN_Disconn_Com_MCU.UseVisualStyleBackColor = true;
            this.BTN_Disconn_Com_MCU.Click += new System.EventHandler(this.BTN_Disconn_Com_MCU_Click);
            // 
            // btnGetPort_MCU
            // 
            this.btnGetPort_MCU.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnGetPort_MCU.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGetPort_MCU.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnGetPort_MCU.ForeColor = System.Drawing.Color.White;
            this.btnGetPort_MCU.Location = new System.Drawing.Point(210, 51);
            this.btnGetPort_MCU.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnGetPort_MCU.Name = "btnGetPort_MCU";
            this.btnGetPort_MCU.Size = new System.Drawing.Size(75, 38);
            this.btnGetPort_MCU.TabIndex = 2;
            this.btnGetPort_MCU.Text = "Get Port";
            this.btnGetPort_MCU.UseVisualStyleBackColor = false;
            this.btnGetPort_MCU.Click += new System.EventHandler(this.btnGetPort_MCU_Click);
            // 
            // BTN_Conn_Com_MCU
            // 
            this.BTN_Conn_Com_MCU.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(199)))), ((int)(((byte)(207)))));
            this.BTN_Conn_Com_MCU.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_Conn_Com_MCU.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.BTN_Conn_Com_MCU.ForeColor = System.Drawing.Color.White;
            this.BTN_Conn_Com_MCU.Location = new System.Drawing.Point(8, 101);
            this.BTN_Conn_Com_MCU.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BTN_Conn_Com_MCU.Name = "BTN_Conn_Com_MCU";
            this.BTN_Conn_Com_MCU.Size = new System.Drawing.Size(126, 56);
            this.BTN_Conn_Com_MCU.TabIndex = 8;
            this.BTN_Conn_Com_MCU.Text = "Connect";
            this.BTN_Conn_Com_MCU.UseVisualStyleBackColor = false;
            this.BTN_Conn_Com_MCU.Click += new System.EventHandler(this.BTN_Conn_Com_MCU_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.LB_Conn_Cam);
            this.groupBox3.Controls.Add(this.TB_CAM);
            this.groupBox3.Controls.Add(this.lblCam);
            this.groupBox3.Controls.Add(this.cbCam);
            this.groupBox3.Controls.Add(this.BTN_Disconn_Cam);
            this.groupBox3.Controls.Add(this.btnGetCam);
            this.groupBox3.Controls.Add(this.BTN_Conn_Cam);
            this.groupBox3.Location = new System.Drawing.Point(17, 211);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Size = new System.Drawing.Size(292, 171);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "CAMERA";
            // 
            // LB_Conn_Cam
            // 
            this.LB_Conn_Cam.AutoSize = true;
            this.LB_Conn_Cam.Location = new System.Drawing.Point(6, 25);
            this.LB_Conn_Cam.Name = "LB_Conn_Cam";
            this.LB_Conn_Cam.Size = new System.Drawing.Size(76, 15);
            this.LB_Conn_Cam.TabIndex = 10;
            this.LB_Conn_Cam.Text = "Connected : ";
            // 
            // TB_CAM
            // 
            this.TB_CAM.Location = new System.Drawing.Point(83, 21);
            this.TB_CAM.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TB_CAM.Name = "TB_CAM";
            this.TB_CAM.ReadOnly = true;
            this.TB_CAM.Size = new System.Drawing.Size(100, 23);
            this.TB_CAM.TabIndex = 11;
            // 
            // lblCam
            // 
            this.lblCam.AutoSize = true;
            this.lblCam.Location = new System.Drawing.Point(6, 62);
            this.lblCam.Name = "lblCam";
            this.lblCam.Size = new System.Drawing.Size(55, 15);
            this.lblCam.TabIndex = 0;
            this.lblCam.Text = "CAMERA";
            // 
            // cbCam
            // 
            this.cbCam.FormattingEnabled = true;
            this.cbCam.Location = new System.Drawing.Point(83, 59);
            this.cbCam.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbCam.Name = "cbCam";
            this.cbCam.Size = new System.Drawing.Size(121, 23);
            this.cbCam.TabIndex = 1;
            // 
            // BTN_Disconn_Cam
            // 
            this.BTN_Disconn_Cam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(198)))), ((int)(((byte)(195)))));
            this.BTN_Disconn_Cam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_Disconn_Cam.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.BTN_Disconn_Cam.ForeColor = System.Drawing.Color.White;
            this.BTN_Disconn_Cam.Location = new System.Drawing.Point(159, 101);
            this.BTN_Disconn_Cam.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BTN_Disconn_Cam.Name = "BTN_Disconn_Cam";
            this.BTN_Disconn_Cam.Size = new System.Drawing.Size(126, 56);
            this.BTN_Disconn_Cam.TabIndex = 9;
            this.BTN_Disconn_Cam.Text = "Disconnect";
            this.BTN_Disconn_Cam.UseVisualStyleBackColor = true;
            this.BTN_Disconn_Cam.Click += new System.EventHandler(this.BTN_Disconn_Cam_Click);
            // 
            // btnGetCam
            // 
            this.btnGetCam.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnGetCam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGetCam.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnGetCam.ForeColor = System.Drawing.Color.White;
            this.btnGetCam.Location = new System.Drawing.Point(210, 51);
            this.btnGetCam.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnGetCam.Name = "btnGetCam";
            this.btnGetCam.Size = new System.Drawing.Size(75, 38);
            this.btnGetCam.TabIndex = 2;
            this.btnGetCam.Text = "Get Port";
            this.btnGetCam.UseVisualStyleBackColor = false;
            this.btnGetCam.Click += new System.EventHandler(this.btnGetCam_Click);
            // 
            // BTN_Conn_Cam
            // 
            this.BTN_Conn_Cam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(199)))), ((int)(((byte)(207)))));
            this.BTN_Conn_Cam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_Conn_Cam.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.BTN_Conn_Cam.ForeColor = System.Drawing.Color.White;
            this.BTN_Conn_Cam.Location = new System.Drawing.Point(8, 101);
            this.BTN_Conn_Cam.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BTN_Conn_Cam.Name = "BTN_Conn_Cam";
            this.BTN_Conn_Cam.Size = new System.Drawing.Size(126, 56);
            this.BTN_Conn_Cam.TabIndex = 8;
            this.BTN_Conn_Cam.Text = "Connect";
            this.BTN_Conn_Cam.UseVisualStyleBackColor = true;
            this.BTN_Conn_Cam.Click += new System.EventHandler(this.BTN_Conn_Cam_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.LB_Conn_Com);
            this.groupBox2.Controls.Add(this.TB_Com);
            this.groupBox2.Controls.Add(this.lblCom);
            this.groupBox2.Controls.Add(this.cbCom);
            this.groupBox2.Controls.Add(this.BTN_Disconn_Com);
            this.groupBox2.Controls.Add(this.btnGetPort);
            this.groupBox2.Controls.Add(this.BTN_Conn_Com);
            this.groupBox2.Location = new System.Drawing.Point(17, 32);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(292, 171);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "COM PORT";
            // 
            // LB_Conn_Com
            // 
            this.LB_Conn_Com.AutoSize = true;
            this.LB_Conn_Com.Location = new System.Drawing.Point(6, 25);
            this.LB_Conn_Com.Name = "LB_Conn_Com";
            this.LB_Conn_Com.Size = new System.Drawing.Size(76, 15);
            this.LB_Conn_Com.TabIndex = 10;
            this.LB_Conn_Com.Text = "Connected : ";
            // 
            // TB_Com
            // 
            this.TB_Com.Location = new System.Drawing.Point(83, 21);
            this.TB_Com.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TB_Com.Name = "TB_Com";
            this.TB_Com.ReadOnly = true;
            this.TB_Com.Size = new System.Drawing.Size(100, 23);
            this.TB_Com.TabIndex = 11;
            // 
            // lblCom
            // 
            this.lblCom.AutoSize = true;
            this.lblCom.Location = new System.Drawing.Point(6, 62);
            this.lblCom.Name = "lblCom";
            this.lblCom.Size = new System.Drawing.Size(68, 15);
            this.lblCom.TabIndex = 0;
            this.lblCom.Text = "COM PORT";
            // 
            // cbCom
            // 
            this.cbCom.FormattingEnabled = true;
            this.cbCom.Location = new System.Drawing.Point(83, 59);
            this.cbCom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbCom.Name = "cbCom";
            this.cbCom.Size = new System.Drawing.Size(121, 23);
            this.cbCom.TabIndex = 1;
            // 
            // BTN_Disconn_Com
            // 
            this.BTN_Disconn_Com.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(198)))), ((int)(((byte)(195)))));
            this.BTN_Disconn_Com.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_Disconn_Com.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.BTN_Disconn_Com.ForeColor = System.Drawing.Color.White;
            this.BTN_Disconn_Com.Location = new System.Drawing.Point(159, 101);
            this.BTN_Disconn_Com.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BTN_Disconn_Com.Name = "BTN_Disconn_Com";
            this.BTN_Disconn_Com.Size = new System.Drawing.Size(126, 56);
            this.BTN_Disconn_Com.TabIndex = 9;
            this.BTN_Disconn_Com.Text = "Disconnect";
            this.BTN_Disconn_Com.UseVisualStyleBackColor = true;
            this.BTN_Disconn_Com.Click += new System.EventHandler(this.BTN_Disconn_Click);
            // 
            // btnGetPort
            // 
            this.btnGetPort.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnGetPort.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGetPort.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnGetPort.ForeColor = System.Drawing.Color.White;
            this.btnGetPort.Location = new System.Drawing.Point(210, 51);
            this.btnGetPort.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnGetPort.Name = "btnGetPort";
            this.btnGetPort.Size = new System.Drawing.Size(75, 38);
            this.btnGetPort.TabIndex = 2;
            this.btnGetPort.Text = "Get Port";
            this.btnGetPort.UseVisualStyleBackColor = false;
            this.btnGetPort.Click += new System.EventHandler(this.btnGetPort_Click);
            // 
            // BTN_Conn_Com
            // 
            this.BTN_Conn_Com.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(199)))), ((int)(((byte)(207)))));
            this.BTN_Conn_Com.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_Conn_Com.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.BTN_Conn_Com.ForeColor = System.Drawing.Color.White;
            this.BTN_Conn_Com.Location = new System.Drawing.Point(8, 101);
            this.BTN_Conn_Com.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BTN_Conn_Com.Name = "BTN_Conn_Com";
            this.BTN_Conn_Com.Size = new System.Drawing.Size(126, 56);
            this.BTN_Conn_Com.TabIndex = 8;
            this.BTN_Conn_Com.Text = "Connect";
            this.BTN_Conn_Com.UseVisualStyleBackColor = false;
            this.BTN_Conn_Com.Click += new System.EventHandler(this.BTN_Conn_Click);
            // 
            // btnPortTab
            // 
            this.btnPortTab.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnPortTab.FlatAppearance.BorderSize = 0;
            this.btnPortTab.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPortTab.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold);
            this.btnPortTab.ForeColor = System.Drawing.Color.White;
            this.btnPortTab.Location = new System.Drawing.Point(0, 175);
            this.btnPortTab.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPortTab.Name = "btnPortTab";
            this.btnPortTab.Size = new System.Drawing.Size(126, 100);
            this.btnPortTab.TabIndex = 13;
            this.btnPortTab.Text = "PORT";
            this.btnPortTab.UseVisualStyleBackColor = false;
            this.btnPortTab.Click += new System.EventHandler(this.btnMainTab_Click);
            // 
            // btnCamTab
            // 
            this.btnCamTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(199)))), ((int)(((byte)(207)))));
            this.btnCamTab.Enabled = false;
            this.btnCamTab.FlatAppearance.BorderSize = 0;
            this.btnCamTab.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCamTab.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold);
            this.btnCamTab.ForeColor = System.Drawing.Color.White;
            this.btnCamTab.Location = new System.Drawing.Point(0, 75);
            this.btnCamTab.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCamTab.Name = "btnCamTab";
            this.btnCamTab.Size = new System.Drawing.Size(126, 100);
            this.btnCamTab.TabIndex = 14;
            this.btnCamTab.Text = "CAMERA";
            this.btnCamTab.UseVisualStyleBackColor = false;
            this.btnCamTab.Click += new System.EventHandler(this.btnCamTab_Click);
            // 
            // Panel_Tabcontrol
            // 
            this.Panel_Tabcontrol.Controls.Add(this.Tab_MAIN);
            this.Panel_Tabcontrol.Location = new System.Drawing.Point(126, -5);
            this.Panel_Tabcontrol.Margin = new System.Windows.Forms.Padding(0);
            this.Panel_Tabcontrol.Name = "Panel_Tabcontrol";
            this.Panel_Tabcontrol.Size = new System.Drawing.Size(1100, 550);
            this.Panel_Tabcontrol.TabIndex = 15;
            // 
            // timer_SendSpot
            // 
            this.timer_SendSpot.Interval = 1000;
            // 
            // Panel_Line
            // 
            this.Panel_Line.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(199)))), ((int)(((byte)(207)))));
            this.Panel_Line.Location = new System.Drawing.Point(126, 0);
            this.Panel_Line.Name = "Panel_Line";
            this.Panel_Line.Size = new System.Drawing.Size(5, 545);
            this.Panel_Line.TabIndex = 16;
            // 
            // Panel_box
            // 
            this.Panel_box.BackColor = System.Drawing.SystemColors.Control;
            this.Panel_box.Controls.Add(this.PB_FIRE);
            this.Panel_box.Controls.Add(this.LB_FIRE_STATE);
            this.Panel_box.Controls.Add(this.PB_Port_OFF_MCU);
            this.Panel_box.Controls.Add(this.LB_PortSTATE_MCU);
            this.Panel_box.Controls.Add(this.btn_setting);
            this.Panel_box.Controls.Add(this.btnFormat);
            this.Panel_box.Controls.Add(this.PB_Port_OFF);
            this.Panel_box.Controls.Add(this.PB_Cam_OFF);
            this.Panel_box.Controls.Add(this.PB_Port_ON);
            this.Panel_box.Controls.Add(this.LB_PortSTATE);
            this.Panel_box.Controls.Add(this.PB_Cam_ON);
            this.Panel_box.Controls.Add(this.LB_CAMSTATE);
            this.Panel_box.Controls.Add(this.PictureBox_logo);
            this.Panel_box.Controls.Add(this.btnGainModeObj);
            this.Panel_box.Controls.Add(this.PB_Port_ON_MCU);
            this.Panel_box.Location = new System.Drawing.Point(0, 0);
            this.Panel_box.Name = "Panel_box";
            this.Panel_box.Size = new System.Drawing.Size(126, 545);
            this.Panel_box.TabIndex = 17;
            // 
            // PB_FIRE
            // 
            this.PB_FIRE.Image = global::SprinklerProject.Properties.Resources.Flame;
            this.PB_FIRE.Location = new System.Drawing.Point(45, 428);
            this.PB_FIRE.Name = "PB_FIRE";
            this.PB_FIRE.Size = new System.Drawing.Size(78, 48);
            this.PB_FIRE.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PB_FIRE.TabIndex = 33;
            this.PB_FIRE.TabStop = false;
            this.PB_FIRE.Visible = false;
            // 
            // LB_FIRE_STATE
            // 
            this.LB_FIRE_STATE.AutoSize = true;
            this.LB_FIRE_STATE.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.LB_FIRE_STATE.Location = new System.Drawing.Point(4, 442);
            this.LB_FIRE_STATE.Name = "LB_FIRE_STATE";
            this.LB_FIRE_STATE.Size = new System.Drawing.Size(37, 21);
            this.LB_FIRE_STATE.TabIndex = 32;
            this.LB_FIRE_STATE.Text = "Fire";
            // 
            // PB_Port_OFF_MCU
            // 
            this.PB_Port_OFF_MCU.Image = global::SprinklerProject.Properties.Resources.Switch_off;
            this.PB_Port_OFF_MCU.Location = new System.Drawing.Point(45, 380);
            this.PB_Port_OFF_MCU.Name = "PB_Port_OFF_MCU";
            this.PB_Port_OFF_MCU.Size = new System.Drawing.Size(78, 48);
            this.PB_Port_OFF_MCU.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PB_Port_OFF_MCU.TabIndex = 30;
            this.PB_Port_OFF_MCU.TabStop = false;
            // 
            // LB_PortSTATE_MCU
            // 
            this.LB_PortSTATE_MCU.AutoSize = true;
            this.LB_PortSTATE_MCU.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.LB_PortSTATE_MCU.Location = new System.Drawing.Point(4, 394);
            this.LB_PortSTATE_MCU.Name = "LB_PortSTATE_MCU";
            this.LB_PortSTATE_MCU.Size = new System.Drawing.Size(41, 21);
            this.LB_PortSTATE_MCU.TabIndex = 29;
            this.LB_PortSTATE_MCU.Text = "Port";
            // 
            // btn_setting
            // 
            this.btn_setting.Location = new System.Drawing.Point(12, 496);
            this.btn_setting.Name = "btn_setting";
            this.btn_setting.Size = new System.Drawing.Size(108, 27);
            this.btn_setting.TabIndex = 28;
            this.btn_setting.Text = "GetSetting";
            this.btn_setting.UseVisualStyleBackColor = true;
            this.btn_setting.Visible = false;
            this.btn_setting.Click += new System.EventHandler(this.btn_set_Click);
            // 
            // btnFormat
            // 
            this.btnFormat.Location = new System.Drawing.Point(15, 494);
            this.btnFormat.Name = "btnFormat";
            this.btnFormat.Size = new System.Drawing.Size(108, 27);
            this.btnFormat.TabIndex = 26;
            this.btnFormat.Text = "Format";
            this.btnFormat.UseVisualStyleBackColor = true;
            this.btnFormat.Visible = false;
            this.btnFormat.Click += new System.EventHandler(this.btnFormat_Click);
            // 
            // PB_Port_OFF
            // 
            this.PB_Port_OFF.Image = global::SprinklerProject.Properties.Resources.Switch_off;
            this.PB_Port_OFF.Location = new System.Drawing.Point(45, 332);
            this.PB_Port_OFF.Name = "PB_Port_OFF";
            this.PB_Port_OFF.Size = new System.Drawing.Size(78, 48);
            this.PB_Port_OFF.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PB_Port_OFF.TabIndex = 25;
            this.PB_Port_OFF.TabStop = false;
            // 
            // PB_Cam_OFF
            // 
            this.PB_Cam_OFF.Image = global::SprinklerProject.Properties.Resources.Switch_off;
            this.PB_Cam_OFF.Location = new System.Drawing.Point(45, 284);
            this.PB_Cam_OFF.Name = "PB_Cam_OFF";
            this.PB_Cam_OFF.Size = new System.Drawing.Size(78, 48);
            this.PB_Cam_OFF.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PB_Cam_OFF.TabIndex = 24;
            this.PB_Cam_OFF.TabStop = false;
            // 
            // PB_Port_ON
            // 
            this.PB_Port_ON.Image = global::SprinklerProject.Properties.Resources.Switch_on;
            this.PB_Port_ON.Location = new System.Drawing.Point(45, 332);
            this.PB_Port_ON.Name = "PB_Port_ON";
            this.PB_Port_ON.Size = new System.Drawing.Size(78, 48);
            this.PB_Port_ON.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PB_Port_ON.TabIndex = 23;
            this.PB_Port_ON.TabStop = false;
            this.PB_Port_ON.Visible = false;
            // 
            // LB_PortSTATE
            // 
            this.LB_PortSTATE.AutoSize = true;
            this.LB_PortSTATE.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.LB_PortSTATE.Location = new System.Drawing.Point(4, 346);
            this.LB_PortSTATE.Name = "LB_PortSTATE";
            this.LB_PortSTATE.Size = new System.Drawing.Size(41, 21);
            this.LB_PortSTATE.TabIndex = 22;
            this.LB_PortSTATE.Text = "Port";
            // 
            // PB_Cam_ON
            // 
            this.PB_Cam_ON.Image = global::SprinklerProject.Properties.Resources.Switch_on;
            this.PB_Cam_ON.Location = new System.Drawing.Point(45, 284);
            this.PB_Cam_ON.Name = "PB_Cam_ON";
            this.PB_Cam_ON.Size = new System.Drawing.Size(78, 48);
            this.PB_Cam_ON.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PB_Cam_ON.TabIndex = 21;
            this.PB_Cam_ON.TabStop = false;
            this.PB_Cam_ON.Visible = false;
            // 
            // LB_CAMSTATE
            // 
            this.LB_CAMSTATE.AutoSize = true;
            this.LB_CAMSTATE.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.LB_CAMSTATE.Location = new System.Drawing.Point(4, 298);
            this.LB_CAMSTATE.Name = "LB_CAMSTATE";
            this.LB_CAMSTATE.Size = new System.Drawing.Size(42, 21);
            this.LB_CAMSTATE.TabIndex = 20;
            this.LB_CAMSTATE.Text = "Cam";
            // 
            // PictureBox_logo
            // 
            this.PictureBox_logo.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox_logo.Image")));
            this.PictureBox_logo.Location = new System.Drawing.Point(0, 0);
            this.PictureBox_logo.Name = "PictureBox_logo";
            this.PictureBox_logo.Size = new System.Drawing.Size(126, 75);
            this.PictureBox_logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictureBox_logo.TabIndex = 19;
            this.PictureBox_logo.TabStop = false;
            // 
            // PB_Port_ON_MCU
            // 
            this.PB_Port_ON_MCU.Image = global::SprinklerProject.Properties.Resources.Switch_on;
            this.PB_Port_ON_MCU.Location = new System.Drawing.Point(45, 380);
            this.PB_Port_ON_MCU.Name = "PB_Port_ON_MCU";
            this.PB_Port_ON_MCU.Size = new System.Drawing.Size(78, 48);
            this.PB_Port_ON_MCU.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PB_Port_ON_MCU.TabIndex = 31;
            this.PB_Port_ON_MCU.TabStop = false;
            this.PB_Port_ON_MCU.Visible = false;
            // 
            // Sprinkler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1225, 541);
            this.Controls.Add(this.Panel_Line);
            this.Controls.Add(this.Panel_Tabcontrol);
            this.Controls.Add(this.btnCamTab);
            this.Controls.Add(this.btnPortTab);
            this.Controls.Add(this.Panel_box);
            this.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ForeColor = System.Drawing.Color.Black;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Sprinkler";
            this.Text = "Sprinkler";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Sprinkler_FormClosing);
            this.gbSettings.ResumeLayout(false);
            this.gbSettings.PerformLayout();
            this.gbTemperature.ResumeLayout(false);
            this.gbTemperature.PerformLayout();
            this.Tab_MAIN.ResumeLayout(false);
            this.camPage.ResumeLayout(false);
            this.camPage.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.Panel_Icon.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_Icon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.portPage.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.Panel_Tabcontrol.ResumeLayout(false);
            this.Panel_box.ResumeLayout(false);
            this.Panel_box.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PB_FIRE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Port_OFF_MCU)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Port_OFF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Cam_OFF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Port_ON)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Cam_ON)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_logo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Port_ON_MCU)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox tbInfo;
        private System.Windows.Forms.RadioButton rbtnGray;
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
        private System.Windows.Forms.Panel Panel_Tabcontrol;
        private System.Windows.Forms.Button btnGetPort;
        private System.Windows.Forms.ComboBox cbCom;
        private System.Windows.Forms.Label lblCom;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Timer timer_SendSpot;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Timer timer_ImgProcess;
        private System.Windows.Forms.Timer timer_Setting;
        private System.Windows.Forms.TextBox TB_Com;
        private System.Windows.Forms.Label LB_Conn_Com;
        private System.Windows.Forms.Button BTN_Disconn_Com;
        private System.Windows.Forms.Button BTN_Conn_Com;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label LB_Conn_Cam;
        private System.Windows.Forms.TextBox TB_CAM;
        private System.Windows.Forms.Label lblCam;
        private System.Windows.Forms.ComboBox cbCam;
        private System.Windows.Forms.Button BTN_Disconn_Cam;
        private System.Windows.Forms.Button btnGetCam;
        private System.Windows.Forms.Button BTN_Conn_Cam;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.Panel Panel_Line;
        private System.Windows.Forms.Panel Panel_box;
        private System.Windows.Forms.Panel Panel_Cam;
        private System.Windows.Forms.Panel Panel_Icon;
        private System.Windows.Forms.PictureBox PictureBox_Icon;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.PictureBox PictureBox_logo;
        private System.Windows.Forms.Label LB_CAMSTATE;
        private System.Windows.Forms.PictureBox PB_Cam_ON;
        private System.Windows.Forms.PictureBox PB_Port_ON;
        private System.Windows.Forms.Label LB_PortSTATE;
        private System.Windows.Forms.PictureBox PB_Port_OFF;
        private System.Windows.Forms.PictureBox PB_Cam_OFF;
        private System.Windows.Forms.Button btnFormat;
        private System.Windows.Forms.Button btn_setting;
        private System.IO.Ports.SerialPort SerialPort_MCU;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TB_Com_MCU;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbCom_MCU;
        private System.Windows.Forms.Button BTN_Disconn_Com_MCU;
        private System.Windows.Forms.Button btnGetPort_MCU;
        private System.Windows.Forms.Button BTN_Conn_Com_MCU;
        private System.Windows.Forms.PictureBox PB_Port_OFF_MCU;
        private System.Windows.Forms.Label LB_PortSTATE_MCU;
        private System.Windows.Forms.PictureBox PB_Port_ON_MCU;
        private System.Windows.Forms.PictureBox PB_FIRE;
        private System.Windows.Forms.Label LB_FIRE_STATE;
        private System.Windows.Forms.Button BTN_RESET_STATE;
        private System.Windows.Forms.Button BTN_GET_SETTING;
    }
}

