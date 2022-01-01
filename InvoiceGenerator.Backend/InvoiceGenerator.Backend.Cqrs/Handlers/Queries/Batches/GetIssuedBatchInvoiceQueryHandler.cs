namespace InvoiceGenerator.Backend.Cqrs.Handlers.Queries.Batches;

using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services.BatchService;

public class GetIssuedBatchInvoiceQueryHandler : RequestHandler<GetIssuedBatchInvoiceQuery, FileContentResult>
{
    private readonly IBatchService _batchService;

    public GetIssuedBatchInvoiceQueryHandler(IBatchService batchService)
    {
        _batchService = batchService;
    }

    public override async Task<FileContentResult> Handle(GetIssuedBatchInvoiceQuery request, CancellationToken cancellationToken)
    {
        var result = await _batchService.GetIssuedInvoice(request.InvoiceNumber, cancellationToken);
        return new FileContentResult(result.ContentData, result.ContentType);
    }
}