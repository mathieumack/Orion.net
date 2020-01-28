using Microsoft.VisualStudio.TestTools.UnitTesting;
using Orion.Net.Client.Scripts;

namespace Orion.Net.Client.UnitTests
{
    /// <summary>
    /// Test for ParameterValue from <see cref="ScriptParameterInterpreterResult">
    /// <list type="number">
    /// <item>At the instantiation of <see cref="ScriptParameterInterpreterResult.ParameterName"/>, expect null</item>
    /// <item>Check <see cref="ScriptParameterInterpreterResult.ParameterName"/> set and get</item>
    /// </list>
    /// </summary>
    [TestClass]
    public class TestParamName
    {
        [TestMethod]
        public void ParamInterpreterResultTestParamName()
        {
            var testParam = new ScriptParameterInterpreterResult();

            Assert.IsNull(testParam.ParameterName);

            testParam.ParameterName = "toto";

            Assert.AreEqual("toto", testParam.ParameterName);
        }
    }
}
