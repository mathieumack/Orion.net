namespace Orion.Net.Models
{
    /// <summary>
    /// Profile Model of the AAD User
    /// </summary>
    public class UserProfileModel
    {
        /// <summary>
        /// Key for Authorization API
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Name of the AAD user connected
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// SupportID of the session
        /// </summary>
        public string SupportID { get; set; }

        /// <summary>
        /// Value for Authorization API
        /// </summary>
        public string Value { get; set; }
    }
}
