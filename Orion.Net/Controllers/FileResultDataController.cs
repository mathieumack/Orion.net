using Microsoft.AspNetCore.Mvc;
using Orion.Net.Interface;
using FileContentResult = Orion.Net.Core.Results.FileContentResult;

namespace Orion.Net.Controllers
{
    /// <summary>
    /// <inheritdoc/>
    /// <para>For File Result Type</para>
    /// </summary>
    [Route("api/v1/FileResultData")]
    public class FileResultDataController : BaseDataController<FileContentResult>
    {
        public FileResultDataController(ICacheManagement cache) : base(cache)
        {

        }
    }
}
