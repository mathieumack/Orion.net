using Microsoft.VisualStudio.TestTools.UnitTesting;
using Orion.Net.Core.Results;

namespace Orion.Net.Core.UnitTests.Results.FileContent
{
    [TestClass]
    public class FileContentTestFileByte
    {
        [TestMethod]
        public void FileTestFileByte()
        {
            byte[] testByte = new byte[] { 0, 1 };
            FileContentResult testContent = new FileContentResult();

            Assert.IsNull(testContent.FileAsByteArray);

            testContent.FileAsByteArray = testByte;

            Assert.AreEqual(testByte, testContent.FileAsByteArray);
        }
    }
}