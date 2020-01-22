
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Orion.Net.Core.Scripts;

namespace Orion.Net.Core.UnitTests.Scripts.ExecuteScriptCom
{
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
