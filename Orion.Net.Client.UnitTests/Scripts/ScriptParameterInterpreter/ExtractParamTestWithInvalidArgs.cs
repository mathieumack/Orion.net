using Microsoft.VisualStudio.TestTools.UnitTesting;
using Orion.Net.Client.Scripts;

namespace Orion.Net.Client.UnitTests
{
    /// <summary>
    /// Unit Test for <see cref="ScriptParameterInterpreter.ExtractParams(string)"/>
    /// with invalid Arguments and invalid Parameter 
    /// both returning an empty list of <see cref="ScriptParameterInterpreterResult"/>
    /// </summary>
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