using System.Diagnostics.CodeAnalysis;
using InvoiceGenerator.Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvoiceGenerator.Backend.Database.Mappings;

[ExcludeFromCodeCoverage]
public class UserCompaniesConfiguration : IEntityTypeConfiguration<UserCompanies>
{
    public void Configure(EntityTypeBuilder<UserCompanies> builder)
        => builder.Property(userCompanies => userCompanies.Id).ValueGeneratedOnAdd();
}