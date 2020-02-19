using System;
using Microsoft.AspNetCore.Mvc;
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
        // GET api/v1/StringResultData
        [HttpGet()]
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns>Guid SupportId in String</returns>
        public string Get()
        {
            if (cacheRedis.KeyExists("supportId" + User.Identity.Name))
            {
                var result = cacheRedis.StringGet("supportId" + User.Identity.Name);
                SupportID = result;
                return result.ToString();
            }
            else
            {
                string guid = Guid.NewGuid().ToString();
                SupportID = guid;
               SupportID = SupportID;
                cacheRedis.StringSet("supportId" + User.Identity.Name, guid, TimeSpan.FromDays(1));
                return guid;
            }
        }
    }
}
