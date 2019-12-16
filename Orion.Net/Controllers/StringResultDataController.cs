using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Orion.Net.Core.Results;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Orion.Net.Controllers
{
    [Route("api/[controller]")]
    public class StringResultDataController : Controller
    {
        // Temporary cache management for tests only.
        // TODO : replace with a  distributed cache management system
        public static Dictionary<Guid, string> CacheManager { get; set; }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(Guid id)
        {
            if (CacheManager.ContainsKey(id))
            {
                var result = CacheManager[id];
                CacheManager.Remove(id);
                return result;
            }

            return string.Empty;
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]StringContentResult model)
        {
            // Save value in cache
            if(!CacheManager.ContainsKey(model.ResultIdentifier))
                CacheManager.Add(model.ResultIdentifier, model.ConsoleContent);
        }
    }
}
