namespace InvoiceGenerator.Backend.Cqrs.Handlers.Queries.Batches
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using Backend.Domain.Enums;

    [ExcludeFromCodeCoverage]
    public class GetBatchProcessingQueryResult
    {
        public ProcessingStatuses ProcessingStatus { get; set; }

        public TimeSpan? BatchProcessingTime { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}