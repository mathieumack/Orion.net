
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Orion.Net.Core.Scripts;

namespace Orion.Net.Core.UnitTests.Scripts.ExecuteScriptCom
{
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
