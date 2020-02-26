using System;

namespace Orion.Net.Models
{
    /// <summary>
    /// Profile Model of the AAD User
    /// </summary>
    public class UserProfileModel
    {
        /// <summary>
        /// Support Identifier
        /// </summary>
        public string SupportID { get; set; }

        /// <summary>
        /// Name of the AAD user connected
        /// </summary>
        public string Name { get; set; }
    }
}
