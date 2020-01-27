using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Orion.Net.Client.Configuration;
using System;

namespace Orion.Net.Client.UnitTests.ConnectorClient
{
    /// <summary>
    /// Not working, try other idea
    /// TODO
    /// </summary>
    [TestClass]
    public class TestConnect
    {
        [TestMethod]
        public async void TestConnectClient()
        {
            Connector testConnector = new Connector();
            TestHub testHub = new TestHub();
            
            await testConnector.Connect("https://localhost:44359/", "test", "test");

            try
            {
                testConnector.hubConnection.On<bool>("TestCompleted", (e) =>
                {
                    Assert.IsTrue(e);
                });
            }
            catch(Exception ex)
            {
                Assert.Fail(ex.ToString());
            }
        }
    }
}
