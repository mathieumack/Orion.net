using Microsoft.AspNetCore.Mvc;
using Orion.Net.Core.Results;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Orion.Net.Controllers
{
    [Route("api/v1/StringResultData")]
    public class StringResultDataController : BaseDataController<StringContentResult>
    {
        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]StringContentResult model)
        {
            // Save value in cache
            if (!CacheManager.ContainsKey(model.ResultIdentifier))
                CacheManager.Add(model.ResultIdentifier, model);
        }
    }
}
