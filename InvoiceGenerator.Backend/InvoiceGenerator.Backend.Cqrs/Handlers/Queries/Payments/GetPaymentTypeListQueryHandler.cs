namespace InvoiceGenerator.Backend.Cqrs.Handlers.Queries.Payments;

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Domain.Enums;
using Core.Extensions;

public class GetPaymentTypeListQueryHandler : RequestHandler<GetPaymentTypeListQuery, IEnumerable<GetPaymentTypeListQueryResult>>
{
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

        return await Task.FromResult(result);
    }
}