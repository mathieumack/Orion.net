using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        protected async Task SendFileContent(string pathFile)
        {
            var result = new FileContentResult()
            {
                ResultIdentifier = Guid.NewGuid(),
                FileInByteArray = System.IO.File.ReadAllBytes(pathFile)
            };

            // Send result content to server :
            await connector.SendResultCommand(result);
        }

        #endregion
    }
}
