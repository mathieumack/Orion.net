using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Orion.Net.Core.Results;
using Orion.Net.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Orion.Net.Controllers
{
    /// <summary>
    /// <inheritdoc/>
    /// <para>For String Result Type</para>
    /// </summary>
    [Route("api/v1/StringResultData")]
    public class StringResultDataController : BaseDataController<StringContentResult>, IStringResultDataController
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="configuration"></param>
        public StringResultDataController(IConfiguration configuration) : base(configuration)
        {

        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        // GET api/v1/StringResultData
        [HttpGet()]
        public string Get()
        {
            if (cacheRedis.KeyExists("supportId" + User.Identity.Name))
            {
                var result = cacheRedis.StringGet("supportId" + User.Identity.Name);
                return result.ToString();
            }
            else
            {
                string guid = Guid.NewGuid().ToString();
                cacheRedis.StringSet("supportId" + User.Identity.Name, guid, TimeSpan.FromDays(1));
                return guid;
            }
        }
    }
}
