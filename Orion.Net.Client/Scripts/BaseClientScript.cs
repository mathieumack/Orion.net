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
    public abstract class BaseClientScript : IClientScript
    {
        public abstract string Title { get; }

        public abstract Guid Identifier { get; }

        protected List<ScriptParameter> AvailableParameters { get; } = new List<ScriptParameter>();

        public abstract Task Execute(string parameters);

        private readonly Connector connector;

        /// <summary>
        /// Extract parameters and check if parameter's names correspond
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        protected async Task <List<ScriptParameterInterpreterResult>> LoadParameters(string parameters)
        {
            var paramItems = parameters.ExtractParams();

            if (!paramItems.Any(e => AvailableParameters.Any(a => a.Name == e.ParameterName)))
            {
                await SendStringContent("parameter invalid.");
                return new List<ScriptParameterInterpreterResult>();
            }

            return paramItems;
        }

        protected BaseClientScript(Connector connector)
        {
            this.connector = connector;
        }

        /// <summary>
        /// Execute parameters
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        internal async Task Start(string parameters)
        {
            // Manage start script :

            // Execute overrided execute method
            await Execute(parameters);

            // Notifiy end script
        }

        #region Pre defined results

        /// <summary>
        ///Check if path is valid or file exists
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        internal bool CheckPathFile(string path)
        {
            return (string.IsNullOrWhiteSpace(path) || !File.Exists(path));
        }

        /// <summary>
        /// Post SendStringContent on the platform
        /// </summary>
        /// <param name="contentResult"></param>
        /// <returns></returns>
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
        /// Post ImageContentResult, with file from path save as byte array, on the paltform
        /// </summary>
        /// <param name="pathImage"></param>
        /// <returns></returns>
        protected async Task SendImageContent(string pathImage)
        {
            if (!CheckPathFile(pathImage))
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
                await this.SendStringContent("An error has occured : " + ex);
            }
        }

        #endregion
    }
}
