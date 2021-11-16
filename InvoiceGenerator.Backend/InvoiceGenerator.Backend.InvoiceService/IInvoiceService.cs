namespace InvoiceGenerator.Backend.InvoiceService
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Models;

    public interface IInvoiceService
    {
        Task<Guid> OrderInvoiceBatchProcessing(IEnumerable<OrderDetail> orderDetails, CancellationToken cancellationToken = default);

        Task<ProcessingStatus> GetBatchInvoiceProcessingStatus(Guid processBatchKey, CancellationToken cancellationToken = default);
 
        Task<byte[]> GetInvoiceTemplate(string templateName, CancellationToken cancellationToken = default);

        Task<byte[]> GetInvoiceTemplate(Guid templateId, CancellationToken cancellationToken = default);

        Task RemoveInvoiceTemplate(string templateName, CancellationToken cancellationToken = default);

        Task RemoveInvoiceTemplate(Guid templateId, CancellationToken cancellationToken = default);

        Task ReplaceInvoiceTemplate(string templateName, TemplateData templateData, CancellationToken cancellationToken = default);

        Task ReplaceInvoiceTemplate(Guid templateId, TemplateData templateData, CancellationToken cancellationToken = default);

        Task<Guid> AddInvoiceTemplate(InvoiceTemplate invoiceTemplate, CancellationToken cancellationToken = default);
    }
}