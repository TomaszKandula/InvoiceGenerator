namespace InvoiceGenerator.Backend.Cqrs.Requests
{
    using MediatR;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using Responses;
    using Shared.Models;

    [ExcludeFromCodeCoverage]
    public class GetPaymentStatusesQueryRequest : RequestProperties, IRequest<IEnumerable<GetPaymentStatusesQueryResponse>>
    {
        public string FilteredBy { get; set; }
    }
}