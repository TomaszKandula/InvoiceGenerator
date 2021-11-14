namespace InvoiceGenerator.Backend.InvoiceService.Models
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using Domain.Enums;

    [ExcludeFromCodeCoverage]
    public class OrderDetail
    {
        public Guid CustomerNumber { get; set; }

        public string InvoiceNumber { get; set; }

        public DateTime VoucherDate { get; set; }

        public DateTime ValueDate { get; set; }

        public DateTime DueDate { get; set; }

        public string PaymentTerms { get; set; }

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

        public IEnumerable<InvoiceItem> InvoiceItems { get; set; }
    }
}