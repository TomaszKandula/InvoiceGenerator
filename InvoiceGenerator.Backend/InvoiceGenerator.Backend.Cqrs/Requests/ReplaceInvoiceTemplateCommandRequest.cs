namespace InvoiceGenerator.Backend.Cqrs.Requests
{
    using System;
    using Shared.Models;
    using MediatR;

    public class ReplaceInvoiceTemplateCommandRequest : RequestProperties, IRequest<Unit>
    {
        public Guid TemplateId { get; set; }

        public byte[] TemplateData { get; set; }

        public string TemplateDataType { get; set; }
    }
}