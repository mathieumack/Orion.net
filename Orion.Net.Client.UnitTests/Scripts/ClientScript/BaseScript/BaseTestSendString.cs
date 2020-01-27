using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Orion.Net.Client.Configuration;
using Orion.Net.Core.Interfaces;
using Orion.Net.Core.Results;

namespace Orion.Net.Client.UnitTests.Scripts.ClientScript.BaseScript
{  
    /// <summary>
    /// SendStringContent is protected and has an await SendResultCommand to Connector (asyncPost and more await)
    /// </summary>
    [TestClass]
    public class BaseTestSendString
    {
        [TestMethod]
        public void TestSendString()
        {
            Mock<Connector> mockConnector = new Mock<Connector>();
            mockConnector.Setup(x => x.SendResultCommand(It.IsAny<StringContentResult>()).IsCanceled);
            TestClassBaseClientScript testBaseClient = new TestClassBaseClientScript(mockConnector.Object);

        }
    }
}
