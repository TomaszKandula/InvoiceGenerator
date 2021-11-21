namespace InvoiceGenerator.Backend.Cqrs.Handlers
{
    using System.Threading;
    using System.Threading.Tasks;
    using System;
    using Requests;
    using Responses;
    using UserService;
    using TemplateService;
    using Core.Exceptions;
    using Shared.Resources;
    using TemplateService.Models;

    public class AddInvoiceTemplateCommandHandler : TemplateHandler<AddInvoiceTemplateCommandRequest, AddInvoiceTemplateCommandResponse>
    {
        private readonly ITemplateService _templateService;

        private readonly IUserService _userService;

        public AddInvoiceTemplateCommandHandler(ITemplateService templateService, IUserService userService)
        {
            _templateService = templateService;
            _userService = userService;
        }

        public override async Task<AddInvoiceTemplateCommandResponse> Handle(AddInvoiceTemplateCommandRequest request, CancellationToken cancellationToken)
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
            return new AddInvoiceTemplateCommandResponse { TemplateId = result };
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