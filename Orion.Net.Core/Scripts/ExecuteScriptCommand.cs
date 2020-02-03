namespace Orion.Net.Core.Scripts
{
    /// <summary>
    /// Command's information send to Client to execute
    /// </summary>
    public class ExecuteScriptCommand
    {
        /// <summary>
        /// AppId of the Client for the hub
        /// </summary>
        public string AppId { get; set; }

        /// <summary>
        /// Title of command from ExecuteScript
        /// </summary>
        public string CommandTitle { get; set; }

        /// <summary>
        /// Parameter of command from ExecuteScript
        /// </summary>
        public string CommandParam { get; set; }
    }
}
