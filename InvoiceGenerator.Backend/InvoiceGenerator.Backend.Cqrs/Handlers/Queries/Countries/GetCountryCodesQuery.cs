using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using MediatR;

namespace InvoiceGenerator.Backend.Cqrs.Handlers.Queries.Countries;

[ExcludeFromCodeCoverage]
public class GetCountryCodesQuery : IRequest<IEnumerable<GetCountryCodesQueryResult>>
{
    public string FilterBy { get; set; }
}