namespace InvoiceGenerator.Backend.Database.Mappings
{
    using System.Diagnostics.CodeAnalysis;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Domain.Entities;

    [ExcludeFromCodeCoverage]
    public class AllowDomainConfiguration : IEntityTypeConfiguration<AllowDomains>
    {
        public void Configure(EntityTypeBuilder<AllowDomains> builder)
        {
            builder.Property(allowDomain => allowDomain.Id).ValueGeneratedOnAdd();

            builder
                .HasOne(allowDomain => allowDomain.User)
                .WithMany(user => user.AllowDomain)
                .HasForeignKey(allowDomain => allowDomain.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AllowDomains_User");
        }
    }
}