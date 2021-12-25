namespace InvoiceGenerator.Backend.Cqrs.Handlers.Commands.Batches;

using System;
using System.Diagnostics.CodeAnalysis;

[ExcludeFromCodeCoverage]
public class OrderInvoiceBatchCommandResult
{
    public Guid ProcessBatchKey { get; set; }
}