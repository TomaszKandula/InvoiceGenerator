namespace InvoiceGenerator.Backend.Cqrs.Handlers.Queries.Batch
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using Backend.Domain.Enums;

    [ExcludeFromCodeCoverage]
    public class GetBatchProcessingQueryResponse
    {
        public ProcessingStatuses ProcessingStatus { get; set; }

        public TimeSpan? BatchProcessingTime { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}