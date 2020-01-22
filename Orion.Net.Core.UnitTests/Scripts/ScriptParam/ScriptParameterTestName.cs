using Microsoft.VisualStudio.TestTools.UnitTesting;
using Orion.Net.Core.Scripts;

namespace Orion.Net.Core.UnitTests.Scripts.ScriptParam
{
    [TestClass]
    public class ScriptParameterTestName
    {
        [TestMethod]
        public void ScriptParamTestName()
        {
            ScriptParameter testScriptParam = new ScriptParameter();

            Assert.IsNull(testScriptParam.Name);

            testScriptParam.Name = "toto";

            Assert.AreEqual("toto", testScriptParam.Name);
        }
    }
}
