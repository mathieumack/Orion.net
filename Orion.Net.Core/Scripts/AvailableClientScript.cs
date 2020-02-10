using System;

namespace Orion.Net.Core.Scripts
{
    /// <summary>
    /// Basic information on a Client Script Available to find it
    /// </summary>
    public class AvailableClientScript
    {
        /// <summary>
        /// Public identifier of the client script
        /// </summary>
        public Guid Identifier { get; set; }

        /// <summary>
        /// Title of the client script
        /// </summary>
        public string Title { get; set; }
    }
}
