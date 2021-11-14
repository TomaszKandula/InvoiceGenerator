namespace InvoiceGenerator.Backend.Database.Mappings
{
    using System.Diagnostics.CodeAnalysis;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Domain.Entities;

    [ExcludeFromCodeCoverage]
    public class IssuedInvoicesConfiguration : IEntityTypeConfiguration<IssuedInvoices>
    {
        public void Configure(EntityTypeBuilder<IssuedInvoices> builder)
            => builder.Property(invoices => invoices.Id).ValueGeneratedOnAdd();
    }
}