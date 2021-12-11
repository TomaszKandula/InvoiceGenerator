namespace InvoiceGenerator.Backend.Cqrs.Handlers.Queries.Templates
{
    using System.Collections.Generic;
    using TemplateService.Models;
    using Shared.Models;
    using MediatR;

    public class GetInvoiceTemplatesQueryRequest : RequestProperties, IRequest<IEnumerable<InvoiceTemplateInfo>>
    {
    }
}