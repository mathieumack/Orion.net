using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Orion.Net.Core.Scripts;

namespace Orion.Net.Hubs
{
    public class OrionHub : Hub
    {
        #region New connections

        /// <summary>
        /// Called by clients in order to transmit information to support
        /// </summary>
        /// <param name="clientLabel"></param>
        /// <returns></returns>
        public async Task Hello(string clientLabel)
        {
            await Clients.All.SendAsync("NewClient", new
            {
                UserName = clientLabel,
                Context.ConnectionId
            });
        }

        #endregion

        #region Discuss with client for available commands

        /// <summary>
        /// Send a command to a dedicated client
        /// </summary>
        /// <param name="scriptCommand"></param>
        /// <returns></returns>
        public async Task SendCommandToClient(ExecuteScriptCommand scriptCommand)
        {
            await Clients.Client(scriptCommand.ConnectionId).SendAsync("ExecuteCommand", scriptCommand.CommandTitle, scriptCommand.CommandParam);
        }

        /// <summary>
        /// Send an ask command to a dedicated client
        /// </summary>
        /// <param name="connectionId"></param>
        /// <returns></returns>
        public async Task AskCommands(string connectionId)
        {
            await Clients.Client(connectionId).SendAsync("AskCommands");
        }

        /// <summary>
        /// Called by clients to send Commands List
        /// </summary>
        /// <param name="availableScripts"></param>
        /// <returns></returns>
        public async Task ClientAnswerCommands(List<AvailableClientScript> availableScripts)
        {
            await Clients.All.SendAsync("AnswerCommands", Context.ConnectionId, availableScripts);
        }

        /// <summary>
        /// Called by client to send result
        /// </summary>
        /// <param name="resultIdentifier"></param>
        /// <param name="resultType"></param>
        /// <returns></returns>
        public async Task ResultCommandSent(Guid resultIdentifier, int resultType)
        {
            await Clients.All.SendAsync("ResultSent", Context.ConnectionId, resultIdentifier, resultType);
        }

        #endregion
    }
}