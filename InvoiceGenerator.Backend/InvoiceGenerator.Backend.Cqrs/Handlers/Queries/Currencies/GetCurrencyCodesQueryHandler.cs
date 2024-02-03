using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using InvoiceGenerator.Backend.Core.Extensions;
using InvoiceGenerator.Backend.Core.Services.LoggerService;
using InvoiceGenerator.Backend.Domain.Enums;

namespace InvoiceGenerator.Backend.Cqrs.Handlers.Queries.Currencies;

public class GetCurrencyCodesQueryHandler : RequestHandler<GetCurrencyCodesQuery, IEnumerable<GetCurrencyCodesQueryResult>>
{
    private readonly ILoggerService _loggerService;

    public GetCurrencyCodesQueryHandler(ILoggerService loggerService) => _loggerService = loggerService;

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

        _loggerService.LogInformation($"Returned {result.Count} currency code(s)");
        return await Task.FromResult(result);
    }
}