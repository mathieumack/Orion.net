using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Orion.Net.Core.Scripts;

namespace Orion.Net.Hubs
{
    /// <summary>
    /// SignalR hub for Orion with methods called by clients
    /// </summary>
    public class OrionHub : Hub
    {
        #region New connections

        /// <summary>
        /// Add client connection to appId group and supportId group
        /// <para>Called by clients to send information to support</para>
        /// </summary>
        /// <param name="appId">Identifier of the Client application</param>
        /// <param name="supportId">Identifier of the Support</param>
        /// <param name="clientLabel">UserName of the Client</param>
        /// <returns></returns>
        public async Task Hello(string appId, string supportId, string clientLabel)
        {
            //Add Connection app to AppGroup named appId in case of reconnection
            await Groups.AddToGroupAsync(Context.ConnectionId, appId);

            //Add Connection app to SupportGroup named support Id
            await Groups.AddToGroupAsync(Context.ConnectionId, supportId);

            //Send to group supportGroup so clients in it too, specify only support ?
            await Clients.OthersInGroup(supportId).SendAsync("NewClient", new
            {
                UserName = clientLabel,
                AppId = appId
            });
        }

        /// <summary>
        /// Create/reconnect SupportId group with support connectionId
        /// </summary>
        /// <param name="supportId">Identifier of Support</param>
        /// <returns></returns>
        public async Task StartSupportGroupe(string supportId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, supportId);
        }

        #endregion

        #region Discuss with client for available commands

        /// <summary>
        /// Send a command to a dedicated client
        /// </summary>
        /// <param name="scriptCommand">Basic Information of the command</param>
        /// <returns></returns>
        public async Task SendCommandToClient(ExecuteScriptCommand scriptCommand)
        {
            await Clients.Group(scriptCommand.AppId).SendAsync("ExecuteCommand", scriptCommand.CommandTitle, scriptCommand.CommandParam);
        }

        /// <summary>
        /// Add support connection id to appId group
        /// <para>Send an ask command to a dedicated client</para>
        /// </summary>
        /// <param name="appId">Identifier of the Client application</param>
        /// <returns></returns>
        public async Task AskCommands(string appId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, appId);
            await Clients.OthersInGroup(appId).SendAsync("AskCommands");
        }

        /// <summary>
        /// Client send list of Commands to support
        /// </summary>
        /// <param name="appId">Identifier of Client application</param>
        /// <param name="availableScripts">List of command scripts available</param>
        /// <returns></returns>
        public async Task ClientAnswerCommands(string appId, List<AvailableClientScript> availableScripts)
        {
            await Clients.OthersInGroup(appId).SendAsync("AnswerCommands", appId, availableScripts);
        }

        /// <summary>
        /// Called by client to send result to support
        /// </summary>
        /// <param name="appId">Identifier of Client application</param>
        /// <param name="resultIdentifier">Identifier of the result object</param>
        /// <param name="resultType">Type of the result object</param>
        /// <returns></returns>
        public async Task ResultCommandSent(string appId, Guid resultIdentifier, int resultType)
        {
            await Clients.OthersInGroup(appId).SendAsync("ResultSent", appId, resultIdentifier, resultType);
        }

        #endregion
    }
}
