namespace InvoiceGenerator.Backend.Cqrs.Handlers.Queries.Batch
{
    using System;
    using MediatR;
    using Shared.Models;

    public class GetBatchProcessingQuery : RequestProperties, IRequest<GetBatchProcessingQueryResult>
    {
        public Guid ProcessBatchKey { get; set; }        
    }
}