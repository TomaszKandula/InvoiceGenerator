namespace InvoiceGenerator.Backend.Cqrs.Handlers
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Requests;
    using UserService;
    using InvoiceService;
    using Core.Exceptions;
    using Shared.Resources;
    using InvoiceService.Models;

    public class GetInvoiceTemplatesQueryHandler : TemplateHandler<GetInvoiceTemplatesQueryRequest, IEnumerable<TemplateInfo>>
    {
        private readonly IInvoiceService _invoiceService;
        
        private readonly IUserService _userService;

        public GetInvoiceTemplatesQueryHandler(IInvoiceService invoiceService, IUserService userService)
        {
            _invoiceService = invoiceService;
            _userService = userService;
        }
        
        public override async Task<IEnumerable<TemplateInfo>> Handle(GetInvoiceTemplatesQueryRequest request, CancellationToken cancellationToken)
        {
            var isKeyValid = await _userService.IsPrivateKeyValid(request.PrivateKey, cancellationToken);
            var userId = await _userService.GetUserByPrivateKey(request.PrivateKey, cancellationToken);

            VerifyArguments(isKeyValid, userId);

            return await _invoiceService.GetInvoiceTemplates(cancellationToken);
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