using Microsoft.VisualStudio.TestTools.UnitTesting;
using Orion.Net.Core.Interfaces;
using Orion.Net.Core.Results;

namespace Orion.Net.Core.UnitTests.Results.ImageContent
{
    /// <summary>
    /// Unit Test for <see cref="ImageContentResult"/>
    /// Verify instantiation of <see cref="ImageContentResult.ResultType"/> to <see cref="ClientScriptResultType.Image"/>
    /// </summary>
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