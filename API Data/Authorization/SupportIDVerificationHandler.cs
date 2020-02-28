using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace API_Data.Authorization
{
    public class SupportIDVerificationHandler : AuthorizationHandler<SupportIDVerification>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly IConfiguration _configuration;

        public SupportIDVerificationHandler(IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, SupportIDVerification requirement)
        {
            HttpContext httpContext = _httpContextAccessor.HttpContext;

            var request = httpContext.Request;

            if (CheckKeyValue(request))
            {
                var key = request.Headers["Key"];
                var value = request.Headers["Value"];

                if (_configuration[key] == value)
                    context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }

        private bool CheckKeyValue(HttpRequest request)
        {
            var keyExist = request.Headers.ContainsKey("Key");
            var valueExist = request.Headers.ContainsKey("Value");
            return (keyExist && valueExist);
        }
    }
}
