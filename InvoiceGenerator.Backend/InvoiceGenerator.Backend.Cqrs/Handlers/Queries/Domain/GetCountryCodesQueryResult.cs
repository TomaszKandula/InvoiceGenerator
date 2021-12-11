namespace InvoiceGenerator.Backend.Cqrs.Handlers.Queries.Domain
{
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public class GetCountryCodesQueryResult
    {
        public int SystemCode { get; set; }

        public string Country { get; set; }
    }
}