using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.SignalR.Client;
using Orion.Net.Client.Configuration;
using System;
using System.Threading.Tasks;

namespace Orion.Net.Client.UnitTests.ConnectorClient
{
    /// <summary>
    /// Unit Test for <see cref="Connector"/>
    /// Check the method <see cref="Connector.Connect(string, string, string)"/>
    /// Error : "System.Net.Http.HttpRequestException: 
    /// Aucune connexion n’a pu être établie car l’ordinateur cible l’a expressément refusée."
    /// TO DO : not working
    /// </summary>
    [TestClass]
    public class TestConnect
    {
        [TestMethod]
        public async Task TestConnectClient()
        {
            TestHub testHub = new TestHub();
            Connector testConnector = new Connector();

            try
            {
                await testConnector.Connect("https://localhost:44359/", "test", "test");
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
