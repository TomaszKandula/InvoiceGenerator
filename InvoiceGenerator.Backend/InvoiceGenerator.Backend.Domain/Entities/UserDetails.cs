namespace InvoiceGenerator.Backend.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.ComponentModel.DataAnnotations;
    using Enums;

    [ExcludeFromCodeCoverage]
    public class UserDetails : Entity<Guid>
    {
        public Guid UserId { get; set; }

        [MaxLength(255)]
        public string CompanyName { get; set; }

        [MaxLength(25)]
        public string VatNumber { get; set; }

        [Required]
        [MaxLength(255)]
        public string StreetAddress { get; set; }

        [Required]
        [MaxLength(12)]
        public string PostalCode { get; set; }

        [Required]
        [MaxLength(255)]
        public string City { get; set; }

        [Required]
        public CurrencyCodes CurrencyCode { get; set; }

        [Required]
        public CountryCodes CountryCode { get; set; }

        public Users User { get; set; }

        public ICollection<BatchInvoices> BatchInvoices { get; set; } = new HashSet<BatchInvoices>();
    }
}