using System.Diagnostics.CodeAnalysis;
using InvoiceGenerator.Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvoiceGenerator.Backend.Database.Mappings;

[ExcludeFromCodeCoverage]
public class BatchInvoiceItemsConfiguration : IEntityTypeConfiguration<BatchInvoiceItems>
{
    public void Configure(EntityTypeBuilder<BatchInvoiceItems> builder)
    {
        builder.Property(items => items.Id).ValueGeneratedOnAdd();

        builder
            .HasOne(items => items.BatchInvoices)
            .WithMany(invoices => invoices.BatchInvoiceItems)
            .HasForeignKey(items => items.BatchInvoiceId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_BatchInvoiceItems_BatchInvoices");
    }
}