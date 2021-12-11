namespace InvoiceGenerator.Backend.Cqrs.Handlers.Queries.Batch
{
    using System;
    using MediatR;
    using Shared.Models;

    public class GetBatchProcessingQueryRequest : RequestProperties, IRequest<GetBatchProcessingQueryResponse>
    {
        public Guid ProcessBatchKey { get; set; }        
    }
}