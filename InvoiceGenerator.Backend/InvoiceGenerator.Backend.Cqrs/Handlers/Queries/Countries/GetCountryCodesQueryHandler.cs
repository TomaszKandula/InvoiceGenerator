namespace InvoiceGenerator.Backend.Cqrs.Handlers.Queries.Countries;

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Domain.Enums;
using Core.Exceptions;
using Core.Extensions;
using Shared.Resources;
using Services.UserService;

public class GetCountryCodesQueryHandler : RequestHandler<GetCountryCodesQuery, IEnumerable<GetCountryCodesQueryResult>>
{
    private readonly IUserService _userService;

    public GetCountryCodesQueryHandler(IUserService userService) => _userService = userService;

    public override async Task<IEnumerable<GetCountryCodesQueryResult>> Handle(GetCountryCodesQuery request, CancellationToken cancellationToken)
    {
        var isKeyValid = await _userService.IsPrivateKeyValid(request.PrivateKey, cancellationToken);
        var userId = await _userService.GetUserByPrivateKey(request.PrivateKey, cancellationToken);

        VerifyArguments(isKeyValid, userId);

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