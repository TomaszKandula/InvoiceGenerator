namespace InvoiceGenerator.Backend.Cqrs.Handlers.Queries.Batch
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

    public class GetProcessingStatusesQueryHandler : TemplateHandler<GetProcessingStatusesQueryRequest, IEnumerable<GetProcessingStatusesQueryResponse>>
    {
        private readonly IUserService _userService;

        public GetProcessingStatusesQueryHandler(IUserService userService) => _userService = userService;

        public override async Task<IEnumerable<GetProcessingStatusesQueryResponse>> Handle(GetProcessingStatusesQueryRequest request, CancellationToken cancellationToken)
        {
            var isKeyValid = await _userService.IsPrivateKeyValid(request.PrivateKey, cancellationToken);
            var userId = await _userService.GetUserByPrivateKey(request.PrivateKey, cancellationToken);

            VerifyArguments(isKeyValid, userId);
            
            var statuses = Enum.GetValues<ProcessingStatuses>();
            var result = statuses
                .Select((processingStatuses, index) => new GetProcessingStatusesQueryResponse
                {
                    SystemCode = index,
                    ProcessingStatus = processingStatuses.ToString().ToUpper()
                })
                .WhereIf(
                    !string.IsNullOrEmpty(request.FilterBy), 
                    response => response.ProcessingStatus == request.FilterBy.ToUpper())
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