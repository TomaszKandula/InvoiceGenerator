namespace InvoiceGenerator.Backend.Cqrs.Handlers.Queries.Batches;

using MediatR;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

[ExcludeFromCodeCoverage]
public class GetBatchProcessingStatusListQuery : IRequest<IEnumerable<GetBatchProcessingStatusListQueryResult>>
{
    public string FilterBy { get; set; }        
}