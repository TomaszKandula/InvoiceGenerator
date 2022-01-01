namespace InvoiceGenerator.Backend.Cqrs.Handlers.Commands.Batches;

using System.Threading;
using System.Diagnostics;
using System.Threading.Tasks;
using Services.BatchService;
using Core.Services.LoggerService;
using MediatR;

public class OrderBatchProcessingCommandHandler : Cqrs.RequestHandler<OrderBatchProcessingCommand, Unit>
{
    private readonly IBatchService _batchService;

    private readonly ILoggerService _loggerService;
        
    public OrderBatchProcessingCommandHandler(IBatchService batchService, ILoggerService loggerService)
    {
        _batchService = batchService;
        _loggerService = loggerService;
    }

    public override async Task<Unit> Handle(OrderBatchProcessingCommand request, CancellationToken cancellationToken)
    {
        var timer = new Stopwatch();

        timer.Start();
        _loggerService.LogInformation("Starting the processing of outstanding invoices...");
        await _batchService.ProcessOutstandingInvoices(cancellationToken);
        timer.Stop();
        _loggerService.LogInformation($"All outstanding invoices has been processed within: {timer.Elapsed}.");

        return Unit.Value;
    }
}