namespace InvoiceGenerator.Backend.Cqrs.Handlers.Queries.Domain
{
    using MediatR;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using Shared.Models;

    [ExcludeFromCodeCoverage]
    public class GetPaymentTypesQueryRequest : RequestProperties, IRequest<IEnumerable<GetPaymentTypesQueryResponse>>
    {
        public string FilterBy { get; set; }
    }
}