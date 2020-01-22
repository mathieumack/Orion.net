using Microsoft.VisualStudio.TestTools.UnitTesting;
using Orion.Net.Core.Results;

namespace Orion.Net.Core.UnitTests.Results.ImageContent
{
    [TestClass]
    public class ImageContentTestImageByte
    {
        [TestMethod]
        public void ImageTestImageByte()
        {
            byte[] testByte = new byte[] { 0, 1 };
            ImageContentResult testContent = new ImageContentResult();

            Assert.IsNull(testContent.ImageAsByteArray);

            testContent.ImageAsByteArray = testByte;

            Assert.AreEqual(testByte, testContent.ImageAsByteArray);
        }
    }
}