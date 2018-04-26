using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace ControlCar
{
    public class ControlClient
    {
        private TcpClient socketClient;
        private NetworkStream tcpStream;
        private byte currentSpeed;

        public string IP { get; private set; }
        public int Port { get; private set; }

        public ControlClient()
        {
            socketClient = new TcpClient();
        }

        public void Send(string command)
        {
            byte[] data = Encoding.ASCII.GetBytes(command);
            tcpStream.Write(data, 0, data.Length);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="commandNumber"> Choose forward/backward/left/right/brake </param>
        /// <param name="speed"> speed in byte </param>
        /// <returns> Succes condition </returns>
        public int SendSpeed(int commandNumber, byte speed)
        {
            byte catCmd = Convert.ToByte(224 + commandNumber);
            try
            {
                if (speed != currentSpeed)
                {
                    byte[] data = { 0x0E, 0xE0, 0x06, catCmd, 0x00, speed };
                    tcpStream.Write(data, 0, data.Length);
                }
                else
                {
                    byte[] data = { 0x0E, 0xE0, 0x04, catCmd };
                    tcpStream.Write(data, 0, data.Length);
                }
                currentSpeed = speed;
                return 1;
            }
            catch
            {
                return 0;
            }

        }

        public void SendLocation(int commandNumber, int location)
        {
            byte[] data = { };
            tcpStream.Write(data, 0, data.Length);
        }

        public void Connect(string ip, int port)
        {
            socketClient.Close();
            IP = ip;
            Port = port;
            socketClient = new TcpClient();
            try
            {
                socketClient.Connect(IPAddress.Parse(ip), port);
                tcpStream = socketClient.GetStream();
            }
            catch(SocketException ex)
            {
                socketClient.Close();
                throw new ArgumentException("Connection failed", ex);
            }
            catch(FormatException ex)
            {
                socketClient.Close();
                throw new FormatException("Ip or port format not correct", ex);
            }
        }

        public void Disconnect()
        {
             socketClient.Close();
        }

        public override string ToString()
        {
            try
            {
                return "Connected: " + socketClient.Connected.ToString() +
                        ", IP: " + IP +
                        ", Port: " + Port;
            }
            catch
            {
                return "No TcpClient initiated";
            }
        }
    }
}
