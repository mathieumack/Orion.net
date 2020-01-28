using Microsoft.VisualStudio.TestTools.UnitTesting;
using Orion.Net.Client.Configuration;
using Orion.Net.Client.Scripts;

namespace Orion.Net.Client.UnitTests.Scripts.ClientScript.BaseScript
{
    /// <summary>
    /// Unit Test for <see cref="BaseClientScript"/> with a test class <see cref="TestClassBaseClientScript"/>
    /// Check the value of the override <see cref="BaseClientScript.Identifier"/>
    /// should be not null or empty
    /// </summary>
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
