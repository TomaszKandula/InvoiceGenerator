using System.Diagnostics.CodeAnalysis;

namespace InvoiceGenerator.Backend.Cqrs.Handlers.Queries.Countries;

[ExcludeFromCodeCoverage]
public class GetCountryCodesQueryResult
{
    public int SystemCode { get; set; }

    public string Country { get; set; }
}