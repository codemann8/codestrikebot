using System.Linq;

namespace CodeStrikeBot
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.stsStrip = new System.Windows.Forms.StatusStrip();
            this.stsStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.stsSpacer = new System.Windows.Forms.ToolStripStatusLabel();
            this.stsState = new System.Windows.Forms.ToolStripStatusLabel();
            this.bckScreenState = new System.ComponentModel.BackgroundWorker();
            this.bckSniffer = new System.ComponentModel.BackgroundWorker();
            this.bckHeartBeat = new System.ComponentModel.BackgroundWorker();
            this.bsColorCustom = new System.Windows.Forms.BindingSource(this.components);
            this.bckRegularTasks = new System.ComponentModel.BackgroundWorker();
            this.bckScheduler = new System.ComponentModel.BackgroundWorker();
            this.bckKeepAlive = new System.ComponentModel.BackgroundWorker();
            this.bckAutoActions = new System.ComponentModel.BackgroundWorker();
            this.dataGridViewComboBoxColumn1 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.tabSettings = new System.Windows.Forms.TabPage();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.txtPushoverUser = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPushoverAPI = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSlackURL = new System.Windows.Forms.TextBox();
            this.btnSaveSettings = new System.Windows.Forms.Button();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.cboEmulator4 = new System.Windows.Forms.ComboBox();
            this.cboEmulator3 = new System.Windows.Forms.ComboBox();
            this.cboEmulator2 = new System.Windows.Forms.ComboBox();
            this.cboEmulator1 = new System.Windows.Forms.ComboBox();
            this.lblEmulator4 = new System.Windows.Forms.Label();
            this.txtEmulator4 = new System.Windows.Forms.TextBox();
            this.lblEmulator3 = new System.Windows.Forms.Label();
            this.txtEmulator3 = new System.Windows.Forms.TextBox();
            this.lblEmulator2 = new System.Windows.Forms.Label();
            this.txtEmulator2 = new System.Windows.Forms.TextBox();
            this.lblEmulator1 = new System.Windows.Forms.Label();
            this.txtEmulator1 = new System.Windows.Forms.TextBox();
            this.tabDebug = new System.Windows.Forms.TabPage();
            this.txtScreenOrder = new System.Windows.Forms.TextBox();
            this.txtBmpSize = new System.Windows.Forms.TextBox();
            this.textBox18 = new System.Windows.Forms.TextBox();
            this.textBox19 = new System.Windows.Forms.TextBox();
            this.txt = new System.Windows.Forms.TextBox();
            this.txtCustomY = new System.Windows.Forms.TextBox();
            this.txtCustomX = new System.Windows.Forms.TextBox();
            this.lblBmpChecksum = new System.Windows.Forms.Label();
            this.picCheck = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tabActivity = new System.Windows.Forms.TabPage();
            this.contActivity = new System.Windows.Forms.SplitContainer();
            this.gridPacket = new System.Windows.Forms.DataGridView();
            this.timestampDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lengthDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsPacket = new System.Windows.Forms.BindingSource(this.components);
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.btnCopyText = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.rdoRaw = new System.Windows.Forms.RadioButton();
            this.rdoPayload = new System.Windows.Forms.RadioButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.hexData = new System.ComponentModel.Design.ByteViewer();
            this.treeXml = new System.Windows.Forms.TreeView();
            this.tabAccounts = new System.Windows.Forms.TabPage();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.lblAccountApp = new System.Windows.Forms.Label();
            this.cboAccountAppFilter = new System.Windows.Forms.ComboBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.gridAccounts = new System.Windows.Forms.DataGridView();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emailDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.passwordDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priorityGridViewComboBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.foodNegativeAmountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastLoginDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastLogoutDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsAccount = new System.Windows.Forms.BindingSource(this.components);
            this.tabScreens = new System.Windows.Forms.TabPage();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.btnScheduleRun = new System.Windows.Forms.Button();
            this.gridSchedules = new System.Windows.Forms.DataGridView();
            this.typeDataGridViewComboBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.intervalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BackupX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BackupY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastActionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nextActionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsScheduleTask = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnResize = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lstAccounts = new System.Windows.Forms.ListBox();
            this.btnSwitch = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rdoWindow4 = new System.Windows.Forms.RadioButton();
            this.rdoWindow3 = new System.Windows.Forms.RadioButton();
            this.rdoWindow2 = new System.Windows.Forms.RadioButton();
            this.rdoWindow1 = new System.Windows.Forms.RadioButton();
            this.tabTasks = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.txtColStart = new System.Windows.Forms.TextBox();
            this.btnRestart = new System.Windows.Forms.Button();
            this.btnMap = new System.Windows.Forms.Button();
            this.btnGrowXP = new System.Windows.Forms.Button();
            this.btnTest = new System.Windows.Forms.Button();
            this.btnSearchEnemy = new System.Windows.Forms.Button();
            this.btnMissionXP = new System.Windows.Forms.Button();
            this.txtSliceStartX = new System.Windows.Forms.TextBox();
            this.txtSliceStartY = new System.Windows.Forms.TextBox();
            this.txtRowStart = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnScreen = new System.Windows.Forms.Button();
            this.txtScreen = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnBoostModifier = new System.Windows.Forms.Button();
            this.chkScheduler = new System.Windows.Forms.CheckBox();
            this.btnScheduler = new System.Windows.Forms.Button();
            this.btnMissions = new System.Windows.Forms.Button();
            this.chkTasks = new System.Windows.Forms.CheckBox();
            this.btnTasks = new System.Windows.Forms.Button();
            this.btnClearGifts = new System.Windows.Forms.Button();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.FormContainer = new System.Windows.Forms.SplitContainer();
            this.tabControlMonitor = new System.Windows.Forms.TabControl();
            this.tabMonitor = new System.Windows.Forms.TabPage();
            this.grpRadar = new System.Windows.Forms.GroupBox();
            this.btnExportMarch = new System.Windows.Forms.Button();
            this.lstRadar = new System.Windows.Forms.ListBox();
            this.dataGridViewComboBoxColumn2 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.stsStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsColorCustom)).BeginInit();
            this.tabSettings.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.tabDebug.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCheck)).BeginInit();
            this.tabActivity.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.contActivity)).BeginInit();
            this.contActivity.Panel1.SuspendLayout();
            this.contActivity.Panel2.SuspendLayout();
            this.contActivity.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPacket)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPacket)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabAccounts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridAccounts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAccount)).BeginInit();
            this.tabScreens.SuspendLayout();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSchedules)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsScheduleTask)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tabTasks.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FormContainer)).BeginInit();
            this.FormContainer.Panel1.SuspendLayout();
            this.FormContainer.Panel2.SuspendLayout();
            this.FormContainer.SuspendLayout();
            this.tabControlMonitor.SuspendLayout();
            this.tabMonitor.SuspendLayout();
            this.grpRadar.SuspendLayout();
            this.SuspendLayout();
            // 
            // stsStrip
            // 
            this.stsStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.stsStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stsStatus,
            this.stsSpacer,
            this.stsState});
            this.stsStrip.Location = new System.Drawing.Point(0, 253);
            this.stsStrip.Name = "stsStrip";
            this.stsStrip.Padding = new System.Windows.Forms.Padding(2, 0, 14, 0);
            this.stsStrip.Size = new System.Drawing.Size(962, 22);
            this.stsStrip.TabIndex = 7;
            // 
            // stsStatus
            // 
            this.stsStatus.Name = "stsStatus";
            this.stsStatus.Size = new System.Drawing.Size(0, 17);
            this.stsStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // stsSpacer
            // 
            this.stsSpacer.Name = "stsSpacer";
            this.stsSpacer.Size = new System.Drawing.Size(882, 17);
            this.stsSpacer.Spring = true;
            // 
            // stsState
            // 
            this.stsState.Name = "stsState";
            this.stsState.Size = new System.Drawing.Size(33, 17);
            this.stsState.Text = "State";
            this.stsState.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bckScreenState
            // 
            this.bckScreenState.WorkerReportsProgress = true;
            this.bckScreenState.WorkerSupportsCancellation = true;
            this.bckScreenState.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bckScreenState_DoWork);
            this.bckScreenState.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bckScreenState_ProgressChanged);
            // 
            // bckSniffer
            // 
            this.bckSniffer.WorkerReportsProgress = true;
            this.bckSniffer.WorkerSupportsCancellation = true;
            this.bckSniffer.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bckSniffer_DoWork);
            this.bckSniffer.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bckSniffer_ProgressChanged);
            // 
            // bckHeartBeat
            // 
            this.bckHeartBeat.WorkerSupportsCancellation = true;
            this.bckHeartBeat.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bckHeartBeat_DoWork);
            // 
            // bsColorCustom
            // 
            this.bsColorCustom.DataSource = typeof(System.Drawing.Color);
            // 
            // bckRegularTasks
            // 
            this.bckRegularTasks.WorkerReportsProgress = true;
            this.bckRegularTasks.WorkerSupportsCancellation = true;
            this.bckRegularTasks.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bckRegularTasks_DoWork);
            this.bckRegularTasks.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bckRegularTasks_ProgressChanged);
            // 
            // bckScheduler
            // 
            this.bckScheduler.WorkerReportsProgress = true;
            this.bckScheduler.WorkerSupportsCancellation = true;
            this.bckScheduler.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bckScheduler_DoWork);
            this.bckScheduler.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bckScheduler_ProgressChanged);
            // 
            // bckKeepAlive
            // 
            this.bckKeepAlive.WorkerSupportsCancellation = true;
            this.bckKeepAlive.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bckKeepAlive_DoWork);
            // 
            // bckAutoActions
            // 
            this.bckAutoActions.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bckAutoActions_DoWork);
            // 
            // dataGridViewComboBoxColumn1
            // 
            this.dataGridViewComboBoxColumn1.DataPropertyName = "Type";
            this.dataGridViewComboBoxColumn1.HeaderText = "Type";
            this.dataGridViewComboBoxColumn1.Name = "dataGridViewComboBoxColumn1";
            this.dataGridViewComboBoxColumn1.Width = 68;
            // 
            // tabSettings
            // 
            this.tabSettings.Controls.Add(this.groupBox10);
            this.tabSettings.Controls.Add(this.btnSaveSettings);
            this.tabSettings.Controls.Add(this.groupBox9);
            this.tabSettings.Location = new System.Drawing.Point(4, 22);
            this.tabSettings.Margin = new System.Windows.Forms.Padding(2);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.Padding = new System.Windows.Forms.Padding(2);
            this.tabSettings.Size = new System.Drawing.Size(585, 227);
            this.tabSettings.TabIndex = 5;
            this.tabSettings.Text = "Settings";
            this.tabSettings.UseVisualStyleBackColor = true;
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.txtPushoverUser);
            this.groupBox10.Controls.Add(this.label3);
            this.groupBox10.Controls.Add(this.txtPushoverAPI);
            this.groupBox10.Controls.Add(this.label2);
            this.groupBox10.Controls.Add(this.label1);
            this.groupBox10.Controls.Add(this.txtSlackURL);
            this.groupBox10.Location = new System.Drawing.Point(4, 107);
            this.groupBox10.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox10.Size = new System.Drawing.Size(547, 69);
            this.groupBox10.TabIndex = 6;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Notifications";
            // 
            // txtPushoverUser
            // 
            this.txtPushoverUser.Location = new System.Drawing.Point(350, 41);
            this.txtPushoverUser.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtPushoverUser.Name = "txtPushoverUser";
            this.txtPushoverUser.Size = new System.Drawing.Size(191, 20);
            this.txtPushoverUser.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(269, 44);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Pushover User";
            // 
            // txtPushoverAPI
            // 
            this.txtPushoverAPI.Location = new System.Drawing.Point(79, 41);
            this.txtPushoverAPI.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtPushoverAPI.Name = "txtPushoverAPI";
            this.txtPushoverAPI.Size = new System.Drawing.Size(190, 20);
            this.txtPushoverAPI.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 44);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Pushover API";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Slack URL";
            // 
            // txtSlackURL
            // 
            this.txtSlackURL.Location = new System.Drawing.Point(79, 15);
            this.txtSlackURL.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtSlackURL.Name = "txtSlackURL";
            this.txtSlackURL.Size = new System.Drawing.Size(462, 20);
            this.txtSlackURL.TabIndex = 4;
            // 
            // btnSaveSettings
            // 
            this.btnSaveSettings.Location = new System.Drawing.Point(4, 204);
            this.btnSaveSettings.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnSaveSettings.Name = "btnSaveSettings";
            this.btnSaveSettings.Size = new System.Drawing.Size(74, 23);
            this.btnSaveSettings.TabIndex = 1;
            this.btnSaveSettings.Text = "Save";
            this.btnSaveSettings.UseVisualStyleBackColor = true;
            this.btnSaveSettings.Click += new System.EventHandler(this.btnSaveSettings_Click);
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.cboEmulator4);
            this.groupBox9.Controls.Add(this.cboEmulator3);
            this.groupBox9.Controls.Add(this.cboEmulator2);
            this.groupBox9.Controls.Add(this.cboEmulator1);
            this.groupBox9.Controls.Add(this.lblEmulator4);
            this.groupBox9.Controls.Add(this.txtEmulator4);
            this.groupBox9.Controls.Add(this.lblEmulator3);
            this.groupBox9.Controls.Add(this.txtEmulator3);
            this.groupBox9.Controls.Add(this.lblEmulator2);
            this.groupBox9.Controls.Add(this.txtEmulator2);
            this.groupBox9.Controls.Add(this.lblEmulator1);
            this.groupBox9.Controls.Add(this.txtEmulator1);
            this.groupBox9.Location = new System.Drawing.Point(3, 3);
            this.groupBox9.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox9.Size = new System.Drawing.Size(139, 100);
            this.groupBox9.TabIndex = 0;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Emulators";
            // 
            // cboEmulator4
            // 
            this.cboEmulator4.FormattingEnabled = true;
            this.cboEmulator4.Location = new System.Drawing.Point(76, 72);
            this.cboEmulator4.Name = "cboEmulator4";
            this.cboEmulator4.Size = new System.Drawing.Size(51, 21);
            this.cboEmulator4.TabIndex = 11;
            // 
            // cboEmulator3
            // 
            this.cboEmulator3.FormattingEnabled = true;
            this.cboEmulator3.Location = new System.Drawing.Point(76, 52);
            this.cboEmulator3.Name = "cboEmulator3";
            this.cboEmulator3.Size = new System.Drawing.Size(51, 21);
            this.cboEmulator3.TabIndex = 10;
            // 
            // cboEmulator2
            // 
            this.cboEmulator2.FormattingEnabled = true;
            this.cboEmulator2.Location = new System.Drawing.Point(76, 34);
            this.cboEmulator2.Name = "cboEmulator2";
            this.cboEmulator2.Size = new System.Drawing.Size(51, 21);
            this.cboEmulator2.TabIndex = 9;
            // 
            // cboEmulator1
            // 
            this.cboEmulator1.FormattingEnabled = true;
            this.cboEmulator1.Location = new System.Drawing.Point(76, 15);
            this.cboEmulator1.Name = "cboEmulator1";
            this.cboEmulator1.Size = new System.Drawing.Size(51, 21);
            this.cboEmulator1.TabIndex = 8;
            // 
            // lblEmulator4
            // 
            this.lblEmulator4.AutoSize = true;
            this.lblEmulator4.Location = new System.Drawing.Point(4, 74);
            this.lblEmulator4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEmulator4.Name = "lblEmulator4";
            this.lblEmulator4.Size = new System.Drawing.Size(13, 13);
            this.lblEmulator4.TabIndex = 7;
            this.lblEmulator4.Text = "4";
            // 
            // txtEmulator4
            // 
            this.txtEmulator4.Location = new System.Drawing.Point(18, 72);
            this.txtEmulator4.Margin = new System.Windows.Forms.Padding(2);
            this.txtEmulator4.Name = "txtEmulator4";
            this.txtEmulator4.Size = new System.Drawing.Size(52, 20);
            this.txtEmulator4.TabIndex = 6;
            // 
            // lblEmulator3
            // 
            this.lblEmulator3.AutoSize = true;
            this.lblEmulator3.Location = new System.Drawing.Point(4, 55);
            this.lblEmulator3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEmulator3.Name = "lblEmulator3";
            this.lblEmulator3.Size = new System.Drawing.Size(13, 13);
            this.lblEmulator3.TabIndex = 5;
            this.lblEmulator3.Text = "3";
            // 
            // txtEmulator3
            // 
            this.txtEmulator3.Location = new System.Drawing.Point(18, 53);
            this.txtEmulator3.Margin = new System.Windows.Forms.Padding(2);
            this.txtEmulator3.Name = "txtEmulator3";
            this.txtEmulator3.Size = new System.Drawing.Size(52, 20);
            this.txtEmulator3.TabIndex = 4;
            // 
            // lblEmulator2
            // 
            this.lblEmulator2.AutoSize = true;
            this.lblEmulator2.Location = new System.Drawing.Point(4, 35);
            this.lblEmulator2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEmulator2.Name = "lblEmulator2";
            this.lblEmulator2.Size = new System.Drawing.Size(13, 13);
            this.lblEmulator2.TabIndex = 3;
            this.lblEmulator2.Text = "2";
            // 
            // txtEmulator2
            // 
            this.txtEmulator2.Location = new System.Drawing.Point(18, 34);
            this.txtEmulator2.Margin = new System.Windows.Forms.Padding(2);
            this.txtEmulator2.Name = "txtEmulator2";
            this.txtEmulator2.Size = new System.Drawing.Size(52, 20);
            this.txtEmulator2.TabIndex = 2;
            // 
            // lblEmulator1
            // 
            this.lblEmulator1.AutoSize = true;
            this.lblEmulator1.Location = new System.Drawing.Point(4, 16);
            this.lblEmulator1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEmulator1.Name = "lblEmulator1";
            this.lblEmulator1.Size = new System.Drawing.Size(13, 13);
            this.lblEmulator1.TabIndex = 1;
            this.lblEmulator1.Text = "1";
            // 
            // txtEmulator1
            // 
            this.txtEmulator1.Location = new System.Drawing.Point(18, 15);
            this.txtEmulator1.Margin = new System.Windows.Forms.Padding(2);
            this.txtEmulator1.Name = "txtEmulator1";
            this.txtEmulator1.Size = new System.Drawing.Size(52, 20);
            this.txtEmulator1.TabIndex = 0;
            // 
            // tabDebug
            // 
            this.tabDebug.Controls.Add(this.txtScreenOrder);
            this.tabDebug.Controls.Add(this.txtBmpSize);
            this.tabDebug.Controls.Add(this.textBox18);
            this.tabDebug.Controls.Add(this.textBox19);
            this.tabDebug.Controls.Add(this.txt);
            this.tabDebug.Controls.Add(this.txtCustomY);
            this.tabDebug.Controls.Add(this.txtCustomX);
            this.tabDebug.Controls.Add(this.lblBmpChecksum);
            this.tabDebug.Controls.Add(this.picCheck);
            this.tabDebug.Controls.Add(this.label6);
            this.tabDebug.Location = new System.Drawing.Point(4, 22);
            this.tabDebug.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabDebug.Name = "tabDebug";
            this.tabDebug.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabDebug.Size = new System.Drawing.Size(585, 227);
            this.tabDebug.TabIndex = 3;
            this.tabDebug.Text = "Debug";
            this.tabDebug.UseVisualStyleBackColor = true;
            // 
            // txtScreenOrder
            // 
            this.txtScreenOrder.Location = new System.Drawing.Point(74, 40);
            this.txtScreenOrder.Multiline = true;
            this.txtScreenOrder.Name = "txtScreenOrder";
            this.txtScreenOrder.Size = new System.Drawing.Size(267, 187);
            this.txtScreenOrder.TabIndex = 29;
            // 
            // txtBmpSize
            // 
            this.txtBmpSize.Location = new System.Drawing.Point(122, 6);
            this.txtBmpSize.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtBmpSize.Name = "txtBmpSize";
            this.txtBmpSize.Size = new System.Drawing.Size(44, 20);
            this.txtBmpSize.TabIndex = 26;
            this.txtBmpSize.Text = "20";
            // 
            // textBox18
            // 
            this.textBox18.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsColorCustom, "B", true));
            this.textBox18.Enabled = false;
            this.textBox18.Location = new System.Drawing.Point(10, 108);
            this.textBox18.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textBox18.Name = "textBox18";
            this.textBox18.Size = new System.Drawing.Size(44, 20);
            this.textBox18.TabIndex = 19;
            // 
            // textBox19
            // 
            this.textBox19.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsColorCustom, "G", true));
            this.textBox19.Enabled = false;
            this.textBox19.Location = new System.Drawing.Point(10, 82);
            this.textBox19.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textBox19.Name = "textBox19";
            this.textBox19.Size = new System.Drawing.Size(44, 20);
            this.textBox19.TabIndex = 18;
            // 
            // txt
            // 
            this.txt.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsColorCustom, "R", true));
            this.txt.Enabled = false;
            this.txt.Location = new System.Drawing.Point(10, 56);
            this.txt.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt.Name = "txt";
            this.txt.Size = new System.Drawing.Size(44, 20);
            this.txt.TabIndex = 17;
            // 
            // txtCustomY
            // 
            this.txtCustomY.Location = new System.Drawing.Point(58, 7);
            this.txtCustomY.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtCustomY.Name = "txtCustomY";
            this.txtCustomY.Size = new System.Drawing.Size(44, 20);
            this.txtCustomY.TabIndex = 1;
            this.txtCustomY.Text = "0";
            // 
            // txtCustomX
            // 
            this.txtCustomX.Location = new System.Drawing.Point(10, 7);
            this.txtCustomX.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtCustomX.Name = "txtCustomX";
            this.txtCustomX.Size = new System.Drawing.Size(44, 20);
            this.txtCustomX.TabIndex = 0;
            this.txtCustomX.Text = "0";
            // 
            // lblBmpChecksum
            // 
            this.lblBmpChecksum.AutoSize = true;
            this.lblBmpChecksum.Location = new System.Drawing.Point(210, 10);
            this.lblBmpChecksum.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBmpChecksum.Name = "lblBmpChecksum";
            this.lblBmpChecksum.Size = new System.Drawing.Size(0, 13);
            this.lblBmpChecksum.TabIndex = 28;
            // 
            // picCheck
            // 
            this.picCheck.Location = new System.Drawing.Point(182, 7);
            this.picCheck.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.picCheck.Name = "picCheck";
            this.picCheck.Size = new System.Drawing.Size(20, 20);
            this.picCheck.TabIndex = 27;
            this.picCheck.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 40);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 13);
            this.label6.TabIndex = 25;
            this.label6.Text = "Custom";
            // 
            // tabActivity
            // 
            this.tabActivity.Controls.Add(this.contActivity);
            this.tabActivity.Location = new System.Drawing.Point(4, 22);
            this.tabActivity.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabActivity.Name = "tabActivity";
            this.tabActivity.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabActivity.Size = new System.Drawing.Size(585, 227);
            this.tabActivity.TabIndex = 2;
            this.tabActivity.Text = "Activity";
            this.tabActivity.UseVisualStyleBackColor = true;
            // 
            // contActivity
            // 
            this.contActivity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contActivity.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.contActivity.Location = new System.Drawing.Point(2, 3);
            this.contActivity.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.contActivity.Name = "contActivity";
            // 
            // contActivity.Panel1
            // 
            this.contActivity.Panel1.Controls.Add(this.gridPacket);
            // 
            // contActivity.Panel2
            // 
            this.contActivity.Panel2.Controls.Add(this.splitContainer2);
            this.contActivity.Size = new System.Drawing.Size(581, 221);
            this.contActivity.SplitterDistance = 270;
            this.contActivity.TabIndex = 20;
            // 
            // gridPacket
            // 
            this.gridPacket.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.gridPacket.AllowDrop = true;
            this.gridPacket.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridPacket.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridPacket.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridPacket.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.timestampDataGridViewTextBoxColumn,
            this.typeDataGridViewTextBoxColumn,
            this.lengthDataGridViewTextBoxColumn,
            this.Id});
            this.gridPacket.DataSource = this.bsPacket;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridPacket.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridPacket.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridPacket.Location = new System.Drawing.Point(0, 0);
            this.gridPacket.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.gridPacket.Name = "gridPacket";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridPacket.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gridPacket.Size = new System.Drawing.Size(270, 221);
            this.gridPacket.TabIndex = 17;
            // 
            // timestampDataGridViewTextBoxColumn
            // 
            this.timestampDataGridViewTextBoxColumn.DataPropertyName = "Timestamp";
            this.timestampDataGridViewTextBoxColumn.HeaderText = "Timestamp";
            this.timestampDataGridViewTextBoxColumn.Name = "timestampDataGridViewTextBoxColumn";
            // 
            // typeDataGridViewTextBoxColumn
            // 
            this.typeDataGridViewTextBoxColumn.DataPropertyName = "Type";
            this.typeDataGridViewTextBoxColumn.HeaderText = "Type";
            this.typeDataGridViewTextBoxColumn.Name = "typeDataGridViewTextBoxColumn";
            this.typeDataGridViewTextBoxColumn.Width = 60;
            // 
            // lengthDataGridViewTextBoxColumn
            // 
            this.lengthDataGridViewTextBoxColumn.DataPropertyName = "Length";
            this.lengthDataGridViewTextBoxColumn.HeaderText = "Length";
            this.lengthDataGridViewTextBoxColumn.Name = "lengthDataGridViewTextBoxColumn";
            this.lengthDataGridViewTextBoxColumn.Width = 50;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            // 
            // bsPacket
            // 
            this.bsPacket.DataSource = typeof(CodeStrikeBot.Messages.Message);
            this.bsPacket.CurrentChanged += new System.EventHandler(this.bsPacket_CurrentChanged);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.btnCopyText);
            this.splitContainer2.Panel1.Controls.Add(this.btnExport);
            this.splitContainer2.Panel1.Controls.Add(this.rdoRaw);
            this.splitContainer2.Panel1.Controls.Add(this.rdoPayload);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer1);
            this.splitContainer2.Size = new System.Drawing.Size(307, 221);
            this.splitContainer2.SplitterDistance = 30;
            this.splitContainer2.TabIndex = 20;
            // 
            // btnCopyText
            // 
            this.btnCopyText.Location = new System.Drawing.Point(208, 4);
            this.btnCopyText.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnCopyText.Name = "btnCopyText";
            this.btnCopyText.Size = new System.Drawing.Size(74, 23);
            this.btnCopyText.TabIndex = 3;
            this.btnCopyText.Text = "Copy Text";
            this.btnCopyText.UseVisualStyleBackColor = true;
            this.btnCopyText.Click += new System.EventHandler(this.btnCopyText_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(126, 4);
            this.btnExport.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(74, 23);
            this.btnExport.TabIndex = 2;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            // 
            // rdoRaw
            // 
            this.rdoRaw.AutoSize = true;
            this.rdoRaw.Location = new System.Drawing.Point(74, 7);
            this.rdoRaw.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.rdoRaw.Name = "rdoRaw";
            this.rdoRaw.Size = new System.Drawing.Size(47, 17);
            this.rdoRaw.TabIndex = 1;
            this.rdoRaw.Text = "Raw";
            this.rdoRaw.UseVisualStyleBackColor = true;
            this.rdoRaw.CheckedChanged += new System.EventHandler(this.rdoRaw_CheckedChanged);
            // 
            // rdoPayload
            // 
            this.rdoPayload.AutoSize = true;
            this.rdoPayload.Checked = true;
            this.rdoPayload.Location = new System.Drawing.Point(4, 7);
            this.rdoPayload.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.rdoPayload.Name = "rdoPayload";
            this.rdoPayload.Size = new System.Drawing.Size(63, 17);
            this.rdoPayload.TabIndex = 0;
            this.rdoPayload.TabStop = true;
            this.rdoPayload.Text = "Payload";
            this.rdoPayload.UseVisualStyleBackColor = true;
            this.rdoPayload.CheckedChanged += new System.EventHandler(this.rdoPayload_CheckedChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.hexData);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.treeXml);
            this.splitContainer1.Size = new System.Drawing.Size(307, 187);
            this.splitContainer1.SplitterDistance = 88;
            this.splitContainer1.TabIndex = 19;
            // 
            // hexData
            // 
            this.hexData.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.hexData.ColumnCount = 1;
            this.hexData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hexData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hexData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hexData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hexData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hexData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hexData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hexData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hexData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hexData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hexData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hexData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hexData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hexData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hexData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hexData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hexData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hexData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hexData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hexData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hexData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hexData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hexData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hexData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hexData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hexData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hexData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hexData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hexData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hexData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hexData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hexData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hexData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hexData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hexData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hexData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hexData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hexData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hexData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hexData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hexData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hexData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hexData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hexData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hexData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hexData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hexData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hexData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hexData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hexData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hexData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hexData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hexData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hexData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hexData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hexData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hexData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hexData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hexData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hexData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hexData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hexData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hexData.Location = new System.Drawing.Point(0, 0);
            this.hexData.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.hexData.Name = "hexData";
            this.hexData.RowCount = 1;
            this.hexData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hexData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hexData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hexData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hexData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hexData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hexData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hexData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hexData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hexData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hexData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hexData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hexData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hexData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hexData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hexData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hexData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hexData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hexData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hexData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hexData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hexData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hexData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hexData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hexData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hexData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hexData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hexData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hexData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hexData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hexData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hexData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hexData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hexData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hexData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hexData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hexData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hexData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hexData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hexData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hexData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hexData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hexData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hexData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hexData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hexData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hexData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hexData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hexData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hexData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hexData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hexData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hexData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hexData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hexData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hexData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hexData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hexData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hexData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hexData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hexData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hexData.Size = new System.Drawing.Size(307, 88);
            this.hexData.TabIndex = 18;
            // 
            // treeXml
            // 
            this.treeXml.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeXml.Location = new System.Drawing.Point(0, 0);
            this.treeXml.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.treeXml.Name = "treeXml";
            this.treeXml.Size = new System.Drawing.Size(307, 95);
            this.treeXml.TabIndex = 0;
            // 
            // tabAccounts
            // 
            this.tabAccounts.Controls.Add(this.splitContainer3);
            this.tabAccounts.Location = new System.Drawing.Point(4, 22);
            this.tabAccounts.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabAccounts.Name = "tabAccounts";
            this.tabAccounts.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabAccounts.Size = new System.Drawing.Size(585, 227);
            this.tabAccounts.TabIndex = 4;
            this.tabAccounts.Text = "Accounts";
            this.tabAccounts.UseVisualStyleBackColor = true;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(2, 3);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.lblAccountApp);
            this.splitContainer3.Panel1.Controls.Add(this.cboAccountAppFilter);
            this.splitContainer3.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.groupBox8);
            this.splitContainer3.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer3.Size = new System.Drawing.Size(581, 221);
            this.splitContainer3.SplitterDistance = 29;
            this.splitContainer3.TabIndex = 19;
            // 
            // lblAccountApp
            // 
            this.lblAccountApp.AutoSize = true;
            this.lblAccountApp.Location = new System.Drawing.Point(6, 6);
            this.lblAccountApp.Name = "lblAccountApp";
            this.lblAccountApp.Size = new System.Drawing.Size(26, 13);
            this.lblAccountApp.TabIndex = 1;
            this.lblAccountApp.Text = "App";
            // 
            // cboAccountAppFilter
            // 
            this.cboAccountAppFilter.Enabled = false;
            this.cboAccountAppFilter.FormattingEnabled = true;
            this.cboAccountAppFilter.Location = new System.Drawing.Point(38, 3);
            this.cboAccountAppFilter.Name = "cboAccountAppFilter";
            this.cboAccountAppFilter.Size = new System.Drawing.Size(121, 21);
            this.cboAccountAppFilter.TabIndex = 0;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.gridAccounts);
            this.groupBox8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox8.Location = new System.Drawing.Point(0, 0);
            this.groupBox8.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox8.Size = new System.Drawing.Size(581, 188);
            this.groupBox8.TabIndex = 18;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Setup";
            // 
            // gridAccounts
            // 
            this.gridAccounts.AutoGenerateColumns = false;
            this.gridAccounts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.gridAccounts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridAccounts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn,
            this.userNameDataGridViewTextBoxColumn,
            this.emailDataGridViewTextBoxColumn,
            this.passwordDataGridViewTextBoxColumn,
            this.priorityGridViewComboBoxColumn,
            this.foodNegativeAmountDataGridViewTextBoxColumn,
            this.lastLoginDataGridViewTextBoxColumn,
            this.lastLogoutDataGridViewTextBoxColumn});
            this.gridAccounts.DataSource = this.bsAccount;
            this.gridAccounts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridAccounts.Location = new System.Drawing.Point(2, 16);
            this.gridAccounts.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.gridAccounts.Name = "gridAccounts";
            this.gridAccounts.Size = new System.Drawing.Size(577, 169);
            this.gridAccounts.TabIndex = 0;
            this.gridAccounts.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.gridAccounts_CellFormatting);
            this.gridAccounts.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridAccounts_CellLeave);
            this.gridAccounts.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.gridAccounts_EditingControlShowing);
            this.gridAccounts.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.gridAccounts_UserDeletingRow);
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.Width = 60;
            // 
            // userNameDataGridViewTextBoxColumn
            // 
            this.userNameDataGridViewTextBoxColumn.DataPropertyName = "UserName";
            this.userNameDataGridViewTextBoxColumn.HeaderText = "UserName";
            this.userNameDataGridViewTextBoxColumn.Name = "userNameDataGridViewTextBoxColumn";
            this.userNameDataGridViewTextBoxColumn.Width = 82;
            // 
            // emailDataGridViewTextBoxColumn
            // 
            this.emailDataGridViewTextBoxColumn.DataPropertyName = "Email";
            this.emailDataGridViewTextBoxColumn.HeaderText = "Email";
            this.emailDataGridViewTextBoxColumn.Name = "emailDataGridViewTextBoxColumn";
            this.emailDataGridViewTextBoxColumn.Width = 57;
            // 
            // passwordDataGridViewTextBoxColumn
            // 
            this.passwordDataGridViewTextBoxColumn.DataPropertyName = "Password";
            this.passwordDataGridViewTextBoxColumn.HeaderText = "Password";
            this.passwordDataGridViewTextBoxColumn.Name = "passwordDataGridViewTextBoxColumn";
            this.passwordDataGridViewTextBoxColumn.Width = 78;
            // 
            // priorityGridViewComboBoxColumn
            // 
            this.priorityGridViewComboBoxColumn.DataPropertyName = "Priority";
            this.priorityGridViewComboBoxColumn.HeaderText = "Priority";
            this.priorityGridViewComboBoxColumn.Name = "priorityGridViewComboBoxColumn";
            this.priorityGridViewComboBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.priorityGridViewComboBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.priorityGridViewComboBoxColumn.Width = 63;
            // 
            // foodNegativeAmountDataGridViewTextBoxColumn
            // 
            this.foodNegativeAmountDataGridViewTextBoxColumn.DataPropertyName = "FoodNegativeAmount";
            this.foodNegativeAmountDataGridViewTextBoxColumn.HeaderText = "FoodNegativeAmount";
            this.foodNegativeAmountDataGridViewTextBoxColumn.Name = "foodNegativeAmountDataGridViewTextBoxColumn";
            this.foodNegativeAmountDataGridViewTextBoxColumn.Width = 135;
            // 
            // lastLoginDataGridViewTextBoxColumn
            // 
            this.lastLoginDataGridViewTextBoxColumn.DataPropertyName = "LastLogin";
            this.lastLoginDataGridViewTextBoxColumn.HeaderText = "LastLogin";
            this.lastLoginDataGridViewTextBoxColumn.Name = "lastLoginDataGridViewTextBoxColumn";
            this.lastLoginDataGridViewTextBoxColumn.ReadOnly = true;
            this.lastLoginDataGridViewTextBoxColumn.Width = 78;
            // 
            // lastLogoutDataGridViewTextBoxColumn
            // 
            this.lastLogoutDataGridViewTextBoxColumn.DataPropertyName = "LastLogout";
            this.lastLogoutDataGridViewTextBoxColumn.HeaderText = "LastLogout";
            this.lastLogoutDataGridViewTextBoxColumn.Name = "lastLogoutDataGridViewTextBoxColumn";
            this.lastLogoutDataGridViewTextBoxColumn.ReadOnly = true;
            this.lastLogoutDataGridViewTextBoxColumn.Width = 85;
            // 
            // bsAccount
            // 
            this.bsAccount.DataSource = typeof(CodeStrikeBot.DataObjects.Account);
            // 
            // tabScreens
            // 
            this.tabScreens.Controls.Add(this.groupBox7);
            this.tabScreens.Controls.Add(this.groupBox5);
            this.tabScreens.Controls.Add(this.groupBox3);
            this.tabScreens.Controls.Add(this.groupBox4);
            this.tabScreens.Location = new System.Drawing.Point(4, 22);
            this.tabScreens.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabScreens.Name = "tabScreens";
            this.tabScreens.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabScreens.Size = new System.Drawing.Size(585, 227);
            this.tabScreens.TabIndex = 1;
            this.tabScreens.Text = "Session";
            this.tabScreens.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.btnScheduleRun);
            this.groupBox7.Controls.Add(this.gridSchedules);
            this.groupBox7.Location = new System.Drawing.Point(266, 7);
            this.groupBox7.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox7.Size = new System.Drawing.Size(359, 218);
            this.groupBox7.TabIndex = 17;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Schedules";
            // 
            // btnScheduleRun
            // 
            this.btnScheduleRun.Location = new System.Drawing.Point(4, 189);
            this.btnScheduleRun.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnScheduleRun.Name = "btnScheduleRun";
            this.btnScheduleRun.Size = new System.Drawing.Size(74, 23);
            this.btnScheduleRun.TabIndex = 1;
            this.btnScheduleRun.Text = "Manual Run";
            this.btnScheduleRun.UseVisualStyleBackColor = true;
            this.btnScheduleRun.Click += new System.EventHandler(this.btnScheduleRun_Click);
            // 
            // gridSchedules
            // 
            this.gridSchedules.AutoGenerateColumns = false;
            this.gridSchedules.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.gridSchedules.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridSchedules.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.typeDataGridViewComboBoxColumn,
            this.intervalDataGridViewTextBoxColumn,
            this.amountDataGridViewTextBoxColumn,
            this.countDataGridViewTextBoxColumn,
            this.xDataGridViewTextBoxColumn,
            this.yDataGridViewTextBoxColumn,
            this.BackupX,
            this.BackupY,
            this.lastActionDataGridViewTextBoxColumn,
            this.nextActionDataGridViewTextBoxColumn});
            this.gridSchedules.DataSource = this.bsScheduleTask;
            this.gridSchedules.Location = new System.Drawing.Point(6, 19);
            this.gridSchedules.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.gridSchedules.Name = "gridSchedules";
            this.gridSchedules.Size = new System.Drawing.Size(349, 164);
            this.gridSchedules.TabIndex = 0;
            this.gridSchedules.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridSchedules_CellLeave);
            this.gridSchedules.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.gridSchedules_UserDeletingRow);
            // 
            // typeDataGridViewComboBoxColumn
            // 
            this.typeDataGridViewComboBoxColumn.DataPropertyName = "Type";
            this.typeDataGridViewComboBoxColumn.HeaderText = "Type";
            this.typeDataGridViewComboBoxColumn.Name = "typeDataGridViewComboBoxColumn";
            this.typeDataGridViewComboBoxColumn.Width = 37;
            // 
            // intervalDataGridViewTextBoxColumn
            // 
            this.intervalDataGridViewTextBoxColumn.DataPropertyName = "Interval";
            this.intervalDataGridViewTextBoxColumn.HeaderText = "Interval";
            this.intervalDataGridViewTextBoxColumn.MaxInputLength = 9;
            this.intervalDataGridViewTextBoxColumn.Name = "intervalDataGridViewTextBoxColumn";
            this.intervalDataGridViewTextBoxColumn.Width = 67;
            // 
            // amountDataGridViewTextBoxColumn
            // 
            this.amountDataGridViewTextBoxColumn.DataPropertyName = "Amount";
            this.amountDataGridViewTextBoxColumn.HeaderText = "Amount";
            this.amountDataGridViewTextBoxColumn.MaxInputLength = 9;
            this.amountDataGridViewTextBoxColumn.Name = "amountDataGridViewTextBoxColumn";
            this.amountDataGridViewTextBoxColumn.Width = 68;
            // 
            // countDataGridViewTextBoxColumn
            // 
            this.countDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.countDataGridViewTextBoxColumn.DataPropertyName = "Count";
            this.countDataGridViewTextBoxColumn.HeaderText = "Count";
            this.countDataGridViewTextBoxColumn.MaxInputLength = 9;
            this.countDataGridViewTextBoxColumn.Name = "countDataGridViewTextBoxColumn";
            this.countDataGridViewTextBoxColumn.Width = 35;
            // 
            // xDataGridViewTextBoxColumn
            // 
            this.xDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.xDataGridViewTextBoxColumn.DataPropertyName = "X";
            this.xDataGridViewTextBoxColumn.HeaderText = "X";
            this.xDataGridViewTextBoxColumn.MaxInputLength = 4;
            this.xDataGridViewTextBoxColumn.Name = "xDataGridViewTextBoxColumn";
            this.xDataGridViewTextBoxColumn.Width = 35;
            // 
            // yDataGridViewTextBoxColumn
            // 
            this.yDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.yDataGridViewTextBoxColumn.DataPropertyName = "Y";
            this.yDataGridViewTextBoxColumn.HeaderText = "Y";
            this.yDataGridViewTextBoxColumn.MaxInputLength = 4;
            this.yDataGridViewTextBoxColumn.Name = "yDataGridViewTextBoxColumn";
            this.yDataGridViewTextBoxColumn.Width = 35;
            // 
            // BackupX
            // 
            this.BackupX.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.BackupX.DataPropertyName = "BackupX";
            this.BackupX.HeaderText = "BackupX";
            this.BackupX.MaxInputLength = 4;
            this.BackupX.Name = "BackupX";
            this.BackupX.Width = 60;
            // 
            // BackupY
            // 
            this.BackupY.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.BackupY.DataPropertyName = "BackupY";
            this.BackupY.HeaderText = "BackupY";
            this.BackupY.MaxInputLength = 4;
            this.BackupY.Name = "BackupY";
            this.BackupY.Width = 60;
            // 
            // lastActionDataGridViewTextBoxColumn
            // 
            this.lastActionDataGridViewTextBoxColumn.DataPropertyName = "LastAction";
            this.lastActionDataGridViewTextBoxColumn.HeaderText = "LastAction";
            this.lastActionDataGridViewTextBoxColumn.Name = "lastActionDataGridViewTextBoxColumn";
            this.lastActionDataGridViewTextBoxColumn.Width = 82;
            // 
            // nextActionDataGridViewTextBoxColumn
            // 
            this.nextActionDataGridViewTextBoxColumn.DataPropertyName = "NextAction";
            this.nextActionDataGridViewTextBoxColumn.HeaderText = "NextAction";
            this.nextActionDataGridViewTextBoxColumn.Name = "nextActionDataGridViewTextBoxColumn";
            this.nextActionDataGridViewTextBoxColumn.ReadOnly = true;
            this.nextActionDataGridViewTextBoxColumn.Width = 84;
            // 
            // bsScheduleTask
            // 
            this.bsScheduleTask.DataSource = typeof(CodeStrikeBot.DataObjects.ScheduleTask);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnResize);
            this.groupBox5.Location = new System.Drawing.Point(6, 67);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox5.Size = new System.Drawing.Size(126, 158);
            this.groupBox5.TabIndex = 16;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Windows Tasks";
            // 
            // btnResize
            // 
            this.btnResize.Location = new System.Drawing.Point(6, 20);
            this.btnResize.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnResize.Name = "btnResize";
            this.btnResize.Size = new System.Drawing.Size(74, 23);
            this.btnResize.TabIndex = 0;
            this.btnResize.Text = "Resize";
            this.btnResize.UseVisualStyleBackColor = true;
            this.btnResize.Click += new System.EventHandler(this.btnResize_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lstAccounts);
            this.groupBox3.Controls.Add(this.btnSwitch);
            this.groupBox3.Location = new System.Drawing.Point(140, 6);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox3.Size = new System.Drawing.Size(120, 219);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Active Session";
            // 
            // lstAccounts
            // 
            this.lstAccounts.FormattingEnabled = true;
            this.lstAccounts.Location = new System.Drawing.Point(6, 19);
            this.lstAccounts.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.lstAccounts.Name = "lstAccounts";
            this.lstAccounts.Size = new System.Drawing.Size(108, 160);
            this.lstAccounts.TabIndex = 10;
            this.lstAccounts.SelectedIndexChanged += new System.EventHandler(this.lstAccounts_SelectedIndexChanged);
            // 
            // btnSwitch
            // 
            this.btnSwitch.Location = new System.Drawing.Point(4, 190);
            this.btnSwitch.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnSwitch.Name = "btnSwitch";
            this.btnSwitch.Size = new System.Drawing.Size(74, 23);
            this.btnSwitch.TabIndex = 11;
            this.btnSwitch.Text = "Switch";
            this.btnSwitch.UseVisualStyleBackColor = true;
            this.btnSwitch.Click += new System.EventHandler(this.btnSwitch_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rdoWindow4);
            this.groupBox4.Controls.Add(this.rdoWindow3);
            this.groupBox4.Controls.Add(this.rdoWindow2);
            this.groupBox4.Controls.Add(this.rdoWindow1);
            this.groupBox4.Location = new System.Drawing.Point(6, 6);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox4.Size = new System.Drawing.Size(128, 53);
            this.groupBox4.TabIndex = 15;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Active Window";
            // 
            // rdoWindow4
            // 
            this.rdoWindow4.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoWindow4.AutoSize = true;
            this.rdoWindow4.Location = new System.Drawing.Point(94, 19);
            this.rdoWindow4.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.rdoWindow4.Name = "rdoWindow4";
            this.rdoWindow4.Size = new System.Drawing.Size(23, 23);
            this.rdoWindow4.TabIndex = 22;
            this.rdoWindow4.TabStop = true;
            this.rdoWindow4.Text = "4";
            this.rdoWindow4.UseVisualStyleBackColor = true;
            this.rdoWindow4.CheckedChanged += new System.EventHandler(this.rdoWindow4_CheckedChanged);
            this.rdoWindow4.MouseUp += new System.Windows.Forms.MouseEventHandler(this.rdoWindow4_MouseUp);
            // 
            // rdoWindow3
            // 
            this.rdoWindow3.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoWindow3.AutoSize = true;
            this.rdoWindow3.Location = new System.Drawing.Point(64, 19);
            this.rdoWindow3.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.rdoWindow3.Name = "rdoWindow3";
            this.rdoWindow3.Size = new System.Drawing.Size(23, 23);
            this.rdoWindow3.TabIndex = 21;
            this.rdoWindow3.TabStop = true;
            this.rdoWindow3.Text = "3";
            this.rdoWindow3.UseVisualStyleBackColor = true;
            this.rdoWindow3.CheckedChanged += new System.EventHandler(this.rdoWindow3_CheckedChanged);
            this.rdoWindow3.MouseUp += new System.Windows.Forms.MouseEventHandler(this.rdoWindow3_MouseUp);
            // 
            // rdoWindow2
            // 
            this.rdoWindow2.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoWindow2.AutoSize = true;
            this.rdoWindow2.Location = new System.Drawing.Point(34, 19);
            this.rdoWindow2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.rdoWindow2.Name = "rdoWindow2";
            this.rdoWindow2.Size = new System.Drawing.Size(23, 23);
            this.rdoWindow2.TabIndex = 20;
            this.rdoWindow2.TabStop = true;
            this.rdoWindow2.Text = "2";
            this.rdoWindow2.UseVisualStyleBackColor = true;
            this.rdoWindow2.CheckedChanged += new System.EventHandler(this.rdoWindow2_CheckedChanged);
            this.rdoWindow2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.rdoWindow2_MouseUp);
            // 
            // rdoWindow1
            // 
            this.rdoWindow1.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoWindow1.AutoSize = true;
            this.rdoWindow1.Checked = true;
            this.rdoWindow1.Location = new System.Drawing.Point(6, 19);
            this.rdoWindow1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.rdoWindow1.Name = "rdoWindow1";
            this.rdoWindow1.Size = new System.Drawing.Size(23, 23);
            this.rdoWindow1.TabIndex = 16;
            this.rdoWindow1.TabStop = true;
            this.rdoWindow1.Text = "1";
            this.rdoWindow1.UseVisualStyleBackColor = true;
            this.rdoWindow1.CheckedChanged += new System.EventHandler(this.rdoWindow1_CheckedChanged);
            this.rdoWindow1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.rdoWindow1_MouseUp);
            // 
            // tabTasks
            // 
            this.tabTasks.Controls.Add(this.groupBox6);
            this.tabTasks.Controls.Add(this.groupBox1);
            this.tabTasks.Controls.Add(this.groupBox2);
            this.tabTasks.Location = new System.Drawing.Point(4, 22);
            this.tabTasks.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabTasks.Name = "tabTasks";
            this.tabTasks.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabTasks.Size = new System.Drawing.Size(585, 227);
            this.tabTasks.TabIndex = 0;
            this.tabTasks.Text = "Tasks";
            this.tabTasks.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.txtColStart);
            this.groupBox6.Controls.Add(this.btnRestart);
            this.groupBox6.Controls.Add(this.btnMap);
            this.groupBox6.Controls.Add(this.btnGrowXP);
            this.groupBox6.Controls.Add(this.btnTest);
            this.groupBox6.Controls.Add(this.btnSearchEnemy);
            this.groupBox6.Controls.Add(this.btnMissionXP);
            this.groupBox6.Controls.Add(this.txtSliceStartX);
            this.groupBox6.Controls.Add(this.txtSliceStartY);
            this.groupBox6.Controls.Add(this.txtRowStart);
            this.groupBox6.Location = new System.Drawing.Point(330, 6);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox6.Size = new System.Drawing.Size(250, 102);
            this.groupBox6.TabIndex = 14;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Debug";
            // 
            // txtColStart
            // 
            this.txtColStart.Location = new System.Drawing.Point(146, 77);
            this.txtColStart.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtColStart.Name = "txtColStart";
            this.txtColStart.Size = new System.Drawing.Size(42, 20);
            this.txtColStart.TabIndex = 12;
            this.txtColStart.Text = "0";
            // 
            // btnRestart
            // 
            this.btnRestart.Location = new System.Drawing.Point(190, 19);
            this.btnRestart.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(50, 23);
            this.btnRestart.TabIndex = 11;
            this.btnRestart.Text = "Restart";
            this.btnRestart.UseVisualStyleBackColor = true;
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // btnMap
            // 
            this.btnMap.Location = new System.Drawing.Point(6, 48);
            this.btnMap.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnMap.Name = "btnMap";
            this.btnMap.Size = new System.Drawing.Size(74, 23);
            this.btnMap.TabIndex = 0;
            this.btnMap.Text = "Map";
            this.btnMap.UseVisualStyleBackColor = true;
            this.btnMap.Click += new System.EventHandler(this.btnMap_Click);
            // 
            // btnGrowXP
            // 
            this.btnGrowXP.Location = new System.Drawing.Point(6, 19);
            this.btnGrowXP.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnGrowXP.Name = "btnGrowXP";
            this.btnGrowXP.Size = new System.Drawing.Size(54, 23);
            this.btnGrowXP.TabIndex = 8;
            this.btnGrowXP.Text = "Mine XP";
            this.btnGrowXP.UseVisualStyleBackColor = true;
            this.btnGrowXP.Click += new System.EventHandler(this.btnGrowXP_Click);
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(66, 19);
            this.btnTest.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(42, 23);
            this.btnTest.TabIndex = 1;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnSearchEnemy
            // 
            this.btnSearchEnemy.Location = new System.Drawing.Point(86, 48);
            this.btnSearchEnemy.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnSearchEnemy.Name = "btnSearchEnemy";
            this.btnSearchEnemy.Size = new System.Drawing.Size(74, 23);
            this.btnSearchEnemy.TabIndex = 9;
            this.btnSearchEnemy.Text = "Enemy";
            this.btnSearchEnemy.UseVisualStyleBackColor = true;
            this.btnSearchEnemy.Click += new System.EventHandler(this.btnSearchEnemy_Click);
            // 
            // btnMissionXP
            // 
            this.btnMissionXP.Location = new System.Drawing.Point(116, 19);
            this.btnMissionXP.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnMissionXP.Name = "btnMissionXP";
            this.btnMissionXP.Size = new System.Drawing.Size(66, 23);
            this.btnMissionXP.TabIndex = 10;
            this.btnMissionXP.Text = "Mission XP";
            this.btnMissionXP.UseVisualStyleBackColor = true;
            this.btnMissionXP.Click += new System.EventHandler(this.btnMissionXP_Click);
            // 
            // txtSliceStartX
            // 
            this.txtSliceStartX.Location = new System.Drawing.Point(6, 77);
            this.txtSliceStartX.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtSliceStartX.Name = "txtSliceStartX";
            this.txtSliceStartX.Size = new System.Drawing.Size(42, 20);
            this.txtSliceStartX.TabIndex = 4;
            this.txtSliceStartX.Text = "0";
            // 
            // txtSliceStartY
            // 
            this.txtSliceStartY.Location = new System.Drawing.Point(52, 77);
            this.txtSliceStartY.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtSliceStartY.Name = "txtSliceStartY";
            this.txtSliceStartY.Size = new System.Drawing.Size(42, 20);
            this.txtSliceStartY.TabIndex = 5;
            this.txtSliceStartY.Text = "0";
            // 
            // txtRowStart
            // 
            this.txtRowStart.Location = new System.Drawing.Point(100, 77);
            this.txtRowStart.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtRowStart.Name = "txtRowStart";
            this.txtRowStart.Size = new System.Drawing.Size(42, 20);
            this.txtRowStart.TabIndex = 6;
            this.txtRowStart.Text = "0";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnScreen);
            this.groupBox1.Controls.Add(this.txtScreen);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox1.Size = new System.Drawing.Size(318, 81);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mapping";
            // 
            // btnScreen
            // 
            this.btnScreen.Location = new System.Drawing.Point(6, 19);
            this.btnScreen.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnScreen.Name = "btnScreen";
            this.btnScreen.Size = new System.Drawing.Size(74, 23);
            this.btnScreen.TabIndex = 2;
            this.btnScreen.Text = "Screen";
            this.btnScreen.UseVisualStyleBackColor = true;
            this.btnScreen.Click += new System.EventHandler(this.btnScreen_Click);
            // 
            // txtScreen
            // 
            this.txtScreen.Location = new System.Drawing.Point(86, 21);
            this.txtScreen.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtScreen.Name = "txtScreen";
            this.txtScreen.Size = new System.Drawing.Size(100, 20);
            this.txtScreen.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnBoostModifier);
            this.groupBox2.Controls.Add(this.chkScheduler);
            this.groupBox2.Controls.Add(this.btnScheduler);
            this.groupBox2.Controls.Add(this.btnMissions);
            this.groupBox2.Controls.Add(this.chkTasks);
            this.groupBox2.Controls.Add(this.btnTasks);
            this.groupBox2.Controls.Add(this.btnClearGifts);
            this.groupBox2.Location = new System.Drawing.Point(6, 93);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox2.Size = new System.Drawing.Size(318, 75);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Routines";
            // 
            // btnBoostModifier
            // 
            this.btnBoostModifier.Location = new System.Drawing.Point(240, 19);
            this.btnBoostModifier.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnBoostModifier.Name = "btnBoostModifier";
            this.btnBoostModifier.Size = new System.Drawing.Size(62, 23);
            this.btnBoostModifier.TabIndex = 16;
            this.btnBoostModifier.Text = "Boost";
            this.btnBoostModifier.UseVisualStyleBackColor = true;
            this.btnBoostModifier.Click += new System.EventHandler(this.btnBoostModifier_Click);
            // 
            // chkScheduler
            // 
            this.chkScheduler.AutoSize = true;
            this.chkScheduler.Location = new System.Drawing.Point(60, 48);
            this.chkScheduler.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.chkScheduler.Name = "chkScheduler";
            this.chkScheduler.Size = new System.Drawing.Size(74, 17);
            this.chkScheduler.TabIndex = 15;
            this.chkScheduler.Text = "Scheduler";
            this.chkScheduler.UseVisualStyleBackColor = true;
            this.chkScheduler.CheckedChanged += new System.EventHandler(this.chkScheduler_CheckedChanged);
            // 
            // btnScheduler
            // 
            this.btnScheduler.Location = new System.Drawing.Point(174, 19);
            this.btnScheduler.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnScheduler.Name = "btnScheduler";
            this.btnScheduler.Size = new System.Drawing.Size(62, 23);
            this.btnScheduler.TabIndex = 14;
            this.btnScheduler.Text = "Scheduler";
            this.btnScheduler.UseVisualStyleBackColor = true;
            this.btnScheduler.Click += new System.EventHandler(this.btnScheduler_Click);
            // 
            // btnMissions
            // 
            this.btnMissions.Location = new System.Drawing.Point(110, 19);
            this.btnMissions.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnMissions.Name = "btnMissions";
            this.btnMissions.Size = new System.Drawing.Size(58, 23);
            this.btnMissions.TabIndex = 13;
            this.btnMissions.Text = "Missions";
            this.btnMissions.UseVisualStyleBackColor = true;
            this.btnMissions.Click += new System.EventHandler(this.btnMissions_Click);
            // 
            // chkTasks
            // 
            this.chkTasks.AutoSize = true;
            this.chkTasks.Location = new System.Drawing.Point(6, 48);
            this.chkTasks.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.chkTasks.Name = "chkTasks";
            this.chkTasks.Size = new System.Drawing.Size(55, 17);
            this.chkTasks.TabIndex = 12;
            this.chkTasks.Text = "Tasks";
            this.chkTasks.UseVisualStyleBackColor = true;
            this.chkTasks.CheckedChanged += new System.EventHandler(this.chkTasks_CheckedChanged);
            // 
            // btnTasks
            // 
            this.btnTasks.Location = new System.Drawing.Point(6, 19);
            this.btnTasks.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnTasks.Name = "btnTasks";
            this.btnTasks.Size = new System.Drawing.Size(48, 23);
            this.btnTasks.TabIndex = 11;
            this.btnTasks.Text = "Tasks";
            this.btnTasks.UseVisualStyleBackColor = true;
            this.btnTasks.Click += new System.EventHandler(this.btnTasks_Click);
            // 
            // btnClearGifts
            // 
            this.btnClearGifts.Location = new System.Drawing.Point(60, 19);
            this.btnClearGifts.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnClearGifts.Name = "btnClearGifts";
            this.btnClearGifts.Size = new System.Drawing.Size(46, 23);
            this.btnClearGifts.TabIndex = 9;
            this.btnClearGifts.Text = "Gifts";
            this.btnClearGifts.UseVisualStyleBackColor = true;
            this.btnClearGifts.Click += new System.EventHandler(this.btnClearGifts_Click);
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabTasks);
            this.tabControlMain.Controls.Add(this.tabScreens);
            this.tabControlMain.Controls.Add(this.tabAccounts);
            this.tabControlMain.Controls.Add(this.tabActivity);
            this.tabControlMain.Controls.Add(this.tabDebug);
            this.tabControlMain.Controls.Add(this.tabSettings);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Location = new System.Drawing.Point(0, 0);
            this.tabControlMain.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(593, 253);
            this.tabControlMain.TabIndex = 16;
            this.tabControlMain.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControlMain_Selected);
            // 
            // FormContainer
            // 
            this.FormContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FormContainer.Location = new System.Drawing.Point(0, 0);
            this.FormContainer.Margin = new System.Windows.Forms.Padding(2);
            this.FormContainer.Name = "FormContainer";
            // 
            // FormContainer.Panel1
            // 
            this.FormContainer.Panel1.Controls.Add(this.tabControlMain);
            // 
            // FormContainer.Panel2
            // 
            this.FormContainer.Panel2.Controls.Add(this.tabControlMonitor);
            this.FormContainer.Size = new System.Drawing.Size(962, 253);
            this.FormContainer.SplitterDistance = 593;
            this.FormContainer.SplitterWidth = 2;
            this.FormContainer.TabIndex = 17;
            // 
            // tabControlMonitor
            // 
            this.tabControlMonitor.Controls.Add(this.tabMonitor);
            this.tabControlMonitor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMonitor.Location = new System.Drawing.Point(0, 0);
            this.tabControlMonitor.Margin = new System.Windows.Forms.Padding(2);
            this.tabControlMonitor.Name = "tabControlMonitor";
            this.tabControlMonitor.SelectedIndex = 0;
            this.tabControlMonitor.Size = new System.Drawing.Size(367, 253);
            this.tabControlMonitor.TabIndex = 0;
            // 
            // tabMonitor
            // 
            this.tabMonitor.Controls.Add(this.grpRadar);
            this.tabMonitor.Location = new System.Drawing.Point(4, 22);
            this.tabMonitor.Margin = new System.Windows.Forms.Padding(2);
            this.tabMonitor.Name = "tabMonitor";
            this.tabMonitor.Padding = new System.Windows.Forms.Padding(2);
            this.tabMonitor.Size = new System.Drawing.Size(359, 227);
            this.tabMonitor.TabIndex = 0;
            this.tabMonitor.Text = "Monitor";
            this.tabMonitor.UseVisualStyleBackColor = true;
            // 
            // grpRadar
            // 
            this.grpRadar.Controls.Add(this.btnExportMarch);
            this.grpRadar.Controls.Add(this.lstRadar);
            this.grpRadar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpRadar.Location = new System.Drawing.Point(2, 2);
            this.grpRadar.Margin = new System.Windows.Forms.Padding(2);
            this.grpRadar.Name = "grpRadar";
            this.grpRadar.Padding = new System.Windows.Forms.Padding(2);
            this.grpRadar.Size = new System.Drawing.Size(355, 223);
            this.grpRadar.TabIndex = 0;
            this.grpRadar.TabStop = false;
            this.grpRadar.Text = "Radar";
            // 
            // btnExportMarch
            // 
            this.btnExportMarch.Location = new System.Drawing.Point(4, 193);
            this.btnExportMarch.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnExportMarch.Name = "btnExportMarch";
            this.btnExportMarch.Size = new System.Drawing.Size(74, 23);
            this.btnExportMarch.TabIndex = 12;
            this.btnExportMarch.Text = "Export";
            this.btnExportMarch.UseVisualStyleBackColor = true;
            this.btnExportMarch.Click += new System.EventHandler(this.btnExportMarch_Click);
            // 
            // lstRadar
            // 
            this.lstRadar.FormattingEnabled = true;
            this.lstRadar.Location = new System.Drawing.Point(4, 17);
            this.lstRadar.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.lstRadar.Name = "lstRadar";
            this.lstRadar.Size = new System.Drawing.Size(347, 173);
            this.lstRadar.TabIndex = 11;
            // 
            // dataGridViewComboBoxColumn2
            // 
            this.dataGridViewComboBoxColumn2.DataPropertyName = "Type";
            this.dataGridViewComboBoxColumn2.HeaderText = "Type";
            this.dataGridViewComboBoxColumn2.Name = "dataGridViewComboBoxColumn2";
            this.dataGridViewComboBoxColumn2.Width = 68;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(962, 275);
            this.Controls.Add(this.FormContainer);
            this.Controls.Add(this.stsStrip);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "Main";
            this.Text = "CodeStrikeBot";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
            this.Load += new System.EventHandler(this.Main_Load);
            this.stsStrip.ResumeLayout(false);
            this.stsStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsColorCustom)).EndInit();
            this.tabSettings.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.tabDebug.ResumeLayout(false);
            this.tabDebug.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCheck)).EndInit();
            this.tabActivity.ResumeLayout(false);
            this.contActivity.Panel1.ResumeLayout(false);
            this.contActivity.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.contActivity)).EndInit();
            this.contActivity.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridPacket)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPacket)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabAccounts.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridAccounts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAccount)).EndInit();
            this.tabScreens.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridSchedules)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsScheduleTask)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.tabTasks.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabControlMain.ResumeLayout(false);
            this.FormContainer.Panel1.ResumeLayout(false);
            this.FormContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FormContainer)).EndInit();
            this.FormContainer.ResumeLayout(false);
            this.tabControlMonitor.ResumeLayout(false);
            this.tabMonitor.ResumeLayout(false);
            this.grpRadar.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip stsStrip;
        private System.Windows.Forms.ToolStripStatusLabel stsState;
        private System.ComponentModel.BackgroundWorker bckScreenState;
        private System.Windows.Forms.ToolStripStatusLabel stsSpacer;
        private System.ComponentModel.BackgroundWorker bckSniffer;
        private System.ComponentModel.BackgroundWorker bckHeartBeat;
        private System.Windows.Forms.BindingSource bsPacket;
        private System.Drawing.Color clrCustom;
        private System.Windows.Forms.BindingSource bsColorCustom;
        private System.ComponentModel.BackgroundWorker bckRegularTasks;
        private System.Windows.Forms.ToolStripStatusLabel stsStatus;
        private System.ComponentModel.BackgroundWorker bckScheduler;
        private System.Windows.Forms.BindingSource bsScheduleTask;
        private System.ComponentModel.BackgroundWorker bckKeepAlive;
        private System.ComponentModel.BackgroundWorker bckAutoActions;
        private System.Windows.Forms.BindingSource bsAccount;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewComboBoxColumn1;
        private System.Windows.Forms.TabPage tabSettings;
        private System.Windows.Forms.Button btnSaveSettings;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Label lblEmulator4;
        private System.Windows.Forms.TextBox txtEmulator4;
        private System.Windows.Forms.Label lblEmulator3;
        private System.Windows.Forms.TextBox txtEmulator3;
        private System.Windows.Forms.Label lblEmulator2;
        private System.Windows.Forms.TextBox txtEmulator2;
        private System.Windows.Forms.Label lblEmulator1;
        private System.Windows.Forms.TextBox txtEmulator1;
        private System.Windows.Forms.TabPage tabDebug;
        private System.Windows.Forms.TextBox txtScreenOrder;
        private System.Windows.Forms.TextBox txtBmpSize;
        private System.Windows.Forms.TextBox textBox18;
        private System.Windows.Forms.TextBox textBox19;
        private System.Windows.Forms.TextBox txt;
        private System.Windows.Forms.TextBox txtCustomY;
        private System.Windows.Forms.TextBox txtCustomX;
        private System.Windows.Forms.Label lblBmpChecksum;
        private System.Windows.Forms.PictureBox picCheck;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TabPage tabActivity;
        private System.Windows.Forms.SplitContainer contActivity;
        private System.Windows.Forms.DataGridView gridPacket;
        private System.Windows.Forms.DataGridViewTextBoxColumn timestampDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lengthDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button btnCopyText;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.RadioButton rdoRaw;
        private System.Windows.Forms.RadioButton rdoPayload;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.ComponentModel.Design.ByteViewer hexData;
        private System.Windows.Forms.TreeView treeXml;
        private System.Windows.Forms.TabPage tabAccounts;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.DataGridView gridAccounts;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn userNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn passwordDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn priorityGridViewComboBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn foodNegativeAmountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastLoginDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastLogoutDataGridViewTextBoxColumn;
        private System.Windows.Forms.TabPage tabScreens;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button btnScheduleRun;
        private System.Windows.Forms.DataGridView gridSchedules;
        private System.Windows.Forms.DataGridViewComboBoxColumn typeDataGridViewComboBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn intervalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn amountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn countDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn xDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn yDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn BackupX;
        private System.Windows.Forms.DataGridViewTextBoxColumn BackupY;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastActionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nextActionDataGridViewTextBoxColumn;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnResize;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListBox lstAccounts;
        private System.Windows.Forms.Button btnSwitch;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton rdoWindow4;
        private System.Windows.Forms.RadioButton rdoWindow3;
        private System.Windows.Forms.RadioButton rdoWindow2;
        private System.Windows.Forms.RadioButton rdoWindow1;
        private System.Windows.Forms.TabPage tabTasks;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button btnRestart;
        private System.Windows.Forms.Button btnMap;
        private System.Windows.Forms.Button btnGrowXP;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Button btnSearchEnemy;
        private System.Windows.Forms.Button btnMissionXP;
        private System.Windows.Forms.TextBox txtSliceStartX;
        private System.Windows.Forms.TextBox txtSliceStartY;
        private System.Windows.Forms.TextBox txtRowStart;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnScreen;
        private System.Windows.Forms.TextBox txtScreen;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnBoostModifier;
        private System.Windows.Forms.CheckBox chkScheduler;
        private System.Windows.Forms.Button btnScheduler;
        private System.Windows.Forms.Button btnMissions;
        private System.Windows.Forms.CheckBox chkTasks;
        private System.Windows.Forms.Button btnTasks;
        private System.Windows.Forms.Button btnClearGifts;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSlackURL;
        private System.Windows.Forms.TextBox txtPushoverUser;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPushoverAPI;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.SplitContainer FormContainer;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewComboBoxColumn2;
        private System.Windows.Forms.TabControl tabControlMonitor;
        private System.Windows.Forms.TabPage tabMonitor;
        private System.Windows.Forms.GroupBox grpRadar;
        private System.Windows.Forms.ListBox lstRadar;
        private System.Windows.Forms.Button btnExportMarch;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.ComboBox cboAccountAppFilter;
        private System.Windows.Forms.ComboBox cboEmulator4;
        private System.Windows.Forms.ComboBox cboEmulator3;
        private System.Windows.Forms.ComboBox cboEmulator2;
        private System.Windows.Forms.ComboBox cboEmulator1;
        private System.Windows.Forms.Label lblAccountApp;
        private System.Windows.Forms.TextBox txtColStart;
    }
}

