using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace Orion.Net.Client.UnitTests.Scripts.ClientScript.BaseScript
{
    /// <summary>
    /// TestExecuteResult is instantiated to false
    /// If Execute worked, TestExecuteResult is true
    /// <seealso cref="TestClassBaseClientScript"/>
    /// </summary>
    [TestClass]
    public class BaseTestExecute
    {
        [TestMethod]
        public async Task TestExecute()
        {
            TestClassBaseClientScript testBaseClient = new TestClassBaseClientScript(null);
            string testParam = @"-test ""test""-args""test";

            Assert.IsFalse(testBaseClient.TestExecuteResult);

            await testBaseClient.Execute(testParam);

            Assert.IsTrue(testBaseClient.TestExecuteResult);
        }
    }
}
