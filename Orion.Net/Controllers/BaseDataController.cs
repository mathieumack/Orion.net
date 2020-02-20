using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Orion.Net.Core.Interfaces;
using Orion.Net.Interfaces;
using StackExchange.Redis;

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

        protected IConfiguration configuration;

        /// <summary>
        /// Constructor of <see cref="BaseDataController{T}"/> with the instantiation of the connection to Redis server <see cref="lazyConnection"/> and the database interface <see cref="cacheRedis"/>
        /// </summary>
        public BaseDataController(IConfiguration configuration)
        {
            this.configuration = configuration;
            lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
            {
                return ConnectionMultiplexer.Connect(configuration["redis"]);
            });
            cacheRedis = lazyConnection.Value.GetDatabase(asyncState: true);
        }

        /// <summary>
        /// Destructor to dispose the connection to redis server
        /// </summary>
        ~BaseDataController()
        {
            lazyConnection.Value.Dispose();
        }

        /// <summary>
        /// Get specific value from <see cref="cacheRedis"/>
        /// </summary>
        /// <param name="id">Key for the cache</param>
        /// <returns>Value in the cache or an error message</returns>
        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(string id)
        {
            if (cacheRedis.KeyExists(id))
            {
                var result = cacheRedis.StringGet(id);
                cacheRedis.KeyDelete(id);
                return result.ToString();
            }

            return "Key Redis doesn't exist";
        }

        //[Authorize(Policy = "SupportID")]
        [AllowAnonymous]
        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]T model)
        {
            // Save value in cache
            if (!cacheRedis.KeyExists(model.ResultIdentifier.ToString()))
                cacheRedis.StringSet(model.ResultIdentifier.ToString(), JsonConvert.SerializeObject(model), TimeSpan.FromDays(1));
        }
    }
}
