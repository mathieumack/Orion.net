using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
using Orion.Net.Core.Interfaces;
using Orion.Net.Core.Scripts;

namespace Orion.Net.Client.Configuration
{
    public class CareCenterConnector : IAsyncDisposable
    {
        private HubConnection hubConnection;
        private readonly List<IClientScript> commands = new List<IClientScript>();

        public async ValueTask DisposeAsync()
        {
            if (hubConnection != null)
                await hubConnection.DisposeAsync();
        }

        /// <summary>
        /// Add a 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="command"></param>
        public void AddCommandService<T>(T command) where T : IClientScript
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));

            commands.Add(command);
        }

        /// <summary>
        /// Connect to the server.
        /// Do not forget to call AddCommandService<>() to register ICareCenterClientScript class
        /// </summary>
        /// <param name="hubUrl"></param>
        /// <param name="environmentLabel"></param>
        /// <returns></returns>
        public async Task Connect(string hubUrl, string environmentLabel)
        {
            hubConnection = new HubConnectionBuilder()
                                        .WithUrl(hubUrl)
                                        .Build();

            hubConnection.On("AskCommands", async () =>
            {
                // Ask client for available commands :
                await hubConnection.InvokeAsync("ClientAnswerCommands", commands
                    .Select(e => new AvailableClientScript()
                    {
                        Title = e.Title,
                        Identifier = e.Identifier
                    }).ToList());
            });

            hubConnection.On<string, string>("ExecuteCommand", async (commandTitle, parameters) =>
            {
                // Ask client for available commands :
                var command = GetCommand(commandTitle);
                var result = command.Execute(parameters);
                await hubConnection.InvokeAsync("ExecuteCommandResult", result);
            });

            await hubConnection.StartAsync();
            await hubConnection.InvokeAsync("Hello", environmentLabel);
        }

        /// <summary>
        /// Return a command from title
        /// </summary>
        /// <param name="commandTitle"></param>
        /// <returns></returns>
        private IClientScript GetCommand(string commandTitle)
        {
            return commands.FirstOrDefault(e => e.Title == commandTitle);
        }
    }
}
