namespace InvoiceGenerator.Backend.Database.Mappings
{
    using System.Diagnostics.CodeAnalysis;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Domain.Entities;

    [ExcludeFromCodeCoverage]
    public class BatchInvoicesProcessingConfiguration : IEntityTypeConfiguration<BatchInvoicesProcessing>
    {
        public void Configure(EntityTypeBuilder<BatchInvoicesProcessing> builder)
        {
            builder.Property(processing => processing.Id).ValueGeneratedOnAdd();

            builder
                .HasOne(processing => processing.BatchInvoices)
                .WithMany(invoices => invoices.BatchInvoicesProcessing)
                .HasForeignKey(processing => processing.ProcessBatchKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BatchInvoicesProcessing_BatchInvoices");
        }
    }
}