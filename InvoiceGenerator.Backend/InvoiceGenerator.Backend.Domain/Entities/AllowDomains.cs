namespace InvoiceGenerator.Backend.Domain.Entities;

using System;
using System.Diagnostics.CodeAnalysis;
using System.ComponentModel.DataAnnotations;

[ExcludeFromCodeCoverage]
public class AllowDomains : Entity<Guid>
{
    public Guid UserId { get; set; }

    [Required]
    [MaxLength(255)]
    public string Host { get; set; }

    public Users User { get; set; }
}