namespace InvoiceGenerator.Backend.Cqrs.Handlers
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Requests;
    using UserService;
    using TemplateService;
    using Core.Exceptions;
    using Shared.Resources;
    using MediatR;

    public class RemoveInvoiceTemplateQueryHandler : TemplateHandler<RemoveInvoiceTemplateQueryRequest, Unit>
    {
        private readonly ITemplateService _templateService;
        
        private readonly IUserService _userService;

        public RemoveInvoiceTemplateQueryHandler(ITemplateService templateService, IUserService userService)
        {
            _templateService = templateService;
            _userService = userService;
        }

        public override async Task<Unit> Handle(RemoveInvoiceTemplateQueryRequest request, CancellationToken cancellationToken)
        {
            var isKeyValid = await _userService.IsPrivateKeyValid(request.PrivateKey, cancellationToken);
            var userId = await _userService.GetUserByPrivateKey(request.PrivateKey, cancellationToken);

            VerifyArguments(isKeyValid, userId);

            await _templateService.RemoveInvoiceTemplate(request.Id, cancellationToken);
            return Unit.Value;
        }

        private static void VerifyArguments(bool isKeyValid, Guid? userId)
        {
            if (!isKeyValid)
                throw new BusinessException(nameof(ErrorCodes.INVALID_PRIVATE_KEY), ErrorCodes.INVALID_PRIVATE_KEY);

            if (userId == null || userId == Guid.Empty)
                throw new BusinessException(nameof(ErrorCodes.INVALID_ASSOCIATED_USER), ErrorCodes.INVALID_ASSOCIATED_USER);
        }
    }
}