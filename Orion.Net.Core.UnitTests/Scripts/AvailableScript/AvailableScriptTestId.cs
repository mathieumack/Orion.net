using Microsoft.VisualStudio.TestTools.UnitTesting;
using Orion.Net.Core.Scripts;
using System;

namespace Orion.Net.Core.UnitTests.Scripts.AvailableScript
{
    /// <summary>
    /// Unit Test for <see cref="AvailableClientScript"/>
    /// <list type="number">
    /// <item>Verify <see cref="AvailableClientScript.Identifier"/> is not instantiated</item>
    /// <item>Verify <see cref="AvailableClientScript.Identifier"/> set and get</item>
    /// </list>
    /// <remarks>Guid.Empty == string "00000000-0000-0000-0000-000000000000"</remarks>
    /// </summary>
    [TestClass]
    public class AvailableScriptTestId
    {
        [TestMethod]
        public void ScriptTestId()
        {
            AvailableClientScript testAvailableScript = new AvailableClientScript();

            Assert.AreEqual("00000000-0000-0000-0000-000000000000", testAvailableScript.Identifier.ToString());

            testAvailableScript.Identifier = Guid.NewGuid();

            Assert.AreNotEqual("00000000-0000-0000-0000-000000000000", testAvailableScript.Identifier.ToString());
        }
    }
}
