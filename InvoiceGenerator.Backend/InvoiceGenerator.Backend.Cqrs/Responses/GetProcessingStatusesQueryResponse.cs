namespace InvoiceGenerator.Backend.Cqrs.Responses
{
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public class GetProcessingStatusesQueryResponse
    {
        public int SystemCode { get; set; }

        public string ProcessingStatus { get; set; }
    }
}