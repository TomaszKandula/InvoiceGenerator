namespace InvoiceGenerator.Backend.Cqrs.Handlers.Queries.Payments
{
    using MediatR;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using Shared.Models;

    [ExcludeFromCodeCoverage]
    public class GetPaymentTypesQuery : RequestProperties, IRequest<IEnumerable<GetPaymentTypesQueryResult>>
    {
        public string FilterBy { get; set; }
    }
}