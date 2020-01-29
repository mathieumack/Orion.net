using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
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

            cacheRedis = lazyConnection.Value.GetDatabase(asyncState:true);
        }

        ~BaseDataController()
        {
            lazyConnection.Value.Dispose();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(Guid id)
        {
            //cacheRedis = lazyConnection.Value.GetDatabase(asyncState: true);

            if (cacheRedis.KeyExists(id.ToString()))
            {
                var result = cacheRedis.StringGet(id.ToString());
                cacheRedis.KeyDelete(id.ToString());
                //new StringContent(result, Encoding.UTF8, "application/json");
                return result.ToString();
            }

            return "{\"ConsoleContent\" : \"Error from Api Get\"}";
        }
    }
}
