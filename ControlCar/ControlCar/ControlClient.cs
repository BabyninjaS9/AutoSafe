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
            IP = "0";
            Port = 0;
        }

        /// <summary>
        /// Used for sending a command
        /// </summary>
        /// <param name="command"> Just a string for a random command for testing or something</param>
        public void Send(string command)
        {
            byte[] data = Encoding.ASCII.GetBytes(command);
            tcpStream.Write(data, 0, data.Length);
        }

        /// <summary>
        /// Used for sending direction and speed with it.
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

        /// <summary>
        /// The process of connecting to wifi module
        /// </summary>
        /// <param name="ip"> ip-addres in string </param>
        /// <param name="port"> port in int </param>
        public async Task Connect(string ip, int port)
        {
            if (socketClient.Connected) { socketClient.Close(); }

            IP = ip;
            Port = port;
            socketClient = new TcpClient();

            await socketClient.ConnectAsync(IPAddress.Parse(ip), port);
            tcpStream = socketClient.GetStream();
        }

        public void Disconnect()
        {
            IP = "0";
            Port = 0;
            socketClient.Close();
        }

        public override string ToString()
        {
            try
            {
                return "Connected: " + socketClient.Connected.ToString() +
                        "\nIP: " + IP +
                        "\nPort: " + Port;
            }
            catch
            {
                return "No TcpClient initiated";
            }
        }
    }
}
