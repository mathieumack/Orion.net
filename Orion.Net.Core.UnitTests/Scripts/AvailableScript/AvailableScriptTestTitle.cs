using Microsoft.VisualStudio.TestTools.UnitTesting;
using Orion.Net.Core.Scripts;

namespace Orion.Net.Core.UnitTests.Scripts.AvailableScript
{
    [TestClass]
    public class AvailableScriptTestTitle
    {
        [TestMethod]
        public void ScriptTestTitle()
        {
            AvailableClientScript testAvailableScript = new AvailableClientScript();

            Assert.IsNull(testAvailableScript.Title);

            testAvailableScript.Title = "toto";

            Assert.AreEqual("toto", testAvailableScript.Title);
        }
    }
}
