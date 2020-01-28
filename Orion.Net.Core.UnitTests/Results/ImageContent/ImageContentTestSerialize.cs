using Microsoft.VisualStudio.TestTools.UnitTesting;
using Orion.Net.Core.Results;

namespace Orion.Net.Core.UnitTests.Results.ImageContent
{
    /// <summary>
    /// Unit Test for <see cref="ImageContentResult"/>
    /// Try the method <see cref="ImageContentResult.GenerateDataContent"/> sending back a string
    /// </summary>
    [TestClass]
    public class ImageContentTestSerialize
    {
        [TestMethod]
        public void Serialize()
        {
            ImageContentResult testContent = new ImageContentResult();

            Assert.IsNotNull(testContent.GenerateDataContent());
        }
    }
}
