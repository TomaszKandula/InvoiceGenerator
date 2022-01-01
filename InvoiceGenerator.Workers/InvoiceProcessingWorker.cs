namespace InvoiceGenerator.Workers;

using System.Diagnostics;
using System.Threading.Tasks;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Services.BatchService;

[ExcludeFromCodeCoverage]
public class InvoiceProcessingWorker
{
    private readonly IBatchService _batchService;

    public InvoiceProcessingWorker(IBatchService batchService) => _batchService = batchService;

    [FunctionName("ProcessOutstandingInvoices")]
    public async Task Run([TimerTrigger("0 */15 * * * *")]TimerInfo myTimer, ILogger logger)
    {
        var timer = new Stopwatch();

        timer.Start();
        logger.LogInformation("Starting the processing of outstanding invoices...");
        await _batchService.ProcessOutstandingInvoices();
        timer.Stop();
        logger.LogInformation("All outstanding invoices has been processed within: {TimeElapsed}", timer.Elapsed);
    }
}