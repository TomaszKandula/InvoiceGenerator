using System.Diagnostics.CodeAnalysis;
using InvoiceGenerator.Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvoiceGenerator.Backend.Database.Mappings;

[ExcludeFromCodeCoverage]
public class AllowDomainsConfiguration : IEntityTypeConfiguration<AllowDomains>
{
    public void Configure(EntityTypeBuilder<AllowDomains> builder)
    {
        builder.Property(allowDomain => allowDomain.Id).ValueGeneratedOnAdd();

        builder
            .HasOne(allowDomain => allowDomain.User)
            .WithMany(user => user.AllowDomains)
            .HasForeignKey(allowDomain => allowDomain.UserId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_AllowDomains_User");
    }
}