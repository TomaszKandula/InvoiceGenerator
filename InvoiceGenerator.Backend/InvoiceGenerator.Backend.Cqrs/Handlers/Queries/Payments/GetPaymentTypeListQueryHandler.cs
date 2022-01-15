namespace InvoiceGenerator.Backend.Cqrs.Handlers.Queries.Payments;

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Domain.Enums;
using Core.Extensions;
using Core.Services.LoggerService;

public class GetPaymentTypeListQueryHandler : RequestHandler<GetPaymentTypeListQuery, IEnumerable<GetPaymentTypeListQueryResult>>
{
    private readonly ILoggerService _loggerService;

    public GetPaymentTypeListQueryHandler(ILoggerService loggerService) =>_loggerService = loggerService;

    public override async Task<IEnumerable<GetPaymentTypeListQueryResult>> Handle(GetPaymentTypeListQuery request, CancellationToken cancellationToken)
    {
        var types = Enum.GetValues<PaymentTypes>();
        var result = types
            .Select((paymentTypes, index) => new GetPaymentTypeListQueryResult
            {
                SystemCode = index,
                PaymentType = paymentTypes.ToString().ToUpper()
            })
            .WhereIf(
                !string.IsNullOrEmpty(request.FilterBy), 
                response => response.PaymentType == request.FilterBy.ToUpper())
            .ToList();

        _loggerService.LogInformation($"Returned {result.Count} payment type(s)");
        return await Task.FromResult(result);
    }
}