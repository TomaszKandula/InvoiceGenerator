using System.Diagnostics.CodeAnalysis;
using InvoiceGenerator.Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvoiceGenerator.Backend.Database.Mappings;

[ExcludeFromCodeCoverage]
public class BatchInvoicesProcessingConfiguration : IEntityTypeConfiguration<BatchInvoicesProcessing>
{
    public void Configure(EntityTypeBuilder<BatchInvoicesProcessing> builder)
        => builder.Property(processing => processing.Id).ValueGeneratedOnAdd();
}