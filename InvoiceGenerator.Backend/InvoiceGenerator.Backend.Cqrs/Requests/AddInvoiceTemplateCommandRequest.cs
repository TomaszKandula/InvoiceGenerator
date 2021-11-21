namespace InvoiceGenerator.Backend.Cqrs.Requests
{
    using Responses;
    using Shared.Models;
    using MediatR;

    public class AddInvoiceTemplateCommandRequest : RequestProperties, IRequest<AddInvoiceTemplateCommandResponse>
    {
        public string TemplateName { get; set; }

        public byte[] TemplateData { get; set; }

        public string TemplateDataType { get; set; }

        public string TemplateDescription { get; set; }
    }
}