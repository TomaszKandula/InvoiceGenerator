namespace InvoiceGenerator.Backend.TemplateService;

using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Models;

public interface ITemplateService
{
    Task<IEnumerable<InvoiceTemplateInfo>> GetInvoiceTemplates(CancellationToken cancellationToken = default);

    Task<InvoiceTemplateData> GetInvoiceTemplate(Guid templateId, CancellationToken cancellationToken = default);

    Task RemoveInvoiceTemplate(Guid templateId, CancellationToken cancellationToken = default);

    Task ReplaceInvoiceTemplate(Guid templateId, InvoiceTemplateData invoiceTemplateData, CancellationToken cancellationToken = default);

    Task<Guid> AddInvoiceTemplate(InvoiceTemplate invoiceTemplate, CancellationToken cancellationToken = default);
}