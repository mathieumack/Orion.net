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
        /// Determine if the program should use Redis or the local Cache management
        /// </summary>
        public bool useRedisCacheManagement = false;
        /// <summary>
        /// Local Cache Management
        /// </summary>
        public static Dictionary<Guid, object> CacheManager = new Dictionary<Guid, object>();
        /// <summary>
        /// Lazy connection to Redis server
        /// </summary>
        internal Lazy<ConnectionMultiplexer> lazyConnection;
        /// <summary>
        /// Interface to Redis database for the access to the methods
        /// </summary>
        internal IDatabase cacheRedis;

        /// <summary>
        /// Constructor of <see cref="BaseDataController{T}"/> with the instantiation of the cache manager :
        /// <list type="table">
        /// <item>With Cache Redis : connection to Redis server <see cref="lazyConnection"/> and the database interface <see cref="cacheRedis"/></item>
        /// <item>With local cache : instantiation of <see cref="CacheManager"/></item>
        /// </list>
        /// </summary>
        public BaseDataController()
        {
            if(useRedisCacheManagement)
            {
                lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
                {
                    return ConnectionMultiplexer.Connect("key");
                });
                cacheRedis = lazyConnection.Value.GetDatabase(asyncState: true);
            }
        }

        /// <summary>
        /// Destructor to dispose the connection to redis server
        /// </summary>
        ~BaseDataController()
        {
            if(useRedisCacheManagement)
            {
                lazyConnection.Value.Dispose();
            }
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(Guid id)
        {
            if (useRedisCacheManagement)
            {
                if (cacheRedis.KeyExists(id.ToString()))
                {
                    var result = cacheRedis.StringGet(id.ToString());
                    cacheRedis.KeyDelete(id.ToString());
                    return result.ToString();
                }
            }
            else
            {
                if (CacheManager.ContainsKey(id))
                {
                    var result = CacheManager[id];
                    CacheManager.Remove(id);
                    return result.ToString();
                }
            }
            return "Key Redis doesn't exist";
        }

        [AllowAnonymous]
        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]T model)
        {
            if (useRedisCacheManagement)
            {
                // Save value in cache
                if (!cacheRedis.KeyExists(model.ResultIdentifier.ToString()))
                    cacheRedis.StringSet(model.ResultIdentifier.ToString(), JsonConvert.SerializeObject(model), TimeSpan.FromDays(1));
            }
            else
            {
                // Save value in cache
                if (!CacheManager.ContainsKey(model.ResultIdentifier))
                    CacheManager.Add(model.ResultIdentifier, JsonConvert.SerializeObject(model));
            }
        }
    }
}