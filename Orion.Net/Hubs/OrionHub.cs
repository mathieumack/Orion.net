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
        /// Called by clients in order to notify server that the server is connected ;)
        /// </summary>
        /// <param name="clientLabel"></param>
        /// <returns></returns>
        public async Task Hello(string clientLabel)
        {
            await Clients.All.SendAsync("NewClient", new {
                UserName = clientLabel,
                Context.ConnectionId
            });
        }
        
        #endregion

        public async Task SendMessage()
        {
            await Hello(Guid.NewGuid().ToString());
        }

        #region Discuss with client for available commands
        
        /// <summary>
        /// Send a command to a dedicated client
        /// </summary>
        /// <param name="connectionId"></param>
        /// <param name="commandTitle"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task SendCommandToClient(ExecuteScriptCommand scriptCommand)
        {
            await Clients.Client(scriptCommand.ConnectionId).SendAsync("ExecuteCommand", scriptCommand.CommandTitle, scriptCommand.CommandParam);
        }

        /// <summary>
        /// Send an ask command to a dedicated client
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public async Task AskCommands(string connectionId)
        {
            await Clients.Client(connectionId).SendAsync("AskCommands");
        }

        /// <summary>
        /// Called by clients in order to notify server that the server is connected ;)
        /// </summary>
        /// <param name="clientLabel"></param>
        /// <returns></returns>
        public async Task ClientAnswerCommands(List<AvailableClientScript> availableScripts)
        {
            await Clients.All.SendAsync("AnswerCommands", Context.ConnectionId, availableScripts);
        }

        /// <summary>
        /// Called by clients in order to notify server of the result
        /// </summary>
        /// <param name="resultIdentifier"></param>
        /// <returns></returns>
        public async Task ResultCommandSent(Guid resultIdentifier)
        {
            await Clients.All.SendAsync("ResultSent", resultIdentifier);
        }

        #endregion
    }
}
