namespace InvoiceGenerator.Backend.Database.Mappings
{
    using System.Diagnostics.CodeAnalysis;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Domain.Entities;

    [ExcludeFromCodeCoverage]
    public class UserBankAccountsConfiguration : IEntityTypeConfiguration<UserBankAccounts>
    {
        public void Configure(EntityTypeBuilder<UserBankAccounts> builder)
            => builder.Property(accounts => accounts.Id).ValueGeneratedOnAdd();
    }
}