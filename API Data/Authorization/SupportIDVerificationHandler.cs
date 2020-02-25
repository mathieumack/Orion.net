using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace API_Data.Authorization
{
    public class SupportIDVerificationHandler : AuthorizationHandler<SupportIDVerification>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly string supportID;

        public SupportIDVerificationHandler(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
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
