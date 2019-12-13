using System;
using Orion.Net.Core.Interfaces;

namespace Orion.Net.Core.Results
{
    public class StringContentResult : ClientScriptResult
    {
        public override ClientScriptResultType ResultType { get; set; } = ClientScriptResultType.ConsoleLog;

        /// <summary>
        /// console result content
        /// </summary>
        public string ConsoleContent { get; set; }
    }
}
