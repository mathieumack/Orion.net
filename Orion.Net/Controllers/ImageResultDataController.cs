using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Orion.Net.Core.Results;
using StackExchange.Redis;
using System;

namespace Orion.Net.Controllers
{
    /// <summary>
    /// <inheritdoc/>
    /// <para>For Image Result Type</para>
    /// </summary>
    [Route("api/v1/ImageResultData")]
    public class ImageResultDataController : BaseDataController<ImageContentResult>
    {
        public ImageResultDataController(IConfiguration configuration) : base(configuration)
        {
            lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
            {
                return ConnectionMultiplexer.Connect(configuration["redis"]);
            });

            cacheRedis = lazyConnection.Value.GetDatabase(asyncState: true);
        }
    }
}