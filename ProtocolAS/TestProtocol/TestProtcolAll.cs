using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProtocolAS;

namespace TestProtocol
{
    [TestClass]
    public class TestProtcolAll
    {
        Packet p = new Packet();
        Unpack u = new Unpack();

        [TestMethod]
        public void TestSerialize()
        {
            byte Command = 0xE1;
            byte[] Payload = new byte[] { 0xA1, 0xA2, 0x33, 0x44 };
            byte Checksum1 = 0x05;
            byte Checksum2 = 0x30;
            byte[] Message = new byte[] { 0x0E, 0xE0, 0x0A, 0XE1, 0xA1, 0xA2, 0x33, 0x44, 0x05, 0x30 };
            byte[] test = p.Serialize(Command, Payload, Checksum1, Checksum2);
            
            Assert.AreEqual(4, Payload.Length);
            Assert.AreEqual(Message[0], test[0]);
            Assert.AreEqual(Message[1], test[1]);
            Assert.AreEqual(Message[2], test.Length);
            Assert.AreEqual(Message[2], test[2]);
            Assert.AreEqual(Message[3], test[3]);
            Assert.AreEqual(Message[4], test[4]);
            Assert.AreEqual(Message[5], test[5]);
            Assert.AreEqual(Message[6], test[6]);
            Assert.AreEqual(Message[7], test[7]);
            Assert.AreEqual(Message[8], test[8]);
            Assert.AreEqual(Message[9], test[9]);

            for(int i = 0; i < test.Length; i++)
            {
                Assert.AreEqual(Message[i], test[i]);
            }
        }

        [TestMethod]
        public void TestSerializePayloadNull()
        {
            byte Command = 0xE1;
            byte Checksum1 = 0x05;
            byte Checksum2 = 0x30;
            byte[] Message = new byte[] { 0x0E, 0xE0, 0x06, 0XE1, 0x05, 0x30 };
            byte[] test = p.Serialize(Command, null, Checksum1, Checksum2);

            Assert.AreEqual(Message[0], test[0]);
            Assert.AreEqual(Message[1], test[1]);
            Assert.AreEqual(Message[2], test.Length);
            Assert.AreEqual(Message[2], test[2]);
            Assert.AreEqual(Message[3], test[3]);
            Assert.AreEqual(Message[4], test[4]);
            Assert.AreEqual(Message[5], test[5]);

            for (int i = 0; i < test.Length; i++)
            {
                Assert.AreEqual(Message[i], test[i]);
            }
        }

        [TestMethod]
        public void TestDeserialize()
        {
            byte[] Message = new byte[] { 0x0E, 0xE0, 0x0A, 0XE1, 0xA1, 0xA2, 0x33, 0x44, 0x05, 0x30 };
            u.Deserialize(Message);
           
            Assert.AreEqual(0x0E, u.magic1);
            Assert.AreEqual(0xE0, u.magic2);
            Assert.AreEqual(0x0A, u.length);
            Assert.AreEqual(0XE0, u.cat);
            Assert.AreEqual(0x01, u.cmd);
            Assert.AreEqual(0xA1, u.payload2[0]);
            Assert.AreEqual(0xA2, u.payload2[1]);
            Assert.AreEqual(0x33, u.payload2[2]);
            Assert.AreEqual(0x44, u.payload2[3]);
            Assert.AreEqual(0x05, u.checksum1);
            Assert.AreEqual(0x30, u.checksum2);
        }

        [TestMethod]
        public void TestDeserializeNoPayload()
        {
            byte[] Message = new byte[] { 0x0E, 0xE0, 0x06, 0XE1, 0x05, 0x30 };
            u.Deserialize(Message);

            Assert.AreEqual(0x0E, u.magic1);
            Assert.AreEqual(0xE0, u.magic2);
            Assert.AreEqual(0x06, u.length);
            Assert.AreEqual(0XE0, u.cat);
            Assert.AreEqual(0x01, u.cmd);
            Assert.AreEqual(0x05, u.checksum1);
            Assert.AreEqual(0x30, u.checksum2);
        }
    }
}
