using System.Threading;
using System.Threading.Tasks;
using InvoiceGenerator.Backend.Core.Services.LoggerService;
using InvoiceGenerator.Services.BatchService;

namespace InvoiceGenerator.Backend.Cqrs.Handlers.Queries.Batches;

public class GetBatchProcessingStatusQueryHandler : RequestHandler<GetBatchProcessingStatusQuery, GetBatchProcessingStatusQueryResult>
{
    private readonly IBatchService _batchService;

    private readonly ILoggerService _loggerService;

    public GetBatchProcessingStatusQueryHandler(IBatchService batchService, ILoggerService loggerService)
    {
        _batchService = batchService;
        _loggerService = loggerService;
    }
        
    public override async Task<GetBatchProcessingStatusQueryResult> Handle(GetBatchProcessingStatusQuery request, CancellationToken cancellationToken)
    {
        var result = await _batchService.GetBatchInvoiceProcessingStatus(request.ProcessBatchKey, cancellationToken);
        _loggerService.LogInformation($"Returned batch invoice processing status. PBK: {request.ProcessBatchKey}");
        return new GetBatchProcessingStatusQueryResult
        {
            ProcessingStatus = result.Status,
            BatchProcessingTime = result.BatchProcessingTime,
            CreatedAt = result.CreatedAt
        };
    }
}