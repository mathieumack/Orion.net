using Microsoft.AspNetCore.Mvc;
using FileContentResult = Orion.Net.Core.Results.FileContentResult;

namespace Orion.Net.Controllers
{
    [Route("api/v1/FileResultData")]
    public class FileResultDataController : BaseDataController<FileContentResult>
    {
    }
}