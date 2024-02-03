using System.Diagnostics.CodeAnalysis;

namespace InvoiceGenerator.Backend.Cqrs.Handlers.Queries.Payments;

[ExcludeFromCodeCoverage]
public class GetPaymentTypeListQueryResult
{
    public int SystemCode { get; set; }

    public string PaymentType { get; set; }
}