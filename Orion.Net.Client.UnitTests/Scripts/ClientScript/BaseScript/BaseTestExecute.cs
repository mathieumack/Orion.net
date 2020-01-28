using Microsoft.VisualStudio.TestTools.UnitTesting;
using Orion.Net.Client.Scripts;
using System.Threading.Tasks;

namespace Orion.Net.Client.UnitTests.Scripts.ClientScript.BaseScript
{
    /// <summary>
    /// Unit Test for <see cref="BaseClientScript"/> with a test class <see cref="TestClassBaseClientScript"/>
    /// Check the method <see cref="BaseClientScript.Execute(string)"/>
    /// <list type="number">
    /// <item>Check instantiation of <see cref="TestClassBaseClientScript.TestExecuteResult"/> to false</item>
    /// <item>Check the method worked and <see cref="TestClassBaseClientScript.TestExecuteResult"/> is true</item>
    /// </list>
    /// </summary>
    /// <remarks><see cref="BaseClientScript(Configuration.Connector)"/> is null as it's not useful</remarks>
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
