namespace Orion.Net.Core.Scripts
{
    public class ExecuteScriptCommand
    {
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
