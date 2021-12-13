namespace InvoiceGenerator.Backend.Database.Mappings
{
    using System.Diagnostics.CodeAnalysis;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Domain.Entities;

    [ExcludeFromCodeCoverage]
    public class BatchInvoicesConfiguration : IEntityTypeConfiguration<BatchInvoices>
    {
        public void Configure(EntityTypeBuilder<BatchInvoices> builder)
        {
            builder.Property(invoices => invoices.Id).ValueGeneratedOnAdd();

            builder
                .HasOne(invoices => invoices.BatchInvoicesProcessing)
                .WithMany(processing => processing.BatchInvoices)
                .HasForeignKey(invoices => invoices.ProcessBatchKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BatchInvoices_BatchInvoicesProcessing");

            builder
                .HasOne(invoices => invoices.Users)
                .WithMany(users => users.BatchInvoices)
                .HasForeignKey(invoices => invoices.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BatchInvoices_Users");

            builder
                .HasOne(invoices => invoices.UserDetails)
                .WithMany(details => details.BatchInvoices)
                .HasForeignKey(invoices => invoices.UserDetailId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BatchInvoices_UserDetails");

            builder
                .HasOne(invoices => invoices.UserBankAccounts)
                .WithMany(bankData => bankData.BatchInvoices)
                .HasForeignKey(invoices => invoices.UserBankAccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BatchInvoices_UserBankAccount");
        }
    }
}