namespace InvoiceGenerator.Backend.Cqrs.Handlers.Queries.Batches;

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Domain.Enums;
using Core.Extensions;
using Services.UserService;
using Core.Services.LoggerService;

public class GetBatchProcessingStatusListQueryHandler : RequestHandler<GetBatchProcessingStatusListQuery, IEnumerable<GetBatchProcessingStatusListQueryResult>>
{
    private readonly IUserService _userService;

    private readonly ILoggerService _loggerService;

    public GetBatchProcessingStatusListQueryHandler(IUserService userService, ILoggerService loggerService)
    {
        _userService = userService;
        _loggerService = loggerService;
    }

    public override async Task<IEnumerable<GetBatchProcessingStatusListQueryResult>> Handle(GetBatchProcessingStatusListQuery request, CancellationToken cancellationToken)
    {
        var statuses = Enum.GetValues<ProcessingStatuses>();
        var result = statuses
            .Select((processingStatuses, index) => new GetBatchProcessingStatusListQueryResult
            {
                SystemCode = index,
                ProcessingStatus = processingStatuses.ToString().ToUpper()
            })
            .WhereIf(
                !string.IsNullOrEmpty(request.FilterBy), 
                response => response.ProcessingStatus == request.FilterBy.ToUpper())
            .ToList();

        _loggerService.LogInformation($"Returned {result.Count} batch processing status(es)");
        return await Task.FromResult(result);
    }
}