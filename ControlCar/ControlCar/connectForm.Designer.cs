namespace ControlCar
{
    partial class connectForm
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
            this.textBox_ip = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numeric_port = new System.Windows.Forms.NumericUpDown();
            this.button_connect = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button_forward = new System.Windows.Forms.Button();
            this.button_left = new System.Windows.Forms.Button();
            this.button_right = new System.Windows.Forms.Button();
            this.button_backward = new System.Windows.Forms.Button();
            this.group_control = new System.Windows.Forms.GroupBox();
            this.button_brake = new System.Windows.Forms.Button();
            this.button_emergencyBrake = new System.Windows.Forms.Button();
            this.textBox_console = new System.Windows.Forms.TextBox();
            this.numeric_speed = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_port)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.group_control.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_speed)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox_ip
            // 
            this.textBox_ip.Location = new System.Drawing.Point(49, 19);
            this.textBox_ip.Name = "textBox_ip";
            this.textBox_ip.Size = new System.Drawing.Size(100, 20);
            this.textBox_ip.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "IP:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Port:";
            // 
            // numeric_port
            // 
            this.numeric_port.Location = new System.Drawing.Point(49, 52);
            this.numeric_port.Maximum = new decimal(new int[] {
            49151,
            0,
            0,
            0});
            this.numeric_port.Name = "numeric_port";
            this.numeric_port.Size = new System.Drawing.Size(100, 20);
            this.numeric_port.TabIndex = 3;
            // 
            // button_connect
            // 
            this.button_connect.Location = new System.Drawing.Point(164, 19);
            this.button_connect.Name = "button_connect";
            this.button_connect.Size = new System.Drawing.Size(64, 53);
            this.button_connect.TabIndex = 4;
            this.button_connect.Text = "Connect";
            this.button_connect.UseVisualStyleBackColor = true;
            this.button_connect.Click += new System.EventHandler(this.button_connect_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_connect);
            this.groupBox1.Controls.Add(this.textBox_ip);
            this.groupBox1.Controls.Add(this.numeric_port);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(247, 87);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::ControlCar.Properties.Resources.Logo___Text;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(707, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(176, 143);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // button_forward
            // 
            this.button_forward.Location = new System.Drawing.Point(147, 19);
            this.button_forward.Name = "button_forward";
            this.button_forward.Size = new System.Drawing.Size(75, 68);
            this.button_forward.TabIndex = 7;
            this.button_forward.Text = "Forward";
            this.button_forward.UseVisualStyleBackColor = true;
            this.button_forward.Click += new System.EventHandler(this.button_forward_Click);
            // 
            // button_left
            // 
            this.button_left.Location = new System.Drawing.Point(50, 107);
            this.button_left.Name = "button_left";
            this.button_left.Size = new System.Drawing.Size(75, 68);
            this.button_left.TabIndex = 8;
            this.button_left.Text = "Left";
            this.button_left.UseVisualStyleBackColor = true;
            // 
            // button_right
            // 
            this.button_right.Location = new System.Drawing.Point(247, 107);
            this.button_right.Name = "button_right";
            this.button_right.Size = new System.Drawing.Size(75, 68);
            this.button_right.TabIndex = 9;
            this.button_right.Text = "Right";
            this.button_right.UseVisualStyleBackColor = true;
            // 
            // button_backward
            // 
            this.button_backward.Location = new System.Drawing.Point(147, 192);
            this.button_backward.Name = "button_backward";
            this.button_backward.Size = new System.Drawing.Size(75, 68);
            this.button_backward.TabIndex = 10;
            this.button_backward.Text = "Backward";
            this.button_backward.UseVisualStyleBackColor = true;
            // 
            // group_control
            // 
            this.group_control.Controls.Add(this.label3);
            this.group_control.Controls.Add(this.numeric_speed);
            this.group_control.Controls.Add(this.button_emergencyBrake);
            this.group_control.Controls.Add(this.button_brake);
            this.group_control.Controls.Add(this.button_forward);
            this.group_control.Controls.Add(this.button_left);
            this.group_control.Controls.Add(this.button_backward);
            this.group_control.Controls.Add(this.button_right);
            this.group_control.Location = new System.Drawing.Point(12, 189);
            this.group_control.Name = "group_control";
            this.group_control.Size = new System.Drawing.Size(526, 277);
            this.group_control.TabIndex = 11;
            this.group_control.TabStop = false;
            this.group_control.Text = "Control";
            // 
            // button_brake
            // 
            this.button_brake.Location = new System.Drawing.Point(398, 84);
            this.button_brake.Name = "button_brake";
            this.button_brake.Size = new System.Drawing.Size(111, 33);
            this.button_brake.TabIndex = 11;
            this.button_brake.Text = "Brake";
            this.button_brake.UseVisualStyleBackColor = true;
            // 
            // button_emergencyBrake
            // 
            this.button_emergencyBrake.Location = new System.Drawing.Point(398, 137);
            this.button_emergencyBrake.Name = "button_emergencyBrake";
            this.button_emergencyBrake.Size = new System.Drawing.Size(111, 38);
            this.button_emergencyBrake.TabIndex = 12;
            this.button_emergencyBrake.Text = "Emergency Brake";
            this.button_emergencyBrake.UseVisualStyleBackColor = true;
            // 
            // textBox_console
            // 
            this.textBox_console.Location = new System.Drawing.Point(544, 189);
            this.textBox_console.Multiline = true;
            this.textBox_console.Name = "textBox_console";
            this.textBox_console.Size = new System.Drawing.Size(191, 277);
            this.textBox_console.TabIndex = 13;
            // 
            // numeric_speed
            // 
            this.numeric_speed.Location = new System.Drawing.Point(389, 19);
            this.numeric_speed.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numeric_speed.Name = "numeric_speed";
            this.numeric_speed.Size = new System.Drawing.Size(120, 20);
            this.numeric_speed.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(342, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Speed:";
            // 
            // connectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(895, 581);
            this.Controls.Add(this.textBox_console);
            this.Controls.Add(this.group_control);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox1);
            this.Name = "connectForm";
            this.Text = "Connect to AutoSafe";
            ((System.ComponentModel.ISupportInitialize)(this.numeric_port)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.group_control.ResumeLayout(false);
            this.group_control.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_speed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_ip;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numeric_port;
        private System.Windows.Forms.Button button_connect;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button_forward;
        private System.Windows.Forms.Button button_left;
        private System.Windows.Forms.Button button_right;
        private System.Windows.Forms.Button button_backward;
        private System.Windows.Forms.GroupBox group_control;
        private System.Windows.Forms.Button button_emergencyBrake;
        private System.Windows.Forms.Button button_brake;
        private System.Windows.Forms.TextBox textBox_console;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numeric_speed;
    }
}

