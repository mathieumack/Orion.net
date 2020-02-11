using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Orion.Net.Core.Results;
using StackExchange.Redis;
using System;

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
        public StringResultDataController(IConfiguration configuration) : base(configuration)
        {
            lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
            {
                return ConnectionMultiplexer.Connect(configuration["profiles:Orion.Net:environmentVariables:redis"]);
            });

            cacheRedis = lazyConnection.Value.GetDatabase(asyncState: true);
        }
    }
}
