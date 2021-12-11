namespace InvoiceGenerator.Backend.Cqrs.Handlers.Queries.Batch
{
    using MediatR;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using Shared.Models;

    [ExcludeFromCodeCoverage]
    public class GetProcessingStatusesQuery : RequestProperties, IRequest<IEnumerable<GetProcessingStatusesQueryResult>>
    {
        public string FilterBy { get; set; }        
    }
}