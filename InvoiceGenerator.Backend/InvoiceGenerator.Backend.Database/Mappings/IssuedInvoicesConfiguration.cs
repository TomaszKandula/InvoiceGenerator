using System.Diagnostics.CodeAnalysis;
using InvoiceGenerator.Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvoiceGenerator.Backend.Database.Mappings;

[ExcludeFromCodeCoverage]
public class IssuedInvoicesConfiguration : IEntityTypeConfiguration<IssuedInvoices>
{
    public void Configure(EntityTypeBuilder<IssuedInvoices> builder)
        => builder.Property(invoices => invoices.Id).ValueGeneratedOnAdd();
}