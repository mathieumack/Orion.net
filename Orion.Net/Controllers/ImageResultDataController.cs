using Microsoft.AspNetCore.Mvc;
using Orion.Net.Core.Results;
using Orion.Net.Interface;

namespace Orion.Net.Controllers
{
    /// <summary>
    /// <inheritdoc/>
    /// <para>For Image Result Type</para>
    /// </summary>
    [Route("api/v1/ImageResultData")]
    public class ImageResultDataController : BaseDataController<ImageContentResult>
    {
        /// <summary>
        /// Constructor from <see cref="BaseDataController{T}"/> to initiate <see cref="CacheData"/>
        /// </summary>
        /// <param name="cache"><see cref="ICacheManagement"/> for <see cref="CacheData"/></param>
        public ImageResultDataController(ICacheManagement cache) : base(cache)
        {

        }
    }
}
