
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Orion.Net.Core.Scripts;

namespace Orion.Net.Core.UnitTests.Scripts.ExecuteScriptCom
{
    /// <summary>
    /// Unit Test for <see cref="ExecuteScriptCommand"/>
    /// <list type="number">
    /// <item>Verify <see cref="ExecuteScriptCommand.CommandTitle"/> is not instantiated</item>
    /// <item>Verify <see cref="ExecuteScriptCommand.CommandTitle"/> set and get</item>
    /// </list>
    /// </summary>
    [TestClass]
    public class ExecuteScriptTestCommandTitle
    {
        [TestMethod]
        public void ExecuteScriptCommandTestCommandTitle()
        {
            ExecuteScriptCommand testExecuteScript = new ExecuteScriptCommand();

            Assert.IsNull(testExecuteScript.CommandTitle);

            testExecuteScript.CommandTitle = "toto";

            Assert.AreEqual("toto", testExecuteScript.CommandTitle);
        }
    }
}
