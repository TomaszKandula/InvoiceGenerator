namespace InvoiceGenerator.Backend.Cqrs.Handlers.Queries.Batch
{
    using MediatR;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using Shared.Models;

    [ExcludeFromCodeCoverage]
    public class GetProcessingStatusesQueryRequest : RequestProperties, IRequest<IEnumerable<GetProcessingStatusesQueryResponse>>
    {
        public string FilterBy { get; set; }        
    }
}