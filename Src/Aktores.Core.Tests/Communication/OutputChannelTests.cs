﻿namespace Aktroes.Tests.Communication
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using Aktores.Communication;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class OutputChannelTests
    {
        [TestMethod]
        public void WriteInteger()
        {
            MemoryStream stream = new MemoryStream();
            OutputChannel channel = new OutputChannel(new BinaryWriter(stream));

            channel.Write(123);

            stream.Seek(0, SeekOrigin.Begin);

            BinaryReader reader = new BinaryReader(stream);

            Assert.AreEqual((byte)Types.Integer, reader.ReadByte());
            Assert.AreEqual(123, reader.ReadInt32());
            reader.Close();
        }

        [TestMethod]
        public void WriteString()
        {
            MemoryStream stream = new MemoryStream();
            OutputChannel channel = new OutputChannel(new BinaryWriter(stream));

            channel.Write("foo");

            stream.Seek(0, SeekOrigin.Begin);

            BinaryReader reader = new BinaryReader(stream);

            Assert.AreEqual((byte)Types.String, reader.ReadByte());
            Assert.AreEqual("foo", reader.ReadString());
            reader.Close();
        }

        [TestMethod]
        public void WriteDouble()
        {
            MemoryStream stream = new MemoryStream();
            OutputChannel channel = new OutputChannel(new BinaryWriter(stream));

            channel.Write(123.45);

            stream.Seek(0, SeekOrigin.Begin);

            BinaryReader reader = new BinaryReader(stream);

            Assert.AreEqual((byte)Types.Double, reader.ReadByte());
            Assert.AreEqual(123.45, reader.ReadDouble());
            reader.Close();
        }

        [TestMethod]
        public void WriteNull()
        {
            MemoryStream stream = new MemoryStream();
            OutputChannel channel = new OutputChannel(new BinaryWriter(stream));

            channel.Write(null);

            stream.Seek(0, SeekOrigin.Begin);

            BinaryReader reader = new BinaryReader(stream);

            Assert.AreEqual((byte)Types.Null, reader.ReadByte());
            reader.Close();
        }
    }
}