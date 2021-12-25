namespace InvoiceGenerator.Backend.Cqrs.Handlers.Queries.Currencies;

using MediatR;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Shared.Models;

[ExcludeFromCodeCoverage]
public class GetCurrencyCodesQuery : RequestProperties, IRequest<IEnumerable<GetCurrencyCodesQueryResult>>
{
    public string FilterBy { get; set; }
}