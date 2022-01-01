namespace InvoiceGenerator.Backend.Cqrs.Handlers.Queries.Payments;

using MediatR;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

[ExcludeFromCodeCoverage]
public class GetPaymentTypeListQuery : IRequest<IEnumerable<GetPaymentTypeListQueryResult>>
{
    public string FilterBy { get; set; }
}