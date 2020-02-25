using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Orion.Net.Core.Results;

namespace API_Data.Controllers
{
    /// <summary>
    /// <inheritdoc/>
    /// <para>For String Result Type</para>
    /// </summary>
    [Route("api/v1/StringResultData")]
    public class StringResultDataController : BaseDataController<StringContentResult>
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="configuration"></param>
        public StringResultDataController(IConfiguration configuration) : base(configuration)
        {

        }
    }
}