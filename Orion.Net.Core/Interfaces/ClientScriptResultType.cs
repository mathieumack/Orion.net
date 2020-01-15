namespace Orion.Net.Core.Interfaces
{
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
        /// byte[], base64
        /// </summary>
        Image = 3,
        /// <summary>
        /// File to download
        /// </summary>
        File = 4
    }
}
