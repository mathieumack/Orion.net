using Microsoft.AspNetCore.SignalR.Client;
using Newtonsoft.Json;
using Orion.Net.Client.Scripts;
using Orion.Net.Core.Interfaces;
using Orion.Net.Core.Scripts;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace Orion.Net.Client.Configuration
{
    /// <summary>
    /// Client Connector to the <see cref="OrionHub"/>
    /// </summary>
    public class Connector : IAsyncDisposable
    {
        /// <summary>
        /// Lazy Connection to Redis Server
        /// </summary>
        internal Lazy<ConnectionMultiplexer> lazyConnection;
        /// <summary>
        /// Interface for Redis Server with the methods
        /// </summary>
        internal IDatabase cacheRedis;
        /// <summary>
        /// Client Connection to the hub
        /// </summary>
        private HubConnection hubConnection;
        /// <summary>
        /// List of <see cref="BaseClientScript"/>, each one corresponding to a executable command
        /// </summary>
        /// <remarks><see cref="commands"/> is empty by default, to add command, the Client App calls <see cref="AddCommandService{T}(T)"/></remarks>
        private readonly List<BaseClientScript> commands = new List<BaseClientScript>();
        /// <summary>
        /// Identifier of the Client Application
        /// </summary>
        /// <remarks>Use for connection purpose on the Hub</remarks>
        private readonly string appId;

        /// <summary>
        /// Constructor with instantiation of the GUID of <see cref="appId"/>, the connection to Redis server <see cref="lazyConnection"/> and the interface of the server <see cref="cacheRedis"/>
        /// </summary>
        public Connector()
        {
            appId = Guid.NewGuid().ToString();
            lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
            {
                string cacheConnection = ConfigurationManager.AppSettings["RedisConnection"].ToString();
                return ConnectionMultiplexer.Connect(cacheConnection);
            });

            cacheRedis = lazyConnection.Value.GetDatabase(asyncState: true);
        }

        /// <summary>
        /// Destructor to close the connection to Redis server
        /// </summary>
        ~Connector()
        {
            lazyConnection.Value.Dispose();
        }

        /// <summary>
        /// Dispose the connection to the Hub
        /// </summary>
        public async ValueTask DisposeAsync()
        {
            if (hubConnection != null)
                await hubConnection.DisposeAsync();
        }

        /// <summary>
        /// Add a CommandService to the Client App
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="command"></param>
        /// <exception cref="ArgumentNullException"> if the command is null</exception>
        public void AddCommandService<T>(T command) where T : BaseClientScript
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));

            commands.Add(command);
        }

        /// <summary>
        /// <para>Connect to the server and interact with On and Invoke 
        /// <list type="bullet">
        /// <item>On.AskCommands() : InvokeAsync.ClientAnswerCommands to send back <see cref="commands"/></item>
        /// <item>On.ExecuteCommand(string,string)</item>
        /// <item>On.StartAsync()</item>
        /// <item>InvokeAsync("Hello", appId, supportID, environmentLabel)</item>
        /// </list></para>
        /// Do not forget to call AddCommandService<>() to register IClientScript class 
        /// </summary>
        /// <param name="platformUri"></param>
        /// <param name="environmentLabel"></param>
        /// <param name="supportID"></param>
        /// <returns><see cref="commands"/> when the the Hub send "AskCommands"</returns>
        public async Task Connect(string platformUri, string environmentLabel, string supportID)
        {
            //TO DO : connection to Azure SignalR Service

            var platFormUri = platformUri.EndsWith("/") ? platformUri : platformUri + "/";

            hubConnection = new HubConnectionBuilder()
                                        .WithUrl("https://<name>.service.signalr.net/client/?hub=<namehub>", options =>
                                        {
                                            options.UseDefaultCredentials = true;
                                        })
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
        /// Get the command corresponding to the title
        /// </summary>
        /// <param name="commandTitle"></param>
        /// <returns><see cref="BaseClientScript"/> Command</returns>
        private BaseClientScript GetCommand(string commandTitle)
        {
            return commands.FirstOrDefault(e => e.Title == commandTitle);
        }

        /// <summary>
        /// Send a result object to the server Redis and notify the hub the result was send with parameters to recuperate it
        /// </summary>
        /// <typeparam name="T"><see cref="ClientScriptResult"/></typeparam>
        /// <param name="result">result object</param>
        internal async Task SendResultCommand<T>(T result) where T : ClientScriptResult
        {
            var content = JsonConvert.SerializeObject(result);

            // Save value if key doesn't exist already
            if (!cacheRedis.KeyExists(result.ResultIdentifier.ToString()))
                cacheRedis.StringSet(result.ResultIdentifier.ToString(), content, TimeSpan.FromDays(1));

            // Notify server client that a result has been sent :
            await hubConnection.InvokeAsync("ResultCommandSent", appId, result.ResultIdentifier, result.ResultType);
        }
    }
}
