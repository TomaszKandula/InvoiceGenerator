namespace InvoiceGenerator.Backend.Cqrs.Responses
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public class OrderInvoiceBatchCommandResponse
    {
        public Guid ProcessBatchKey { get; set; }
    }
}