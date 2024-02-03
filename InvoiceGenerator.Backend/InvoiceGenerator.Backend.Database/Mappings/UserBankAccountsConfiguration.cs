using System.Diagnostics.CodeAnalysis;
using InvoiceGenerator.Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvoiceGenerator.Backend.Database.Mappings;

[ExcludeFromCodeCoverage]
public class UserBankAccountsConfiguration : IEntityTypeConfiguration<UserBankAccounts>
{
    public void Configure(EntityTypeBuilder<UserBankAccounts> builder)
        => builder.Property(accounts => accounts.Id).ValueGeneratedOnAdd();
}