using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace InvoiceGenerator.Backend.Domain.Entities;

[ExcludeFromCodeCoverage]
public class AllowDomains : Entity<Guid>
{
    public Guid UserId { get; set; }

    [Required]
    [MaxLength(255)]
    public string Host { get; set; }

    public Users User { get; set; }
}