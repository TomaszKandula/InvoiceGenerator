namespace InvoiceGenerator.Backend.Cqrs.Requests
{
    using System;
    using MediatR;
    using Responses;
    using Shared.Models;

    public class GetBatchProcessingStatusQueryRequest : RequestProperties, IRequest<GetBatchProcessingStatusQueryResponse>
    {
        public Guid ProcessBatchKey { get; set; }        
    }
}