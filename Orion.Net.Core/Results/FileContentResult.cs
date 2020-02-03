using System.Text;
using System.Net.Http;
using Newtonsoft.Json;
using Orion.Net.Core.Interfaces;

namespace Orion.Net.Core.Results
{
    /// <summary>
    /// <inheritdoc/>
    /// <para>Type File</para>
    /// </summary>
    public class FileContentResult : ClientScriptResult
    {
        /// <summary>
        /// Set <see cref="ClientScriptResultType"/> to <see cref="ClientScriptResultType.File"/>
        /// </summary>
        public override ClientScriptResultType ResultType { get; set; } = ClientScriptResultType.File;

        /// <summary>
        /// File as byte array
        /// </summary>
        public byte[] FileAsByteArray { get; set; }

        /// <summary>
        /// File name with extension
        /// </summary>
        /// <example>filename.extension</example>
        public string FileName { get; set; }

        /// <summary>
        /// File's mime type
        /// </summary>
        public string Mime { get; set; }

        /// <summary>
        /// Serialize <see cref="FileContentResult"/> into <see cref="HttpContent"/>
        /// </summary>
        /// <returns>HttpContent of <see cref="FileContentResult"/></returns>
        internal override HttpContent GenerateDataContent()
        {
            return new StringContent(JsonConvert.SerializeObject(this), Encoding.UTF8, "application/json");
        }
    }
}