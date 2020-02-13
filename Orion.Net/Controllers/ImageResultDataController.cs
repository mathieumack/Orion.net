using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Orion.Net.Core.Results;

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
        /// <inheritdoc/>
        /// </summary>
        /// <param name="configuration"></param>
        public ImageResultDataController(IConfiguration configuration) : base(configuration)
        {
        }
    }
}