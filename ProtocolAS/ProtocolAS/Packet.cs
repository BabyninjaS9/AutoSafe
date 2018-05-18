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
        public byte payload { get; private set; }
        public byte[] payload2 { get; private set; }
        public byte checksum1 { get; private set; }
        public byte checksum2 { get; private set; }
        public byte[] newMessage { get; private set; }
        public byte[] payloadn { get; private set; }


        //byte[] newMessage;
        //byte[] payloadn;
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
        {
            int magic1 = bitmask & (Magic1); //1e deel magic
            int magic2 = bitmask & (Magic2); //2e deel magic

            int payloadvalue = Length - 6;  //rekent lengte uit, 6 vanwege 6 bytes kwijt aan Magic, Length, Cat+Cmd, Checksum

            int newbitmask = bitmask & ((byte)Cat << 5); //Cat naar 1e index
            newbitmask = newbitmask | (Cmd); //cmd naar zijn index

            int check1 = bitmask & (Checksum1); //1e deel checksum
            int check2 = bitmask & (Checksum2); //2e deel checksum
            byte[] x = Split(Payload, payloadvalue); //splitst payload in bytes

            //maakt het bericht vanaf hier
            newMessage[0] = (byte)magic1;
            newMessage[1] = (byte)magic2;
            newMessage[2] = Length;
            newMessage[3] = (byte)newbitmask;

            for (int i = 4; i < (payloadvalue + 4) - 1; i++)
            {
                newMessage[i] = x[i - 4];
            }
            newMessage[payloadvalue - 1] = (byte)check1;
            newMessage[payloadvalue] = (byte)check2;
            return newMessage; //verstuurt message, message is klaar
        }

        /// <summary>
        /// Splitst alle payloads naar losse bytes om het bericht te kunnen versturen
        /// </summary>
        /// <param name="Payload"> De informatie die moet woorden geknipt</param>
        /// <param name="payloadvalue"> de hoeveelheid bytes die de message inclusief de header zal krijgen</param>
        /// <returns>alle payload bytes geknipt om in de byte array mee te sturen</returns>
        public byte[] Split(byte[] Payload, int payloadvalue)
        {
            for (int i = 0; i < payloadvalue; i++)
            {
                payloadn[i] = (byte)(bitmask & (Payload[i] << i * 8));
            }
            return payloadn;
        }

        /// <summary>
        /// Ontcijfert het bericht dat hij meekrijgt volgens ons protocol
        /// </summary>
        /// <param name="message">het bericht dat moet worden ontcijferd</param>
        public void Deserialize(byte[] message)
        {
            int magicx = message[0]; //1e deel magic
            int magicy = message[1]; //2e deel magic
            magic1 = (byte)(magicx << 8); //maakt van magic 1 grote byte
            magic2 = (byte)(magicy); //idem

            length = message[2]; //lengte van bericht
            int catandcmd = message[3]; //cat en cmd 
            cat = (byte)(bitmask & (catandcmd >> 3)); //zet categorie
            cmd = (byte)(0b00000111 & (catandcmd)); //zet bericht

            byte[] x = Paste(message, length); //maakt losse bytes van de payload voor om uit te lezen
            for (int i = 4; i < (length + 4) - 1; i++)
            {
                payload2[i - 4] = message[i]; //de eerste 4 zijn niet nodig en de laatste 2 ook niet
            }
            int checkx = message[length - 1]; //1e deel checksum
            int checky = message[length]; //2e deel checksum
            checksum1 = (byte)(checkx); //maakt in checksum hele verhaal
            checksum2 = (byte)(checky); //idem
        }

        /// <summary>
        /// Maakt voor de deserialize het bericht in stukjes om in de payload in te krijgen. Moet de eerste 4 en laatste 2 bytes NIET in de payload-arrays zetten
        /// </summary>
        /// <param name="FullMessage">het oorspronkelijke bericht</param>
        /// <param name="lengthOfMessage">de lengte van het hele bericht, wat gelijk staat aan byte[2]</param>
        /// <returns></returns>
        public byte[] Paste(byte[] FullMessage, int lengthOfMessage)
        {
            for (int i = 0; i < lengthOfMessage; i++)
            {
                if ((i < 4) || (i >= lengthOfMessage - 1))
                {
                    //de eerste heb je al en de laatste 2 zijn ook niet nodig
                }
                else
                {
                    payloadn[i] = (byte)(bitmask & (FullMessage[i] >> i * 8));

                }
            }
            return payloadn;
        }
    }
}
