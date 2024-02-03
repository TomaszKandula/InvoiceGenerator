using System;
using MediatR;

namespace InvoiceGenerator.Backend.Cqrs.Handlers.Queries.Batches;

public class GetBatchProcessingStatusQuery : IRequest<GetBatchProcessingStatusQueryResult>
{
    public Guid ProcessBatchKey { get; set; }        
}