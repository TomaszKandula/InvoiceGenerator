namespace InvoiceGenerator.Backend.Domain.Entities
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [ExcludeFromCodeCoverage]
    public class IssuedInvoices : Entity<Guid>
    {
        [Required]
        public Guid UserId { get; set; }

        [Required]
        public string InvoiceName { get; set; }

        [Required]
        [Column(TypeName = "varbinary(max)")]
        public byte[] InvoiceData { get; set; }

        [Required]
        public string ContentType { get; set; }

        [Required]
        public DateTime GeneratedAt { get; set; }

        public Users User { get; set; }
    }
}