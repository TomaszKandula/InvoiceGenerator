namespace InvoiceGenerator.Backend.Cqrs.Handlers.Queries.Batches;

using System;
using MediatR;

public class GetBatchProcessingStatusQuery : IRequest<GetBatchProcessingStatusQueryResult>
{
    public Guid ProcessBatchKey { get; set; }        
}