using Microsoft.VisualStudio.TestTools.UnitTesting;
using Orion.Net.Core.Results;
using System;

namespace Orion.Net.Core.UnitTests.Results.ImageContent
{
    [TestClass]
    public class ImageContentTestSerialize
    {
        [TestMethod]
        public void Serialize()
        {
            ImageContentResult testContent = new ImageContentResult();

            try
            {
                Assert.IsNotNull(testContent.GenerateDataContent());
            }
            catch(Exception ex)
            {
                Assert.Fail(ex.ToString());
            }
        }
    }
}
