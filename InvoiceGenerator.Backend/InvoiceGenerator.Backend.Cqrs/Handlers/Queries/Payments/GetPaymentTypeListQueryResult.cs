namespace InvoiceGenerator.Backend.Cqrs.Handlers.Queries.Payments
{
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public class GetPaymentTypeListQueryResult
    {
        public int SystemCode { get; set; }

        public string PaymentType { get; set; }
    }
}