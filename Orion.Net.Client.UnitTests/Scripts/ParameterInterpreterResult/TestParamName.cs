using Microsoft.VisualStudio.TestTools.UnitTesting;
using Orion.Net.Client.Scripts;

namespace Orion.Net.Client.UnitTests
{
    /// <summary>
    /// Test for <see cref="CareCenterScriptParameterInterpreterResult">
    /// </summary>
    [TestClass]
    public class TestParamName
    {
        /// <summary>
        /// Test for ParameterName from <see cref="ScriptParameterInterpreterResult">
        /// <list type="bullet">
        /// <item>
        /// <term>First Assert</term>
        /// <description>At the instantiation, expect null</description>
        /// </item>
        /// <item>
        /// <term>Second Assert</term>
        /// <description>After attribution of value, expect value</description>
        /// </item>
        /// </list>
        /// </summary>
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
