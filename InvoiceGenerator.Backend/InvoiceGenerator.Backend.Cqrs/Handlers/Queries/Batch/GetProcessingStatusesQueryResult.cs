namespace InvoiceGenerator.Backend.Cqrs.Handlers.Queries.Batch
{
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public class GetProcessingStatusesQueryResult
    {
        public int SystemCode { get; set; }

        public string ProcessingStatus { get; set; }
    }
}