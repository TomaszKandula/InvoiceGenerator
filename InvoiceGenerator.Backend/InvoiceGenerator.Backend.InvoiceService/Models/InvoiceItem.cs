namespace InvoiceGenerator.Backend.InvoiceService.Models
{
    using Domain.Enums;

    public class InvoiceItem
    {
        public string ItemText { get; set; }

        public int ItemQuantity { get; set; }

        public string ItemQuantityUnit { get; set; }

        public decimal ItemAmount { get; set; }

        public decimal? ItemDiscountRate { get; set; }

        public decimal ValueAmount { get; set; }

        public decimal? VatRate { get; set; }

        public decimal GrossAmount { get; set; }

        public CurrencyCodes CurrencyCode { get; set; }
    }
}