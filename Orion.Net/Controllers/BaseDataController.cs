using Microsoft.AspNetCore.Mvc;
using Orion.Net.Core.Interfaces;
using StackExchange.Redis;
using System;
using System.Configuration;

namespace Orion.Net.Controllers
{
    /// <summary>
    /// Platform API local
    /// </summary>
    /// <typeparam name="T"> Client Script Result</typeparam>
    [ApiController]
    public class BaseDataController<T> : Controller where T : ClientScriptResult, new()
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
        /// Constructor of <see cref="BaseDataController{T}"/> with the instantiation of the connection to Redis server <see cref="lazyConnection"/> and the database interface <see cref="cacheRedis"/>
        /// </summary>
        public BaseDataController()
        {
            lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
            {
                string cacheConnection = Environment.GetEnvironmentVariable("redis");
                return ConnectionMultiplexer.Connect(cacheConnection);
            });

            cacheRedis = lazyConnection.Value.GetDatabase(asyncState:true);
        }

        /// <summary>
        /// Destructor to dispose the connection to redis server
        /// </summary>
        ~BaseDataController()
        {
            lazyConnection.Value.Dispose();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(Guid id)
        {
            if (cacheRedis.KeyExists(id.ToString()))
            {
                var result = cacheRedis.StringGet(id.ToString());
                cacheRedis.KeyDelete(id.ToString());
                return result.ToString();
            }

            return "{\"ConsoleContent\" : \"Error from Api Get\"}";
        }
    }
}
