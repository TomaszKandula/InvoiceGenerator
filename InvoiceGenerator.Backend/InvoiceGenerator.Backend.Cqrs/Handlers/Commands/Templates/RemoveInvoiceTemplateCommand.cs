using System;
using MediatR;

namespace InvoiceGenerator.Backend.Cqrs.Handlers.Commands.Templates;

public class RemoveInvoiceTemplateCommand : IRequest<Unit>
{
    public Guid Id { get; set; }
}