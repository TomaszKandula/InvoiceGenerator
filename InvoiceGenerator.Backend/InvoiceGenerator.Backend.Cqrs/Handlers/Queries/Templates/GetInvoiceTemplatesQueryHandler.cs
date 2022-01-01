namespace InvoiceGenerator.Backend.Cqrs.Handlers.Queries.Templates;

using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Services.TemplateService;
using Services.TemplateService.Models;

public class GetInvoiceTemplatesQueryHandler : RequestHandler<GetInvoiceTemplatesQuery, IEnumerable<InvoiceTemplateInfo>>
{
    private readonly ITemplateService _templateService;

    public GetInvoiceTemplatesQueryHandler(ITemplateService templateService)
    {
        _templateService = templateService;
    }
        
    public override async Task<IEnumerable<InvoiceTemplateInfo>> Handle(GetInvoiceTemplatesQuery request, CancellationToken cancellationToken)
    {
        return await _templateService.GetInvoiceTemplates(cancellationToken);
    }
}