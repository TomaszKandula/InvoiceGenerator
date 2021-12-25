namespace InvoiceGenerator.Backend.Cqrs.Handlers.Queries.Batches;

using System;
using System.Threading;
using System.Threading.Tasks;
using UserService;
using BatchService;
using Core.Exceptions;
using Shared.Resources;

public class GetBatchProcessingStatusQueryHandler : RequestHandler<GetBatchProcessingStatusQuery, GetBatchProcessingStatusQueryResult>
{
    private readonly IBatchService _batchService;

    private readonly IUserService _userService;

    public GetBatchProcessingStatusQueryHandler(IBatchService batchService, IUserService userService)
    {
        _batchService = batchService;
        _userService = userService;
    }
        
    public override async Task<GetBatchProcessingStatusQueryResult> Handle(GetBatchProcessingStatusQuery request, CancellationToken cancellationToken)
    {
        var isKeyValid = await _userService.IsPrivateKeyValid(request.PrivateKey, cancellationToken);
        var userId = await _userService.GetUserByPrivateKey(request.PrivateKey, cancellationToken);

        VerifyArguments(isKeyValid, userId);

        var result = await _batchService.GetBatchInvoiceProcessingStatus(request.ProcessBatchKey, cancellationToken);
        return new GetBatchProcessingStatusQueryResult
        {
            ProcessingStatus = result.Status,
            BatchProcessingTime = result.BatchProcessingTime,
            CreatedAt = result.CreatedAt
        };
    }
 
    private static void VerifyArguments(bool isKeyValid, Guid? userId)
    {
        if (!isKeyValid)
            throw new AccessException(nameof(ErrorCodes.INVALID_PRIVATE_KEY), ErrorCodes.INVALID_PRIVATE_KEY);

        if (userId == null || userId == Guid.Empty)
            throw new BusinessException(nameof(ErrorCodes.INVALID_ASSOCIATED_USER), ErrorCodes.INVALID_ASSOCIATED_USER);
    }
}