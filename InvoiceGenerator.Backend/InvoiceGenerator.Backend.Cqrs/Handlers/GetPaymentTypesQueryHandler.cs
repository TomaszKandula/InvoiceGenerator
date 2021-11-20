namespace InvoiceGenerator.Backend.Cqrs.Handlers
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Requests;
    using Responses;
    using UserService;
    using Domain.Enums;
    using Core.Exceptions;
    using Core.Extensions;
    using Shared.Resources;

    public class GetPaymentTypesQueryHandler : TemplateHandler<GetPaymentTypesQueryRequest, IEnumerable<GetPaymentTypesQueryResponse>>
    {
        private readonly IUserService _userService;

        public GetPaymentTypesQueryHandler(IUserService userService) => _userService = userService;
        
        public override async Task<IEnumerable<GetPaymentTypesQueryResponse>> Handle(GetPaymentTypesQueryRequest request, CancellationToken cancellationToken)
        {
            var isKeyValid = await _userService.IsPrivateKeyValid(request.PrivateKey, cancellationToken);
            var userId = await _userService.GetUserByPrivateKey(request.PrivateKey, cancellationToken);

            VerifyArguments(isKeyValid, userId);
            
            var types = Enum.GetValues<PaymentTypes>();
            var result = types
                .Select((paymentTypes, index) => new GetPaymentTypesQueryResponse
                {
                    SystemCode = index,
                    PaymentType = paymentTypes.ToString().ToUpper()
                })
                .WhereIf(
                    !string.IsNullOrEmpty(request.FilteredBy), 
                    response => response.PaymentType == request.FilteredBy.ToUpper())
                .ToList();

            return await Task.FromResult(result);
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