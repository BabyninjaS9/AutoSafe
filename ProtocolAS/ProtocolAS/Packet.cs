using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtocolAS
{
    /* Fields
     * 
     * Magic - 16 bits
     * Indicates the start of a new packet; it has the value 0x0EE0.
     * 
     * Length - 8 bits
     * Represents the number of bytes in the packet (including the header and checksum).
     * 
     * Cat - 3 bits
     * The category of the command (see Categories). A receiver must ignore a packet if it doesn’t recognize the category.
     * 
     * Cmd - 5 bits
     * The number identifying the command within the category (see Commands). A receiver must ignore a packet if it doesn’t recognize the command.
     * 
     * Payload - n × 16 bits
     * Arbitrary number of data bytes carried by the packet. This must be interpreted depending on the command.
     * 
     * Checksum - 16 bits
     * Checksum of the complete packet computed using the Fletcher-16 algorithm. This is used to detect if the packet was corrupted.
     */
    public class Packet
    {
        public byte magic1 { get; private set; }
        public byte magic2 { get; private set; }
        public byte length { get; private set; }
        public byte cat { get; private set; }
        public byte cmd { get; private set; }
        public byte[] payloadn { get; private set; }
        public byte[] payload2 { get; private set; }
        public byte checksum1 { get; private set; }
        public byte checksum2 { get; private set; }
        public byte[] newMessage { get; private set; }

        byte bitmask = 0xFF;

        /// <summary>
        /// Maakt een heel bericht volgens ons protocol
        /// </summary>
        /// <param name="Magic">Magic - 16 bits, Indicates the start of a new packet; it has the value 0x0EE0.</param>
        /// <param name="Length"> Length - 8 bits, Represents the number of bytes in the packet(including the header and checksum).</param>
        /// <param name="Cat">Cat - 3 bits, The category of the command(see Categories). A receiver must ignore a packet if it doesn’t recognize the category.</param>
        /// <param name="Cmd">Cmd - 5 bits, The number identifying the command within the category(see Commands). A receiver must ignore a packet if it doesn’t recognize the command.</param>
        /// <param name="Payload">Payload - n × 16 bit, Arbitrary number of data bytes carried by the packet.This must be interpreted depending on the command. </param>
        /// <param name="Checksum">Checksum - 16 bits, Checksum of the complete packet computed using the Fletcher-16 algorithm.This is used to detect if the packet was corrupted.</param>
        /// <returns>het gehele bericht</returns>
        public byte[] Serialize(byte Magic1, byte Magic2, byte Length, byte Cat, byte Cmd, byte[] Payload, byte Checksum1, byte Checksum2)
        { //maakt payloadarray aan
            payloadn = new byte[100];
            for (int i = 0; i < Payload.Length; i++)
            {
                payloadn[i] = 0x00;
            };
            //maakt message-array aan
            newMessage = new byte[Length];
            for (int i = 0; i < Length; i++)
            {
                newMessage[i] = 0x00;
            };

            magic1 = Magic1; //1e deel magic
            magic2 = Magic2; //2e deel magic

            int payloadvalue = Length - 6;  //rekent lengte uit, 6 vanwege 6 bytes kwijt aan Magic, Length, Cat+Cmd, Checksum

            int firstnewbitmask = bitmask & ((byte)Cat << 5); //Cat naar 1e index
            int secondnewbitmask = bitmask & (Cmd); //cmd naar zijn index
            int newbitmask = firstnewbitmask | secondnewbitmask;

            int check1 = bitmask & (Checksum1); //1e deel checksum
            int check2 = bitmask & (Checksum2); //2e deel checksum

            for (int i = 0; i < payloadvalue; i++)//splitst Payload in losse bytes
            {
                payloadn[i] = (byte)(bitmask & (Payload[i] << i * 8));
            }
            //maakt het bericht vanaf hier
            newMessage[0] = magic1;
            newMessage[1] = magic2;
            newMessage[2] = Length;
            newMessage[3] = (byte)newbitmask;

            for (int j = 4; j < (payloadvalue + 4) - 1; j++)
            {
                newMessage[j] = payloadn[j - 4];
            }
            newMessage[payloadvalue - 1] = (byte)check1;
            newMessage[payloadvalue] = (byte)check2;
            return newMessage; //verstuurt message, message is klaar
        }


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

            //maakt payloadarray aan
            payload2 = new byte[100];
            for (int i = 4; i < length; i++)
            {
                payload2[i-4] = message[i]; 
            }

            checksum1 = message[length - 1]; //maakt in checksum hele verhaal
            checksum2 = message[length]; //idem
        }
    }
}
