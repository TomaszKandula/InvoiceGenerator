namespace InvoiceGenerator.Backend.Cqrs.Handlers.Queries.Batches
{
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public class GetBatchProcessingStatusListQueryResult
    {
        public int SystemCode { get; set; }

        public string ProcessingStatus { get; set; }
    }
}