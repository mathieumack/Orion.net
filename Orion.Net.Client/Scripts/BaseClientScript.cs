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
        protected async Task<List<CareCenterScriptParameterInterpreterResult>> LoadParameters(string parameters)
        {
            var paramItems = parameters.ExtractParams();

            if (!paramItems.Any(e => AvailableParameters.Any(a => a.Name == e.ParameterName)))
            {
                await SendStringContent("parameter invalid.");
                return new List<CareCenterScriptParameterInterpreterResult>();
            }

            return paramItems;
        }

        protected BaseClientScript(Connector connector)
        {
            this.connector = connector;
        }

        internal async Task Start(string parameters)
        {
            // Manage start script :

            // Execute overrided execute method
            await Execute(parameters);

            // Notifiy end script
        }

        #region Pre defined results

        internal async Task<bool> CheckPathFile(string path)
        {
            //Check if path is valid and file exists
            if (string.IsNullOrWhiteSpace(path) || !File.Exists(path))
            {
                await SendStringContent("File not found or not accessible");
                return false;
            }

            //Check if file can be read
            try
            {
                var fileStream = new FileStream(path, FileMode.Open);
                var isReadable = fileStream.CanRead;
                fileStream.Dispose();
            }
            catch (IOException ex)
            {
                await SendStringContent("An error occured : " + ex.Message);
                return false;
            }

            return true;
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
        /// Check path 
        /// Post ImageContentResult, with file from path save as byte array, on the paltform
        /// </summary>
        /// <param name="pathImage"></param>
        /// <returns></returns>
        protected async Task SendImageContent(string pathImage)
        {
            //Check if path is valid and file exists
            if (!await CheckPathFile(pathImage))
                return;
            
            //Create result content
            var result = new ImageContentResult()
            {
                ResultIdentifier = Guid.NewGuid(),
                ImageAsByteArray = File.ReadAllBytes(pathImage)
            };

            // Send result content to server :
            await connector.SendResultCommand(result);
        }

        /// <summary>
        /// get the mime of the file, read the file's bytes, extract the file's name from the path
        /// Send FileContentResult
        /// </summary>
        /// <param name="pathFile"></param>
        /// <returns></returns>
        protected async Task SendFileContent(string pathFile)
        {
            //Check if path is valid and file exists
            if (!await CheckPathFile(pathFile))
                return;

            //Get the file's mime or a default one
            new FileExtensionContentTypeProvider().TryGetContentType(pathFile, out string mime);
            mime = mime ?? "application/octet-stream";

            //Create result content
            var result = new FileContentResult()
            {
                ResultIdentifier = Guid.NewGuid(),
                FileAsByteArray = File.ReadAllBytes(pathFile),
                FileName = pathFile.Substring(pathFile.LastIndexOf('\\') + 1 ,pathFile.Length - pathFile.LastIndexOf('\\') - 1),
                Mime = mime
            };

            // Send result content to server :
            await connector.SendResultCommand(result);
        }

        #endregion
    }
}
