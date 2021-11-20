namespace InvoiceGenerator.Backend.Shared.Dto.Models
{
    using System.Diagnostics.CodeAnalysis;
    using Domain.Enums;

    [ExcludeFromCodeCoverage]
    public class OrderDetailsInvoiceItem
    {
        public string ItemText { get; set; }

        public int ItemQuantity { get; set; }

        public string ItemQuantityUnit { get; set; }

        public decimal ItemAmount { get; set; }

        public decimal? ItemDiscountRate { get; set; }

        public decimal? VatRate { get; set; }

        public CurrencyCodes CurrencyCode { get; set; }
    }
}