using System;
using System.Net.Http;

namespace Orion.Net.Core.Interfaces
{
    public abstract class ClientScriptResult
    {
        /// <summary>
        /// Identifier for the generated result
        /// Used by the server to check result content
        /// </summary>
        public virtual Guid ResultIdentifier { get; set; }

        /// <summary>
        /// Type of the result
        /// </summary>
        public abstract ClientScriptResultType ResultType { get; set; } 

        /// <summary>
        /// Internal method used by Script layer
        /// </summary>
        /// <returns></returns>
        internal abstract HttpContent GenerateDataContent();
    }
}
