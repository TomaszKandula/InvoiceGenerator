namespace InvoiceGenerator.Backend.Cqrs.Responses
{
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public class GetPaymentStatusesQueryResponse
    {
        public int SystemCode { get; set; }

        public string PaymentStatus { get; set; }
    }
}