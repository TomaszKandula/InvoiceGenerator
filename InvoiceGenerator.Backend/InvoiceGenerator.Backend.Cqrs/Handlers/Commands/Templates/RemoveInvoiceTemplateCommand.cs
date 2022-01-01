namespace InvoiceGenerator.Backend.Cqrs.Handlers.Commands.Templates;

using System;
using MediatR;

public class RemoveInvoiceTemplateCommand : IRequest<Unit>
{
    public Guid Id { get; set; }
}