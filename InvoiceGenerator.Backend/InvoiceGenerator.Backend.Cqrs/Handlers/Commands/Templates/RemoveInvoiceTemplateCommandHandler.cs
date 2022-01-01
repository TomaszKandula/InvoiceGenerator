namespace InvoiceGenerator.Backend.Cqrs.Handlers.Commands.Templates;

using System.Threading;
using System.Threading.Tasks;
using Services.TemplateService;
using MediatR;

public class RemoveInvoiceTemplateCommandHandler : Cqrs.RequestHandler<RemoveInvoiceTemplateCommand, Unit>
{
    private readonly ITemplateService _templateService;

    public RemoveInvoiceTemplateCommandHandler(ITemplateService templateService)
    {
        _templateService = templateService;
    }

    public override async Task<Unit> Handle(RemoveInvoiceTemplateCommand request, CancellationToken cancellationToken)
    {
        await _templateService.RemoveInvoiceTemplate(request.Id, cancellationToken);
        return Unit.Value;
    }
}