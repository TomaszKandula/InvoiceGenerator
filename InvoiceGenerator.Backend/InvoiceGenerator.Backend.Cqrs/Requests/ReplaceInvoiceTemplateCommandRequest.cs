namespace InvoiceGenerator.Backend.Cqrs.Requests
{
    using System;
    using Shared.Models;
    using MediatR;

    public class ReplaceInvoiceTemplateCommandRequest : RequestProperties, IRequest<Unit>
    {
        public Guid Id { get; set; }

        public byte[] Data { get; set; }

        public string DataType { get; set; }
    }
}