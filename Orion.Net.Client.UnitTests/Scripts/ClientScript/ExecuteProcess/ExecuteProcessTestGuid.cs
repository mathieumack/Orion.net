using Microsoft.VisualStudio.TestTools.UnitTesting;
using Orion.Net.Scripts.Common.Diagnostics;

namespace Orion.Net.Client.UnitTests.Scripts.ClientScript.ExecuteProcess
{
    /// <summary>
    /// Unit Test for <see cref="ExecuteProcessClientScript"/>
    /// Check the value of the override <see cref="ExecuteProcessClientScript.Identifier"/>
    /// should be not null or empty
    /// </summary>
    [TestClass]
    public class ExecuteProcessTestGuid
    {
        [TestMethod]
        public void TestGuid()
        {
            ExecuteProcessClientScript testExexuteProcess = new ExecuteProcessClientScript(null);

            Assert.AreNotEqual("00000000-0000-0000-0000-000000000000", testExexuteProcess.Identifier.ToString());
        }
    }
}
