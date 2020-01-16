using System.Text;
using System.Net.Http;
using Newtonsoft.Json;
using Orion.Net.Core.Interfaces;

namespace Orion.Net.Core.Results
{
    public class FileContentResult : ClientScriptResult
    {
        public override ClientScriptResultType ResultType { get; set; } = ClientScriptResultType.File;

        /// <summary>
        /// console result content
        /// </summary>
        public byte[] FileAsByteArray { get; set; }

        public string FileName { get; set; }

        public string Mime { get; set; }

        internal override HttpContent GenerateDataContent()
        {
            return new StringContent(JsonConvert.SerializeObject(this), Encoding.UTF8, "application/json");
        }
    }
}