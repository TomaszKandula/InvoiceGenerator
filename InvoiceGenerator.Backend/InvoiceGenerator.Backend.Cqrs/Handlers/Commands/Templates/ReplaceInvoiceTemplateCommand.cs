namespace InvoiceGenerator.Backend.Cqrs.Handlers.Commands.Templates
{
    using System;
    using Shared.Models;
    using MediatR;

    public class ReplaceInvoiceTemplateCommand : RequestProperties, IRequest<Unit>
    {
        public Guid Id { get; set; }

        public byte[] Data { get; set; }

        public string DataType { get; set; }

        public string Description { get; set; }
    }
}