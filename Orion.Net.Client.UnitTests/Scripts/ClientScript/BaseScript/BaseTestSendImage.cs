using Microsoft.VisualStudio.TestTools.UnitTesting;
using Orion.Net.Client.Scripts;

namespace Orion.Net.Client.UnitTests.Scripts.ClientScript.BaseScript
{
    /// <summary>
    /// Unit Test for <see cref="BaseClientScript"/> with a test class <see cref="TestClassBaseClientScript"/>
    /// Check the method <see cref="BaseClientScript.SendImageContent(string)"/>
    /// TODO : not the best or good way to test the method
    /// </summary>
    /// <remarks><see cref="BaseClientScript(Configuration.Connector)"/> is null as it's not useful</remarks>

    [TestClass]
    public class BaseTestSendImage
    {
        [TestMethod]
        public void TestSendString()
        {
            TestClassBaseClientScript testBaseClient = new TestClassBaseClientScript(null);

            Assert.IsTrue(testBaseClient.TestSendStringContent("test"));
        }
    }
}
