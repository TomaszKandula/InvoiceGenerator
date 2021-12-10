namespace InvoiceGenerator.Backend.Database.Mappings
{
    using System.Diagnostics.CodeAnalysis;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Domain.Entities;

    [ExcludeFromCodeCoverage]
    public class UserBankDataConfiguration : IEntityTypeConfiguration<UserBankData>
    {
        public void Configure(EntityTypeBuilder<UserBankData> builder)
            => builder.Property(userBankData => userBankData.Id).ValueGeneratedOnAdd();
    }
}