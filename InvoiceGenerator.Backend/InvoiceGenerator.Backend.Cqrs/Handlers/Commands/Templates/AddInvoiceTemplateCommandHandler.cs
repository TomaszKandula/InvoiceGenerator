namespace InvoiceGenerator.Backend.Cqrs.Handlers.Commands.Templates;

using System;
using System.Threading;
using System.Threading.Tasks;
using Core.Exceptions;
using Shared.Resources;
using Services.UserService;
using Services.TemplateService;
using Services.TemplateService.Models;

public class AddInvoiceTemplateCommandHandler : RequestHandler<AddInvoiceTemplateCommand, AddInvoiceTemplateCommandResult>
{
    private readonly ITemplateService _templateService;

    private readonly IUserService _userService;

    public AddInvoiceTemplateCommandHandler(ITemplateService templateService, IUserService userService)
    {
        _templateService = templateService;
        _userService = userService;
    }

    public override async Task<AddInvoiceTemplateCommandResult> Handle(AddInvoiceTemplateCommand request, CancellationToken cancellationToken)
    {
        var isKeyValid = await _userService.IsPrivateKeyValid(request.PrivateKey, cancellationToken);
        var userId = await _userService.GetUserByPrivateKey(request.PrivateKey, cancellationToken);

        VerifyArguments(isKeyValid, userId);

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

    private static void VerifyArguments(bool isKeyValid, Guid? userId)
    {
        if (!isKeyValid)
            throw new AccessException(nameof(ErrorCodes.INVALID_PRIVATE_KEY), ErrorCodes.INVALID_PRIVATE_KEY);

        if (userId == null || userId == Guid.Empty)
            throw new BusinessException(nameof(ErrorCodes.INVALID_ASSOCIATED_USER), ErrorCodes.INVALID_ASSOCIATED_USER);
    }
}