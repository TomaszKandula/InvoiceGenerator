namespace InvoiceGenerator.Backend.Cqrs.Handlers.Commands.Templates;

using System.Threading;
using System.Threading.Tasks;
using Services.TemplateService;
using Services.TemplateService.Models;
using MediatR;

public class ReplaceInvoiceTemplateCommandHandler : Cqrs.RequestHandler<ReplaceInvoiceTemplateCommand, Unit>
{
    private readonly ITemplateService _templateService;

    public ReplaceInvoiceTemplateCommandHandler(ITemplateService templateService)
    {
        _templateService = templateService;
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
        return Unit.Value;
    }
}