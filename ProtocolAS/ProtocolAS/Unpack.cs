using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtocolAS
{
    public class Unpack
    {
        public byte magic1 { get; private set; }
        public byte magic2 { get; private set; }
        public byte length { get; private set; }
        public byte cat { get; private set; }
        public byte cmd { get; private set; }
        public byte[] payload2 { get; private set; }
        public byte checksum1 { get; private set; }
        public byte checksum2 { get; private set; }


        /// <summary>
        /// Ontcijfert het bericht dat hij meekrijgt volgens ons protocol
        /// </summary>
        /// <param name="message">het bericht dat moet worden ontcijferd</param>
        public void Deserialize(byte[] message)
        {
            magic1 = message[0]; //1e deel magic
            magic2 = message[1]; //2e deel magic

            length = message[2]; //lengte van bericht
            int catandcmd = message[3]; //cat en cmd 
            cat = (byte)(0b11100000 & (catandcmd)); //zet categorie
            cmd = (byte)(0b00011111 & (message[3])); //zet bericht

            if (length > 0x06)
            {
                //maakt payloadarray aan
                payload2 = new byte[100];
                for (int i = 4; i < length; i++)
                {
                    payload2[i - 4] = message[i];
                }
            }

            checksum1 = message[length - 2]; //maakt in checksum hele verhaal
            checksum2 = message[length - 1]; //idem

        }
    }
}
