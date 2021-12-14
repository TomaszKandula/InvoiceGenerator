namespace InvoiceGenerator.Backend.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.ComponentModel.DataAnnotations;
    using Enums;

    [ExcludeFromCodeCoverage]
    public class UserBankAccounts : Entity<Guid>
    {
        public Guid UserId { get; set; }

        [Required]
        [MaxLength(255)]
        public string BankName { get; set; }

        [Required]
        [MaxLength(11)]
        public string SwiftNumber { get; set; }        

        [Required]
        [MaxLength(28)]
        public string AccountNumber { get; set; }

        [Required]
        public CurrencyCodes CurrencyCode { get; set; }

        public Users User { get; set; }

        public ICollection<BatchInvoices> BatchInvoices { get; set; } = new HashSet<BatchInvoices>();
    }
}