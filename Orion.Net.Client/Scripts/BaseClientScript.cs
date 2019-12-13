using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        #region Pre defined results

        protected async Task SendStringContent(string contentResult)
        {
            var result = new StringContentResult()
            {
                ConsoleContent = contentResult
            };

            // Send result content to server :


            // Notifiy server that result has been sent

        }

        #endregion
    }
}
