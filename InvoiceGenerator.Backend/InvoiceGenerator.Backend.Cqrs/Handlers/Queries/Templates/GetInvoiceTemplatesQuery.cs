namespace InvoiceGenerator.Backend.Cqrs.Handlers.Queries.Templates
{
    using System.Collections.Generic;
    using TemplateService.Models;
    using Shared.Models;
    using MediatR;

    public class GetInvoiceTemplatesQuery : RequestProperties, IRequest<IEnumerable<InvoiceTemplateInfo>>
    {
    }
}