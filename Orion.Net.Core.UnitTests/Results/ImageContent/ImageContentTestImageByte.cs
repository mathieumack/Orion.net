using Microsoft.VisualStudio.TestTools.UnitTesting;
using Orion.Net.Core.Results;

namespace Orion.Net.Core.UnitTests.Results.ImageContent
{
    /// <summary>
    /// Unit Test for <see cref="ImageContentResult"/>
    /// <list type="number">
    /// <item>Verify <see cref="ImageContentResult.ImageAsByteArray"/> is not instantiated</item>
    /// <item>Verify <see cref="ImageContentResult.ImageAsByteArray"/> set and get</item>
    /// </list>
    /// </summary>
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