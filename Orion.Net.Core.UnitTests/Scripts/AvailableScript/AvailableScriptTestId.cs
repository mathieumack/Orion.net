using Microsoft.VisualStudio.TestTools.UnitTesting;
using Orion.Net.Core.Scripts;
using System;

namespace Orion.Net.Core.UnitTests.Scripts.AvailableScript
{
    [TestClass]
    public class AvailableScriptTestId
    {
        /// <summary>
        /// Test Identifier of <see cref="AvailableClientScript"/>
        /// </summary>
        /// <remarks>Guid.Empty == string "00000000-0000-0000-0000-000000000000"</remarks>
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
