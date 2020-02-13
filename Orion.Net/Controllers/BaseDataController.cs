using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Orion.Net.Core.Interfaces;
using StackExchange.Redis;
using System;
using System.Collections.Generic;

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
                return ConnectionMultiplexer.Connect("keyRedis");
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

            return "Key API doesn't exist";
        }

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
