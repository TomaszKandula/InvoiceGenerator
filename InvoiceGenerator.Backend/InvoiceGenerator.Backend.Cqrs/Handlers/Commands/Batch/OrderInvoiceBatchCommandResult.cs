namespace InvoiceGenerator.Backend.Cqrs.Handlers.Commands.Batch
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public class OrderInvoiceBatchCommandResult
    {
        public Guid ProcessBatchKey { get; set; }
    }
}