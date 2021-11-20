namespace InvoiceGenerator.Backend.Cqrs.Requests
{
    using System;
    using MediatR;
    using Responses;
    using Shared.Models;

    public class GetBatchProcessingQueryRequest : RequestProperties, IRequest<GetBatchProcessingQueryResponse>
    {
        public Guid ProcessBatchKey { get; set; }        
    }
}