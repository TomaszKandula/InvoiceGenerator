namespace InvoiceGenerator.Backend.Cqrs.Handlers.Queries.Batches;

using MediatR;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Shared.Models;

[ExcludeFromCodeCoverage]
public class GetBatchProcessingStatusListQuery : RequestProperties, IRequest<IEnumerable<GetBatchProcessingStatusListQueryResult>>
{
    public string FilterBy { get; set; }        
}