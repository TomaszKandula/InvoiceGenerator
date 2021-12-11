namespace InvoiceGenerator.Backend.Cqrs.Handlers.Commands.Templates
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using UserService;
    using TemplateService;
    using Core.Exceptions;
    using Shared.Resources;
    using TemplateService.Models;
    using MediatR;

    public class ReplaceInvoiceTemplateCommandHandler : Cqrs.RequestHandler<ReplaceInvoiceTemplateCommand, Unit>
    {
        private readonly ITemplateService _templateService;

        private readonly IUserService _userService;

        public ReplaceInvoiceTemplateCommandHandler(ITemplateService templateService, IUserService userService)
        {
            _templateService = templateService;
            _userService = userService;
        }

        public override async Task<Unit> Handle(ReplaceInvoiceTemplateCommand request, CancellationToken cancellationToken)
        {
            var isKeyValid = await _userService.IsPrivateKeyValid(request.PrivateKey, cancellationToken);
            var userId = await _userService.GetUserByPrivateKey(request.PrivateKey, cancellationToken);

            VerifyArguments(isKeyValid, userId);

            var newTemplate = new InvoiceTemplateData
            {
                ContentData = request.Data,
                ContentType = request.DataType
            };

            await _templateService.ReplaceInvoiceTemplate(request.Id, newTemplate, cancellationToken);
            return Unit.Value;
        }

        private static void VerifyArguments(bool isKeyValid, Guid? userId)
        {
            if (!isKeyValid)
                throw new AccessException(nameof(ErrorCodes.INVALID_PRIVATE_KEY), ErrorCodes.INVALID_PRIVATE_KEY);

            if (userId == null || userId == Guid.Empty)
                throw new BusinessException(nameof(ErrorCodes.INVALID_ASSOCIATED_USER), ErrorCodes.INVALID_ASSOCIATED_USER);
        }
    }
}