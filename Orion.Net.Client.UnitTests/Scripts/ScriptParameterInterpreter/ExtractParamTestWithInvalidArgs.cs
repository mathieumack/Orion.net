using Microsoft.VisualStudio.TestTools.UnitTesting;
using Orion.Net.Client.Scripts;

namespace Orion.Net.Core.UnitTests
{
    [TestClass]
    public class ExtractParamTestWithInvalidArgs
    {
        [TestMethod]
        public void InvalidArgs()
        {
            var testParams = @"-filePath ""c:\temp\K*o /ala.jpg"" -ext ""c:\temp\Ko@ala.jpg""";

            var results = testParams.ExtractParams();

            Assert.AreEqual(0, results.Count);

        }

        [TestMethod]
        public void InvalidParam()
        {
            var testParams = @"-fil*ePath ""c:\temp\Ko /ala.jpg"" -ex@t ""c:\temp\Koala.jpg""";

            var results = testParams.ExtractParams();

            Assert.AreEqual(0, results.Count);

        }
    }
}