namespace InvoiceGenerator.Backend.Cqrs.Handlers.Commands.Templates
{
    using Shared.Models;
    using MediatR;

    public class AddInvoiceTemplateCommand : RequestProperties, IRequest<AddInvoiceTemplateCommandResult>
    {
        public string Name { get; set; }

        public byte[] Data { get; set; }

        public string DataType { get; set; }

        public string Description { get; set; }
    }
}