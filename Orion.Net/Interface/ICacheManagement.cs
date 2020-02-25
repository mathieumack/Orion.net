using System;

namespace Orion.Net.Interface
{
    /// <summary>
    /// Interface for Cache Management
    /// <para>To choose between <see cref="RedisCache"/> and <see cref="LocalCache"/></para>
    /// </summary>
    public interface ICacheManagement
    {
        /// <summary>
        /// Return Guid of the supportId
        /// </summary>
        /// <param name="key">SupportId=userId</param>
        /// <returns>Guid in string</returns>
        /// <remarks>Save up to one day</remarks>
        string GetSupportId(string key);

        /// <summary>
        /// Return the value at the key or an error message if the key doesn't exist
        /// </summary>
        /// <param name="key">Identifier key</param>
        /// <returns>Value in string</returns>
        string GetValue(Guid key);

        /// <summary>
        /// Set the value at the key or do nothing if the key already exists
        /// </summary>
        /// <param name="key">Identifier key</param>
        /// <param name="value">Value in string</param>
        void SetValue(Guid key, string value);

        /// <summary>
        /// Set the value at the key or do nothing if the key already exists
        /// </summary>
        /// <param name="key">Identifier Key</param>
        void SetSupportId(string key);
    }
}
