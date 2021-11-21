namespace InvoiceGenerator.Backend.Cqrs.Requests
{
    using System.Collections.Generic;
    using TemplateService.Models;
    using Shared.Models;
    using MediatR;

    public class GetInvoiceTemplatesQueryRequest : RequestProperties, IRequest<IEnumerable<InvoiceTemplateInfo>>
    {
    }
}