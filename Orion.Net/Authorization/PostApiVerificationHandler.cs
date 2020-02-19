using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Orion.Net.Interfaces;

namespace Orion.Net.Authorization
{
    public class PostApiVerificationHandler : AuthorizationHandler<PostApiVerification>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly IStringResultDataController _controller;

        public PostApiVerificationHandler(IHttpContextAccessor httpContextAccessor, IStringResultDataController controller)
        {
            _httpContextAccessor = httpContextAccessor;
            _controller = controller;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, PostApiVerification requirement)
        {
            var supportID = _controller.Get();
            HttpContext httpContext = _httpContextAccessor.HttpContext;

            var request = httpContext.Request;

            bool verification = request.Headers.ContainsKey("Authorization") ? (request.Headers["Authorization"] == supportID) : false;

            if (verification)
                context.Succeed(requirement);
          
            return Task.CompletedTask;
        }
    }
}
