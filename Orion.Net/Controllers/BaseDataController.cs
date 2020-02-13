using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Orion.Net.Core.Interfaces;
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
        // Temporary cache management for tests only.
        // TODO : replace with a  distributed cache management system
        public static Dictionary<Guid, object> CacheManager = new Dictionary<Guid, object>();

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public T Get(Guid id)
        {
            if (CacheManager.ContainsKey(id))
            {
                var result = CacheManager[id];
                CacheManager.Remove(id);
                return result as T;
            }

            return new T();
        }

        [AllowAnonymous]
        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]T model)
        {
            // Save value in cache
            if (!CacheManager.ContainsKey(model.ResultIdentifier))
                CacheManager.Add(model.ResultIdentifier, model);
        }
    }
}
