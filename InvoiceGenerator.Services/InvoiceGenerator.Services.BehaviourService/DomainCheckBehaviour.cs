using Microsoft.AspNetCore.Http;
using System.Diagnostics.CodeAnalysis;
using InvoiceGenerator.Backend.Shared.Resources;
using InvoiceGenerator.Backend.Core.Services.LoggerService;
using InvoiceGenerator.Services.UserService;
using MediatR;

namespace InvoiceGenerator.Services.BehaviourService;

[ExcludeFromCodeCoverage]
public class DomainCheckBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly ILoggerService _logger;

    private readonly IUserService _userService;
    
    private readonly IHttpContextAccessor _httpContextAccessor;

    public DomainCheckBehaviour(ILoggerService logger, IUserService userService, IHttpContextAccessor httpContextAccessor)
    {
        _logger = logger;
        _userService = userService;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
    {
        var origin = _httpContextAccessor.HttpContext?.Request.Host.ToString();
        var isDomainAllowed = await _userService.IsDomainAllowed(origin, CancellationToken.None);

        if (isDomainAllowed) 
            return await next();

        _logger.LogWarning($"Access forbidden for: {origin}");
        throw new Backend.Core.Exceptions.AccessException(nameof(ErrorCodes.ACCESS_FORBIDDEN), ErrorCodes.ACCESS_FORBIDDEN);
    }
}