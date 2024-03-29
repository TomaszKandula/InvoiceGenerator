using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using InvoiceGenerator.Backend.Database;
using InvoiceGenerator.Backend.Core.Services.LoggerService;

namespace InvoiceGenerator.Services.UserService;

public class UserService : IUserService
{
    private readonly DatabaseContext _databaseContext;

    private readonly ILoggerService _loggerService;

    private readonly IHttpContextAccessor _httpContextAccessor;

    public UserService(DatabaseContext databaseContext, ILoggerService loggerService, IHttpContextAccessor httpContextAccessor)
    {
        _databaseContext = databaseContext;
        _loggerService = loggerService;
        _httpContextAccessor = httpContextAccessor;
    }

    /// <summary>
    /// Returns private key presented in the request header or empty string.
    /// </summary>
    /// <returns>String value.</returns>
    public string GetPrivateKeyFromHeader(string headerName = "X-Private-Key")
    {
        return _httpContextAccessor.HttpContext?.Request.Headers[headerName].ToString();
    }

    /// <summary>
    /// Checks if given domain name is registered within the system. It should not contain scheme,
    /// but it may contain port number.
    /// </summary>
    /// <param name="domainName">Domain name without scheme, but it may have port.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>True or False.</returns>
    public async Task<bool> IsDomainAllowed(string domainName, CancellationToken cancellationToken = default)
    {
        var domains = await _databaseContext.AllowDomains
            .AsNoTracking()
            .Where(allowDomain => allowDomain.Host == domainName)
            .ToListAsync(cancellationToken);
            
        var isDomainAllowed = domains.Any();
        if (!isDomainAllowed) 
            _loggerService.LogWarning($"Domain '{domainName}' is not registered within the system.");
            
        return isDomainAllowed;
    }

    /// <summary>
    /// Checks if given private key is registered within the system.
    /// </summary>
    /// <param name="privateKey"></param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>True or False.</returns>
    public async Task<bool> IsPrivateKeyValid(string privateKey, CancellationToken cancellationToken = default)
    {
        var keys = await _databaseContext.Users
            .AsNoTracking()
            .Where(user => user.PrivateKey == privateKey)
            .ToListAsync(cancellationToken);
            
        var isPrivateKeyExists = keys.Any();
        if (!isPrivateKeyExists)
            _loggerService.LogWarning($"Key '{privateKey}' is not registered within the system.");
            
        return isPrivateKeyExists;
    }

    /// <summary>
    /// Returns user ID registered for given private key within the system.
    /// </summary>
    /// <param name="privateKey">Private key (alphanumerical).</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>User ID (Guid).</returns>
    public async Task<Guid> GetUserByPrivateKey(string privateKey, CancellationToken cancellationToken = default)
    {
        return await _databaseContext.Users
            .AsNoTracking()
            .Where(user => user.PrivateKey == privateKey)
            .Select(user => user.Id)
            .FirstOrDefaultAsync(cancellationToken);
    }
}