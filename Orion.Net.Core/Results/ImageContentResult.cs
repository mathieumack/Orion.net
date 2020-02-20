using System.Text;
using System.Net.Http;
using Newtonsoft.Json;
using Orion.Net.Core.Interfaces;

namespace Orion.Net.Core.Results
{
    /// <summary>
    /// <inheritdoc/>
    /// <para>Type Image</para>
    /// </summary>
    public class ImageContentResult : ClientScriptResult
    {
        /// <summary>
        /// Set <see cref="ClientScriptResultType"/> to <see cref="ClientScriptResultType.Image"/>
        /// </summary>
        public override ClientScriptResultType ResultType { get; set; } = ClientScriptResultType.Image;

        /// <summary>
        /// Image as byte array
        /// </summary>
        public byte[] ImageAsByteArray { get; set; }

        /// <summary>
        /// Serialize <see cref="ImageContentResult"/> into <see cref="HttpContent"/>
        /// </summary>
        /// <returns>HttpContent of <see cref="ImageContentResult"/></returns>
        internal override HttpContent GenerateDataContent()
        {
            return new StringContent(JsonConvert.SerializeObject(this), Encoding.UTF8, "application/json");
        }
    }
}
