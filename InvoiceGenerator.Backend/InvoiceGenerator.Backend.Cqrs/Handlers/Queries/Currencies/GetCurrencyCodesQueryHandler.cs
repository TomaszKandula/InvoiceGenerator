namespace InvoiceGenerator.Backend.Cqrs.Handlers.Queries.Currencies;

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Domain.Enums;
using Core.Extensions;

public class GetCurrencyCodesQueryHandler : RequestHandler<GetCurrencyCodesQuery, IEnumerable<GetCurrencyCodesQueryResult>>
{
    public override async Task<IEnumerable<GetCurrencyCodesQueryResult>> Handle(GetCurrencyCodesQuery request, CancellationToken cancellationToken)
    {
        var codes = Enum.GetValues<CurrencyCodes>();
        var result = codes
            .Select((currencyCodes, index) => new GetCurrencyCodesQueryResult
            {
                SystemCode = index,
                Currency = currencyCodes.ToString().ToUpper()
            })
            .Where(response => response.SystemCode != 0)
            .WhereIf(
                !string.IsNullOrEmpty(request.FilterBy), 
                response => response.Currency == request.FilterBy.ToUpper())
            .ToList();

        return await Task.FromResult(result);
    }
}