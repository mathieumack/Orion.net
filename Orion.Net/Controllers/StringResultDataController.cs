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
            string result = cacheRedis.KeyExists("supportId" + User.Identity.Name) ? cacheRedis.StringGet("supportId" + User.Identity.Name).ToString() : Guid.NewGuid().ToString();

            //Save supportID in cache and app
            cacheRedis.StringSet("supportId" + User.Identity.Name, result, TimeSpan.FromDays(1));
            configuration["SupportID"] = result;

            return result;
        }
    }
}
