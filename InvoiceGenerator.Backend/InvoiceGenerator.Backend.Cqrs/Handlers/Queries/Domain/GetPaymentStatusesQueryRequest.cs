namespace InvoiceGenerator.Backend.Cqrs.Handlers.Queries.Domain
{
    using MediatR;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using Shared.Models;

    [ExcludeFromCodeCoverage]
    public class GetPaymentStatusesQueryRequest : RequestProperties, IRequest<IEnumerable<GetPaymentStatusesQueryResponse>>
    {
        public string FilterBy { get; set; }
    }
}