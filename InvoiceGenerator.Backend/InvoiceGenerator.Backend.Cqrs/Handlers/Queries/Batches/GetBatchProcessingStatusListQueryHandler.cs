namespace InvoiceGenerator.Backend.Cqrs.Handlers.Queries.Batches;

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Domain.Enums;
using Core.Extensions;
using Services.UserService;

public class GetBatchProcessingStatusListQueryHandler : RequestHandler<GetBatchProcessingStatusListQuery, IEnumerable<GetBatchProcessingStatusListQueryResult>>
{
    private readonly IUserService _userService;

    public GetBatchProcessingStatusListQueryHandler(IUserService userService) => _userService = userService;

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

        return await Task.FromResult(result);
    }
}