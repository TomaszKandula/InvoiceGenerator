namespace InvoiceGenerator.Backend.Cqrs.Responses
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using Domain.Enums;

    [ExcludeFromCodeCoverage]
    public class GetBatchProcessingStatusQueryResponse
    {
        public ProcessingStatuses ProcessingStatus { get; set; }

        public TimeSpan? BatchProcessingTime { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}