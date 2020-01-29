using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
using Newtonsoft.Json;
using Orion.Net.Client.Scripts;
using Orion.Net.Core.Interfaces;
using Orion.Net.Core.Scripts;
using StackExchange.Redis;

namespace Orion.Net.Client.Configuration
{
    public class Connector : IAsyncDisposable
    {
        internal Lazy<ConnectionMultiplexer> lazyConnection;
        internal IDatabase cacheRedis;
        private HubConnection hubConnection;
        private string platFormUri;
        private readonly List<BaseClientScript> commands = new List<BaseClientScript>();
        private readonly string appId;

        public Connector() { 
            appId = Guid.NewGuid().ToString();
            lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
            {
                string cacheConnection = ConfigurationManager.AppSettings["RedisConnection"].ToString();
                return ConnectionMultiplexer.Connect(cacheConnection);
            });

            cacheRedis = lazyConnection.Value.GetDatabase(asyncState: true);
        }

        ~Connector()
        {
            lazyConnection.Value.Dispose();
        }

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
        public void AddCommandService<T>(T command) where T : BaseClientScript
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));

            commands.Add(command);
        }

        /// <summary>
        /// Connect to the server.
        /// Do not forget to call AddCommandService<>() to register IClientScript class 
        /// </summary>
        /// <param name="platformUri"></param>
        /// <param name="environmentLabel"></param>
        /// <param name="supportID"></param>
        /// <returns></returns>
        public async Task Connect(string platformUri, string environmentLabel, string supportID)
        {
            this.platFormUri = platformUri.EndsWith("/") ? platformUri : platformUri + "/";

            hubConnection = new HubConnectionBuilder()
                                        .WithUrl(platFormUri + "orionhub")
                                        .Build();

            hubConnection.On("AskCommands", async () =>
            {
                // Ask client for available commands :
                await hubConnection.InvokeAsync("ClientAnswerCommands", appId, commands
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
                await command.Start(parameters);
            });

            await hubConnection.StartAsync();
            await hubConnection.InvokeAsync("Hello", appId, supportID, environmentLabel);

        }

        /// <summary>
        /// Return a command from title
        /// </summary>
        /// <param name="commandTitle"></param>
        /// <returns></returns>
        private BaseClientScript GetCommand(string commandTitle)
        {
            return commands.FirstOrDefault(e => e.Title == commandTitle);
        }

        /// <summary>
        /// Send a result object to the platform and call hub to force refresh
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="result"></param>
        internal async Task SendResultCommand<T>(T result) where T : ClientScriptResult
        {
            var content = JsonConvert.SerializeObject(result);

            //cacheRedis = lazyConnection.Value.GetDatabase(asyncState: true);
            // Save value if key doesn't exist already
            if (!cacheRedis.KeyExists(result.ResultIdentifier.ToString()))
                cacheRedis.StringSet(result.ResultIdentifier.ToString(), content);

            // Notify server client that a result has been sent :
            await hubConnection.InvokeAsync("ResultCommandSent", appId, result.ResultIdentifier, result.ResultType);
        }
    }
}
