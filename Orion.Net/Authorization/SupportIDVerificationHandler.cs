using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Orion.Net.Interfaces;

namespace Orion.Net.Authorization
{
    public class SupportIDVerificationHandler : AuthorizationHandler<SupportIDVerification>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly string supportID;

        public SupportIDVerificationHandler(IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
        {
            _httpContextAccessor = httpContextAccessor;
            supportID = configuration["SupportID"];
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, SupportIDVerification requirement)
        {
            HttpContext httpContext = _httpContextAccessor.HttpContext;

            var request = httpContext.Request;

            bool verification = request.Headers.ContainsKey("Authorization") ? (request.Headers["Authorization"] == supportID) : false;

            if (verification)
                context.Succeed(requirement);
          
            return Task.CompletedTask;
        }
    }
}
