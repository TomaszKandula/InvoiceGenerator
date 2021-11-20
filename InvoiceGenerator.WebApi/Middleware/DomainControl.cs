namespace InvoiceGenerator.WebApi.Middleware
{
    using System.Threading;
    using System.Threading.Tasks;
    using System.Diagnostics.CodeAnalysis;
    using Microsoft.AspNetCore.Http;
    using Backend.UserService;
    using Backend.Core.Models;
    using Backend.Shared.Resources;
    using Newtonsoft.Json;

    [ExcludeFromCodeCoverage]
    public class DomainControl
    {
        private readonly RequestDelegate _requestDelegate;

        public DomainControl(RequestDelegate requestDelegate) => _requestDelegate = requestDelegate;

        /// <summary>
        /// Checks if requests from given origin can be processed.
        /// </summary>
        /// <param name="httpContext">Current HTTP context.</param>
        /// <param name="userService">Service exposing methods related to a user.</param>
        public async Task Invoke(HttpContext httpContext, IUserService userService)
        {
            var origin = httpContext.Request.Host.ToString();
            var allowDomains = await userService.IsDomainAllowed(origin, CancellationToken.None);

            if (!allowDomains)
            {
                httpContext.Response.StatusCode = 403;
                var applicationError = new ApplicationError(nameof(ErrorCodes.USER_UNAUTHORIZED), ErrorCodes.USER_UNAUTHORIZED);
                await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(applicationError));
                return;
            }

            await _requestDelegate(httpContext);
        }
    }
}