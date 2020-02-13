using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.StaticFiles;
using Orion.Net.Client.Configuration;
using Orion.Net.Core.Interfaces;
using Orion.Net.Core.Results;
using Orion.Net.Core.Scripts;

namespace Orion.Net.Client.Scripts
{
    /// <summary>
    /// Client Script use to execute a command on the client side
    /// </summary>
    public abstract class BaseClientScript : IClientScript
    {
        /// <summary>
        /// <inheritdoc/>
        /// Inherited from <see cref="IClientScript"/>
        /// </summary>
        public abstract string Title { get; }
        /// <summary>
        /// <inheritdoc/>
        /// Inherited from <see cref="IClientScript"/>
        /// </summary>
        public abstract Guid Identifier { get; }
        /// <summary>
        /// List of <see cref="ScriptParameter"/> for the command
        /// </summary>
        protected List<ScriptParameter> AvailableParameters { get; } = new List<ScriptParameter>();
        /// <summary>
        /// <inheritdoc/>
        /// Inherited from <see cref="IClientScript"/>
        /// </summary>
        public abstract Task Execute(string parameters);
        /// <summary>
        /// Client Connector to the Hub
        /// </summary>
        private readonly Connector connector;

        /// <summary>
        /// Extract parameters and check if parameters's names correspond
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns>A list of <see cref="ScriptParameterInterpreterResult"/></returns>
        /// <remarks>The returned list will be empty is the parameters don't correspond</remarks>
        protected async Task <List<ScriptParameterInterpreterResult>> LoadParameters(string parameters)
        {
            var paramItems = parameters.ExtractParams();

            if (!paramItems.Any(e => AvailableParameters.Any(a => a.Name == e.ParameterName)))
            {
                await SendStringContent("Parameter invalid.");
                return new List<ScriptParameterInterpreterResult>();
            }

            return paramItems;
        }

        /// <summary>
        /// Constructor with the Client Connector
        /// </summary>
        /// <param name="connector">Client Connector</param>
        protected BaseClientScript(Connector connector)
        {
            this.connector = connector;
        }

        /// <summary>
        /// Execute parameters
        /// </summary>
        /// <param name="parameters"></param>
        /// <return></return>
        internal async Task Start(string parameters)
        {
            // Manage start script :

            // Execute overrided execute method
            await Execute(parameters);

            // Notifiy end script
        }

        #region Pre defined results

        /// <summary>
        /// Create and send a new string content result
        /// </summary>
        /// <return></return>
        /// <param name="contentResult">String content</param>
        protected async Task SendStringContent(string contentResult)
        {
            var result = new StringContentResult()
            {
                ResultIdentifier = Guid.NewGuid(),
                ConsoleContent = contentResult
            };

            // Send result content to server :
            await connector.SendResultCommand(result);
        }

        /// <summary>
        /// Check path and file
        /// Create and send a new image content with file from path save as byte array
        /// </summary>
        /// <param name="pathImage">Path to the image</param>
        /// <return></return>
        /// <exception cref="Exception">The conversion can fail and a message will be send</exception>
        protected async Task SendImageContent(string pathImage)
        {
            if (!File.Exists(pathImage))
            {
                await SendStringContent("File not found.");
                return;
            }

            try
            {
                //Create result content
                var result = new ImageContentResult()
                {
                    ResultIdentifier = Guid.NewGuid(),
                    ImageAsByteArray = File.ReadAllBytes(pathImage)
                };

                // Send result content to server :
                await connector.SendResultCommand(result);
            }
            catch(Exception ex)
            {
                await SendStringContent("An error has occured : " + ex);
            }
        }

        /// <summary>
        /// Check path and file, get the the file's mime
        /// Create and send a new file content with file from path save as byte array
        /// </summary>
        /// <param name="pathFile">Path of the file</param>
        /// <return></return>
        /// <exception cref="Exception">The conversion can fail and a message will be send</exception>
        protected async Task SendFileContent(string pathFile)
        {
            if (!File.Exists(pathFile))
            {
                await SendStringContent("File not found.");
                return;
            }

            try
            {
                //Get the file's mime or a default one
                new FileExtensionContentTypeProvider().TryGetContentType(pathFile, out string mime);
                mime = mime ?? "application/octet-stream";

                //Create result content
                var result = new FileContentResult()
                {
                    ResultIdentifier = Guid.NewGuid(),
                    FileAsByteArray = File.ReadAllBytes(pathFile),
                    FileName = pathFile.Substring(pathFile.LastIndexOf('\\') + 1, pathFile.Length - pathFile.LastIndexOf('\\') - 1),
                    Mime = mime
                };

                // Send result content to server :
                await connector.SendResultCommand(result);
            }
            catch (Exception ex)
            {
                await SendStringContent("An error occured : " + ex);
            }
        }

        #endregion
    }
}