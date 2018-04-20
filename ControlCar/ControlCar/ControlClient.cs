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

        public void SendSpeed(int commandNumber, byte speed)
        {
            byte catCmd = Convert.ToByte(224 + commandNumber);
            byte[] data = { 0x0E, 0xE0, 0x06, catCmd, 0x00, speed };
            tcpStream.Write(data, 0, data.Length);
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
            catch(SocketException)
            {
                socketClient.Close();
                throw new ArgumentException("Could not connect\nConnection failed");
            }
            catch(FormatException)
            {
                socketClient.Close();
                throw new ArgumentException("Ip or port format not correct");
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
