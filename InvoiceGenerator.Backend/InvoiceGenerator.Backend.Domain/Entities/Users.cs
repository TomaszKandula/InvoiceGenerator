namespace InvoiceGenerator.Backend.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.ComponentModel.DataAnnotations;
    using Domain;

    [ExcludeFromCodeCoverage]
    public class Users : Entity<Guid>
    {
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(5)]
        public string UserAlias { get; set; }

        [Required]
        [MaxLength(255)]
        public string EmailAddress { get; set; }

        public bool IsActivated { get; set; }

        public DateTime Registered { get; set; }

        [Required]
        [MaxLength(100)]
        public string PrivateKey { get; set; }

        public ICollection<UserCompanies> UserCompanies { get; set; } = new HashSet<UserCompanies>();

        public ICollection<UserBankAccounts> UserBankAccounts { get; set; } = new HashSet<UserBankAccounts>();

        public ICollection<AllowDomains> AllowDomains { get; set; } = new HashSet<AllowDomains>();

        public ICollection<IssuedInvoices> IssuedInvoices { get; set; } = new HashSet<IssuedInvoices>();

        public ICollection<BatchInvoices> BatchInvoices { get; set; } = new HashSet<BatchInvoices>();
    }
}