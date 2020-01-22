namespace Orion.Net.Core.Scripts
{
    public class ExecuteScriptCommand
    {
        /// <summary>
        /// ConnectionId of client
        /// </summary>
        public string ConnectionId { get; set; }

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
