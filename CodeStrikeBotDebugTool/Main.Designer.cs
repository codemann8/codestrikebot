namespace CodeStrikeBot.Debug
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
            this.picScreen1 = new System.Windows.Forms.PictureBox();
            this.txtBmpSizeX = new System.Windows.Forms.TextBox();
            this.txtRGB = new System.Windows.Forms.TextBox();
            this.txtCustomX = new System.Windows.Forms.TextBox();
            this.lblBmpChecksum = new System.Windows.Forms.Label();
            this.picCheck = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCustomY = new System.Windows.Forms.TextBox();
            this.txtBmpSizeY = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnScreen1 = new System.Windows.Forms.Button();
            this.btnScreen2 = new System.Windows.Forms.Button();
            this.btnScreen3 = new System.Windows.Forms.Button();
            this.btnScreen4 = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.dlgLoad = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.picScreen1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCheck)).BeginInit();
            this.SuspendLayout();
            // 
            // picScreen1
            // 
            this.picScreen1.Location = new System.Drawing.Point(12, 12);
            this.picScreen1.Name = "picScreen1";
            this.picScreen1.Size = new System.Drawing.Size(394, 702);
            this.picScreen1.TabIndex = 0;
            this.picScreen1.TabStop = false;
            this.picScreen1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picScreen1_MouseMove);
            // 
            // txtBmpSizeX
            // 
            this.txtBmpSizeX.Location = new System.Drawing.Point(108, 796);
            this.txtBmpSizeX.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtBmpSizeX.Name = "txtBmpSizeX";
            this.txtBmpSizeX.Size = new System.Drawing.Size(30, 20);
            this.txtBmpSizeX.TabIndex = 12;
            this.txtBmpSizeX.Text = "20";
            this.txtBmpSizeX.TextChanged += new System.EventHandler(this.txtBmpSizeX_TextChanged);
            // 
            // txtRGB
            // 
            this.txtRGB.Enabled = false;
            this.txtRGB.Location = new System.Drawing.Point(187, 796);
            this.txtRGB.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtRGB.Name = "txtRGB";
            this.txtRGB.Size = new System.Drawing.Size(70, 20);
            this.txtRGB.TabIndex = 32;
            // 
            // txtCustomX
            // 
            this.txtCustomX.Location = new System.Drawing.Point(12, 796);
            this.txtCustomX.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtCustomX.Name = "txtCustomX";
            this.txtCustomX.Size = new System.Drawing.Size(39, 20);
            this.txtCustomX.TabIndex = 10;
            this.txtCustomX.Text = "0";
            this.txtCustomX.TextChanged += new System.EventHandler(this.txtCustomX_TextChanged);
            // 
            // lblBmpChecksum
            // 
            this.lblBmpChecksum.AutoSize = true;
            this.lblBmpChecksum.Location = new System.Drawing.Point(301, 799);
            this.lblBmpChecksum.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBmpChecksum.Name = "lblBmpChecksum";
            this.lblBmpChecksum.Size = new System.Drawing.Size(0, 13);
            this.lblBmpChecksum.TabIndex = 38;
            // 
            // picCheck
            // 
            this.picCheck.Location = new System.Drawing.Point(273, 796);
            this.picCheck.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.picCheck.Name = "picCheck";
            this.picCheck.Size = new System.Drawing.Size(20, 20);
            this.picCheck.TabIndex = 37;
            this.picCheck.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(184, 780);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 35;
            this.label6.Text = "Color";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 780);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 13);
            this.label1.TabIndex = 39;
            this.label1.Text = "X";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 780);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 13);
            this.label2.TabIndex = 40;
            this.label2.Text = "Y";
            // 
            // txtCustomY
            // 
            this.txtCustomY.Location = new System.Drawing.Point(55, 796);
            this.txtCustomY.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtCustomY.Name = "txtCustomY";
            this.txtCustomY.Size = new System.Drawing.Size(39, 20);
            this.txtCustomY.TabIndex = 11;
            this.txtCustomY.Text = "0";
            this.txtCustomY.TextChanged += new System.EventHandler(this.txtCustomY_TextChanged);
            // 
            // txtBmpSizeY
            // 
            this.txtBmpSizeY.Location = new System.Drawing.Point(142, 796);
            this.txtBmpSizeY.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtBmpSizeY.Name = "txtBmpSizeY";
            this.txtBmpSizeY.Size = new System.Drawing.Size(30, 20);
            this.txtBmpSizeY.TabIndex = 13;
            this.txtBmpSizeY.Text = "20";
            this.txtBmpSizeY.TextChanged += new System.EventHandler(this.txtBmpSizeY_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(105, 780);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 13);
            this.label3.TabIndex = 44;
            this.label3.Text = "W";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(142, 780);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 13);
            this.label4.TabIndex = 45;
            this.label4.Text = "H";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(270, 780);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 46;
            this.label5.Text = "Checksum";
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(12, 720);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 4;
            this.btnLoad.Text = "&Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnScreen1
            // 
            this.btnScreen1.Location = new System.Drawing.Point(93, 720);
            this.btnScreen1.Name = "btnScreen1";
            this.btnScreen1.Size = new System.Drawing.Size(23, 23);
            this.btnScreen1.TabIndex = 5;
            this.btnScreen1.Text = "1";
            this.btnScreen1.UseVisualStyleBackColor = true;
            this.btnScreen1.Click += new System.EventHandler(this.btnScreen1_Click);
            // 
            // btnScreen2
            // 
            this.btnScreen2.Location = new System.Drawing.Point(122, 720);
            this.btnScreen2.Name = "btnScreen2";
            this.btnScreen2.Size = new System.Drawing.Size(23, 23);
            this.btnScreen2.TabIndex = 6;
            this.btnScreen2.Text = "2";
            this.btnScreen2.UseVisualStyleBackColor = true;
            this.btnScreen2.Click += new System.EventHandler(this.btnScreen2_Click);
            // 
            // btnScreen3
            // 
            this.btnScreen3.Location = new System.Drawing.Point(151, 720);
            this.btnScreen3.Name = "btnScreen3";
            this.btnScreen3.Size = new System.Drawing.Size(23, 23);
            this.btnScreen3.TabIndex = 7;
            this.btnScreen3.Text = "3";
            this.btnScreen3.UseVisualStyleBackColor = true;
            this.btnScreen3.Click += new System.EventHandler(this.btnScreen3_Click);
            // 
            // btnScreen4
            // 
            this.btnScreen4.Location = new System.Drawing.Point(180, 720);
            this.btnScreen4.Name = "btnScreen4";
            this.btnScreen4.Size = new System.Drawing.Size(23, 23);
            this.btnScreen4.TabIndex = 8;
            this.btnScreen4.Text = "4";
            this.btnScreen4.UseVisualStyleBackColor = true;
            this.btnScreen4.Click += new System.EventHandler(this.btnScreen4_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(331, 720);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 862);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnScreen4);
            this.Controls.Add(this.btnScreen3);
            this.Controls.Add(this.btnScreen2);
            this.Controls.Add(this.btnScreen1);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtBmpSizeY);
            this.Controls.Add(this.txtCustomY);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBmpSizeX);
            this.Controls.Add(this.txtRGB);
            this.Controls.Add(this.txtCustomX);
            this.Controls.Add(this.lblBmpChecksum);
            this.Controls.Add(this.picCheck);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.picScreen1);
            this.DataBindings.Add(new System.Windows.Forms.Binding("Location", global::CodeStrikeBot.Properties.Settings.Default, "Location", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Location = global::CodeStrikeBot.Properties.Settings.Default.Location;
            this.Name = "Main";
            this.Text = "CodeStrikeBot Debug Tool";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picScreen1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCheck)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picScreen1;
        private System.Windows.Forms.TextBox txtBmpSizeX;
        private System.Windows.Forms.TextBox txtRGB;
        private System.Windows.Forms.TextBox txtCustomX;
        private System.Windows.Forms.Label lblBmpChecksum;
        private System.Windows.Forms.PictureBox picCheck;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCustomY;
        private System.Windows.Forms.TextBox txtBmpSizeY;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnScreen1;
        private System.Windows.Forms.Button btnScreen2;
        private System.Windows.Forms.Button btnScreen3;
        private System.Windows.Forms.Button btnScreen4;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.OpenFileDialog dlgLoad;
    }
}

