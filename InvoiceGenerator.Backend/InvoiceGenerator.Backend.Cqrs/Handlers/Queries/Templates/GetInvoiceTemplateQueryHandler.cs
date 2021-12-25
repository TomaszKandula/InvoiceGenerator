namespace InvoiceGenerator.Backend.Cqrs.Handlers.Queries.Templates;

using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UserService;
using TemplateService;
using Core.Exceptions;
using Shared.Resources;

public class GetInvoiceTemplateQueryHandler : RequestHandler<GetInvoiceTemplateQuery, FileContentResult>
{
    private readonly ITemplateService _templateService;
        
    private readonly IUserService _userService;

    public GetInvoiceTemplateQueryHandler(ITemplateService templateService, IUserService userService)
    {
        _templateService = templateService;
        _userService = userService;
    }

    public override async Task<FileContentResult> Handle(GetInvoiceTemplateQuery request, CancellationToken cancellationToken)
    {
        var isKeyValid = await _userService.IsPrivateKeyValid(request.PrivateKey, cancellationToken);
        var userId = await _userService.GetUserByPrivateKey(request.PrivateKey, cancellationToken);

        VerifyArguments(isKeyValid, userId);

        var result = await _templateService.GetInvoiceTemplate(request.Id, cancellationToken);
        return new FileContentResult(result.ContentData, result.ContentType);
    }

    private static void VerifyArguments(bool isKeyValid, Guid? userId)
    {
        if (!isKeyValid)
            throw new AccessException(nameof(ErrorCodes.INVALID_PRIVATE_KEY), ErrorCodes.INVALID_PRIVATE_KEY);

        if (userId == null || userId == Guid.Empty)
            throw new BusinessException(nameof(ErrorCodes.INVALID_ASSOCIATED_USER), ErrorCodes.INVALID_ASSOCIATED_USER);
    }
}