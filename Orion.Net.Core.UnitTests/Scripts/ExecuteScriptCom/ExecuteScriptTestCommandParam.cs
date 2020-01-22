using Microsoft.VisualStudio.TestTools.UnitTesting;
using Orion.Net.Core.Scripts;

namespace Orion.Net.Core.UnitTests.Scripts.ExecuteScriptCom
{
    [TestClass]
    public class ExecuteScriptTestCommandParam
    {
        [TestMethod]
        public void ExecuteScriptCommandTestCommandParam()
        {
            ExecuteScriptCommand testExecuteScript = new ExecuteScriptCommand();

            Assert.IsNull(testExecuteScript.CommandParam);

            testExecuteScript.CommandParam = "toto";

            Assert.AreEqual("toto", testExecuteScript.CommandParam);
        }
    }
}
