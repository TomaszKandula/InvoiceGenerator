namespace InvoiceGenerator.Backend.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.ComponentModel.DataAnnotations;
    using Enums;
    using Contracts;

    [ExcludeFromCodeCoverage]
    public class BatchInvoices : Entity<Guid>, IAuditable
    {
        [Required]
        [MaxLength(255)]
        public string InvoiceNumber { get; set; }

        [Required]
        public DateTime VoucherDate { get; set; }

        [Required]
        public DateTime ValueDate { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

        public int PaymentTerms { get; set; }

        [Required]
        public PaymentTypes PaymentType { get; set; }

        [Required]
        [MaxLength(255)]
        public string CustomerName { get; set; }

        [MaxLength(25)]
        public string CustomerVatNumber { get; set; }

        [Required]
        public CountryCodes CountryCode { get; set; }

        [Required]
        [MaxLength(255)]
        public string City { get; set; }

        [Required]
        [MaxLength(100)]
        public string StreetAddress { get; set; }

        [Required]
        [MaxLength(25)]
        public string PostalCode { get; set; }

        [Required]
        [MaxLength(150)]
        public string PostalArea { get; set; }

        [Required]
        public Guid ProcessBatchKey { get; set; }

        [Required]
        public Guid CreatedBy { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        public Guid? ModifiedBy { get; set; }

        public DateTime? ModifiedAt { get; set; }

        [Required]
        [MaxLength(255)]
        public string InvoiceTemplateName { get; set; }

        public BatchInvoicesProcessing BatchInvoicesProcessing { get; set; }

        public ICollection<BatchInvoiceItems> BatchInvoiceItems { get; set; } = new HashSet<BatchInvoiceItems>();
    }
}