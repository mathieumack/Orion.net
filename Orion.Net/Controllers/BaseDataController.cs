﻿using System;
using System.Collections.Generic;
using System.Configuration;
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
                string cacheConnection = ConfigurationManager.AppSettings["RedisConnection"].ToString();
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
