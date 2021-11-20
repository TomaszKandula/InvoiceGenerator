namespace InvoiceGenerator.Backend.Cqrs.Responses
{
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public class GetCurrencyCodesQueryResponse
    {
        public int SystemCode { get; set; }

        public string Currency { get; set; }
    }
}