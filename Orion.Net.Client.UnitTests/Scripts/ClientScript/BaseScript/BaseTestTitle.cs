using Microsoft.VisualStudio.TestTools.UnitTesting;
using Orion.Net.Client.Configuration;

namespace Orion.Net.Client.UnitTests.Scripts.ClientScript.BaseScript
{
    [TestClass]
    public class BaseTestTitle
    {
        [TestMethod]
        public void TestTitle()
        {
            TestClassBaseClientScript testBaseClient = new TestClassBaseClientScript(new Connector());

            Assert.AreEqual("TestClass", testBaseClient.Title);
        }
    }
}
