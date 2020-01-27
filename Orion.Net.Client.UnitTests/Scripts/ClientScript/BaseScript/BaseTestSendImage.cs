using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Orion.Net.Client.UnitTests.Scripts.ClientScript.BaseScript
{
    /// <summary>
    /// TODO : not the best or good way to test the method
    /// Constructor with <see cref="Connector"/> as null to never connect with the connector
    /// We just want to test the method SendImageContent in <see cref="BaseClientScript"/>
    /// </summary>
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
