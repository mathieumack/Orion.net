using Microsoft.VisualStudio.TestTools.UnitTesting;
using Orion.Net.Client.Scripts;

namespace Orion.Net.Core.UnitTests
{
    [TestClass]
    public class ExtractParamTestWithNoArgs
    {
        [TestMethod]
        public void ParamArgNull()
        {
            var testParams = @"""""""";

            var results = testParams.ExtractParams();

            Assert.AreEqual(0, results.Count);
        }

        [TestMethod]
        public void ParamArgWhiteSpace()
        {
            var testParams = @" "" "" "" ";

            var results = testParams.ExtractParams();

            Assert.AreEqual(0, results.Count);
        }
    }
}
