using System.Diagnostics.CodeAnalysis;

namespace InvoiceGenerator.Services.BatchService.Models;

[ExcludeFromCodeCoverage]
public class CurrencyCode
{
    public int SystemCode { get; set; }

    public string Currency { get; set; }
}