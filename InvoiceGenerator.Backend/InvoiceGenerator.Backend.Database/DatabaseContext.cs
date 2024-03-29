﻿using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using InvoiceGenerator.Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace InvoiceGenerator.Backend.Database;

[ExcludeFromCodeCoverage]
public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

    public virtual DbSet<Users> Users { get; set; }

    public virtual DbSet<UserCompanies> UserCompanies { get; set; }

    public virtual DbSet<UserBankAccounts> UserBankAccounts { get; set; }

    public virtual DbSet<AllowDomains> AllowDomains { get; set; }

    public virtual DbSet<VatNumberPatterns> VatNumberPatterns { get; set; }

    public virtual DbSet<IssuedInvoices> IssuedInvoices { get; set; }

    public virtual DbSet<BatchInvoices> BatchInvoices { get; set; }

    public virtual DbSet<BatchInvoiceItems> BatchInvoiceItems { get; set; }

    public virtual DbSet<BatchInvoicesProcessing> BatchInvoicesProcessing { get; set; }

    public virtual DbSet<InvoiceTemplates> InvoiceTemplates { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        ApplyConfiguration(modelBuilder);
    }

    private static void ApplyConfiguration(ModelBuilder modelBuilder) 
        => modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
}