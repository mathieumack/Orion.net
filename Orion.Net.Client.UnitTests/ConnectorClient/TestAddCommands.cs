
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Microsoft.AspNetCore.SignalR;
using Orion.Net.Client.Configuration;
using Orion.Net.Scripts.Common.Diagnostics;

namespace Orion.Net.Client.UnitTests.ConnectorClient
{
    [TestClass]
    public class TestAddCommands
    {
        /// <summary>
        /// Add a command service, as <see cref="ExecuteProcessClientScript"/>, to commands in <see cref="Connector"/>
        /// </summary>
        /// <remarks> Not working, why ?? What does WPF have that the test doesn't</remarks>
        [TestMethod]
        public void ConnectorTestAddCommand()
        {
            //Mock<Connector> mockConnector = new Mock<Connector>();
            //Connector test = mockConnector.Object;

            Connector test = new Connector();

            Assert.IsNotNull(test.commands);

            Assert.AreEqual(0, test.commands.Count);

            test.AddCommandService(new ExecuteProcessClientScript(test));

            Assert.AreEqual(1, test.commands.Count);
        }
    }
}
