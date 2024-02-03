using System.Threading;
using System.Threading.Tasks;
using InvoiceGenerator.Backend.Core.Services.LoggerService;
using InvoiceGenerator.Services.TemplateService;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceGenerator.Backend.Cqrs.Handlers.Queries.Templates;

public class GetInvoiceTemplateQueryHandler : RequestHandler<GetInvoiceTemplateQuery, FileContentResult>
{
    private readonly ITemplateService _templateService;

    private readonly ILoggerService _loggerService;

    public GetInvoiceTemplateQueryHandler(ITemplateService templateService, ILoggerService loggerService)
    {
        _templateService = templateService;
        _loggerService = loggerService;
    }

    public override async Task<FileContentResult> Handle(GetInvoiceTemplateQuery request, CancellationToken cancellationToken)
    {
        var result = await _templateService.GetInvoiceTemplate(request.Id, cancellationToken);
        _loggerService.LogInformation($"Returned invoice template. Description: {result.Description}");
        return new FileContentResult(result.ContentData, result.ContentType);
    }
}