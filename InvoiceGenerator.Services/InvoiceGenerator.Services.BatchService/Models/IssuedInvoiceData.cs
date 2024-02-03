using System.Diagnostics;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using InvoiceGenerator.Backend.Domain.Entities;

namespace InvoiceGenerator.Services.BatchService.Models;

[ExcludeFromCodeCoverage]
public class IssuedInvoiceData
{
    public string InvoiceContent { get; set; }

    public BatchInvoices CurrentInvoice { get; set; }

    public ICollection<IssuedInvoices> InvoiceCollection { get; set; }

    public BatchInvoicesProcessing BatchInvoicesProcessing { get; set; }

    public Stopwatch ProcessingTimer { get; set; }
}