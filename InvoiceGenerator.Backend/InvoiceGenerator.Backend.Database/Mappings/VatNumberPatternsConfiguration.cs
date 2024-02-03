using System.Diagnostics.CodeAnalysis;
using InvoiceGenerator.Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvoiceGenerator.Backend.Database.Mappings;

[ExcludeFromCodeCoverage]
public class VatNumberPatternsConfiguration : IEntityTypeConfiguration<VatNumberPatterns>
{
    public void Configure(EntityTypeBuilder<VatNumberPatterns> builder) 
        => builder.Property(patterns => patterns.Id).ValueGeneratedOnAdd();
}