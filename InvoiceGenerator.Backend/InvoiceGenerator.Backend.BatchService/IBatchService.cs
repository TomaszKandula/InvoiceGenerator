namespace InvoiceGenerator.Backend.BatchService
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Models;

    public interface IBatchService
    {
        Task<Guid> OrderInvoiceBatchProcessing(IEnumerable<OrderDetail> orderDetails, CancellationToken cancellationToken = default);

        Task<ProcessingStatus> GetBatchInvoiceProcessingStatus(Guid processBatchKey, CancellationToken cancellationToken = default);
 
        Task<InvoiceData> GetIssuedInvoice(string invoiceNumber, CancellationToken cancellationToken = default);

        Task<IEnumerable<InvoiceTemplateInfo>> GetInvoiceTemplates(CancellationToken cancellationToken = default);

        Task<InvoiceTemplateData> GetInvoiceTemplate(Guid templateId, CancellationToken cancellationToken = default);

        Task RemoveInvoiceTemplate(Guid templateId, CancellationToken cancellationToken = default);

        Task ReplaceInvoiceTemplate(Guid templateId, InvoiceTemplateData invoiceTemplateData, CancellationToken cancellationToken = default);

        Task<Guid> AddInvoiceTemplate(InvoiceTemplate invoiceTemplate, CancellationToken cancellationToken = default);
    }
}