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
        public connectForm()
        {
            InitializeComponent();
        }

        private void button_connect_Click(object sender, EventArgs e)
        {
            string ip = textBox_ip.Text;
            int port = (int)numeric_port.Value;
            try
            {
                client.Connect(ip, port);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
