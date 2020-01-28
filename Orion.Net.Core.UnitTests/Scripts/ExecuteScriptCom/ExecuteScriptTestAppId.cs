
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Orion.Net.Core.Scripts;

namespace Orion.Net.Core.UnitTests.Scripts.ExecuteScriptCom
{
    /// <summary>
    /// Unit Test for <see cref="ExecuteScriptCommand"/>
    /// <list type="number">
    /// <item>Verify <see cref="ExecuteScriptCommand.AppId"/> is not instantiated</item>
    /// <item>Verify <see cref="ExecuteScriptCommand.AppId"/> set and get</item>
    /// </list>
    /// </summary>
    [TestClass]
    public class ExecuteScriptTestAppId
    {
        [TestMethod]
        public void ExecuteScriptCommandTestAppId()
        {
            ExecuteScriptCommand testExecuteScript = new ExecuteScriptCommand();

            Assert.IsNull(testExecuteScript.AppId);

            testExecuteScript.AppId = "toto";

            Assert.AreEqual("toto", testExecuteScript.AppId);
        }
    }
}
