using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace InvoiceGenerator.Backend.Cqrs;

[ExcludeFromCodeCoverage]
public abstract class RequestHandler<TRequest, TResult> : IRequestHandler<TRequest, TResult> where TRequest : IRequest<TResult>
{
    public abstract Task<TResult> Handle(TRequest request, CancellationToken cancellationToken);
}