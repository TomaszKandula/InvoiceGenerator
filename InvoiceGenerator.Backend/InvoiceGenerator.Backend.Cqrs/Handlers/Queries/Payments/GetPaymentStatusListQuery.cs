using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using MediatR;

namespace InvoiceGenerator.Backend.Cqrs.Handlers.Queries.Payments;

[ExcludeFromCodeCoverage]
public class GetPaymentStatusListQuery : IRequest<IEnumerable<GetPaymentStatusListQueryResult>>
{
    public string FilterBy { get; set; }
}