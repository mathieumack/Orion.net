using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Orion.Net.Core.Results;
using Orion.Net.Interface;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Orion.Net.Controllers
{
    /// <summary>
    /// <inheritdoc/>
    /// <para>For String Result Type</para>
    /// </summary>
    [Route("api/v1/StringResultData")]
    public class StringResultDataController : BaseDataController<StringContentResult>
    {
        public StringResultDataController(ILocalCache cache) : base(cache)
        {
            CacheData = cache;
        }

        // GET api/v1/StringResultData
        [HttpGet()]
        /// <summary>
        /// Return SupportId of the user
        /// </summary>
        /// <returns>Guid SupportId in String</returns>
        /// <remarks>If the key doesn't exist, save and return a new one</remarks>
        public string Get()
        {
            return CacheData.GetSupportId("supportId" + User.Identity.Name);
        }
    }
}
