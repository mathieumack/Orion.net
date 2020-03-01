using Microsoft.AspNetCore.Mvc;
using Orion.Net.Core.Results;
using Orion.Net.Interface;

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
        /// <summary>
        /// Constructor from <see cref="BaseDataController{T}"/> to initiate <see cref="CacheData"/>
        /// </summary>
        /// <param name="cache"><see cref="ICacheManagement"/> for <see cref="CacheData"/></param>
        public StringResultDataController(ICacheManagement cache) : base(cache)
        {

        }

    }
}
