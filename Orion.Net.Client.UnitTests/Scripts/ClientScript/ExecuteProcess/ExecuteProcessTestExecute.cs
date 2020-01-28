using Microsoft.VisualStudio.TestTools.UnitTesting;
using Orion.Net.Scripts.Common.Diagnostics;

namespace Orion.Net.Client.UnitTests.Scripts.ClientScript.ExecuteProcess
{
    /// <summary>
    /// Unit Test for <see cref="ExecuteProcessClientScript"/>
    /// Check the method <see cref="ExecuteProcessClientScript.Execute(string)"/>
    /// TO DO : not a clue on how to test it, same problem of await SentStringContent
    /// </summary>
    [TestClass]
    public class ExecuteProcessTestExecute
    {
        [TestMethod]
        public void TestExecute()
        {
            ExecuteProcessClientScript testExecuteProcess = new ExecuteProcessClientScript(null);

        }
    }
}
