using System.Threading;
using System.Threading.Tasks;
using InvoiceGenerator.Backend.Core.Services.LoggerService;
using InvoiceGenerator.Services.TemplateService;
using InvoiceGenerator.Services.TemplateService.Models;
using MediatR;

namespace InvoiceGenerator.Backend.Cqrs.Handlers.Commands.Templates;

public class ReplaceInvoiceTemplateCommandHandler : Cqrs.RequestHandler<ReplaceInvoiceTemplateCommand, Unit>
{
    private readonly ITemplateService _templateService;

    private readonly ILoggerService _loggerService;

    public ReplaceInvoiceTemplateCommandHandler(ITemplateService templateService, ILoggerService loggerService)
    {
        _templateService = templateService;
        _loggerService = loggerService;
    }

    public override async Task<Unit> Handle(ReplaceInvoiceTemplateCommand request, CancellationToken cancellationToken)
    {
        var newTemplate = new InvoiceTemplateData
        {
            ContentData = request.Data,
            ContentType = request.DataType,
            Description = request.Description
        };

        await _templateService.ReplaceInvoiceTemplate(request.Id, newTemplate, cancellationToken);
        _loggerService.LogInformation($"Invoice template (ID: {request.Id}) has been replaced by the provided template with description: {newTemplate.Description}");
        return Unit.Value;
    }
}