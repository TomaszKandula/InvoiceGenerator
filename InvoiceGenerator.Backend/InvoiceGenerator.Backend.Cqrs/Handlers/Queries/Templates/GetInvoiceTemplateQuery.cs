using System;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceGenerator.Backend.Cqrs.Handlers.Queries.Templates;

public class GetInvoiceTemplateQuery : IRequest<FileContentResult>
{
    public Guid Id { get; set; }        
}