namespace InvoiceGenerator.Backend.UserService
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IUserService
    {
        Task<bool> IsDomainAllowed(string domainName, CancellationToken cancellationToken = default);

        Task<bool> IsPrivateKeyValid(string privateKey, CancellationToken cancellationToken = default);

        Task<Guid> GetUserByPrivateKey(string privateKey, CancellationToken cancellationToken = default);
    }
}