using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using MediatR;

namespace InvoiceGenerator.Backend.Cqrs.Handlers.Queries.Currencies;

[ExcludeFromCodeCoverage]
public class GetCurrencyCodesQuery : IRequest<IEnumerable<GetCurrencyCodesQueryResult>>
{
    public string FilterBy { get; set; }
}