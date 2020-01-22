using Microsoft.VisualStudio.TestTools.UnitTesting;
using Orion.Net.Core.Interfaces;
using Orion.Net.Core.Results;

namespace Orion.Net.Core.UnitTests.Results.ImageContent
{
    [TestClass]
    public class ImageContentTestResultType
    {
        [TestMethod]
        public void ImageTestResultType()
        {
            ImageContentResult testContent = new ImageContentResult();

            Assert.AreEqual(ClientScriptResultType.Image, testContent.ResultType);
        }
    }
}