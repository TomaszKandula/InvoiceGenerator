namespace InvoiceGenerator.Workers
{
    using System.Diagnostics;
    using System.Threading.Tasks;
    using Microsoft.Azure.WebJobs;
    using Backend.BatchService;
    using Backend.Core.Services.LoggerService;

    public class InvoiceProcessingWorker
    {
        private readonly IBatchService _batchService;
        private readonly ILoggerService _loggerService;
        
        public InvoiceProcessingWorker(IBatchService batchService, ILoggerService loggerService)
        {
            _batchService = batchService;
            _loggerService = loggerService;
        }

        [FunctionName("ProcessOutstandingInvoices")]
        public async Task Run([TimerTrigger("0 */5 * * * *")]TimerInfo myTimer)
        {
            var timer = new Stopwatch();

            timer.Start();
            _loggerService.LogInformation("Starting the processing of outstanding invoices...");
            await _batchService.ProcessOutstandingInvoices();
            timer.Stop();
            _loggerService.LogInformation($"All outstanding invoices has been processed within: {timer.Elapsed}.");
        }
    }
}
