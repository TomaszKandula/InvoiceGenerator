namespace InvoiceGenerator.Backend.Cqrs.Handlers.Commands.Templates;

using System.Threading;
using System.Threading.Tasks;
using Services.TemplateService;
using Services.TemplateService.Models;

public class AddInvoiceTemplateCommandHandler : RequestHandler<AddInvoiceTemplateCommand, AddInvoiceTemplateCommandResult>
{
    private readonly ITemplateService _templateService;

    public AddInvoiceTemplateCommandHandler(ITemplateService templateService)
    {
        _templateService = templateService;
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
        return new AddInvoiceTemplateCommandResult { TemplateId = result };
    }
}