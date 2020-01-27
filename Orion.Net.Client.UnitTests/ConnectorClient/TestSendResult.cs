using Microsoft.VisualStudio.TestTools.UnitTesting;
using Orion.Net.Client.Configuration;
using Microsoft.AspNetCore.SignalR.Client;
using Orion.Net.Core.Interfaces;
using Orion.Net.Core.Results;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;

namespace Orion.Net.Client.UnitTests.ConnectorClient
{
    /// <summary>
    /// Not the best way or the good way at all
    /// Fail error : "System.Net.Http.HttpRequestException.
    /// Aucune connexion n’a pu être établie car l’ordinateur cible l’a expressément refusée."
    /// </summary>
    [TestClass]
    public class TestSendResult
    {
        [TestMethod]
        public async Task VerifySendResultTestCommand()
        {
            Connector testConnector = new Connector();
            TestHub testHub = new TestHub();
            List<ClientScriptResult> testResults = new List<ClientScriptResult>
            {
                new StringContentResult(),
                new ImageContentResult()
            };

            try
            {
                await testConnector.Connect("https://localhost:44359/", "test", "test");

                foreach (var result in testResults)
                {
                    await testConnector.SendResultCommand(result);
                    testConnector.hubConnection.On<bool>("TestCompleted", (e) =>
                    {
                        Assert.IsTrue(e);
                    });
                }
            }
            catch(Exception ex)
            { 
                Assert.Fail(ex.ToString()); 
            }
        }
    }
}
