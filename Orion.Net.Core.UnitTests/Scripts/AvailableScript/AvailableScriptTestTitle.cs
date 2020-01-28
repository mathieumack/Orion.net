using Microsoft.VisualStudio.TestTools.UnitTesting;
using Orion.Net.Core.Scripts;

namespace Orion.Net.Core.UnitTests.Scripts.AvailableScript
{
    /// <summary>
    /// Unit Test for <see cref="AvailableClientScript"/>
    /// <list type="number">
    /// <item>Verify <see cref="AvailableClientScript.Title"/> is not instantiated</item>
    /// <item>Verify <see cref="AvailableClientScript.Title"/> set and get</item>
    /// </list>
    /// </summary>
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
