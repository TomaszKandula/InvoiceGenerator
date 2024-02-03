using System;

namespace InvoiceGenerator.Backend.Cqrs.Handlers.Commands.Templates;

public class AddInvoiceTemplateCommandResult
{
    public Guid TemplateId { get; set; }
}