namespace InvoiceGenerator.Backend.Cqrs.Handlers.Queries.Countries;

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Domain.Enums;
using Core.Extensions;
using Core.Services.LoggerService;

public class GetCountryCodesQueryHandler : RequestHandler<GetCountryCodesQuery, IEnumerable<GetCountryCodesQueryResult>>
{
    private readonly ILoggerService _loggerService;

    public GetCountryCodesQueryHandler(ILoggerService loggerService) => _loggerService = loggerService;

    public override async Task<IEnumerable<GetCountryCodesQueryResult>> Handle(GetCountryCodesQuery request, CancellationToken cancellationToken)
    {
        var codes = Enum.GetValues<CountryCodes>();
        var result = codes
            .Select((countryCodes, index) => new GetCountryCodesQueryResult
            {
                SystemCode = index,
                Country = countryCodes.ToString().ToUpper()
            })
            .Where(response => response.SystemCode != 0)
            .WhereIf(
                !string.IsNullOrEmpty(request.FilterBy), 
                response => response.Country == request.FilterBy.ToUpper())
            .ToList();

        _loggerService.LogInformation($"Returned {result.Count} country code(s)");
        return await Task.FromResult(result);
    }
}