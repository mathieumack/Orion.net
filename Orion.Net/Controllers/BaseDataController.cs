using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Orion.Net.Core.Interfaces;
using Orion.Net.Core.Results;
using StackExchange.Redis;

namespace Orion.Net.Controllers
{
    [ApiController]
    public class BaseDataController<T> : Controller where T : ClientScriptResult, new()
    {
        //RedicAzureCache

        internal Lazy<ConnectionMultiplexer> lazyConnection;
        internal IDatabase cacheRedis;

        public BaseDataController()
        {
            lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
            {
                string cacheConnection = "<name>.redis.cache.windows.net,abortConnect=false,ssl=true,password=<key>";
                return ConnectionMultiplexer.Connect(cacheConnection);
            });

            cacheRedis = lazyConnection.Value.GetDatabase();
        }

        ~BaseDataController()
        {
            lazyConnection.Value.Dispose();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public T Get(Guid id)
        {
            if (cacheRedis.KeyExists(id.ToString()))
            {
                var result = cacheRedis.ExecuteAsync("GET",id.ToString());
                cacheRedis.KeyDelete(id.ToString());
                return result as T;
            }

            return new T();
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]T model)
        {
            // Save value if key doesn't exist already
            cacheRedis.ExecuteAsync("SETNX",model.ResultIdentifier.ToString(), model.ToString());
        }
    }
}
