using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace ControlCar
{
    public partial class connectForm : Form
    {
        ControlClient carController = new ControlClient();
        Timer refreshTimer = new Timer();
        public connectForm()
        {
            InitializeComponent();
            group_control.Enabled = false;
            textBox_ip.Text = "192.168.4.1";
            numeric_port.Value = 23;
            refreshTimer.Tick += new EventHandler(refreshTheStatus);
            refreshTimer.Interval = 5000;
            refreshTimer.Start();
            label_status.Text = carController.ToString();
        }

        private void refreshTheStatus(object sender, EventArgs e)
        {
            label_status.Text = carController.ToString();
        }

        private async void button_connect_Click(object sender, EventArgs e)
        {
            button_connect.Enabled = false;
            refreshTimer.Stop();
            string ip = textBox_ip.Text;
            int port = (int)numeric_port.Value;
            try
            {
                printToTextbox("Trying to connect...");
                await carController.Connect(ip, port);
                group_control.Enabled = true;
                groupBox_connect.Enabled = false;
                printToTextbox("Connected");
            }
            catch (SocketException)
            {
                carController.Disconnect();
                carController = new ControlClient();
                printToTextbox("Connection failed");
            }
            catch (FormatException)
            {
                carController.Disconnect();
                carController = new ControlClient();
                printToTextbox("Ip or port format not correct");
            }
            finally
            {
                refreshTimer.Start();
                button_connect.Enabled = true;
            }
            
        }

        private void printToTextbox(string tekst)
        {
            textBox_console.AppendText(tekst + "\n");
        }

        private void button_forward_Click(object sender, EventArgs e)
        {
            byte speed = (byte)numeric_speed.Value;
            if(carController.SendSpeed(2, speed) == 1)
            {
                printToTextbox("Forward sent");
            }
            else
            {
                printToTextbox("Sending forward failed");
            }
        }

        private void button_right_Click(object sender, EventArgs e)
        {
            byte speed = (byte)numeric_speed.Value;
            if (carController.SendSpeed(5, speed) == 1)
            {
                printToTextbox("Right sent");
            }
            else
            {
                printToTextbox("Sending right failed");
            }
        }

        private void button_left_Click(object sender, EventArgs e)
        {
            byte speed = (byte)numeric_speed.Value;
            if (carController.SendSpeed(4, speed) == 1)
            {
                printToTextbox("Left sent");
            }
            else
            {
                printToTextbox("Sending left failed");
            }
        }

        private void button_backward_Click(object sender, EventArgs e)
        {
            byte speed = (byte)numeric_speed.Value;
            if (carController.SendSpeed(3, speed) == 1)
            {
                printToTextbox("Backward sent");
            }
            else
            {
                printToTextbox("Sending backward failed");
            }
        }

        private void button_brake_Click(object sender, EventArgs e)
        {
            byte speed = (byte)numeric_speed.Value;
            if (carController.SendSpeed(7, speed) == 1)
            {
                printToTextbox("Brake sent");
            }
            else
            {
                printToTextbox("Sending brake failed");
            }
        }

        private void button_emergencyBrake_Click(object sender, EventArgs e)
        {
            byte speed = (byte)numeric_speed.Value;
            if (carController.SendSpeed(1, speed) == 1)
            {
                printToTextbox("Emergency brake sent");
            }
            else
            {
                printToTextbox("Sending emergency brake failed");
            }
        }

        private void button_disconnect_Click(object sender, EventArgs e)
        {
            carController.Disconnect();
            groupBox_connect.Enabled = true;
            group_control.Enabled = false;
            printToTextbox("Disconnected");
        }
    }
}
