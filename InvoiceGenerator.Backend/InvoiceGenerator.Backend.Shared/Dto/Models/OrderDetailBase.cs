namespace InvoiceGenerator.Backend.Shared.Dto.Models
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using Domain.Enums;

    [ExcludeFromCodeCoverage]
    public class OrderDetailBase
    {
        public DateTime? VoucherDate { get; set; }

        public DateTime? ValueDate { get; set; }

        public int PaymentTerms { get; set; }

        public PaymentTypes PaymentType { get; set; }

        public string CompanyName { get; set; }

        public string CompanyVatNumber { get; set; }

        public CountryCodes CountryCode { get; set; }

        public string City { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string AddressLine3 { get; set; }

        public string PostalCode { get; set; }

        public string PostalArea { get; set; }

        public string InvoiceTemplateName { get; set; }

        public IEnumerable<OrderDetailsInvoiceItem> InvoiceItems { get; set; }
    }
}