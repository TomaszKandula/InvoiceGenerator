namespace InvoiceGenerator.Backend.Cqrs.Handlers.Queries.Batches;

using System.Threading;
using System.Threading.Tasks;
using Services.BatchService;

public class GetBatchProcessingStatusQueryHandler : RequestHandler<GetBatchProcessingStatusQuery, GetBatchProcessingStatusQueryResult>
{
    private readonly IBatchService _batchService;

    public GetBatchProcessingStatusQueryHandler(IBatchService batchService)
    {
        _batchService = batchService;
    }
        
    public override async Task<GetBatchProcessingStatusQueryResult> Handle(GetBatchProcessingStatusQuery request, CancellationToken cancellationToken)
    {
        var result = await _batchService.GetBatchInvoiceProcessingStatus(request.ProcessBatchKey, cancellationToken);
        return new GetBatchProcessingStatusQueryResult
        {
            ProcessingStatus = result.Status,
            BatchProcessingTime = result.BatchProcessingTime,
            CreatedAt = result.CreatedAt
        };
    }
}