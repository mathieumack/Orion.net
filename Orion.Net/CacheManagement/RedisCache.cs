using System;
using Microsoft.Extensions.Configuration;
using Orion.Net.Interface;
using StackExchange.Redis;

namespace Orion.Net.CacheManagement
{
    /// <summary>
    /// Redis Cache management
    /// </summary>
    /// <remarks>Work with both local Redis and Azure Cache for Redis</remarks>
    public class RedisCache : ICacheManagement
    {
        /// <summary>
        /// Lazy connection to Redis server
        /// </summary>
        internal Lazy<ConnectionMultiplexer> lazyConnection;

        /// <summary>
        /// Interface to Redis database for the access to the methods
        /// </summary>
        internal IDatabase cacheRedis;

        /// <summary>
        /// Constructor of <see cref="RedisCache"/> with the instantiation of the connection to Redis server <see cref="lazyConnection"/> and the database interface <see cref="cacheRedis"/>
        /// </summary>
        public RedisCache(IConfiguration configuration)
        {
            lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
            {
                return ConnectionMultiplexer.Connect(configuration["redis"]);
            });
            cacheRedis = lazyConnection.Value.GetDatabase(asyncState: true);
        }

        /// <summary>
        /// Destructor to dispose the connection to redis server
        /// </summary>
        ~RedisCache()
        {
            lazyConnection.Value.Dispose();
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="key">Identifier key</param>
        /// <returns>SupportId in string</returns>
        public string GetSupportId(string key)
        {
            return cacheRedis.KeyExists(key) ? cacheRedis.StringGet(key).ToString() : "SupportId doesn't exist";
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="key">Identifier key</param>
        /// <returns>Value in string</returns>
        public string GetValue(Guid key)
        {
            if (cacheRedis.KeyExists(key.ToString()))
            {
                var result = cacheRedis.StringGet(key.ToString());
                cacheRedis.KeyDelete(key.ToString());
                return result.ToString();
            }
            return "Key doesn't exist";
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="key">Identifier Key</param>
        public void SetSupportId(string key)
        {
            if (!cacheRedis.KeyExists(key))
                cacheRedis.StringSet(key, "true", TimeSpan.FromDays(1));
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="key">Identifier key</param>
        /// <param name="value">Value in string</param>
        public void SetValue(Guid key, string value)
        {
            if (!cacheRedis.KeyExists(key.ToString()))
                cacheRedis.StringSet(key.ToString(), value, TimeSpan.FromDays(1));
        }
    }
}
