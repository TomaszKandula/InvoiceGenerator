namespace InvoiceGenerator.Backend.BatchService.Models
{
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public class CurrencyCode
    {
        public int SystemCode { get; set; }

        public string Currency { get; set; }
    }
}