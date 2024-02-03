using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using InvoiceGenerator.Backend.Core.Extensions;
using InvoiceGenerator.Backend.Core.Services.LoggerService;
using InvoiceGenerator.Backend.Domain.Enums;

namespace InvoiceGenerator.Backend.Cqrs.Handlers.Queries.Payments;

public class GetPaymentStatusListQueryHandler : RequestHandler<GetPaymentStatusListQuery, IEnumerable<GetPaymentStatusListQueryResult>>
{
    private readonly ILoggerService _loggerService;

    public GetPaymentStatusListQueryHandler(ILoggerService loggerService) => _loggerService = loggerService;

    public override async Task<IEnumerable<GetPaymentStatusListQueryResult>> Handle(GetPaymentStatusListQuery request, CancellationToken cancellationToken)
    {
        var statuses = Enum.GetValues<PaymentStatuses>();
        var result = statuses
            .Select((paymentStatuses, index) => new GetPaymentStatusListQueryResult
            {
                SystemCode = index,
                PaymentStatus = paymentStatuses.ToString().ToUpper()
            })
            .WhereIf(
                !string.IsNullOrEmpty(request.FilterBy), 
                response => response.PaymentStatus == request.FilterBy.ToUpper())
            .ToList();

        _loggerService.LogInformation($"Returned {result.Count} payment status(es)");
        return await Task.FromResult(result);
    }
}