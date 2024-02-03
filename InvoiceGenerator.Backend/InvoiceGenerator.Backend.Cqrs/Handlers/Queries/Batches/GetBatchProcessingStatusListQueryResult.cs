using System.Diagnostics.CodeAnalysis;

namespace InvoiceGenerator.Backend.Cqrs.Handlers.Queries.Batches;

[ExcludeFromCodeCoverage]
public class GetBatchProcessingStatusListQueryResult
{
    public int SystemCode { get; set; }

    public string ProcessingStatus { get; set; }
}