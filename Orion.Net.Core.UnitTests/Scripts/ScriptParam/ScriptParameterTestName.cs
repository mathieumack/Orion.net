using Microsoft.VisualStudio.TestTools.UnitTesting;
using Orion.Net.Core.Scripts;

namespace Orion.Net.Core.UnitTests.Scripts.ScriptParam
{
    /// <summary>
    /// Unit Test for <see cref="ScriptParameter"/>
    /// <list type="number">
    /// <item>Verify <see cref="ScriptParameter.Name"/> is not instantiated</item>
    /// <item>Verify <see cref="ScriptParameter.Name"/> set and get</item>
    /// </list>
    /// </summary>
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
