using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using Soccer.Services;

namespace Soccer.Test
{
    [TestClass]
    public class FileHandlerTest
    {
        // Helper to creeate a stream from a string
        public Stream CreateStream(string content)
        {
            return new MemoryStream(System.Text.Encoding.UTF8.GetBytes(content));
        }

        [TestMethod]
        public void TestLoadEmptyFile()
        {
            var stream = CreateStream("");
            var handler = new FileHandler(stream);
            var content = handler.ParseContent();
            Assert.AreEqual(0, content.Count);

            stream = CreateStream("HEADER Line");
            handler = new FileHandler(stream);
            content = handler.ParseContent();
            Assert.AreEqual(0, content.Count);
        }

        [TestMethod]
        public void TestLoadFile()
        {
            var stream = CreateStream("Header\nLine1\nLine2");
            var handler = new FileHandler(stream);
            var content = handler.ParseContent();
            Assert.AreEqual(2, content.Count);
            Assert.AreEqual("Line2", content[1]);
        }
    }
}

