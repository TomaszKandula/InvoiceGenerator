namespace InvoiceGenerator.Backend.Cqrs.Requests
{
    using System;
    using Shared.Models;
    using MediatR;

    public class RemoveInvoiceTemplateCommandRequest : RequestProperties, IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}