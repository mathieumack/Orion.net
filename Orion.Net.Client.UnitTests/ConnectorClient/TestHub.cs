using Microsoft.AspNet.SignalR;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Orion.Net.Core.Scripts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Orion.Net.Client.Configuration
{
    /// <summary>
    /// Class Test to simulate <see cref="OrionHub"/> for Unit Test of <see cref="Connector"/>
    /// Suppression of the support side
    /// </summary>
    [TestClass]
    public class TestHub : Hub
    {
        private string clientConnection;
        private string appID;

        /// <summary>
        /// Add client connection to appId group and supportId group
        /// Called by clients to send information to support
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="supportId"></param>
        /// <param name="clientLabel"></param>
        /// <returns></returns>
        public async Task Hello(string appId, string supportId, string clientLabel)
        {
            clientConnection = Context.ConnectionId;
            appID = appId;
            await AskCommands();
        }

        /// <summary>
        /// Add support connection id to appId group
        /// Send an ask command to a dedicated client
        /// </summary>
        /// <param name="appId"></param>
        /// <returns></returns>
        public async Task AskCommands()
        {
            await Clients.Client(clientConnection).SendAsync("AskCommands");
        }

        /// <summary>
        /// Client send Command to support
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="availableScripts"></param>
        /// <returns></returns>
        public async Task ClientAnswerCommands(string appId, List<AvailableClientScript> availableScripts)
        {
            await SendCommandToClient();
        }

        /// <summary>
        /// Send a command to a dedicated client
        /// </summary>
        /// <param name="scriptCommand"></param>
        /// <returns></returns>
        public async Task SendCommandToClient()
        {
            ExecuteScriptCommand testScript = new ExecuteScriptCommand()
            {
                CommandTitle = "Execute process",
                CommandParam = "-filePath exe"
            };
            await Clients.Client(clientConnection).SendAsync("ExecuteCommand", testScript.CommandTitle, testScript.CommandParam);
        }

        /// <summary>
        /// Called by client in order to notify support of the result
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="resultIdentifier"></param>
        /// <param name="resultType"></param>
        /// <returns></returns>
        public async Task ResultCommandSent(string appId, Guid resultIdentifier, int resultType)
        {
            await Clients.Client(clientConnection).SendAsync("TestCompleted", true);
        }
    }
}
