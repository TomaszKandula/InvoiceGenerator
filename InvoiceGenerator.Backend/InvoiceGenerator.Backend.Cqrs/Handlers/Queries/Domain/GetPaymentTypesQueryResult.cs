namespace InvoiceGenerator.Backend.Cqrs.Handlers.Queries.Domain
{
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public class GetPaymentTypesQueryResult
    {
        public int SystemCode { get; set; }

        public string PaymentType { get; set; }
    }
}