using System;
using System.Threading;
using System.Threading.Tasks;

namespace InvoiceGenerator.Services.UserService;

public interface IUserService
{
    string GetPrivateKeyFromHeader(string headerName = "X-Private-Key");

    Task<bool> IsDomainAllowed(string domainName, CancellationToken cancellationToken = default);

    Task<bool> IsPrivateKeyValid(string privateKey, CancellationToken cancellationToken = default);

    Task<Guid> GetUserByPrivateKey(string privateKey, CancellationToken cancellationToken = default);
}