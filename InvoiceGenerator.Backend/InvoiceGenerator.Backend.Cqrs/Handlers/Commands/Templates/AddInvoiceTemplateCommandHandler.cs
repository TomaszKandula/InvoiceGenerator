using System.Threading;
using System.Threading.Tasks;
using InvoiceGenerator.Backend.Core.Services.LoggerService;
using InvoiceGenerator.Services.TemplateService;
using InvoiceGenerator.Services.TemplateService.Models;

namespace InvoiceGenerator.Backend.Cqrs.Handlers.Commands.Templates;

public class AddInvoiceTemplateCommandHandler : RequestHandler<AddInvoiceTemplateCommand, AddInvoiceTemplateCommandResult>
{
    private readonly ITemplateService _templateService;

    private readonly ILoggerService _loggerService;

    public AddInvoiceTemplateCommandHandler(ITemplateService templateService, ILoggerService loggerService)
    {
        _templateService = templateService;
        _loggerService = loggerService;
    }

    public override async Task<AddInvoiceTemplateCommandResult> Handle(AddInvoiceTemplateCommand request, CancellationToken cancellationToken)
    {
        var newInvoiceTemplate = new InvoiceTemplate
        {
            TemplateName = request.Name,
            InvoiceTemplateData = new InvoiceTemplateData
            {
                ContentData = request.Data,
                ContentType = request.DataType
            },
            InvoiceTemplateDescription = request.Description
        };

        var result = await _templateService.AddInvoiceTemplate(newInvoiceTemplate, cancellationToken);
        _loggerService.LogInformation($"New invoice template has been added. Invoice template name: {request.Name}");

        return new AddInvoiceTemplateCommandResult { TemplateId = result };
    }
}