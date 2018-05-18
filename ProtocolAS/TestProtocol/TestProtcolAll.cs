using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProtocolAS;

namespace TestProtocol
{
    [TestClass]
    public class TestProtcolAll
    {
        Packet p = new Packet();

        [TestMethod]
        public void TestSerialize()
        {
            byte Magic1 = 0x0E;
            byte Magic2 = 0xE0;
            byte Length = 0x08;
            byte Cat = 0xE0;
            byte Cmd = 0x01;
            byte[] Payload = new byte[] { 0xA1, 0xA2, 0x33 };
            byte Checksum1 = 0x05;
            byte Checksum2 = 0x30;
            byte[] Message = new byte[] { 0x0E, 0xE0, 0x08, 0XE1, 0xA1, 0xA2, 0x33, 0x05, 0x30 };
            byte[] ExpectedMessage = new byte[] { 0x0E, 0xE0, 0x08, 0XE0, 0x01, 0xA1, 0xA2, 0x33, 0x05, 0x30 };
            byte[] test = p.Serialize(Magic1, Magic2, Length, Cat, Cmd, Payload, Checksum1, Checksum2);

            Assert.AreEqual(Message[0], test[0]);
            //Assert.AreEqual(Message[1], test[1]);
            Assert.AreEqual(Message[2], test.Length);
            Assert.AreEqual(Message[3], test[3]);
            Assert.AreEqual(Message[4], test[4]);
            Assert.AreEqual(Payload[0], test[5]);
            Assert.AreEqual(Payload[1], test[6]);
            Assert.AreEqual(Payload[2], test[7]);
            Assert.AreEqual(Message[8], test[6]);
            Assert.AreEqual(Message[9], test[7]);

            /*for(int i = 0; i < test.Length; i++)
            {
                Assert.AreEqual(Message[i], test[i]);
            }*/
        }

        [TestMethod]
        public void TestDeserialize()
        {
            byte[] Message = new byte[] { 0x0E, 0xE0, 0x08, 0XE1, 0xA1, 0xA2, 0x33, 0x05, 0x30 };
            p.Deserialize(Message);
            Assert.AreEqual(0x0E, Message[0]);
            Assert.AreEqual(0xE0, Message[1]);
            Assert.AreEqual(0x08, Message[2]);
            Assert.AreEqual(0XE1, Message[3]);
            Assert.AreEqual(0xA1, Message[4]);
            Assert.AreEqual(0xA2, Message[5]);
            Assert.AreEqual(0x33, Message[6]);
            Assert.AreEqual(0x05, Message[7]);
            Assert.AreEqual(0x30, Message[8]);

            Assert.AreEqual(0x0E, p.magic1);
            Assert.AreEqual(0xE0, p.magic2);
            Assert.AreEqual(0x08, p.length);
            Assert.AreEqual(0XE0, p.cat);
            Assert.AreEqual(0x01, p.cmd);
            Assert.AreEqual(0xA1, p.payload2[0]);
            Assert.AreEqual(0xA2, p.payload2[1]);
            Assert.AreEqual(0x33, p.payload2[2]);
            Assert.AreEqual(0x05, p.checksum1);
            Assert.AreEqual(0x30, p.checksum2);
        }
    }
}
