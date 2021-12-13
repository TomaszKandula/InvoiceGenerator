namespace InvoiceGenerator.Backend.Database.Mappings
{
    using System.Diagnostics.CodeAnalysis;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Domain.Entities;

    [ExcludeFromCodeCoverage]
    public class UserCompaniesConfiguration : IEntityTypeConfiguration<UserCompanies>
    {
        public void Configure(EntityTypeBuilder<UserCompanies> builder)
            => builder.Property(userCompanies => userCompanies.Id).ValueGeneratedOnAdd();
    }
}