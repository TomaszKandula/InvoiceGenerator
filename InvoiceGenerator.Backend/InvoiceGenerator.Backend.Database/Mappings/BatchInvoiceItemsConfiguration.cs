namespace InvoiceGenerator.Backend.Database.Mappings;

using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;

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