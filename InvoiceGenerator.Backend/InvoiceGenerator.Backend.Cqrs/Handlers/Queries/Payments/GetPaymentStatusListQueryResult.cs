using System.Diagnostics.CodeAnalysis;

namespace InvoiceGenerator.Backend.Cqrs.Handlers.Queries.Payments;

[ExcludeFromCodeCoverage]
public class GetPaymentStatusListQueryResult
{
    public int SystemCode { get; set; }

    public string PaymentStatus { get; set; }
}