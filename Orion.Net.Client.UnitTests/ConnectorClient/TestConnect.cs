using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Orion.Net.Client.Configuration;

namespace Orion.Net.Client.UnitTests.ConnectorClient
{
    [TestClass]
    public class TestConnect
    {
        [TestMethod]
        public async void TestConnectClient()
        {
            Connector testConnector = new Connector();
            TestHub testHub = new TestHub();
            await testConnector.Connect("https://localhost:44359/", "test", "test");

            testConnector.hubConnection.On<bool>("TestCompleted", (e) =>
            {
                Assert.IsTrue(e);
            });
        }
    }
}
