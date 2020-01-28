using Microsoft.VisualStudio.TestTools.UnitTesting;
using Orion.Net.Client.Scripts;

namespace Orion.Net.Client.UnitTests
{
    /// <summary>
    /// Test for ParameterValue from <see cref="ScriptParameterInterpreterResult">
    /// <list type="number">
    /// <item>At the instantiation of <see cref="ScriptParameterInterpreterResult.ParameterValue"/>, expect null</item>
    /// <item>Check <see cref="ScriptParameterInterpreterResult.ParameterValue"/> set and get</item>
    /// </list>
    /// </summary>
    [TestClass]
    public class TestParamValue
    {
        [TestMethod]
        public void ParamInterpreterResultTestParamValue()
        {
            var testParam = new ScriptParameterInterpreterResult();

            Assert.IsNull(testParam.ParameterValue);

            testParam.ParameterValue = "toto";

            Assert.AreEqual("toto", testParam.ParameterValue);
        }
    }
}