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
        [MaxLength(255)]
        public string InvoiceNumber { get; set; }

        [Required]
        [Column(TypeName = "varbinary(8000)")]
        public byte[] InvoiceData { get; set; }

        [Required]
        [MaxLength(100)]
        public string ContentType { get; set; }

        [Required]
        public DateTime GeneratedAt { get; set; }

        public Users User { get; set; }
    }
}