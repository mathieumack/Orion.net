using Microsoft.VisualStudio.TestTools.UnitTesting;
using Orion.Net.Client.Configuration;
using Orion.Net.Client.Scripts;

namespace Orion.Net.Client.UnitTests.Scripts.ClientScript.BaseScript
{
    /// <summary>
    /// Unit Test for <see cref="BaseClientScript"/> with a test class <see cref="TestClassBaseClientScript"/>
    /// Check the value of the override <see cref="BaseClientScript.Title"/>
    /// </summary>
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
