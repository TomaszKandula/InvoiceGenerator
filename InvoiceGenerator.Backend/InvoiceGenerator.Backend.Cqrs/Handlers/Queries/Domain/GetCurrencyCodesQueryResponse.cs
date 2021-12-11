namespace InvoiceGenerator.Backend.Cqrs.Handlers.Queries.Domain
{
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public class GetCurrencyCodesQueryResponse
    {
        public int SystemCode { get; set; }

        public string Currency { get; set; }
    }
}