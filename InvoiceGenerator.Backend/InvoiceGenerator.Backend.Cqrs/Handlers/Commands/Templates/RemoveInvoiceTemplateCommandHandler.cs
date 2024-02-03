using System.Threading;
using System.Threading.Tasks;
using InvoiceGenerator.Backend.Core.Services.LoggerService;
using InvoiceGenerator.Services.TemplateService;
using MediatR;

namespace InvoiceGenerator.Backend.Cqrs.Handlers.Commands.Templates;

public class RemoveInvoiceTemplateCommandHandler : Cqrs.RequestHandler<RemoveInvoiceTemplateCommand, Unit>
{
    private readonly ITemplateService _templateService;

    private readonly ILoggerService _loggerService;

    public RemoveInvoiceTemplateCommandHandler(ITemplateService templateService, ILoggerService loggerService)
    {
        _templateService = templateService;
        _loggerService = loggerService;
    }

    public override async Task<Unit> Handle(RemoveInvoiceTemplateCommand request, CancellationToken cancellationToken)
    {
        await _templateService.RemoveInvoiceTemplate(request.Id, cancellationToken);
        _loggerService.LogInformation($"Invoice template has been remove from the system. Invoice template ID: {request.Id}");
        return Unit.Value;
    }
}