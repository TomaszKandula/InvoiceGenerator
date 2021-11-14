namespace InvoiceGenerator.Backend.Database
{
    using System.Reflection;
    using System.Diagnostics.CodeAnalysis;
    using Microsoft.EntityFrameworkCore;
    using Domain.Entities;

    [ExcludeFromCodeCoverage]
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public virtual DbSet<Users> Users { get; set; }

        public virtual DbSet<UserDetails> UserDetails { get; set; }

        public virtual DbSet<AllowDomains> AllowDomains { get; set; }

        public virtual DbSet<VatNumberPatterns> VatNumberPatterns { get; set; }

        public virtual DbSet<IssuedInvoices> IssuedInvoices { get; set; }

        public virtual DbSet<BatchInvoices> BatchInvoices { get; set; }

        public virtual DbSet<BatchInvoiceItems> BatchInvoiceItems { get; set; }

        public virtual DbSet<BatchInvoicesProcessing> BatchInvoicesProcessing { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            ApplyConfiguration(modelBuilder);
        }

        private static void ApplyConfiguration(ModelBuilder modelBuilder) 
            => modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}