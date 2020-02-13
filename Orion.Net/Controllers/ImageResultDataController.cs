using Microsoft.AspNetCore.Mvc;
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
    }
}
