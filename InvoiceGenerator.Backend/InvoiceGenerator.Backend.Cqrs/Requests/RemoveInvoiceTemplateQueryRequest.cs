namespace InvoiceGenerator.Backend.Cqrs.Requests
{
    using System;
    using Shared.Models;
    using MediatR;

    public class RemoveInvoiceTemplateQueryRequest : RequestProperties, IRequest<Unit>
    {
        public Guid TemplateId { get; set; }
    }
}