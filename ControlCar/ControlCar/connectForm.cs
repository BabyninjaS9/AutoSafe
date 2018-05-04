using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlCar
{
    public partial class connectForm : Form
    {
        ControlClient carController = new ControlClient();
        public connectForm()
        {
            InitializeComponent();
            //group_control.Enabled = false;
        }

        private void button_connect_Click(object sender, EventArgs e)
        {
            string ip = textBox_ip.Text;
            int port = (int)numeric_port.Value;
            try
            {
                carController.Connect(ip, port);
                group_control.Enabled = true;
                printToTextbox(carController.ToString());
            }
            catch(ArgumentException ex)
            {
                printToTextbox(ex.Message);
            }
            catch(FormatException ex)
            {
                printToTextbox(ex.Message);
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
    }
}
