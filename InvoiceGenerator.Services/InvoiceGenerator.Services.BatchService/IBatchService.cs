using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using InvoiceGenerator.Services.BatchService.Models;

namespace InvoiceGenerator.Services.BatchService;

public interface IBatchService
{
    Task<Guid> OrderInvoiceBatchProcessing(IEnumerable<OrderDetail> orderDetails, CancellationToken cancellationToken = default);

    Task ProcessOutstandingInvoices(CancellationToken cancellationToken = default);

    Task<ProcessingStatus> GetBatchInvoiceProcessingStatus(Guid processBatchKey, CancellationToken cancellationToken = default);
 
    Task<InvoiceData> GetIssuedInvoice(string invoiceNumber, CancellationToken cancellationToken = default);
}