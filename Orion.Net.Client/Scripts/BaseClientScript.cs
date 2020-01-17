using System;
using System.IO;
using System.Collections.Generic;
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

        protected async Task SendStringContent(string contentResult)
        {
            var result = new StringContentResult()
            {
                ResultIdentifier = Guid.NewGuid(),
                ConsoleContent = contentResult
            };

            // Send result content to server :
            await connector.SendResultCommand(result);

            // Notifiy server that result has been sent

        }

        protected async Task SendImageContent(string pathImage)
        {
            var result = new ImageContentResult()
            {
                ResultIdentifier = Guid.NewGuid(),
                ImageInByteArray = System.IO.File.ReadAllBytes(pathImage)
            };

            // Send result content to server :
            await connector.SendResultCommand(result);
        }

        /// <summary>
        /// TODO Add check for path and file, same as SendImageContent so put it in a function
        /// get the mime of the file, read the file's bytes, extract the file's name from the path
        /// Send FileContentResult
        /// </summary>
        /// <param name="pathFile"></param>
        /// <returns></returns>
        protected async Task SendFileContent(string pathFile)
        {
            //Get the file's mime or a default one
            new FileExtensionContentTypeProvider().TryGetContentType(pathFile, out string mime);
            mime = mime ?? "application/octet-stream";

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
