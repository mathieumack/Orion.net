using Microsoft.VisualStudio.TestTools.UnitTesting;
using Orion.Net.Core.Results;

namespace Orion.Net.Core.UnitTests.Results.StringContent
{
    /// <summary>
    /// Unit Test for <see cref="StringContentResult"/>
    /// Try the method <see cref="StringContentResult.GenerateDataContent"/> sending back a string
    /// </summary>
    [TestClass]
    public class StringContentTestSerialize
    {
        [TestMethod]
        public void Serialize()
        {
            StringContentResult testContent = new StringContentResult();
            var serializeContent = testContent.GenerateDataContent();

            Assert.IsNotNull(serializeContent);
        }
    }
}
