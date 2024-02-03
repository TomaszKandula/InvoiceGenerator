using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using MediatR;

namespace InvoiceGenerator.Backend.Cqrs.Handlers.Queries.Batches;

[ExcludeFromCodeCoverage]
public class GetBatchProcessingStatusListQuery : IRequest<IEnumerable<GetBatchProcessingStatusListQueryResult>>
{
    public string FilterBy { get; set; }        
}