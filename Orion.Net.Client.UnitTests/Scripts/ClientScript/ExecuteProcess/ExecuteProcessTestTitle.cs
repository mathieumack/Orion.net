using Microsoft.VisualStudio.TestTools.UnitTesting;
using Orion.Net.Scripts.Common.Diagnostics;

namespace Orion.Net.Client.UnitTests.Scripts.ClientScript.ExecuteProcess
{
    /// <summary>
    /// Unit Test for <see cref="ExecuteProcessClientScript"/>
    /// Check the value of the override <see cref="ExecuteProcessClientScript.Title"/>    
    /// </summary>
    [TestClass]
    public class ExecuteProcessTestTitle
    {
        [TestMethod]
        public void TestTitle()
        {
            ExecuteProcessClientScript testExecuteProcess = new ExecuteProcessClientScript(null);

            Assert.AreEqual("Execute process", testExecuteProcess.Title);
        }
    }
}
