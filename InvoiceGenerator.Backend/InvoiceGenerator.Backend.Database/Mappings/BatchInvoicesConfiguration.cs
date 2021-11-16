namespace InvoiceGenerator.Backend.Database.Mappings
{
    using System.Diagnostics.CodeAnalysis;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Domain.Entities;

    [ExcludeFromCodeCoverage]
    public class BatchInvoicesConfiguration : IEntityTypeConfiguration<BatchInvoices>
    {
        public void Configure(EntityTypeBuilder<BatchInvoices> builder)
        {
            builder.Property(invoices => invoices.Id).ValueGeneratedOnAdd();

            builder
                .HasOne(invoices => invoices.BatchInvoicesProcessing)
                .WithMany(processing => processing.BatchInvoices)
                .HasForeignKey(invoices => invoices.ProcessBatchKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BatchInvoices_BatchInvoicesProcessing");
        }
    }
}