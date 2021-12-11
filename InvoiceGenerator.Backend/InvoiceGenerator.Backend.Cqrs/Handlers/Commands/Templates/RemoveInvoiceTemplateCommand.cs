namespace InvoiceGenerator.Backend.Cqrs.Handlers.Commands.Templates
{
    using System;
    using Shared.Models;
    using MediatR;

    public class RemoveInvoiceTemplateCommand : RequestProperties, IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}