namespace InvoiceGenerator.Backend.Cqrs.Handlers.Queries.Batches
{
    using System;
    using MediatR;
    using Shared.Models;

    public class GetBatchProcessingStatusQuery : RequestProperties, IRequest<GetBatchProcessingStatusQueryResult>
    {
        public Guid ProcessBatchKey { get; set; }        
    }
}