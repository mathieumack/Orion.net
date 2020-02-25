using System;
using Microsoft.AspNetCore.Mvc;
using Orion.Net.Core.Results;
using Orion.Net.Interface;

namespace Orion.Net.Controllers
{
    /// <summary>
    /// <inheritdoc/>
    /// <para>To check SupportID</para>
    /// </summary>
    [Route("api/v1/Authorize")]
    public class AuthorizeController : BaseDataController<StringContentResult>
    {
        /// <summary>
        /// Constructor from <see cref="BaseDataController{T}"/> to initiate <see cref="CacheData"/>
        /// </summary>
        /// <param name="cache"><see cref="ICacheManagement"/> for <see cref="CacheData"/></param>
        public AuthorizeController(ICacheManagement cache) : base(cache)
        {

        }

        //GET api/v1/Authorize/{id}
        [HttpGet("{id}")]
        public new string Get(Guid id)
        {
            return CacheData.GetSupportId(id.ToString());
        }

        //POST api/v1/Authorize
        [HttpPost]
        public void Post(string supportId)
        {
            CacheData.SetSupportId(supportId);
        }
    }
}