using System;
using System.Net.Http;

namespace Orion.Net.Core.Interfaces
{
    /// <summary>
    /// Result Script from Client
    /// </summary>
    public abstract class ClientScriptResult
    {
        /// <summary>
        /// Identifier for the generated result
        /// </summary>
        /// <remarks>Used by the server to check result content</remarks>
        public virtual Guid ResultIdentifier { get; set; }

        /// <summary>
        /// Type of the result
        /// </summary>
        public abstract ClientScriptResultType ResultType { get; set; }

        /// <summary>
        /// Internal method used by Script layer
        /// </summary>
        /// <returns>Serialize Json HttpContent</returns>
        internal abstract HttpContent GenerateDataContent();
    }
}
