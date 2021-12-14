namespace InvoiceGenerator.Backend.BatchService.Models
{
    using System.Diagnostics.CodeAnalysis;
    using Shared.Dto.Models;

    [ExcludeFromCodeCoverage]
    public class InvoiceItem : InvoiceItemBase
    {
        public decimal ValueAmount { get; set; }

        public decimal GrossAmount { get; set; }
    }
}