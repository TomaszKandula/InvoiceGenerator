namespace InvoiceGenerator.Backend.Cqrs.Handlers.Queries.Countries;

using MediatR;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

[ExcludeFromCodeCoverage]
public class GetCountryCodesQuery : IRequest<IEnumerable<GetCountryCodesQueryResult>>
{
    public string FilterBy { get; set; }
}