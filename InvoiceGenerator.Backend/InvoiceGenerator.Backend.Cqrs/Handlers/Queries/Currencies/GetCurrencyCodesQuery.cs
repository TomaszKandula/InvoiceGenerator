namespace InvoiceGenerator.Backend.Cqrs.Handlers.Queries.Currencies;

using MediatR;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

[ExcludeFromCodeCoverage]
public class GetCurrencyCodesQuery : IRequest<IEnumerable<GetCurrencyCodesQueryResult>>
{
    public string FilterBy { get; set; }
}