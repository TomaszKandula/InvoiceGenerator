namespace InvoiceGenerator.Backend.Cqrs.Requests
{
    using MediatR;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using Responses;
    using Shared.Models;

    [ExcludeFromCodeCoverage]
    public class GetProcessingStatusesQueryRequest : RequestProperties, IRequest<IEnumerable<GetProcessingStatusesQueryResponse>>
    {
        public string FilteredBy { get; set; }        
    }
}