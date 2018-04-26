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
        ControlClient client = new ControlClient();
        byte speed = 0;
        public connectForm()
        {
            InitializeComponent();
            group_control.Enabled = false;
        }

        private void button_connect_Click(object sender, EventArgs e)
        {
            string ip = textBox_ip.Text;
            int port = (int)numeric_port.Value;
            try
            {
                client.Connect(ip, port);
                group_control.Enabled = true;
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
            speed = (byte)numeric_speed.Value;
            if(client.SendSpeed(2, speed) == 1)
            {
                printToTextbox("Forward sent");
            }
            else
            {
                printToTextbox("Sending forward failed");
            }
        }
    }
}
