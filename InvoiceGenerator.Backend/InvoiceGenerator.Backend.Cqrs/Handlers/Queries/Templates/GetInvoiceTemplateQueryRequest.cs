namespace InvoiceGenerator.Backend.Cqrs.Handlers.Queries.Templates
{
    using System;
    using Microsoft.AspNetCore.Mvc;
    using Shared.Models;
    using MediatR;

    public class GetInvoiceTemplateQueryRequest : RequestProperties, IRequest<FileContentResult>
    {
        public Guid Id { get; set; }        
    }
}