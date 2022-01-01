namespace InvoiceGenerator.Backend.Cqrs.Handlers.Queries.Payments;

using MediatR;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

[ExcludeFromCodeCoverage]
public class GetPaymentStatusListQuery : IRequest<IEnumerable<GetPaymentStatusListQueryResult>>
{
    public string FilterBy { get; set; }
}