using Microsoft.VisualStudio.TestTools.UnitTesting;
using Orion.Net.Client.Scripts;

namespace Orion.Net.Client.UnitTests
{
    [TestClass]
    public class ExtracParamTestWithValidArgs
    {
        [TestMethod]
        public void TestMethod1()
        {
            var testParams = @"-filePath ""c:\temp\Ko /ala.jpg"" -ext ""c:\temp\Koala.jpg""";

            var results = testParams.ExtractParams();

            Assert.AreEqual(2, results.Count);
            
            // First parameter :
            Assert.AreEqual("filePath", results[0].ParameterName);
            Assert.AreEqual(@"c:\temp\Ko /ala.jpg", results[0].ParameterValue);

            // Second parameter :
            Assert.AreEqual("ext", results[1].ParameterName);
            Assert.AreEqual(@"c:\temp\Koala.jpg", results[1].ParameterValue);
        }
    }
}
