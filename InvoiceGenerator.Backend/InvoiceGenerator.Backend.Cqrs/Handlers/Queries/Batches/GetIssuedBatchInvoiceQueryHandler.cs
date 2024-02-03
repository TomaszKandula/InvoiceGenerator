using System.Threading;
using System.Threading.Tasks;
using InvoiceGenerator.Backend.Core.Services.LoggerService;
using InvoiceGenerator.Services.BatchService;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceGenerator.Backend.Cqrs.Handlers.Queries.Batches;

public class GetIssuedBatchInvoiceQueryHandler : RequestHandler<GetIssuedBatchInvoiceQuery, FileContentResult>
{
    private readonly IBatchService _batchService;

    private readonly ILoggerService _loggerService;

    public GetIssuedBatchInvoiceQueryHandler(IBatchService batchService, ILoggerService loggerService)
    {
        _batchService = batchService;
        _loggerService = loggerService;
    }

    public override async Task<FileContentResult> Handle(GetIssuedBatchInvoiceQuery request, CancellationToken cancellationToken)
    {
        var result = await _batchService.GetIssuedInvoice(request.InvoiceNumber, cancellationToken);
        _loggerService.LogInformation($"Returned issued invoice. Invoice number: {result.Number}");
        return new FileContentResult(result.ContentData, result.ContentType);
    }
}