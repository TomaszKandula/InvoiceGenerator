namespace InvoiceGenerator.Backend.Cqrs.Requests
{
    using System.Collections.Generic;
    using InvoiceService.Models;
    using Shared.Models;
    using MediatR;

    public class GetInvoiceTemplatesQueryRequest : RequestProperties, IRequest<IEnumerable<InvoiceTemplateInfo>>
    {
    }
}