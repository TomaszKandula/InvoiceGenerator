namespace InvoiceGenerator.Backend.Cqrs.Handlers.Queries.Currencies;

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using UserService;
using Core.Exceptions;
using Core.Extensions;
using Shared.Resources;
using Domain.Enums;

public class GetCurrencyCodesQueryHandler : RequestHandler<GetCurrencyCodesQuery, IEnumerable<GetCurrencyCodesQueryResult>>
{
    private readonly IUserService _userService;

    public GetCurrencyCodesQueryHandler(IUserService userService) => _userService = userService;

    public override async Task<IEnumerable<GetCurrencyCodesQueryResult>> Handle(GetCurrencyCodesQuery request, CancellationToken cancellationToken)
    {
        var isKeyValid = await _userService.IsPrivateKeyValid(request.PrivateKey, cancellationToken);
        var userId = await _userService.GetUserByPrivateKey(request.PrivateKey, cancellationToken);

        VerifyArguments(isKeyValid, userId);

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

    private static void VerifyArguments(bool isKeyValid, Guid? userId)
    {
        if (!isKeyValid)
            throw new AccessException(nameof(ErrorCodes.INVALID_PRIVATE_KEY), ErrorCodes.INVALID_PRIVATE_KEY);

        if (userId == null || userId == Guid.Empty)
            throw new BusinessException(nameof(ErrorCodes.INVALID_ASSOCIATED_USER), ErrorCodes.INVALID_ASSOCIATED_USER);
    }
}