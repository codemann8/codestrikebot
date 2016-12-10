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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnMap = new System.Windows.Forms.Button();
            this.btnTest = new System.Windows.Forms.Button();
            this.btnScreen = new System.Windows.Forms.Button();
            this.txtScreen = new System.Windows.Forms.TextBox();
            this.txtSliceStartX = new System.Windows.Forms.TextBox();
            this.txtSliceStartY = new System.Windows.Forms.TextBox();
            this.txtRowStart = new System.Windows.Forms.TextBox();
            this.stsStrip = new System.Windows.Forms.StatusStrip();
            this.stsStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.stsSpacer = new System.Windows.Forms.ToolStripStatusLabel();
            this.stsState = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnGrowXP = new System.Windows.Forms.Button();
            this.bckScreenState = new System.ComponentModel.BackgroundWorker();
            this.btnSearchEnemy = new System.Windows.Forms.Button();
            this.bckSniffer = new System.ComponentModel.BackgroundWorker();
            this.bckHeartBeat = new System.ComponentModel.BackgroundWorker();
            this.lstAccounts = new System.Windows.Forms.ListBox();
            this.btnSwitch = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkScheduler = new System.Windows.Forms.CheckBox();
            this.btnScheduler = new System.Windows.Forms.Button();
            this.btnMissions = new System.Windows.Forms.Button();
            this.chkTasks = new System.Windows.Forms.CheckBox();
            this.btnTasks = new System.Windows.Forms.Button();
            this.btnClearGifts = new System.Windows.Forms.Button();
            this.btnMissionXP = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rdoWindow4 = new System.Windows.Forms.RadioButton();
            this.rdoWindow3 = new System.Windows.Forms.RadioButton();
            this.rdoWindow2 = new System.Windows.Forms.RadioButton();
            this.rdoWindow1 = new System.Windows.Forms.RadioButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabTasks = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.btnRestart = new System.Windows.Forms.Button();
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
            this.lastActionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nextActionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsScheduleTask = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnResize = new System.Windows.Forms.Button();
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
            this.bsAccount = new System.Windows.Forms.BindingSource(this.components);
            this.tabActivity = new System.Windows.Forms.TabPage();
            this.contActivity = new System.Windows.Forms.SplitContainer();
            this.gridPacket = new System.Windows.Forms.DataGridView();
            this.timestampDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lengthDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ack = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsPacket = new System.Windows.Forms.BindingSource(this.components);
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.btnCopyText = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.rdoRaw = new System.Windows.Forms.RadioButton();
            this.rdoPayload = new System.Windows.Forms.RadioButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.hexData = new System.ComponentModel.Design.ByteViewer();
            this.treeXml = new System.Windows.Forms.TreeView();
            this.tabDebug = new System.Windows.Forms.TabPage();
            this.lblBmpChecksum = new System.Windows.Forms.Label();
            this.picCheck = new System.Windows.Forms.PictureBox();
            this.txtBmpSize = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox18 = new System.Windows.Forms.TextBox();
            this.bsColorCustom = new System.Windows.Forms.BindingSource(this.components);
            this.textBox19 = new System.Windows.Forms.TextBox();
            this.txt = new System.Windows.Forms.TextBox();
            this.textBox15 = new System.Windows.Forms.TextBox();
            this.textBox16 = new System.Windows.Forms.TextBox();
            this.textBox17 = new System.Windows.Forms.TextBox();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.textBox13 = new System.Windows.Forms.TextBox();
            this.textBox14 = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.txtCustomY = new System.Windows.Forms.TextBox();
            this.txtCustomX = new System.Windows.Forms.TextBox();
            this.bckRegularTasks = new System.ComponentModel.BackgroundWorker();
            this.bckScheduler = new System.ComponentModel.BackgroundWorker();
            this.bckKeepAlive = new System.ComponentModel.BackgroundWorker();
            this.bckAutoActions = new System.ComponentModel.BackgroundWorker();
            this.stsStrip.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabTasks.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.tabScreens.SuspendLayout();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSchedules)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsScheduleTask)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.tabAccounts.SuspendLayout();
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridAccounts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAccount)).BeginInit();
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
            this.tabDebug.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCheck)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsColorCustom)).BeginInit();
            this.SuspendLayout();
            // 
            // btnMap
            // 
            this.btnMap.Location = new System.Drawing.Point(12, 92);
            this.btnMap.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnMap.Name = "btnMap";
            this.btnMap.Size = new System.Drawing.Size(149, 44);
            this.btnMap.TabIndex = 0;
            this.btnMap.Text = "Map";
            this.btnMap.UseVisualStyleBackColor = true;
            this.btnMap.Click += new System.EventHandler(this.btnMap_Click);
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(133, 36);
            this.btnTest.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(85, 44);
            this.btnTest.TabIndex = 1;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnScreen
            // 
            this.btnScreen.Location = new System.Drawing.Point(12, 36);
            this.btnScreen.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnScreen.Name = "btnScreen";
            this.btnScreen.Size = new System.Drawing.Size(149, 44);
            this.btnScreen.TabIndex = 2;
            this.btnScreen.Text = "Screen";
            this.btnScreen.UseVisualStyleBackColor = true;
            this.btnScreen.Click += new System.EventHandler(this.btnScreen_Click);
            // 
            // txtScreen
            // 
            this.txtScreen.Location = new System.Drawing.Point(173, 40);
            this.txtScreen.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtScreen.Name = "txtScreen";
            this.txtScreen.Size = new System.Drawing.Size(196, 31);
            this.txtScreen.TabIndex = 3;
            // 
            // txtSliceStartX
            // 
            this.txtSliceStartX.Location = new System.Drawing.Point(336, 102);
            this.txtSliceStartX.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtSliceStartX.Name = "txtSliceStartX";
            this.txtSliceStartX.Size = new System.Drawing.Size(79, 31);
            this.txtSliceStartX.TabIndex = 4;
            this.txtSliceStartX.Text = "0";
            // 
            // txtSliceStartY
            // 
            this.txtSliceStartY.Location = new System.Drawing.Point(429, 102);
            this.txtSliceStartY.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtSliceStartY.Name = "txtSliceStartY";
            this.txtSliceStartY.Size = new System.Drawing.Size(79, 31);
            this.txtSliceStartY.TabIndex = 5;
            this.txtSliceStartY.Text = "0";
            // 
            // txtRowStart
            // 
            this.txtRowStart.Location = new System.Drawing.Point(524, 102);
            this.txtRowStart.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtRowStart.Name = "txtRowStart";
            this.txtRowStart.Size = new System.Drawing.Size(79, 31);
            this.txtRowStart.TabIndex = 6;
            this.txtRowStart.Text = "0";
            // 
            // stsStrip
            // 
            this.stsStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.stsStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stsStatus,
            this.stsSpacer,
            this.stsState});
            this.stsStrip.Location = new System.Drawing.Point(0, 391);
            this.stsStrip.Name = "stsStrip";
            this.stsStrip.Padding = new System.Windows.Forms.Padding(3, 0, 28, 0);
            this.stsStrip.Size = new System.Drawing.Size(1920, 37);
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
            this.stsSpacer.Size = new System.Drawing.Size(1821, 32);
            this.stsSpacer.Spring = true;
            // 
            // stsState
            // 
            this.stsState.Name = "stsState";
            this.stsState.Size = new System.Drawing.Size(68, 32);
            this.stsState.Text = "State";
            this.stsState.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnGrowXP
            // 
            this.btnGrowXP.Location = new System.Drawing.Point(12, 36);
            this.btnGrowXP.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnGrowXP.Name = "btnGrowXP";
            this.btnGrowXP.Size = new System.Drawing.Size(109, 44);
            this.btnGrowXP.TabIndex = 8;
            this.btnGrowXP.Text = "Mine XP";
            this.btnGrowXP.UseVisualStyleBackColor = true;
            this.btnGrowXP.Click += new System.EventHandler(this.btnGrowXP_Click);
            // 
            // bckScreenState
            // 
            this.bckScreenState.WorkerReportsProgress = true;
            this.bckScreenState.WorkerSupportsCancellation = true;
            this.bckScreenState.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bckScreenState_DoWork);
            this.bckScreenState.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bckScreenState_ProgressChanged);
            // 
            // btnSearchEnemy
            // 
            this.btnSearchEnemy.Location = new System.Drawing.Point(173, 92);
            this.btnSearchEnemy.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnSearchEnemy.Name = "btnSearchEnemy";
            this.btnSearchEnemy.Size = new System.Drawing.Size(149, 44);
            this.btnSearchEnemy.TabIndex = 9;
            this.btnSearchEnemy.Text = "Enemy";
            this.btnSearchEnemy.UseVisualStyleBackColor = true;
            this.btnSearchEnemy.Click += new System.EventHandler(this.btnSearchEnemy_Click);
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
            // lstAccounts
            // 
            this.lstAccounts.FormattingEnabled = true;
            this.lstAccounts.ItemHeight = 25;
            this.lstAccounts.Location = new System.Drawing.Point(12, 36);
            this.lstAccounts.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.lstAccounts.Name = "lstAccounts";
            this.lstAccounts.Size = new System.Drawing.Size(212, 204);
            this.lstAccounts.TabIndex = 10;
            this.lstAccounts.SelectedIndexChanged += new System.EventHandler(this.lstAccounts_SelectedIndexChanged);
            // 
            // btnSwitch
            // 
            this.btnSwitch.Location = new System.Drawing.Point(12, 258);
            this.btnSwitch.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnSwitch.Name = "btnSwitch";
            this.btnSwitch.Size = new System.Drawing.Size(149, 44);
            this.btnSwitch.TabIndex = 11;
            this.btnSwitch.Text = "Switch";
            this.btnSwitch.UseVisualStyleBackColor = true;
            this.btnSwitch.Click += new System.EventHandler(this.btnSwitch_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnScreen);
            this.groupBox1.Controls.Add(this.txtScreen);
            this.groupBox1.Location = new System.Drawing.Point(12, 11);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.groupBox1.Size = new System.Drawing.Size(635, 156);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mapping";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkScheduler);
            this.groupBox2.Controls.Add(this.btnScheduler);
            this.groupBox2.Controls.Add(this.btnMissions);
            this.groupBox2.Controls.Add(this.chkTasks);
            this.groupBox2.Controls.Add(this.btnTasks);
            this.groupBox2.Controls.Add(this.btnClearGifts);
            this.groupBox2.Location = new System.Drawing.Point(12, 179);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.groupBox2.Size = new System.Drawing.Size(635, 144);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Routines";
            // 
            // chkScheduler
            // 
            this.chkScheduler.AutoSize = true;
            this.chkScheduler.Checked = true;
            this.chkScheduler.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkScheduler.Location = new System.Drawing.Point(120, 92);
            this.chkScheduler.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.chkScheduler.Name = "chkScheduler";
            this.chkScheduler.Size = new System.Drawing.Size(141, 29);
            this.chkScheduler.TabIndex = 15;
            this.chkScheduler.Text = "Scheduler";
            this.chkScheduler.UseVisualStyleBackColor = true;
            this.chkScheduler.CheckedChanged += new System.EventHandler(this.chkScheduler_CheckedChanged);
            // 
            // btnScheduler
            // 
            this.btnScheduler.Location = new System.Drawing.Point(349, 36);
            this.btnScheduler.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnScheduler.Name = "btnScheduler";
            this.btnScheduler.Size = new System.Drawing.Size(125, 44);
            this.btnScheduler.TabIndex = 14;
            this.btnScheduler.Text = "Scheduler";
            this.btnScheduler.UseVisualStyleBackColor = true;
            this.btnScheduler.Click += new System.EventHandler(this.btnScheduler_Click);
            // 
            // btnMissions
            // 
            this.btnMissions.Location = new System.Drawing.Point(221, 36);
            this.btnMissions.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
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
            this.chkTasks.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.chkTasks.Name = "chkTasks";
            this.chkTasks.Size = new System.Drawing.Size(102, 29);
            this.chkTasks.TabIndex = 12;
            this.chkTasks.Text = "Tasks";
            this.chkTasks.UseVisualStyleBackColor = true;
            this.chkTasks.CheckedChanged += new System.EventHandler(this.chkTasks_CheckedChanged);
            // 
            // btnTasks
            // 
            this.btnTasks.Location = new System.Drawing.Point(12, 36);
            this.btnTasks.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnTasks.Name = "btnTasks";
            this.btnTasks.Size = new System.Drawing.Size(96, 44);
            this.btnTasks.TabIndex = 11;
            this.btnTasks.Text = "Tasks";
            this.btnTasks.UseVisualStyleBackColor = true;
            this.btnTasks.Click += new System.EventHandler(this.btnTasks_Click);
            // 
            // btnClearGifts
            // 
            this.btnClearGifts.Location = new System.Drawing.Point(120, 36);
            this.btnClearGifts.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnClearGifts.Name = "btnClearGifts";
            this.btnClearGifts.Size = new System.Drawing.Size(91, 44);
            this.btnClearGifts.TabIndex = 9;
            this.btnClearGifts.Text = "Gifts";
            this.btnClearGifts.UseVisualStyleBackColor = true;
            this.btnClearGifts.Click += new System.EventHandler(this.btnClearGifts_Click);
            // 
            // btnMissionXP
            // 
            this.btnMissionXP.Location = new System.Drawing.Point(232, 36);
            this.btnMissionXP.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnMissionXP.Name = "btnMissionXP";
            this.btnMissionXP.Size = new System.Drawing.Size(133, 44);
            this.btnMissionXP.TabIndex = 10;
            this.btnMissionXP.Text = "Mission XP";
            this.btnMissionXP.UseVisualStyleBackColor = true;
            this.btnMissionXP.Click += new System.EventHandler(this.btnMissionXP_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lstAccounts);
            this.groupBox3.Controls.Add(this.btnSwitch);
            this.groupBox3.Location = new System.Drawing.Point(280, 11);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.groupBox3.Size = new System.Drawing.Size(240, 318);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Active Session";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rdoWindow4);
            this.groupBox4.Controls.Add(this.rdoWindow3);
            this.groupBox4.Controls.Add(this.rdoWindow2);
            this.groupBox4.Controls.Add(this.rdoWindow1);
            this.groupBox4.Location = new System.Drawing.Point(12, 11);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.groupBox4.Size = new System.Drawing.Size(256, 102);
            this.groupBox4.TabIndex = 15;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Active Window";
            // 
            // rdoWindow4
            // 
            this.rdoWindow4.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoWindow4.AutoSize = true;
            this.rdoWindow4.Location = new System.Drawing.Point(187, 36);
            this.rdoWindow4.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
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
            this.rdoWindow3.Location = new System.Drawing.Point(128, 36);
            this.rdoWindow3.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
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
            this.rdoWindow2.Location = new System.Drawing.Point(69, 36);
            this.rdoWindow2.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
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
            this.rdoWindow1.Location = new System.Drawing.Point(12, 36);
            this.rdoWindow1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.rdoWindow1.Name = "rdoWindow1";
            this.rdoWindow1.Size = new System.Drawing.Size(34, 35);
            this.rdoWindow1.TabIndex = 16;
            this.rdoWindow1.TabStop = true;
            this.rdoWindow1.Text = "1";
            this.rdoWindow1.UseVisualStyleBackColor = true;
            this.rdoWindow1.CheckedChanged += new System.EventHandler(this.rdoWindow1_CheckedChanged);
            this.rdoWindow1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.rdoWindow1_MouseUp);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabTasks);
            this.tabControl1.Controls.Add(this.tabScreens);
            this.tabControl1.Controls.Add(this.tabAccounts);
            this.tabControl1.Controls.Add(this.tabActivity);
            this.tabControl1.Controls.Add(this.tabDebug);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1920, 391);
            this.tabControl1.TabIndex = 16;
            // 
            // tabTasks
            // 
            this.tabTasks.Controls.Add(this.groupBox6);
            this.tabTasks.Controls.Add(this.groupBox1);
            this.tabTasks.Controls.Add(this.groupBox2);
            this.tabTasks.Location = new System.Drawing.Point(8, 39);
            this.tabTasks.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tabTasks.Name = "tabTasks";
            this.tabTasks.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tabTasks.Size = new System.Drawing.Size(1904, 344);
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
            this.groupBox6.Location = new System.Drawing.Point(659, 11);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.groupBox6.Size = new System.Drawing.Size(828, 156);
            this.groupBox6.TabIndex = 14;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Debug";
            // 
            // btnRestart
            // 
            this.btnRestart.Location = new System.Drawing.Point(380, 36);
            this.btnRestart.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(99, 44);
            this.btnRestart.TabIndex = 11;
            this.btnRestart.Text = "Restart";
            this.btnRestart.UseVisualStyleBackColor = true;
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // tabScreens
            // 
            this.tabScreens.Controls.Add(this.groupBox7);
            this.tabScreens.Controls.Add(this.groupBox5);
            this.tabScreens.Controls.Add(this.groupBox3);
            this.tabScreens.Controls.Add(this.groupBox4);
            this.tabScreens.Location = new System.Drawing.Point(8, 39);
            this.tabScreens.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tabScreens.Name = "tabScreens";
            this.tabScreens.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tabScreens.Size = new System.Drawing.Size(1904, 344);
            this.tabScreens.TabIndex = 1;
            this.tabScreens.Text = "Session";
            this.tabScreens.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.btnScheduleRun);
            this.groupBox7.Controls.Add(this.gridSchedules);
            this.groupBox7.Location = new System.Drawing.Point(533, 14);
            this.groupBox7.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.groupBox7.Size = new System.Drawing.Size(1357, 315);
            this.groupBox7.TabIndex = 17;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Schedules";
            // 
            // btnScheduleRun
            // 
            this.btnScheduleRun.Location = new System.Drawing.Point(13, 256);
            this.btnScheduleRun.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnScheduleRun.Name = "btnScheduleRun";
            this.btnScheduleRun.Size = new System.Drawing.Size(149, 44);
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
            this.lastActionDataGridViewTextBoxColumn,
            this.nextActionDataGridViewTextBoxColumn});
            this.gridSchedules.DataSource = this.bsScheduleTask;
            this.gridSchedules.Location = new System.Drawing.Point(12, 36);
            this.gridSchedules.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.gridSchedules.Name = "gridSchedules";
            this.gridSchedules.Size = new System.Drawing.Size(1333, 206);
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
            this.intervalDataGridViewTextBoxColumn.Name = "intervalDataGridViewTextBoxColumn";
            this.intervalDataGridViewTextBoxColumn.Width = 127;
            // 
            // amountDataGridViewTextBoxColumn
            // 
            this.amountDataGridViewTextBoxColumn.DataPropertyName = "Amount";
            this.amountDataGridViewTextBoxColumn.HeaderText = "Amount";
            this.amountDataGridViewTextBoxColumn.Name = "amountDataGridViewTextBoxColumn";
            this.amountDataGridViewTextBoxColumn.Width = 130;
            // 
            // countDataGridViewTextBoxColumn
            // 
            this.countDataGridViewTextBoxColumn.DataPropertyName = "Count";
            this.countDataGridViewTextBoxColumn.HeaderText = "Count";
            this.countDataGridViewTextBoxColumn.Name = "countDataGridViewTextBoxColumn";
            this.countDataGridViewTextBoxColumn.Width = 114;
            // 
            // xDataGridViewTextBoxColumn
            // 
            this.xDataGridViewTextBoxColumn.DataPropertyName = "X";
            this.xDataGridViewTextBoxColumn.HeaderText = "X";
            this.xDataGridViewTextBoxColumn.Name = "xDataGridViewTextBoxColumn";
            this.xDataGridViewTextBoxColumn.Width = 71;
            // 
            // yDataGridViewTextBoxColumn
            // 
            this.yDataGridViewTextBoxColumn.DataPropertyName = "Y";
            this.yDataGridViewTextBoxColumn.HeaderText = "Y";
            this.yDataGridViewTextBoxColumn.Name = "yDataGridViewTextBoxColumn";
            this.yDataGridViewTextBoxColumn.Width = 72;
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
            // bsScheduleTask
            // 
            this.bsScheduleTask.DataSource = typeof(CodeStrikeBot.ScheduleTask);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnResize);
            this.groupBox5.Location = new System.Drawing.Point(13, 128);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.groupBox5.Size = new System.Drawing.Size(253, 202);
            this.groupBox5.TabIndex = 16;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Windows Tasks";
            // 
            // btnResize
            // 
            this.btnResize.Location = new System.Drawing.Point(13, 39);
            this.btnResize.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnResize.Name = "btnResize";
            this.btnResize.Size = new System.Drawing.Size(149, 44);
            this.btnResize.TabIndex = 0;
            this.btnResize.Text = "Resize";
            this.btnResize.UseVisualStyleBackColor = true;
            this.btnResize.Click += new System.EventHandler(this.btnResize_Click);
            // 
            // tabAccounts
            // 
            this.tabAccounts.Controls.Add(this.groupBox8);
            this.tabAccounts.Location = new System.Drawing.Point(8, 39);
            this.tabAccounts.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tabAccounts.Name = "tabAccounts";
            this.tabAccounts.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tabAccounts.Size = new System.Drawing.Size(1904, 343);
            this.tabAccounts.TabIndex = 4;
            this.tabAccounts.Text = "Accounts";
            this.tabAccounts.UseVisualStyleBackColor = true;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.gridAccounts);
            this.groupBox8.Location = new System.Drawing.Point(16, 8);
            this.groupBox8.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
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
            this.gridAccounts.Location = new System.Drawing.Point(12, 36);
            this.gridAccounts.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.gridAccounts.Name = "gridAccounts";
            this.gridAccounts.Size = new System.Drawing.Size(1848, 268);
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
            // bsAccount
            // 
            this.bsAccount.DataSource = typeof(CodeStrikeBot.Account);
            // 
            // tabActivity
            // 
            this.tabActivity.Controls.Add(this.contActivity);
            this.tabActivity.Location = new System.Drawing.Point(8, 39);
            this.tabActivity.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tabActivity.Name = "tabActivity";
            this.tabActivity.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tabActivity.Size = new System.Drawing.Size(1904, 343);
            this.tabActivity.TabIndex = 2;
            this.tabActivity.Text = "Activity";
            this.tabActivity.UseVisualStyleBackColor = true;
            // 
            // contActivity
            // 
            this.contActivity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contActivity.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.contActivity.Location = new System.Drawing.Point(5, 6);
            this.contActivity.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.contActivity.Name = "contActivity";
            // 
            // contActivity.Panel1
            // 
            this.contActivity.Panel1.Controls.Add(this.gridPacket);
            // 
            // contActivity.Panel2
            // 
            this.contActivity.Panel2.Controls.Add(this.splitContainer2);
            this.contActivity.Size = new System.Drawing.Size(1894, 331);
            this.contActivity.SplitterDistance = 270;
            this.contActivity.SplitterWidth = 8;
            this.contActivity.TabIndex = 20;
            // 
            // gridPacket
            // 
            this.gridPacket.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.gridPacket.AllowDrop = true;
            this.gridPacket.AutoGenerateColumns = false;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridPacket.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.gridPacket.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridPacket.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.timestampDataGridViewTextBoxColumn,
            this.typeDataGridViewTextBoxColumn,
            this.lengthDataGridViewTextBoxColumn,
            this.Ack});
            this.gridPacket.DataSource = this.bsPacket;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridPacket.DefaultCellStyle = dataGridViewCellStyle8;
            this.gridPacket.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridPacket.Location = new System.Drawing.Point(0, 0);
            this.gridPacket.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.gridPacket.Name = "gridPacket";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridPacket.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.gridPacket.Size = new System.Drawing.Size(270, 331);
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
            // Ack
            // 
            this.Ack.DataPropertyName = "Ack";
            this.Ack.HeaderText = "Ack";
            this.Ack.Name = "Ack";
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
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
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
            this.splitContainer2.Size = new System.Drawing.Size(1616, 331);
            this.splitContainer2.SplitterDistance = 30;
            this.splitContainer2.SplitterWidth = 8;
            this.splitContainer2.TabIndex = 20;
            // 
            // btnCopyText
            // 
            this.btnCopyText.Location = new System.Drawing.Point(416, 8);
            this.btnCopyText.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnCopyText.Name = "btnCopyText";
            this.btnCopyText.Size = new System.Drawing.Size(149, 44);
            this.btnCopyText.TabIndex = 3;
            this.btnCopyText.Text = "Copy Text";
            this.btnCopyText.UseVisualStyleBackColor = true;
            this.btnCopyText.Click += new System.EventHandler(this.btnCopyText_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(253, 8);
            this.btnExport.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(149, 44);
            this.btnExport.TabIndex = 2;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            // 
            // rdoRaw
            // 
            this.rdoRaw.AutoSize = true;
            this.rdoRaw.Location = new System.Drawing.Point(147, 14);
            this.rdoRaw.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
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
            this.rdoPayload.Location = new System.Drawing.Point(8, 14);
            this.rdoPayload.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
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
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
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
            this.splitContainer1.Size = new System.Drawing.Size(1616, 293);
            this.splitContainer1.SplitterDistance = 144;
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
            this.hexData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hexData.Location = new System.Drawing.Point(0, 0);
            this.hexData.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
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
            this.hexData.Size = new System.Drawing.Size(1616, 144);
            this.hexData.TabIndex = 18;
            // 
            // treeXml
            // 
            this.treeXml.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeXml.Location = new System.Drawing.Point(0, 0);
            this.treeXml.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.treeXml.Name = "treeXml";
            this.treeXml.Size = new System.Drawing.Size(1616, 141);
            this.treeXml.TabIndex = 0;
            // 
            // tabDebug
            // 
            this.tabDebug.Controls.Add(this.lblBmpChecksum);
            this.tabDebug.Controls.Add(this.picCheck);
            this.tabDebug.Controls.Add(this.txtBmpSize);
            this.tabDebug.Controls.Add(this.label6);
            this.tabDebug.Controls.Add(this.label5);
            this.tabDebug.Controls.Add(this.label4);
            this.tabDebug.Controls.Add(this.label3);
            this.tabDebug.Controls.Add(this.label2);
            this.tabDebug.Controls.Add(this.label1);
            this.tabDebug.Controls.Add(this.textBox18);
            this.tabDebug.Controls.Add(this.textBox19);
            this.tabDebug.Controls.Add(this.txt);
            this.tabDebug.Controls.Add(this.textBox15);
            this.tabDebug.Controls.Add(this.textBox16);
            this.tabDebug.Controls.Add(this.textBox17);
            this.tabDebug.Controls.Add(this.textBox12);
            this.tabDebug.Controls.Add(this.textBox13);
            this.tabDebug.Controls.Add(this.textBox14);
            this.tabDebug.Controls.Add(this.textBox9);
            this.tabDebug.Controls.Add(this.textBox10);
            this.tabDebug.Controls.Add(this.textBox11);
            this.tabDebug.Controls.Add(this.textBox8);
            this.tabDebug.Controls.Add(this.textBox7);
            this.tabDebug.Controls.Add(this.textBox6);
            this.tabDebug.Controls.Add(this.textBox5);
            this.tabDebug.Controls.Add(this.textBox4);
            this.tabDebug.Controls.Add(this.textBox3);
            this.tabDebug.Controls.Add(this.txtCustomY);
            this.tabDebug.Controls.Add(this.txtCustomX);
            this.tabDebug.Location = new System.Drawing.Point(8, 39);
            this.tabDebug.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tabDebug.Name = "tabDebug";
            this.tabDebug.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tabDebug.Size = new System.Drawing.Size(1904, 343);
            this.tabDebug.TabIndex = 3;
            this.tabDebug.Text = "Debug";
            this.tabDebug.UseVisualStyleBackColor = true;
            // 
            // lblBmpChecksum
            // 
            this.lblBmpChecksum.AutoSize = true;
            this.lblBmpChecksum.Location = new System.Drawing.Point(419, 19);
            this.lblBmpChecksum.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblBmpChecksum.Name = "lblBmpChecksum";
            this.lblBmpChecksum.Size = new System.Drawing.Size(0, 25);
            this.lblBmpChecksum.TabIndex = 28;
            // 
            // picCheck
            // 
            this.picCheck.Location = new System.Drawing.Point(365, 14);
            this.picCheck.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.picCheck.Name = "picCheck";
            this.picCheck.Size = new System.Drawing.Size(40, 39);
            this.picCheck.TabIndex = 27;
            this.picCheck.TabStop = false;
            // 
            // txtBmpSize
            // 
            this.txtBmpSize.Location = new System.Drawing.Point(245, 11);
            this.txtBmpSize.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtBmpSize.Name = "txtBmpSize";
            this.txtBmpSize.Size = new System.Drawing.Size(84, 31);
            this.txtBmpSize.TabIndex = 26;
            this.txtBmpSize.Text = "20";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(520, 75);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 25);
            this.label6.TabIndex = 25;
            this.label6.Text = "Custom";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(443, 75);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 25);
            this.label5.TabIndex = 24;
            this.label5.Text = "c5";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(341, 75);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 25);
            this.label4.TabIndex = 23;
            this.label4.Text = "c4";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(240, 75);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 25);
            this.label3.TabIndex = 22;
            this.label3.Text = "c3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(140, 75);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 25);
            this.label2.TabIndex = 21;
            this.label2.Text = "c2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 75);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 25);
            this.label1.TabIndex = 20;
            this.label1.Text = "c1";
            // 
            // textBox18
            // 
            this.textBox18.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsColorCustom, "B", true));
            this.textBox18.Enabled = false;
            this.textBox18.Location = new System.Drawing.Point(517, 206);
            this.textBox18.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.textBox18.Name = "textBox18";
            this.textBox18.Size = new System.Drawing.Size(84, 31);
            this.textBox18.TabIndex = 19;
            // 
            // bsColorCustom
            // 
            this.bsColorCustom.DataSource = typeof(System.Drawing.Color);
            // 
            // textBox19
            // 
            this.textBox19.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsColorCustom, "G", true));
            this.textBox19.Enabled = false;
            this.textBox19.Location = new System.Drawing.Point(517, 156);
            this.textBox19.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.textBox19.Name = "textBox19";
            this.textBox19.Size = new System.Drawing.Size(84, 31);
            this.textBox19.TabIndex = 18;
            // 
            // txt
            // 
            this.txt.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsColorCustom, "R", true));
            this.txt.Enabled = false;
            this.txt.Location = new System.Drawing.Point(517, 106);
            this.txt.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txt.Name = "txt";
            this.txt.Size = new System.Drawing.Size(84, 31);
            this.txt.TabIndex = 17;
            // 
            // textBox15
            // 
            this.textBox15.Enabled = false;
            this.textBox15.Location = new System.Drawing.Point(419, 206);
            this.textBox15.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.textBox15.Name = "textBox15";
            this.textBox15.Size = new System.Drawing.Size(84, 31);
            this.textBox15.TabIndex = 16;
            // 
            // textBox16
            // 
            this.textBox16.Enabled = false;
            this.textBox16.Location = new System.Drawing.Point(419, 156);
            this.textBox16.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.textBox16.Name = "textBox16";
            this.textBox16.Size = new System.Drawing.Size(84, 31);
            this.textBox16.TabIndex = 15;
            // 
            // textBox17
            // 
            this.textBox17.Enabled = false;
            this.textBox17.Location = new System.Drawing.Point(419, 106);
            this.textBox17.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.textBox17.Name = "textBox17";
            this.textBox17.Size = new System.Drawing.Size(84, 31);
            this.textBox17.TabIndex = 14;
            // 
            // textBox12
            // 
            this.textBox12.Enabled = false;
            this.textBox12.Location = new System.Drawing.Point(317, 206);
            this.textBox12.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(84, 31);
            this.textBox12.TabIndex = 13;
            // 
            // textBox13
            // 
            this.textBox13.Enabled = false;
            this.textBox13.Location = new System.Drawing.Point(317, 156);
            this.textBox13.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new System.Drawing.Size(84, 31);
            this.textBox13.TabIndex = 12;
            // 
            // textBox14
            // 
            this.textBox14.Enabled = false;
            this.textBox14.Location = new System.Drawing.Point(317, 106);
            this.textBox14.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new System.Drawing.Size(84, 31);
            this.textBox14.TabIndex = 11;
            // 
            // textBox9
            // 
            this.textBox9.Enabled = false;
            this.textBox9.Location = new System.Drawing.Point(219, 206);
            this.textBox9.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(84, 31);
            this.textBox9.TabIndex = 10;
            // 
            // textBox10
            // 
            this.textBox10.Enabled = false;
            this.textBox10.Location = new System.Drawing.Point(219, 156);
            this.textBox10.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(84, 31);
            this.textBox10.TabIndex = 9;
            // 
            // textBox11
            // 
            this.textBox11.Enabled = false;
            this.textBox11.Location = new System.Drawing.Point(219, 106);
            this.textBox11.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(84, 31);
            this.textBox11.TabIndex = 8;
            // 
            // textBox8
            // 
            this.textBox8.Enabled = false;
            this.textBox8.Location = new System.Drawing.Point(117, 206);
            this.textBox8.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(84, 31);
            this.textBox8.TabIndex = 7;
            // 
            // textBox7
            // 
            this.textBox7.Enabled = false;
            this.textBox7.Location = new System.Drawing.Point(117, 156);
            this.textBox7.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(84, 31);
            this.textBox7.TabIndex = 6;
            // 
            // textBox6
            // 
            this.textBox6.Enabled = false;
            this.textBox6.Location = new System.Drawing.Point(117, 106);
            this.textBox6.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(84, 31);
            this.textBox6.TabIndex = 5;
            // 
            // textBox5
            // 
            this.textBox5.Enabled = false;
            this.textBox5.Location = new System.Drawing.Point(19, 206);
            this.textBox5.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(84, 31);
            this.textBox5.TabIndex = 4;
            // 
            // textBox4
            // 
            this.textBox4.Enabled = false;
            this.textBox4.Location = new System.Drawing.Point(19, 156);
            this.textBox4.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(84, 31);
            this.textBox4.TabIndex = 3;
            // 
            // textBox3
            // 
            this.textBox3.Enabled = false;
            this.textBox3.Location = new System.Drawing.Point(19, 106);
            this.textBox3.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(84, 31);
            this.textBox3.TabIndex = 2;
            // 
            // txtCustomY
            // 
            this.txtCustomY.Location = new System.Drawing.Point(117, 14);
            this.txtCustomY.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtCustomY.Name = "txtCustomY";
            this.txtCustomY.Size = new System.Drawing.Size(84, 31);
            this.txtCustomY.TabIndex = 1;
            this.txtCustomY.Text = "0";
            // 
            // txtCustomX
            // 
            this.txtCustomX.Location = new System.Drawing.Point(19, 14);
            this.txtCustomX.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtCustomX.Name = "txtCustomX";
            this.txtCustomX.Size = new System.Drawing.Size(84, 31);
            this.txtCustomX.TabIndex = 0;
            this.txtCustomX.Text = "0";
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
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1920, 428);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.stsStrip);
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "Main";
            this.Text = "CodeStrikeBot";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
            this.Load += new System.EventHandler(this.Main_Load);
            this.stsStrip.ResumeLayout(false);
            this.stsStrip.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabTasks.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.tabScreens.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridSchedules)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsScheduleTask)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.tabAccounts.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridAccounts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAccount)).EndInit();
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
            this.tabDebug.ResumeLayout(false);
            this.tabDebug.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCheck)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsColorCustom)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnMap;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Button btnScreen;
        private System.Windows.Forms.TextBox txtScreen;
        private System.Windows.Forms.TextBox txtSliceStartX;
        private System.Windows.Forms.TextBox txtSliceStartY;
        private System.Windows.Forms.TextBox txtRowStart;
        private System.Windows.Forms.StatusStrip stsStrip;
        private System.Windows.Forms.ToolStripStatusLabel stsState;
        private System.Windows.Forms.Button btnGrowXP;
        private System.ComponentModel.BackgroundWorker bckScreenState;
        private System.Windows.Forms.ToolStripStatusLabel stsSpacer;
        private System.Windows.Forms.Button btnSearchEnemy;
        private System.ComponentModel.BackgroundWorker bckSniffer;
        private System.ComponentModel.BackgroundWorker bckHeartBeat;
        private System.Windows.Forms.ListBox lstAccounts;
        private System.Windows.Forms.Button btnSwitch;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton rdoWindow4;
        private System.Windows.Forms.RadioButton rdoWindow3;
        private System.Windows.Forms.RadioButton rdoWindow2;
        private System.Windows.Forms.RadioButton rdoWindow1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabTasks;
        private System.Windows.Forms.TabPage tabScreens;
        private System.Windows.Forms.TabPage tabActivity;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnResize;
        private System.Windows.Forms.DataGridView gridPacket;
        private System.Windows.Forms.BindingSource bsPacket;
        private System.ComponentModel.Design.ByteViewer hexData;
        private System.Windows.Forms.SplitContainer contActivity;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeXml;
        private System.Windows.Forms.DataGridViewTextBoxColumn timestampDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lengthDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ack;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.RadioButton rdoRaw;
        private System.Windows.Forms.RadioButton rdoPayload;
        private System.Windows.Forms.Button btnCopyText;
        private System.Windows.Forms.TabPage tabDebug;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox18;
        private System.Windows.Forms.TextBox textBox19;
        private System.Windows.Forms.TextBox txt;
        private System.Windows.Forms.TextBox textBox15;
        private System.Windows.Forms.TextBox textBox16;
        private System.Windows.Forms.TextBox textBox17;
        private System.Windows.Forms.TextBox textBox12;
        private System.Windows.Forms.TextBox textBox13;
        private System.Windows.Forms.TextBox textBox14;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox txtCustomY;
        private System.Windows.Forms.TextBox txtCustomX;
        private System.Drawing.Color clrCustom;
        private System.Windows.Forms.BindingSource bsColorCustom;
        private System.Windows.Forms.Button btnClearGifts;
        private System.Windows.Forms.Button btnMissionXP;
        private System.Windows.Forms.Button btnTasks;
        private System.ComponentModel.BackgroundWorker bckRegularTasks;
        private System.Windows.Forms.CheckBox chkTasks;
        private System.Windows.Forms.ToolStripStatusLabel stsStatus;
        private System.Windows.Forms.PictureBox picCheck;
        private System.Windows.Forms.TextBox txtBmpSize;
        private System.Windows.Forms.Label lblBmpChecksum;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.DataGridView gridSchedules;
        private System.ComponentModel.BackgroundWorker bckScheduler;
        private System.Windows.Forms.BindingSource bsScheduleTask;
        private System.ComponentModel.BackgroundWorker bckKeepAlive;
        private System.Windows.Forms.Button btnMissions;
        private System.Windows.Forms.Button btnScheduler;
        private System.Windows.Forms.CheckBox chkScheduler;
        private System.Windows.Forms.Button btnScheduleRun;
        private System.ComponentModel.BackgroundWorker bckAutoActions;
        private System.Windows.Forms.TabPage tabAccounts;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.DataGridView gridAccounts;
        private System.Windows.Forms.BindingSource bsAccount;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn userNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn passwordDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn priorityGridViewComboBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn foodNegativeAmountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastLoginDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastLogoutDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn typeDataGridViewComboBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn intervalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn amountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn countDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn xDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn yDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastActionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nextActionDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button btnRestart;
    }
}

