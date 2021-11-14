namespace InvoiceGenerator.Backend.Domain.Entities
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [ExcludeFromCodeCoverage]
    public class InvoiceTemplates : Entity<Guid>
    {
        [Required]
        public string TemplateName { get; set; }

        [Required]
        [Column(TypeName = "varbinary(max)")]
        public byte[] TemplateData { get; set; }

        [Required]
        public string ContentType { get; set; }

        [Required]
        [MaxLength(100)]
        public string ShortDescription { get; set; }

        [Required]
        public DateTime GeneratedAt { get; set; }
    }
}