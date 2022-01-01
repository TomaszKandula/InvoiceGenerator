namespace InvoiceGenerator.Backend.Cqrs.Handlers.Queries.Templates;

using System;
using Microsoft.AspNetCore.Mvc;
using MediatR;

public class GetInvoiceTemplateQuery : IRequest<FileContentResult>
{
    public Guid Id { get; set; }        
}