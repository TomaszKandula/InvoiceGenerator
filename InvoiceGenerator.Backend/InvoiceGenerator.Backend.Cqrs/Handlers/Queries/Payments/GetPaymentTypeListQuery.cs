using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using MediatR;

namespace InvoiceGenerator.Backend.Cqrs.Handlers.Queries.Payments;

[ExcludeFromCodeCoverage]
public class GetPaymentTypeListQuery : IRequest<IEnumerable<GetPaymentTypeListQueryResult>>
{
    public string FilterBy { get; set; }
}