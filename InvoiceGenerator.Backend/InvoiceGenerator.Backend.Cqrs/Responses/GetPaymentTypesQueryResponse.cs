namespace InvoiceGenerator.Backend.Cqrs.Responses
{
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public class GetPaymentTypesQueryResponse
    {
        public int SystemCode { get; set; }

        public string PaymentType { get; set; }
    }
}