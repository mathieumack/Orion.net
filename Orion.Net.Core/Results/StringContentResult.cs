using System.Text;
using System.Net.Http;
using Newtonsoft.Json;
using Orion.Net.Core.Interfaces;

namespace Orion.Net.Core.Results
{
    /// <summary>
    /// <inheritdoc/>
    /// <para>Type String</para>
    /// </summary>
    public class StringContentResult : ClientScriptResult
    {
        /// <summary>
        /// Set <see cref="ClientScriptResultType"/> to <see cref="ClientScriptResultType.ConsoleLog"/>
        /// </summary>
        public override ClientScriptResultType ResultType { get; set; } = ClientScriptResultType.ConsoleLog;

        /// <summary>
        /// String send to support
        /// </summary>
        public string ConsoleContent { get; set; }

        /// <summary>
        /// Serialize <see cref="StringContentResult"/> into <see cref="HttpContent"/>
        /// </summary>
        /// <returns>HttpContent of <see cref="StringContentResult"/></returns>
        internal override HttpContent GenerateDataContent()
        {
            return new StringContent(JsonConvert.SerializeObject(this), Encoding.UTF8, "application/json");
        }
    }
}
