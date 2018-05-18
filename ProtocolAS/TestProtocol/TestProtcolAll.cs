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
        public void TestSplit()
        {
            //byte Magic1 = 0x0E;
            //byte Magic2 = 0xE0;
            byte Length = 0x09;
            //byte Cat = 0xE0;
            //byte Cmd = 0x01;
            byte[] Payload = new byte[] { 0xA1, 0xA2, 0x33 };
            //byte Checksum1 = 0x05;
            //byte Checksum2 = 0x30;
            Assert.AreEqual(Payload, p.Split(Payload, (Length - 6)));
        }
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
            Assert.AreEqual(1, p.Serialize(Magic1, Magic2, Length, Cat, Cmd, Payload, Checksum1, Checksum2));
        }
        [TestMethod]
        public void TestPaste()
        {
            byte[] Message = new byte[] { 0x0E, 0xE0, 0x08, 0XE1, 0x01, 0xA1, 0xA2, 0x33, 0x05, 0x30 };
            byte[] Payload = new byte[] { 0xA1, 0xA2, 0x33 };
            byte[] x = p.Paste(Message, Message[2]);
            Assert.AreEqual(Payload, x);
            Assert.AreEqual(Message[6], p.payload2[0]);
        }
        [TestMethod]
        public void TestDeserialize()
        {
            byte[] Message = new byte[] { 0x0E, 0xE0, 0x08, 0XE1, 0x01, 0xA1, 0xA2, 0x33, 0x05, 0x30 };
            p.Deserialize(Message);
            Assert.AreEqual(0x0E, Message[0]);
            Assert.AreEqual(0xE0, Message[1]);
            Assert.AreEqual(0x08, Message[2]);
            Assert.AreEqual(0XE1, Message[3]);
            Assert.AreEqual(0x01, Message[4]);
            Assert.AreEqual(0xA1, Message[5]);
            Assert.AreEqual(0xA2, Message[6]);
            Assert.AreEqual(0x33, Message[7]);
            Assert.AreEqual(0x05, Message[8]);
            Assert.AreEqual(0x30, Message[9]);

            Assert.AreEqual(0x0E, p.magic1);
            Assert.AreEqual(0xE0, p.magic2);
            Assert.AreEqual(0x08, p.length);
            Assert.AreEqual(0XE1, p.cat);
            Assert.AreEqual(0x01, p.cmd);
            Assert.AreEqual(0xA1, p.payload2[0]);
            Assert.AreEqual(0xA2, p.payload2[1]);
            Assert.AreEqual(0x33, p.payload2[2]);
            Assert.AreEqual(0x05, p.checksum1);
            Assert.AreEqual(0x30, p.checksum2);
        }
    }
}
