namespace Orion.Net.Core.Interfaces
{
    /// <summary>
    /// Result type for Client Script
    /// </summary>
    public enum ClientScriptResultType
    {
        /// <summary>
        /// No results needed, default
        /// </summary>
        NONE = 1,
        /// <summary>
        /// List of string content
        /// </summary>
        ConsoleLog = 2,
        /// <summary>
        /// Image as byte[]
        /// </summary>
        Image = 3
    }
}
