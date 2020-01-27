using Microsoft.VisualStudio.TestTools.UnitTesting;
using Orion.Net.Client.Configuration;

namespace Orion.Net.Client.UnitTests.Scripts.ClientScript.BaseScript
{
    [TestClass]
    public class BaseTestGuid
    {
        [TestMethod]
        public void TestGuid()
        {
            TestClassBaseClientScript testBaseClient = new TestClassBaseClientScript(new Connector());

            Assert.AreNotEqual("00000000-0000-0000-0000-000000000000", testBaseClient.Identifier.ToString());

        }
    }
}
