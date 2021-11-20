namespace InvoiceGenerator.Backend.Cqrs.Handlers
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Requests;
    using UserService;
    using InvoiceService;
    using Core.Exceptions;
    using Shared.Resources;

    public class GetIssuedInvoiceQueryHandler : TemplateHandler<GetIssuedInvoiceQueryRequest, FileContentResult>
    {
        private readonly IInvoiceService _invoiceService;
        
        private readonly IUserService _userService;

        public GetIssuedInvoiceQueryHandler(IInvoiceService invoiceService, IUserService userService)
        {
            _invoiceService = invoiceService;
            _userService = userService;
        }

        public override async Task<FileContentResult> Handle(GetIssuedInvoiceQueryRequest request, CancellationToken cancellationToken)
        {
            var isKeyValid = await _userService.IsPrivateKeyValid(request.PrivateKey, cancellationToken);
            var userId = await _userService.GetUserByPrivateKey(request.PrivateKey, cancellationToken);

            VerifyArguments(isKeyValid, userId);

            var result = await _invoiceService.GetIssuedInvoice(request.InvoiceNumber, cancellationToken);
            return new FileContentResult(result.ContentData, result.ContentType);
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