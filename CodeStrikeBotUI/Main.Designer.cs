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
            this.bsScheduleTask = new System.Windows.Forms.BindingSource(this.components);
            this.bsAccount = new System.Windows.Forms.BindingSource(this.components);
            this.bsPacket = new System.Windows.Forms.BindingSource(this.components);
            this.bsColorCustom = new System.Windows.Forms.BindingSource(this.components);
            this.bckRegularTasks = new System.ComponentModel.BackgroundWorker();
            this.bckScheduler = new System.ComponentModel.BackgroundWorker();
            this.bckKeepAlive = new System.ComponentModel.BackgroundWorker();
            this.bckAutoActions = new System.ComponentModel.BackgroundWorker();
            this.dataGridViewComboBoxColumn1 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.tabSettings = new System.Windows.Forms.TabPage();
            this.btnSaveSettings = new System.Windows.Forms.Button();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
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
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.btnCopyText = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.rdoRaw = new System.Windows.Forms.RadioButton();
            this.rdoPayload = new System.Windows.Forms.RadioButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.hexData = new System.ComponentModel.Design.ByteViewer();
            this.treeXml = new System.Windows.Forms.TreeView();
            this.tabAccounts = new System.Windows.Forms.TabPage();
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.txtSlackURL = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPushoverAPI = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPushoverUser = new System.Windows.Forms.TextBox();
            this.stsStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsScheduleTask)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAccount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPacket)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsColorCustom)).BeginInit();
            this.tabSettings.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.tabDebug.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCheck)).BeginInit();
            this.tabActivity.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.contActivity)).BeginInit();
            this.contActivity.Panel1.SuspendLayout();
            this.contActivity.Panel2.SuspendLayout();
            this.contActivity.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPacket)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabAccounts.SuspendLayout();
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridAccounts)).BeginInit();
            this.tabScreens.SuspendLayout();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSchedules)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tabTasks.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.SuspendLayout();
            // 
            // stsStrip
            // 
            this.stsStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.stsStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stsStatus,
            this.stsSpacer,
            this.stsState});
            this.stsStrip.Location = new System.Drawing.Point(0, 392);
            this.stsStrip.Name = "stsStrip";
            this.stsStrip.Padding = new System.Windows.Forms.Padding(4, 0, 28, 0);
            this.stsStrip.Size = new System.Drawing.Size(1916, 37);
            this.stsStrip.TabIndex = 7;
            // 
            // stsStatus
            // 
            this.stsStatus.Name = "stsStatus";
            this.stsStatus.Size = new System.Drawing.Size(0, 32);
            this.stsStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // stsSpacer
            // 
            this.stsSpacer.Name = "stsSpacer";
            this.stsSpacer.Size = new System.Drawing.Size(1816, 32);
            this.stsSpacer.Spring = true;
            // 
            // stsState
            // 
            this.stsState.Name = "stsState";
            this.stsState.Size = new System.Drawing.Size(68, 32);
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
            // bsScheduleTask
            // 
            this.bsScheduleTask.DataSource = typeof(CodeStrikeBot.ScheduleTask);
            // 
            // bsAccount
            // 
            this.bsAccount.DataSource = typeof(CodeStrikeBot.Account);
            // 
            // bsPacket
            // 
            this.bsPacket.DataSource = typeof(CodeStrikeBot.Messages.Message);
            this.bsPacket.CurrentChanged += new System.EventHandler(this.bsPacket_CurrentChanged);
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
            this.tabSettings.Location = new System.Drawing.Point(8, 39);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabSettings.Size = new System.Drawing.Size(1900, 345);
            this.tabSettings.TabIndex = 5;
            this.tabSettings.Text = "Settings";
            this.tabSettings.UseVisualStyleBackColor = true;
            // 
            // btnSaveSettings
            // 
            this.btnSaveSettings.Location = new System.Drawing.Point(7, 292);
            this.btnSaveSettings.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnSaveSettings.Name = "btnSaveSettings";
            this.btnSaveSettings.Size = new System.Drawing.Size(148, 44);
            this.btnSaveSettings.TabIndex = 1;
            this.btnSaveSettings.Text = "Save";
            this.btnSaveSettings.UseVisualStyleBackColor = true;
            this.btnSaveSettings.Click += new System.EventHandler(this.btnSaveSettings_Click);
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.lblEmulator4);
            this.groupBox9.Controls.Add(this.txtEmulator4);
            this.groupBox9.Controls.Add(this.lblEmulator3);
            this.groupBox9.Controls.Add(this.txtEmulator3);
            this.groupBox9.Controls.Add(this.lblEmulator2);
            this.groupBox9.Controls.Add(this.txtEmulator2);
            this.groupBox9.Controls.Add(this.lblEmulator1);
            this.groupBox9.Controls.Add(this.txtEmulator1);
            this.groupBox9.Location = new System.Drawing.Point(6, 6);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(156, 187);
            this.groupBox9.TabIndex = 0;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Emulators";
            // 
            // lblEmulator4
            // 
            this.lblEmulator4.AutoSize = true;
            this.lblEmulator4.Location = new System.Drawing.Point(7, 142);
            this.lblEmulator4.Name = "lblEmulator4";
            this.lblEmulator4.Size = new System.Drawing.Size(24, 25);
            this.lblEmulator4.TabIndex = 7;
            this.lblEmulator4.Text = "4";
            // 
            // txtEmulator4
            // 
            this.txtEmulator4.Location = new System.Drawing.Point(37, 139);
            this.txtEmulator4.Name = "txtEmulator4";
            this.txtEmulator4.Size = new System.Drawing.Size(100, 31);
            this.txtEmulator4.TabIndex = 6;
            // 
            // lblEmulator3
            // 
            this.lblEmulator3.AutoSize = true;
            this.lblEmulator3.Location = new System.Drawing.Point(7, 105);
            this.lblEmulator3.Name = "lblEmulator3";
            this.lblEmulator3.Size = new System.Drawing.Size(24, 25);
            this.lblEmulator3.TabIndex = 5;
            this.lblEmulator3.Text = "3";
            // 
            // txtEmulator3
            // 
            this.txtEmulator3.Location = new System.Drawing.Point(37, 102);
            this.txtEmulator3.Name = "txtEmulator3";
            this.txtEmulator3.Size = new System.Drawing.Size(100, 31);
            this.txtEmulator3.TabIndex = 4;
            // 
            // lblEmulator2
            // 
            this.lblEmulator2.AutoSize = true;
            this.lblEmulator2.Location = new System.Drawing.Point(7, 68);
            this.lblEmulator2.Name = "lblEmulator2";
            this.lblEmulator2.Size = new System.Drawing.Size(24, 25);
            this.lblEmulator2.TabIndex = 3;
            this.lblEmulator2.Text = "2";
            // 
            // txtEmulator2
            // 
            this.txtEmulator2.Location = new System.Drawing.Point(37, 65);
            this.txtEmulator2.Name = "txtEmulator2";
            this.txtEmulator2.Size = new System.Drawing.Size(100, 31);
            this.txtEmulator2.TabIndex = 2;
            // 
            // lblEmulator1
            // 
            this.lblEmulator1.AutoSize = true;
            this.lblEmulator1.Location = new System.Drawing.Point(7, 31);
            this.lblEmulator1.Name = "lblEmulator1";
            this.lblEmulator1.Size = new System.Drawing.Size(24, 25);
            this.lblEmulator1.TabIndex = 1;
            this.lblEmulator1.Text = "1";
            // 
            // txtEmulator1
            // 
            this.txtEmulator1.Location = new System.Drawing.Point(37, 28);
            this.txtEmulator1.Name = "txtEmulator1";
            this.txtEmulator1.Size = new System.Drawing.Size(100, 31);
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
            this.tabDebug.Location = new System.Drawing.Point(8, 39);
            this.tabDebug.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.tabDebug.Name = "tabDebug";
            this.tabDebug.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.tabDebug.Size = new System.Drawing.Size(1900, 345);
            this.tabDebug.TabIndex = 3;
            this.tabDebug.Text = "Debug";
            this.tabDebug.UseVisualStyleBackColor = true;
            // 
            // txtScreenOrder
            // 
            this.txtScreenOrder.Location = new System.Drawing.Point(148, 77);
            this.txtScreenOrder.Margin = new System.Windows.Forms.Padding(6);
            this.txtScreenOrder.Multiline = true;
            this.txtScreenOrder.Name = "txtScreenOrder";
            this.txtScreenOrder.Size = new System.Drawing.Size(196, 166);
            this.txtScreenOrder.TabIndex = 29;
            // 
            // txtBmpSize
            // 
            this.txtBmpSize.Location = new System.Drawing.Point(244, 12);
            this.txtBmpSize.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txtBmpSize.Name = "txtBmpSize";
            this.txtBmpSize.Size = new System.Drawing.Size(84, 31);
            this.txtBmpSize.TabIndex = 26;
            this.txtBmpSize.Text = "20";
            // 
            // textBox18
            // 
            this.textBox18.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsColorCustom, "B", true));
            this.textBox18.Enabled = false;
            this.textBox18.Location = new System.Drawing.Point(20, 208);
            this.textBox18.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.textBox18.Name = "textBox18";
            this.textBox18.Size = new System.Drawing.Size(84, 31);
            this.textBox18.TabIndex = 19;
            // 
            // textBox19
            // 
            this.textBox19.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsColorCustom, "G", true));
            this.textBox19.Enabled = false;
            this.textBox19.Location = new System.Drawing.Point(20, 158);
            this.textBox19.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.textBox19.Name = "textBox19";
            this.textBox19.Size = new System.Drawing.Size(84, 31);
            this.textBox19.TabIndex = 18;
            // 
            // txt
            // 
            this.txt.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsColorCustom, "R", true));
            this.txt.Enabled = false;
            this.txt.Location = new System.Drawing.Point(20, 108);
            this.txt.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txt.Name = "txt";
            this.txt.Size = new System.Drawing.Size(84, 31);
            this.txt.TabIndex = 17;
            // 
            // txtCustomY
            // 
            this.txtCustomY.Location = new System.Drawing.Point(116, 13);
            this.txtCustomY.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txtCustomY.Name = "txtCustomY";
            this.txtCustomY.Size = new System.Drawing.Size(84, 31);
            this.txtCustomY.TabIndex = 1;
            this.txtCustomY.Text = "0";
            // 
            // txtCustomX
            // 
            this.txtCustomX.Location = new System.Drawing.Point(20, 13);
            this.txtCustomX.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txtCustomX.Name = "txtCustomX";
            this.txtCustomX.Size = new System.Drawing.Size(84, 31);
            this.txtCustomX.TabIndex = 0;
            this.txtCustomX.Text = "0";
            // 
            // lblBmpChecksum
            // 
            this.lblBmpChecksum.AutoSize = true;
            this.lblBmpChecksum.Location = new System.Drawing.Point(420, 19);
            this.lblBmpChecksum.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBmpChecksum.Name = "lblBmpChecksum";
            this.lblBmpChecksum.Size = new System.Drawing.Size(0, 25);
            this.lblBmpChecksum.TabIndex = 28;
            // 
            // picCheck
            // 
            this.picCheck.Location = new System.Drawing.Point(364, 13);
            this.picCheck.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.picCheck.Name = "picCheck";
            this.picCheck.Size = new System.Drawing.Size(40, 38);
            this.picCheck.TabIndex = 27;
            this.picCheck.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 77);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 25);
            this.label6.TabIndex = 25;
            this.label6.Text = "Custom";
            // 
            // tabActivity
            // 
            this.tabActivity.Controls.Add(this.contActivity);
            this.tabActivity.Location = new System.Drawing.Point(8, 39);
            this.tabActivity.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.tabActivity.Name = "tabActivity";
            this.tabActivity.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.tabActivity.Size = new System.Drawing.Size(1900, 345);
            this.tabActivity.TabIndex = 2;
            this.tabActivity.Text = "Activity";
            this.tabActivity.UseVisualStyleBackColor = true;
            // 
            // contActivity
            // 
            this.contActivity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contActivity.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.contActivity.Location = new System.Drawing.Point(4, 6);
            this.contActivity.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.contActivity.Name = "contActivity";
            // 
            // contActivity.Panel1
            // 
            this.contActivity.Panel1.Controls.Add(this.gridPacket);
            // 
            // contActivity.Panel2
            // 
            this.contActivity.Panel2.Controls.Add(this.splitContainer2);
            this.contActivity.Size = new System.Drawing.Size(1892, 333);
            this.contActivity.SplitterDistance = 270;
            this.contActivity.SplitterWidth = 8;
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
            this.gridPacket.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.gridPacket.Name = "gridPacket";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridPacket.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gridPacket.Size = new System.Drawing.Size(270, 333);
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
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
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
            this.splitContainer2.Size = new System.Drawing.Size(1614, 333);
            this.splitContainer2.SplitterDistance = 30;
            this.splitContainer2.SplitterWidth = 8;
            this.splitContainer2.TabIndex = 20;
            // 
            // btnCopyText
            // 
            this.btnCopyText.Location = new System.Drawing.Point(416, 8);
            this.btnCopyText.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnCopyText.Name = "btnCopyText";
            this.btnCopyText.Size = new System.Drawing.Size(148, 44);
            this.btnCopyText.TabIndex = 3;
            this.btnCopyText.Text = "Copy Text";
            this.btnCopyText.UseVisualStyleBackColor = true;
            this.btnCopyText.Click += new System.EventHandler(this.btnCopyText_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(252, 8);
            this.btnExport.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(148, 44);
            this.btnExport.TabIndex = 2;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            // 
            // rdoRaw
            // 
            this.rdoRaw.AutoSize = true;
            this.rdoRaw.Location = new System.Drawing.Point(148, 13);
            this.rdoRaw.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.rdoRaw.Name = "rdoRaw";
            this.rdoRaw.Size = new System.Drawing.Size(85, 29);
            this.rdoRaw.TabIndex = 1;
            this.rdoRaw.Text = "Raw";
            this.rdoRaw.UseVisualStyleBackColor = true;
            this.rdoRaw.CheckedChanged += new System.EventHandler(this.rdoRaw_CheckedChanged);
            // 
            // rdoPayload
            // 
            this.rdoPayload.AutoSize = true;
            this.rdoPayload.Checked = true;
            this.rdoPayload.Location = new System.Drawing.Point(8, 13);
            this.rdoPayload.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.rdoPayload.Name = "rdoPayload";
            this.rdoPayload.Size = new System.Drawing.Size(121, 29);
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
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
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
            this.splitContainer1.Size = new System.Drawing.Size(1614, 295);
            this.splitContainer1.SplitterDistance = 141;
            this.splitContainer1.SplitterWidth = 8;
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
            this.hexData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hexData.Location = new System.Drawing.Point(0, 0);
            this.hexData.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
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
            this.hexData.Size = new System.Drawing.Size(1614, 141);
            this.hexData.TabIndex = 18;
            // 
            // treeXml
            // 
            this.treeXml.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeXml.Location = new System.Drawing.Point(0, 0);
            this.treeXml.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.treeXml.Name = "treeXml";
            this.treeXml.Size = new System.Drawing.Size(1614, 146);
            this.treeXml.TabIndex = 0;
            // 
            // tabAccounts
            // 
            this.tabAccounts.Controls.Add(this.groupBox8);
            this.tabAccounts.Location = new System.Drawing.Point(8, 39);
            this.tabAccounts.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.tabAccounts.Name = "tabAccounts";
            this.tabAccounts.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.tabAccounts.Size = new System.Drawing.Size(1900, 345);
            this.tabAccounts.TabIndex = 4;
            this.tabAccounts.Text = "Accounts";
            this.tabAccounts.UseVisualStyleBackColor = true;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.gridAccounts);
            this.groupBox8.Location = new System.Drawing.Point(16, 8);
            this.groupBox8.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.groupBox8.Size = new System.Drawing.Size(1872, 315);
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
            this.gridAccounts.Location = new System.Drawing.Point(12, 37);
            this.gridAccounts.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.gridAccounts.Name = "gridAccounts";
            this.gridAccounts.Size = new System.Drawing.Size(1848, 267);
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
            this.nameDataGridViewTextBoxColumn.Width = 113;
            // 
            // userNameDataGridViewTextBoxColumn
            // 
            this.userNameDataGridViewTextBoxColumn.DataPropertyName = "UserName";
            this.userNameDataGridViewTextBoxColumn.HeaderText = "UserName";
            this.userNameDataGridViewTextBoxColumn.Name = "userNameDataGridViewTextBoxColumn";
            this.userNameDataGridViewTextBoxColumn.Width = 158;
            // 
            // emailDataGridViewTextBoxColumn
            // 
            this.emailDataGridViewTextBoxColumn.DataPropertyName = "Email";
            this.emailDataGridViewTextBoxColumn.HeaderText = "Email";
            this.emailDataGridViewTextBoxColumn.Name = "emailDataGridViewTextBoxColumn";
            this.emailDataGridViewTextBoxColumn.Width = 110;
            // 
            // passwordDataGridViewTextBoxColumn
            // 
            this.passwordDataGridViewTextBoxColumn.DataPropertyName = "Password";
            this.passwordDataGridViewTextBoxColumn.HeaderText = "Password";
            this.passwordDataGridViewTextBoxColumn.Name = "passwordDataGridViewTextBoxColumn";
            this.passwordDataGridViewTextBoxColumn.Width = 151;
            // 
            // priorityGridViewComboBoxColumn
            // 
            this.priorityGridViewComboBoxColumn.DataPropertyName = "Priority";
            this.priorityGridViewComboBoxColumn.HeaderText = "Priority";
            this.priorityGridViewComboBoxColumn.Name = "priorityGridViewComboBoxColumn";
            this.priorityGridViewComboBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.priorityGridViewComboBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.priorityGridViewComboBoxColumn.Width = 124;
            // 
            // foodNegativeAmountDataGridViewTextBoxColumn
            // 
            this.foodNegativeAmountDataGridViewTextBoxColumn.DataPropertyName = "FoodNegativeAmount";
            this.foodNegativeAmountDataGridViewTextBoxColumn.HeaderText = "FoodNegativeAmount";
            this.foodNegativeAmountDataGridViewTextBoxColumn.Name = "foodNegativeAmountDataGridViewTextBoxColumn";
            this.foodNegativeAmountDataGridViewTextBoxColumn.Width = 264;
            // 
            // lastLoginDataGridViewTextBoxColumn
            // 
            this.lastLoginDataGridViewTextBoxColumn.DataPropertyName = "LastLogin";
            this.lastLoginDataGridViewTextBoxColumn.HeaderText = "LastLogin";
            this.lastLoginDataGridViewTextBoxColumn.Name = "lastLoginDataGridViewTextBoxColumn";
            this.lastLoginDataGridViewTextBoxColumn.ReadOnly = true;
            this.lastLoginDataGridViewTextBoxColumn.Width = 151;
            // 
            // lastLogoutDataGridViewTextBoxColumn
            // 
            this.lastLogoutDataGridViewTextBoxColumn.DataPropertyName = "LastLogout";
            this.lastLogoutDataGridViewTextBoxColumn.HeaderText = "LastLogout";
            this.lastLogoutDataGridViewTextBoxColumn.Name = "lastLogoutDataGridViewTextBoxColumn";
            this.lastLogoutDataGridViewTextBoxColumn.ReadOnly = true;
            this.lastLogoutDataGridViewTextBoxColumn.Width = 164;
            // 
            // tabScreens
            // 
            this.tabScreens.Controls.Add(this.groupBox7);
            this.tabScreens.Controls.Add(this.groupBox5);
            this.tabScreens.Controls.Add(this.groupBox3);
            this.tabScreens.Controls.Add(this.groupBox4);
            this.tabScreens.Location = new System.Drawing.Point(8, 39);
            this.tabScreens.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.tabScreens.Name = "tabScreens";
            this.tabScreens.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.tabScreens.Size = new System.Drawing.Size(1900, 345);
            this.tabScreens.TabIndex = 1;
            this.tabScreens.Text = "Session";
            this.tabScreens.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.btnScheduleRun);
            this.groupBox7.Controls.Add(this.gridSchedules);
            this.groupBox7.Location = new System.Drawing.Point(532, 13);
            this.groupBox7.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.groupBox7.Size = new System.Drawing.Size(1356, 315);
            this.groupBox7.TabIndex = 17;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Schedules";
            // 
            // btnScheduleRun
            // 
            this.btnScheduleRun.Location = new System.Drawing.Point(12, 256);
            this.btnScheduleRun.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnScheduleRun.Name = "btnScheduleRun";
            this.btnScheduleRun.Size = new System.Drawing.Size(148, 44);
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
            this.gridSchedules.Location = new System.Drawing.Point(12, 37);
            this.gridSchedules.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.gridSchedules.Name = "gridSchedules";
            this.gridSchedules.Size = new System.Drawing.Size(1332, 206);
            this.gridSchedules.TabIndex = 0;
            this.gridSchedules.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridSchedules_CellLeave);
            this.gridSchedules.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.gridSchedules_UserDeletingRow);
            // 
            // typeDataGridViewComboBoxColumn
            // 
            this.typeDataGridViewComboBoxColumn.DataPropertyName = "Type";
            this.typeDataGridViewComboBoxColumn.HeaderText = "Type";
            this.typeDataGridViewComboBoxColumn.Name = "typeDataGridViewComboBoxColumn";
            this.typeDataGridViewComboBoxColumn.Width = 66;
            // 
            // intervalDataGridViewTextBoxColumn
            // 
            this.intervalDataGridViewTextBoxColumn.DataPropertyName = "Interval";
            this.intervalDataGridViewTextBoxColumn.HeaderText = "Interval";
            this.intervalDataGridViewTextBoxColumn.MaxInputLength = 9;
            this.intervalDataGridViewTextBoxColumn.Name = "intervalDataGridViewTextBoxColumn";
            this.intervalDataGridViewTextBoxColumn.Width = 127;
            // 
            // amountDataGridViewTextBoxColumn
            // 
            this.amountDataGridViewTextBoxColumn.DataPropertyName = "Amount";
            this.amountDataGridViewTextBoxColumn.HeaderText = "Amount";
            this.amountDataGridViewTextBoxColumn.MaxInputLength = 9;
            this.amountDataGridViewTextBoxColumn.Name = "amountDataGridViewTextBoxColumn";
            this.amountDataGridViewTextBoxColumn.Width = 130;
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
            this.lastActionDataGridViewTextBoxColumn.Width = 158;
            // 
            // nextActionDataGridViewTextBoxColumn
            // 
            this.nextActionDataGridViewTextBoxColumn.DataPropertyName = "NextAction";
            this.nextActionDataGridViewTextBoxColumn.HeaderText = "NextAction";
            this.nextActionDataGridViewTextBoxColumn.Name = "nextActionDataGridViewTextBoxColumn";
            this.nextActionDataGridViewTextBoxColumn.ReadOnly = true;
            this.nextActionDataGridViewTextBoxColumn.Width = 161;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnResize);
            this.groupBox5.Location = new System.Drawing.Point(12, 129);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.groupBox5.Size = new System.Drawing.Size(252, 202);
            this.groupBox5.TabIndex = 16;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Windows Tasks";
            // 
            // btnResize
            // 
            this.btnResize.Location = new System.Drawing.Point(12, 38);
            this.btnResize.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnResize.Name = "btnResize";
            this.btnResize.Size = new System.Drawing.Size(148, 44);
            this.btnResize.TabIndex = 0;
            this.btnResize.Text = "Resize";
            this.btnResize.UseVisualStyleBackColor = true;
            this.btnResize.Click += new System.EventHandler(this.btnResize_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lstAccounts);
            this.groupBox3.Controls.Add(this.btnSwitch);
            this.groupBox3.Location = new System.Drawing.Point(280, 12);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.groupBox3.Size = new System.Drawing.Size(240, 317);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Active Session";
            // 
            // lstAccounts
            // 
            this.lstAccounts.FormattingEnabled = true;
            this.lstAccounts.ItemHeight = 25;
            this.lstAccounts.Location = new System.Drawing.Point(12, 37);
            this.lstAccounts.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.lstAccounts.Name = "lstAccounts";
            this.lstAccounts.Size = new System.Drawing.Size(212, 204);
            this.lstAccounts.TabIndex = 10;
            this.lstAccounts.SelectedIndexChanged += new System.EventHandler(this.lstAccounts_SelectedIndexChanged);
            // 
            // btnSwitch
            // 
            this.btnSwitch.Location = new System.Drawing.Point(12, 258);
            this.btnSwitch.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnSwitch.Name = "btnSwitch";
            this.btnSwitch.Size = new System.Drawing.Size(148, 44);
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
            this.groupBox4.Location = new System.Drawing.Point(12, 12);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.groupBox4.Size = new System.Drawing.Size(256, 102);
            this.groupBox4.TabIndex = 15;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Active Window";
            // 
            // rdoWindow4
            // 
            this.rdoWindow4.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoWindow4.AutoSize = true;
            this.rdoWindow4.Location = new System.Drawing.Point(188, 37);
            this.rdoWindow4.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.rdoWindow4.Name = "rdoWindow4";
            this.rdoWindow4.Size = new System.Drawing.Size(34, 35);
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
            this.rdoWindow3.Location = new System.Drawing.Point(128, 37);
            this.rdoWindow3.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.rdoWindow3.Name = "rdoWindow3";
            this.rdoWindow3.Size = new System.Drawing.Size(34, 35);
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
            this.rdoWindow2.Location = new System.Drawing.Point(68, 37);
            this.rdoWindow2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.rdoWindow2.Name = "rdoWindow2";
            this.rdoWindow2.Size = new System.Drawing.Size(34, 35);
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
            this.rdoWindow1.Location = new System.Drawing.Point(12, 37);
            this.rdoWindow1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.rdoWindow1.Name = "rdoWindow1";
            this.rdoWindow1.Size = new System.Drawing.Size(34, 35);
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
            this.tabTasks.Location = new System.Drawing.Point(8, 39);
            this.tabTasks.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.tabTasks.Name = "tabTasks";
            this.tabTasks.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.tabTasks.Size = new System.Drawing.Size(1900, 345);
            this.tabTasks.TabIndex = 0;
            this.tabTasks.Text = "Tasks";
            this.tabTasks.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.btnRestart);
            this.groupBox6.Controls.Add(this.btnMap);
            this.groupBox6.Controls.Add(this.btnGrowXP);
            this.groupBox6.Controls.Add(this.btnTest);
            this.groupBox6.Controls.Add(this.btnSearchEnemy);
            this.groupBox6.Controls.Add(this.btnMissionXP);
            this.groupBox6.Controls.Add(this.txtSliceStartX);
            this.groupBox6.Controls.Add(this.txtSliceStartY);
            this.groupBox6.Controls.Add(this.txtRowStart);
            this.groupBox6.Location = new System.Drawing.Point(660, 12);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.groupBox6.Size = new System.Drawing.Size(640, 156);
            this.groupBox6.TabIndex = 14;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Debug";
            // 
            // btnRestart
            // 
            this.btnRestart.Location = new System.Drawing.Point(380, 37);
            this.btnRestart.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(100, 44);
            this.btnRestart.TabIndex = 11;
            this.btnRestart.Text = "Restart";
            this.btnRestart.UseVisualStyleBackColor = true;
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // btnMap
            // 
            this.btnMap.Location = new System.Drawing.Point(12, 92);
            this.btnMap.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnMap.Name = "btnMap";
            this.btnMap.Size = new System.Drawing.Size(148, 44);
            this.btnMap.TabIndex = 0;
            this.btnMap.Text = "Map";
            this.btnMap.UseVisualStyleBackColor = true;
            this.btnMap.Click += new System.EventHandler(this.btnMap_Click);
            // 
            // btnGrowXP
            // 
            this.btnGrowXP.Location = new System.Drawing.Point(12, 37);
            this.btnGrowXP.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnGrowXP.Name = "btnGrowXP";
            this.btnGrowXP.Size = new System.Drawing.Size(108, 44);
            this.btnGrowXP.TabIndex = 8;
            this.btnGrowXP.Text = "Mine XP";
            this.btnGrowXP.UseVisualStyleBackColor = true;
            this.btnGrowXP.Click += new System.EventHandler(this.btnGrowXP_Click);
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(132, 37);
            this.btnTest.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(84, 44);
            this.btnTest.TabIndex = 1;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnSearchEnemy
            // 
            this.btnSearchEnemy.Location = new System.Drawing.Point(172, 92);
            this.btnSearchEnemy.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnSearchEnemy.Name = "btnSearchEnemy";
            this.btnSearchEnemy.Size = new System.Drawing.Size(148, 44);
            this.btnSearchEnemy.TabIndex = 9;
            this.btnSearchEnemy.Text = "Enemy";
            this.btnSearchEnemy.UseVisualStyleBackColor = true;
            this.btnSearchEnemy.Click += new System.EventHandler(this.btnSearchEnemy_Click);
            // 
            // btnMissionXP
            // 
            this.btnMissionXP.Location = new System.Drawing.Point(232, 37);
            this.btnMissionXP.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnMissionXP.Name = "btnMissionXP";
            this.btnMissionXP.Size = new System.Drawing.Size(132, 44);
            this.btnMissionXP.TabIndex = 10;
            this.btnMissionXP.Text = "Mission XP";
            this.btnMissionXP.UseVisualStyleBackColor = true;
            this.btnMissionXP.Click += new System.EventHandler(this.btnMissionXP_Click);
            // 
            // txtSliceStartX
            // 
            this.txtSliceStartX.Location = new System.Drawing.Point(336, 102);
            this.txtSliceStartX.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txtSliceStartX.Name = "txtSliceStartX";
            this.txtSliceStartX.Size = new System.Drawing.Size(80, 31);
            this.txtSliceStartX.TabIndex = 4;
            this.txtSliceStartX.Text = "0";
            // 
            // txtSliceStartY
            // 
            this.txtSliceStartY.Location = new System.Drawing.Point(428, 102);
            this.txtSliceStartY.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txtSliceStartY.Name = "txtSliceStartY";
            this.txtSliceStartY.Size = new System.Drawing.Size(80, 31);
            this.txtSliceStartY.TabIndex = 5;
            this.txtSliceStartY.Text = "0";
            // 
            // txtRowStart
            // 
            this.txtRowStart.Location = new System.Drawing.Point(524, 102);
            this.txtRowStart.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txtRowStart.Name = "txtRowStart";
            this.txtRowStart.Size = new System.Drawing.Size(80, 31);
            this.txtRowStart.TabIndex = 6;
            this.txtRowStart.Text = "0";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnScreen);
            this.groupBox1.Controls.Add(this.txtScreen);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.groupBox1.Size = new System.Drawing.Size(636, 156);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mapping";
            // 
            // btnScreen
            // 
            this.btnScreen.Location = new System.Drawing.Point(12, 37);
            this.btnScreen.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnScreen.Name = "btnScreen";
            this.btnScreen.Size = new System.Drawing.Size(148, 44);
            this.btnScreen.TabIndex = 2;
            this.btnScreen.Text = "Screen";
            this.btnScreen.UseVisualStyleBackColor = true;
            this.btnScreen.Click += new System.EventHandler(this.btnScreen_Click);
            // 
            // txtScreen
            // 
            this.txtScreen.Location = new System.Drawing.Point(172, 40);
            this.txtScreen.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txtScreen.Name = "txtScreen";
            this.txtScreen.Size = new System.Drawing.Size(196, 31);
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
            this.groupBox2.Location = new System.Drawing.Point(12, 179);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.groupBox2.Size = new System.Drawing.Size(636, 144);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Routines";
            // 
            // btnBoostModifier
            // 
            this.btnBoostModifier.Location = new System.Drawing.Point(480, 37);
            this.btnBoostModifier.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnBoostModifier.Name = "btnBoostModifier";
            this.btnBoostModifier.Size = new System.Drawing.Size(124, 44);
            this.btnBoostModifier.TabIndex = 16;
            this.btnBoostModifier.Text = "Boost";
            this.btnBoostModifier.UseVisualStyleBackColor = true;
            this.btnBoostModifier.Click += new System.EventHandler(this.btnBoostModifier_Click);
            // 
            // chkScheduler
            // 
            this.chkScheduler.AutoSize = true;
            this.chkScheduler.Checked = true;
            this.chkScheduler.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkScheduler.Location = new System.Drawing.Point(120, 92);
            this.chkScheduler.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.chkScheduler.Name = "chkScheduler";
            this.chkScheduler.Size = new System.Drawing.Size(141, 29);
            this.chkScheduler.TabIndex = 15;
            this.chkScheduler.Text = "Scheduler";
            this.chkScheduler.UseVisualStyleBackColor = true;
            this.chkScheduler.CheckedChanged += new System.EventHandler(this.chkScheduler_CheckedChanged);
            // 
            // btnScheduler
            // 
            this.btnScheduler.Location = new System.Drawing.Point(348, 37);
            this.btnScheduler.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnScheduler.Name = "btnScheduler";
            this.btnScheduler.Size = new System.Drawing.Size(124, 44);
            this.btnScheduler.TabIndex = 14;
            this.btnScheduler.Text = "Scheduler";
            this.btnScheduler.UseVisualStyleBackColor = true;
            this.btnScheduler.Click += new System.EventHandler(this.btnScheduler_Click);
            // 
            // btnMissions
            // 
            this.btnMissions.Location = new System.Drawing.Point(220, 37);
            this.btnMissions.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnMissions.Name = "btnMissions";
            this.btnMissions.Size = new System.Drawing.Size(116, 44);
            this.btnMissions.TabIndex = 13;
            this.btnMissions.Text = "Missions";
            this.btnMissions.UseVisualStyleBackColor = true;
            this.btnMissions.Click += new System.EventHandler(this.btnMissions_Click);
            // 
            // chkTasks
            // 
            this.chkTasks.AutoSize = true;
            this.chkTasks.Checked = true;
            this.chkTasks.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTasks.Location = new System.Drawing.Point(12, 92);
            this.chkTasks.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.chkTasks.Name = "chkTasks";
            this.chkTasks.Size = new System.Drawing.Size(102, 29);
            this.chkTasks.TabIndex = 12;
            this.chkTasks.Text = "Tasks";
            this.chkTasks.UseVisualStyleBackColor = true;
            this.chkTasks.CheckedChanged += new System.EventHandler(this.chkTasks_CheckedChanged);
            // 
            // btnTasks
            // 
            this.btnTasks.Location = new System.Drawing.Point(12, 37);
            this.btnTasks.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnTasks.Name = "btnTasks";
            this.btnTasks.Size = new System.Drawing.Size(96, 44);
            this.btnTasks.TabIndex = 11;
            this.btnTasks.Text = "Tasks";
            this.btnTasks.UseVisualStyleBackColor = true;
            this.btnTasks.Click += new System.EventHandler(this.btnTasks_Click);
            // 
            // btnClearGifts
            // 
            this.btnClearGifts.Location = new System.Drawing.Point(120, 37);
            this.btnClearGifts.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnClearGifts.Name = "btnClearGifts";
            this.btnClearGifts.Size = new System.Drawing.Size(92, 44);
            this.btnClearGifts.TabIndex = 9;
            this.btnClearGifts.Text = "Gifts";
            this.btnClearGifts.UseVisualStyleBackColor = true;
            this.btnClearGifts.Click += new System.EventHandler(this.btnClearGifts_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabTasks);
            this.tabControl1.Controls.Add(this.tabScreens);
            this.tabControl1.Controls.Add(this.tabAccounts);
            this.tabControl1.Controls.Add(this.tabActivity);
            this.tabControl1.Controls.Add(this.tabDebug);
            this.tabControl1.Controls.Add(this.tabSettings);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1916, 392);
            this.tabControl1.TabIndex = 16;
            // 
            // txtSlackURL
            // 
            this.txtSlackURL.Location = new System.Drawing.Point(175, 28);
            this.txtSlackURL.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txtSlackURL.Name = "txtSlackURL";
            this.txtSlackURL.Size = new System.Drawing.Size(902, 31);
            this.txtSlackURL.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "Slack URL";
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.txtPushoverUser);
            this.groupBox10.Controls.Add(this.label3);
            this.groupBox10.Controls.Add(this.txtPushoverAPI);
            this.groupBox10.Controls.Add(this.label2);
            this.groupBox10.Controls.Add(this.label1);
            this.groupBox10.Controls.Add(this.txtSlackURL);
            this.groupBox10.Location = new System.Drawing.Point(168, 6);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(1094, 187);
            this.groupBox10.TabIndex = 6;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Notifications";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "Pushover API";
            // 
            // txtPushoverAPI
            // 
            this.txtPushoverAPI.Location = new System.Drawing.Point(155, 65);
            this.txtPushoverAPI.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txtPushoverAPI.Name = "txtPushoverAPI";
            this.txtPushoverAPI.Size = new System.Drawing.Size(377, 31);
            this.txtPushoverAPI.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(539, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(154, 25);
            this.label3.TabIndex = 8;
            this.label3.Text = "Pushover User";
            // 
            // txtPushoverUser
            // 
            this.txtPushoverUser.Location = new System.Drawing.Point(700, 65);
            this.txtPushoverUser.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txtPushoverUser.Name = "txtPushoverUser";
            this.txtPushoverUser.Size = new System.Drawing.Size(377, 31);
            this.txtPushoverUser.TabIndex = 9;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1916, 429);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.stsStrip);
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Name = "Main";
            this.Text = "CodeStrikeBot";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
            this.Load += new System.EventHandler(this.Main_Load);
            this.stsStrip.ResumeLayout(false);
            this.stsStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsScheduleTask)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAccount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPacket)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsColorCustom)).EndInit();
            this.tabSettings.ResumeLayout(false);
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
            this.groupBox8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridAccounts)).EndInit();
            this.tabScreens.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridSchedules)).EndInit();
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
            this.tabControl1.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
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
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSlackURL;
        private System.Windows.Forms.TextBox txtPushoverUser;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPushoverAPI;
        private System.Windows.Forms.Label label2;
    }
}

