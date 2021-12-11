namespace InvoiceGenerator.Backend.Cqrs.Handlers.Queries.Domain
{
    using MediatR;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using Shared.Models;

    [ExcludeFromCodeCoverage]
    public class GetPaymentStatusesQuery : RequestProperties, IRequest<IEnumerable<GetPaymentStatusesQueryResult>>
    {
        public string FilterBy { get; set; }
    }
}