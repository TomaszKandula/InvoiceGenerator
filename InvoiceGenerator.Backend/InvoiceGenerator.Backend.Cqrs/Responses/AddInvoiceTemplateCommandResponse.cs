namespace InvoiceGenerator.Backend.Cqrs.Responses
{
    using System;

    public class AddInvoiceTemplateCommandResponse
    {
        public Guid TemplateId { get; set; }
    }
}