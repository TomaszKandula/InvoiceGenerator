namespace InvoiceGenerator.Backend.Cqrs.Handlers.Commands.Templates;

using System;
using MediatR;

public class ReplaceInvoiceTemplateCommand : IRequest<Unit>
{
    public Guid Id { get; set; }

    public byte[] Data { get; set; }

    public string DataType { get; set; }

    public string Description { get; set; }
}