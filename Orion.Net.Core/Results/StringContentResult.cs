using System.Text;
using System.Net.Http;
using Newtonsoft.Json;
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

        internal override HttpContent GenerateDataContent()
        {
            return new StringContent(JsonConvert.SerializeObject(this), Encoding.UTF8, "application/json");
        }
    }
}
