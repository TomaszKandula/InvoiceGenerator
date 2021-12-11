namespace InvoiceGenerator.Backend.Cqrs.Handlers.Queries.Domain
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using UserService;
    using Core.Exceptions;
    using Core.Extensions;
    using Shared.Resources;
    using Backend.Domain.Enums;

    public class GetPaymentTypesQueryHandler : RequestHandler<GetPaymentTypesQuery, IEnumerable<GetPaymentTypesQueryResult>>
    {
        private readonly IUserService _userService;

        public GetPaymentTypesQueryHandler(IUserService userService) => _userService = userService;
        
        public override async Task<IEnumerable<GetPaymentTypesQueryResult>> Handle(GetPaymentTypesQuery request, CancellationToken cancellationToken)
        {
            var isKeyValid = await _userService.IsPrivateKeyValid(request.PrivateKey, cancellationToken);
            var userId = await _userService.GetUserByPrivateKey(request.PrivateKey, cancellationToken);

            VerifyArguments(isKeyValid, userId);
            
            var types = Enum.GetValues<PaymentTypes>();
            var result = types
                .Select((paymentTypes, index) => new GetPaymentTypesQueryResult
                {
                    SystemCode = index,
                    PaymentType = paymentTypes.ToString().ToUpper()
                })
                .WhereIf(
                    !string.IsNullOrEmpty(request.FilterBy), 
                    response => response.PaymentType == request.FilterBy.ToUpper())
                .ToList();

            return await Task.FromResult(result);
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