namespace InvoiceGenerator.Backend.Database.Mappings;

using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;

[ExcludeFromCodeCoverage]
public class InvoiceTemplatesConfiguration : IEntityTypeConfiguration<InvoiceTemplates>
{
    public void Configure(EntityTypeBuilder<InvoiceTemplates> builder) 
        => builder.Property(templates => templates.Id).ValueGeneratedOnAdd();
}