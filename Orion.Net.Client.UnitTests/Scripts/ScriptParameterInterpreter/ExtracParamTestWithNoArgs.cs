using Microsoft.VisualStudio.TestTools.UnitTesting;
using Orion.Net.Client.Scripts;

namespace Orion.Net.Client.UnitTests
{
    /// <summary>
    /// Unit Test for <see cref="ScriptParameterInterpreter.ExtractParams(string)"/>
    /// Check with parameters value empty or white spaced
    /// both should return a empty list of <see cref="ScriptParameterInterpreterResult"/>
    /// </summary>
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