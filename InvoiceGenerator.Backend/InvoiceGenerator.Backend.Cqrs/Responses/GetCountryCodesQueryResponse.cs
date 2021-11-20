namespace InvoiceGenerator.Backend.Cqrs.Responses
{
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public class GetCountryCodesQueryResponse
    {
        public int SystemCode { get; set; }

        public string Country { get; set; }
    }
}