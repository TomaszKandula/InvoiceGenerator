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
            => builder.Property(user => user.Id).ValueGeneratedOnAdd();
    }
}