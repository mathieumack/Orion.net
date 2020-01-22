
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Orion.Net.Client.Configuration;
using Orion.Net.Scripts.Common.Diagnostics;
using Microsoft.AspNetCore.SignalR;
using Moq;

namespace Orion.Net.Client.UnitTests
{
    [TestClass]
    public class TestAddCommands
    {
        /// <summary>
        /// Add a command service, as <see cref="ExecuteProcessClientScript"/>, to commands in <see cref="Connector"/>
        /// </summary>
        /// <remarks> Not working, why ??</remarks>
        /// <remarks> No delete useless using just yet</remarks>
        [TestMethod]
        public void ConnectorTestAddCommand()
        {
            Connector testConnector = new Connector();

            Assert.IsNotNull(testConnector.commands);

            Assert.AreEqual(0, testConnector.commands.Count);

            testConnector.AddCommandService<ExecuteProcessClientScript>(new ExecuteProcessClientScript(testConnector));

            Assert.AreEqual(1, testConnector.commands.Count);
        }
    }
}
