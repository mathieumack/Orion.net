using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Orion.Net.CacheManagement;
using Orion.Net.Core.Interfaces;
using Orion.Net.Interface;

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
        /// Cache Management of the API
        /// <list type="table">
        /// <item><see cref="LocalCache"/> is for a internal cache memory</item>
        /// <item><see cref="RedisCache"/> is for external cache memory with Redis</item>
        /// </list>
        /// </summary>
        /// <remarks>Change <see cref="LocalCache"/> to <see cref="RedisCache"/> and vice versa depending you need</remarks>
        protected ICacheManagement CacheData = new LocalCache();

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(Guid id)
        {
            return CacheData.GetValue(id);
        }

        [AllowAnonymous]
        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]T model)
        {
            CacheData.SetValue(model.ResultIdentifier, JsonConvert.SerializeObject(model));
        }
    }
}