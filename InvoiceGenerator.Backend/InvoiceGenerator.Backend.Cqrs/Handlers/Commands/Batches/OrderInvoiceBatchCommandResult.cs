using System;
using System.Diagnostics.CodeAnalysis;

namespace InvoiceGenerator.Backend.Cqrs.Handlers.Commands.Batches;

[ExcludeFromCodeCoverage]
public class OrderInvoiceBatchCommandResult
{
    public Guid ProcessBatchKey { get; set; }
}