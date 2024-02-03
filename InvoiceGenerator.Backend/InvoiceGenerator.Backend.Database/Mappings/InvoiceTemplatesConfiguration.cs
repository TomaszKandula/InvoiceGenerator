using System.Diagnostics.CodeAnalysis;
using InvoiceGenerator.Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvoiceGenerator.Backend.Database.Mappings;

[ExcludeFromCodeCoverage]
public class InvoiceTemplatesConfiguration : IEntityTypeConfiguration<InvoiceTemplates>
{
    public void Configure(EntityTypeBuilder<InvoiceTemplates> builder) 
        => builder.Property(templates => templates.Id).ValueGeneratedOnAdd();
}