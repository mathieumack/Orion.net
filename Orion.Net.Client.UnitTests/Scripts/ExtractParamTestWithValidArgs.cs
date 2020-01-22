using Microsoft.VisualStudio.TestTools.UnitTesting;
using Orion.Net.Client.Scripts;

namespace Orion.Net.Core.UnitTests
{
    [TestClass]
    public class ExtractParamTestWithValidArgs
    {
        [TestMethod]
        public void TestMethod1()
        {
            var testParams = @"-filePath ""c:\temp\K-o /al_a.jpg"" -ext ""c:\temp\Koa_l-a.jpg""";

            var results = testParams.ExtractParams();

            Assert.AreEqual(2, results.Count);
            
            // First parameter :
            Assert.AreEqual("filePath", results[0].ParameterName);
            Assert.AreEqual(@"c:\temp\K-o /al_a.jpg", results[0].ParameterValue);

            // Second parameter :
            Assert.AreEqual("ext", results[1].ParameterName);
            Assert.AreEqual(@"c:\temp\Koa_l-a.jpg", results[1].ParameterValue);
        }
    }
}
