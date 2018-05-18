namespace PTT2CarGps
{
    partial class GPSform
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
            this.settingsGB = new System.Windows.Forms.GroupBox();
            this.SerialComLB = new System.Windows.Forms.ListBox();
            this.ConnectBTTN = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.baudRateCBB = new System.Windows.Forms.ComboBox();
            this.refreshComPortBTTN = new System.Windows.Forms.Button();
            this.comPortCBB = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.readSerialTimer = new System.Windows.Forms.Timer(this.components);
            this.CarLocationsPB = new System.Windows.Forms.PictureBox();
            this.infoSS = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.button1 = new System.Windows.Forms.Button();
            this.settingsGB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CarLocationsPB)).BeginInit();
            this.infoSS.SuspendLayout();
            this.SuspendLayout();
            // 
            // settingsGB
            // 
            this.settingsGB.Controls.Add(this.SerialComLB);
            this.settingsGB.Controls.Add(this.ConnectBTTN);
            this.settingsGB.Controls.Add(this.label2);
            this.settingsGB.Controls.Add(this.baudRateCBB);
            this.settingsGB.Controls.Add(this.refreshComPortBTTN);
            this.settingsGB.Controls.Add(this.comPortCBB);
            this.settingsGB.Controls.Add(this.label1);
            this.settingsGB.Location = new System.Drawing.Point(12, 12);
            this.settingsGB.Name = "settingsGB";
            this.settingsGB.Size = new System.Drawing.Size(211, 589);
            this.settingsGB.TabIndex = 0;
            this.settingsGB.TabStop = false;
            this.settingsGB.Text = "Settings";
            // 
            // SerialComLB
            // 
            this.SerialComLB.FormattingEnabled = true;
            this.SerialComLB.Location = new System.Drawing.Point(6, 130);
            this.SerialComLB.Name = "SerialComLB";
            this.SerialComLB.Size = new System.Drawing.Size(199, 134);
            this.SerialComLB.TabIndex = 6;
            // 
            // ConnectBTTN
            // 
            this.ConnectBTTN.Location = new System.Drawing.Point(84, 101);
            this.ConnectBTTN.Name = "ConnectBTTN";
            this.ConnectBTTN.Size = new System.Drawing.Size(121, 23);
            this.ConnectBTTN.TabIndex = 5;
            this.ConnectBTTN.Text = "Connect";
            this.ConnectBTTN.UseVisualStyleBackColor = true;
            this.ConnectBTTN.Click += new System.EventHandler(this.ConnectBTTN_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Baud rate:";
            // 
            // baudRateCBB
            // 
            this.baudRateCBB.FormattingEnabled = true;
            this.baudRateCBB.Items.AddRange(new object[] {
            "110",
            "150",
            "300",
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "115200",
            "230400",
            "460800",
            "921600"});
            this.baudRateCBB.Location = new System.Drawing.Point(84, 74);
            this.baudRateCBB.Name = "baudRateCBB";
            this.baudRateCBB.Size = new System.Drawing.Size(121, 21);
            this.baudRateCBB.TabIndex = 3;
            // 
            // refreshComPortBTTN
            // 
            this.refreshComPortBTTN.Location = new System.Drawing.Point(84, 18);
            this.refreshComPortBTTN.Name = "refreshComPortBTTN";
            this.refreshComPortBTTN.Size = new System.Drawing.Size(121, 23);
            this.refreshComPortBTTN.TabIndex = 2;
            this.refreshComPortBTTN.Text = "Refresh COM ports";
            this.refreshComPortBTTN.UseVisualStyleBackColor = true;
            this.refreshComPortBTTN.Click += new System.EventHandler(this.refreshComPortBTTN_Click);
            // 
            // comPortCBB
            // 
            this.comPortCBB.FormattingEnabled = true;
            this.comPortCBB.Location = new System.Drawing.Point(84, 47);
            this.comPortCBB.Name = "comPortCBB";
            this.comPortCBB.Size = new System.Drawing.Size(121, 21);
            this.comPortCBB.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "COM port:";
            // 
            // readSerialTimer
            // 
            this.readSerialTimer.Interval = 10;
            this.readSerialTimer.Tick += new System.EventHandler(this.ReadSerialTimer_Tick);
            // 
            // CarLocationsPB
            // 
            this.CarLocationsPB.BackColor = System.Drawing.Color.Black;
            this.CarLocationsPB.Location = new System.Drawing.Point(229, 12);
            this.CarLocationsPB.Name = "CarLocationsPB";
            this.CarLocationsPB.Size = new System.Drawing.Size(640, 400);
            this.CarLocationsPB.TabIndex = 1;
            this.CarLocationsPB.TabStop = false;
            this.CarLocationsPB.Paint += new System.Windows.Forms.PaintEventHandler(this.CarLocationsPB_Paint);
            // 
            // infoSS
            // 
            this.infoSS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.infoSS.Location = new System.Drawing.Point(0, 591);
            this.infoSS.Name = "infoSS";
            this.infoSS.Size = new System.Drawing.Size(883, 22);
            this.infoSS.TabIndex = 2;
            this.infoSS.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(120, 17);
            this.toolStripStatusLabel1.Text = "ConnectionStatusLBL";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(794, 418);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Test";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // GPSform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 613);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.infoSS);
            this.Controls.Add(this.CarLocationsPB);
            this.Controls.Add(this.settingsGB);
            this.Name = "GPSform";
            this.Text = "Car gps";
            this.settingsGB.ResumeLayout(false);
            this.settingsGB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CarLocationsPB)).EndInit();
            this.infoSS.ResumeLayout(false);
            this.infoSS.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox settingsGB;
        private System.Windows.Forms.Button refreshComPortBTTN;
        private System.Windows.Forms.ComboBox comPortCBB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox baudRateCBB;
        private System.Windows.Forms.Timer readSerialTimer;
        private System.Windows.Forms.PictureBox CarLocationsPB;
        private System.Windows.Forms.StatusStrip infoSS;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button ConnectBTTN;
        private System.Windows.Forms.ListBox SerialComLB;
        private System.Windows.Forms.Button button1;
    }
}

