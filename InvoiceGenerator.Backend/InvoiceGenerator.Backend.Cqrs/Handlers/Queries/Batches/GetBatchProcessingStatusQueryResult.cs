using System;
using System.Diagnostics.CodeAnalysis;
using InvoiceGenerator.Backend.Domain.Enums;

namespace InvoiceGenerator.Backend.Cqrs.Handlers.Queries.Batches;

[ExcludeFromCodeCoverage]
public class GetBatchProcessingStatusQueryResult
{
    public ProcessingStatuses ProcessingStatus { get; set; }

    public TimeSpan? BatchProcessingTime { get; set; }

    public DateTime CreatedAt { get; set; }
}