namespace InvoiceGenerator.Backend.Cqrs.Handlers.Queries.Templates;

using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services.TemplateService;

public class GetInvoiceTemplateQueryHandler : RequestHandler<GetInvoiceTemplateQuery, FileContentResult>
{
    private readonly ITemplateService _templateService;

    public GetInvoiceTemplateQueryHandler(ITemplateService templateService)
    {
        _templateService = templateService;
    }

    public override async Task<FileContentResult> Handle(GetInvoiceTemplateQuery request, CancellationToken cancellationToken)
    {
        var result = await _templateService.GetInvoiceTemplate(request.Id, cancellationToken);
        return new FileContentResult(result.ContentData, result.ContentType);
    }
}