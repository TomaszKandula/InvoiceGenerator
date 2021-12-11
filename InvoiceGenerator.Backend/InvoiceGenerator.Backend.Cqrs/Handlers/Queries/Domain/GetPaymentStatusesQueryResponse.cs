namespace InvoiceGenerator.Backend.Cqrs.Handlers.Queries.Domain
{
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public class GetPaymentStatusesQueryResponse
    {
        public int SystemCode { get; set; }

        public string PaymentStatus { get; set; }
    }
}