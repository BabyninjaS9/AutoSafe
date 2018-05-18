using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;

namespace PTT2CarGps
{
    public partial class GPSform : Form
    {
        SerialPort port;
        public List<Point[]> signatureTrails;
        public GPSform()
        {
            InitializeComponent();
            signatureTrails = new List<Point[]>();
            comPortCBB.DataSource = SerialPort.GetPortNames();
            readSerialTimer.Start();
        }

        private void TestTrailDrawing()
        {
            Random r = new Random();
            for(int i = 0; i < 10; i++)
            {
                Point[] points = new Point[10];
                for (int j = 0; j < 10; j++)
                {
                    points[j] = new Point(i * 50 + r.Next(0, 10), j * i * i + j + r.Next(0, 10));
                }
                AddPositions(points);
            }
            DrawPositions();
        }

        private void refreshComPortBTTN_Click(object sender, EventArgs e)
        {
            comPortCBB.DataSource = SerialPort.GetPortNames();
        }

        private void SetSerialPort()
        {
            if(!string.IsNullOrEmpty(baudRateCBB.Text) && !string.IsNullOrEmpty(comPortCBB.Text))
            {
                try
                {
                    if(port != null) port.Close();
                    port = new SerialPort(comPortCBB.Text, Convert.ToInt32(baudRateCBB.Text), Parity.None, 8, StopBits.One);
                    port.Open();
                    port.ReadTimeout = 1000;
                }
                catch (FormatException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch(System.IO.IOException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch (System.UnauthorizedAccessException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        
        private void ReadSerialTimer_Tick(object sender, EventArgs e)
        {
            if(port == null)
            {
                toolStripStatusLabel1.Text = "Not connected";
                return;
            }
            if (!port.IsOpen)
            {
                toolStripStatusLabel1.Text = "Not connected";
                return;
            }

            while(port.BytesToRead > 0)
            {
                char[] data;
                try
                {
                    data = port.ReadLine().ToCharArray();
                    SerialComLB.Items.Add(new String(data));
                    toolStripStatusLabel1.Text = "Connected";
                }
                catch (TimeoutException)
                {
                    port.Close();
                    toolStripStatusLabel1.Text = "Wrong baud rate";
                }
            }

            while(SerialComLB.Items.Count > 8)
            {
                SerialComLB.Items.RemoveAt(0);
            }
        }

        private void ConnectBTTN_Click(object sender, EventArgs e)
        {
            SetSerialPort();
        }

        public void AddPositions(Point[] positions)
        {
            //Check for errors
            if (positions == null) return;

            //Create new signature trails if more positions are given
            while(positions.Length > signatureTrails.Count)
            {
                for(int i = 0; i < positions.Length - signatureTrails.Count; i++)
                {
                    signatureTrails.Add(new Point[10]);
                }
            }

            //Update signature trails
            for(int i = 0; i < signatureTrails.Count; i++)
            {
                //shift array
                for (int j = 9; j > 0; j--)
                {
                    signatureTrails[i][j] = signatureTrails[i][j - 1];
                }

                //add new value
                if (i < positions.Length) { signatureTrails[i][0] = positions[i]; }
            }

            DrawPositions();
        }

        private void DrawPositions()
        {
            CarLocationsPB.Invalidate();
        }

        private void CarLocationsPB_Paint(object sender, PaintEventArgs e)
        {
            Graphics Canvas = e.Graphics;
            Random r = new Random(10 );
            foreach (Point[] trail in signatureTrails)
            {
                Pen pen = new Pen(Color.FromArgb(r.Next(100,255),r.Next(100,255),r.Next(100,255)));
                Point pos = trail[0];
                pos.Offset(-15, -15);
                Canvas.DrawEllipse
                    (
                        pen,
                        new Rectangle(pos, new Size(30, 30))
                    );
                Canvas.DrawLines(pen, trail);
                Canvas.DrawString("ID:" + signatureTrails.IndexOf(trail), DefaultFont, new SolidBrush(Color.White), pos);
            }
            Canvas.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TestTrailDrawing();
        }
    }
}
