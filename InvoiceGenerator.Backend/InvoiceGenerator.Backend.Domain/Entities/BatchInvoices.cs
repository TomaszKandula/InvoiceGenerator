namespace InvoiceGenerator.Backend.Domain.Entities
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Enums;
    using Contracts;

    [ExcludeFromCodeCoverage]
    public class BatchInvoices : Entity<Guid>, IAuditable
    {
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        public Guid CustomerNumber { get; set; }

        [Required]
        [MaxLength(255)]
        public string InvoiceNumber { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal OpenCurrencyAmount { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal OpenAmount { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal CurrencyAmount { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        [Required]
        public CurrencyCodes CurrencyCode { get; set; }

        [Required]
        public DateTime VoucherDate { get; set; }

        [Required]
        public DateTime ValueDate { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

        [Required]
        [MaxLength(255)]
        public string PaymentTerms { get; set; }

        [Required]
        public PaymentStatuses PaymentStatus { get; set; }

        [Required]
        public CountryCodes CountryCode { get; set; }

        [Required]
        [MaxLength(255)]
        public string City { get; set; }

        [Required]
        [MaxLength(100)]
        public string AddressLine1 { get; set; }

        [Required]
        [MaxLength(100)]
        public string AddressLine2 { get; set; }

        [Required]
        [MaxLength(100)]
        public string AddressLine3 { get; set; }

        [Required]
        [MaxLength(25)]
        public string PostalCode { get; set; }

        [Required]
        [MaxLength(150)]
        public string PostalArea { get; set; }

        [Required]
        [MaxLength(255)]
        public string Text { get; set; }

        [MaxLength(255)]
        public string AdditionalText { get; set; }

        [MaxLength(255)]
        public string PersonResponsible { get; set; }

        [MaxLength(255)]
        public string SalesResponsible { get; set; }

        [MaxLength(255)]
        public string CustomerGroup { get; set; }

        [Required]
        public Guid ProcessBatchKey { get; set; }

        [Required]
        public Guid CreatedBy { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        public Guid? ModifiedBy { get; set; }

        public DateTime? ModifiedAt { get; set; }
    }
}