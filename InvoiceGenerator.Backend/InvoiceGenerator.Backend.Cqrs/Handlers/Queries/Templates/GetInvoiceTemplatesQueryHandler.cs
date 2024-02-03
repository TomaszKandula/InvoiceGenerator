using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using InvoiceGenerator.Backend.Core.Services.LoggerService;
using InvoiceGenerator.Services.TemplateService;
using InvoiceGenerator.Services.TemplateService.Models;

namespace InvoiceGenerator.Backend.Cqrs.Handlers.Queries.Templates;

public class GetInvoiceTemplatesQueryHandler : RequestHandler<GetInvoiceTemplatesQuery, IEnumerable<InvoiceTemplateInfo>>
{
    private readonly ITemplateService _templateService;

    private readonly ILoggerService _loggerService;

    public GetInvoiceTemplatesQueryHandler(ITemplateService templateService, ILoggerService loggerService)
    {
        _templateService = templateService;
        _loggerService = loggerService;
    }
        
    public override async Task<IEnumerable<InvoiceTemplateInfo>> Handle(GetInvoiceTemplatesQuery request, CancellationToken cancellationToken)
    {
        var result = (await _templateService.GetInvoiceTemplates(cancellationToken)).ToList();
        _loggerService.LogInformation($"Returned {result.Count} invoice template(s)");
        return result;
    }
}