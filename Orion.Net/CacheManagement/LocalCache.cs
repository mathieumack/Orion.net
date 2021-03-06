﻿using System;
using System.Collections.Generic;
using Orion.Net.Interface;

namespace Orion.Net.CacheManagement
{
    /// <summary>
    /// LocalCache management
    /// </summary>
    public class LocalCache : ICacheManagement
    {
        /// <summary>
        /// Local Cache Management
        /// </summary>
        public static Dictionary<Guid, object> CacheManager = new Dictionary<Guid, object>();

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="key">Identifier key</param>
        /// <returns>SupportId in string</returns>
        public string GetSupportId(string key)
        {
            return CacheManager.ContainsKey(Guid.Parse(key)) ? CacheManager[Guid.Parse(key)].ToString() : "SupportId doesn't exist";
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="key">Identifier key</param>
        /// <returns>Value in string</returns>
        public string GetValue(Guid key)
        {
            if (CacheManager.ContainsKey(key)) 
            {
                var result = CacheManager[key];
                CacheManager.Remove(key);
                return result.ToString();
            }

            return "Key doesn't exist";
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="key">identifier key</param>
        public void SetSupportId(string key)
        {
            if (!CacheManager.ContainsKey(Guid.Parse(key)))
                CacheManager.Add(Guid.Parse(key), "true");
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="key">Identifier key</param>
        /// <param name="value">Value in string</param>
        public void SetValue(Guid key, string value)
        {
            if (!CacheManager.ContainsKey(key))
                CacheManager.Add(key, value);
        }
    }
}
