namespace InvoiceGenerator.Backend.Database.Mappings;

using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;

[ExcludeFromCodeCoverage]
public class BatchInvoicesProcessingConfiguration : IEntityTypeConfiguration<BatchInvoicesProcessing>
{
    public void Configure(EntityTypeBuilder<BatchInvoicesProcessing> builder)
        => builder.Property(processing => processing.Id).ValueGeneratedOnAdd();
}