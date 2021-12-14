﻿// <auto-generated />
using System;
using InvoiceGenerator.Backend.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace InvoiceGenerator.Backend.Database.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20211213102045_RenameCountryCodesColumn")]
    partial class RenameCountryCodesColumn
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("InvoiceGenerator.Backend.Domain.Entities.AllowDomains", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Host")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AllowDomains");
                });

            modelBuilder.Entity("InvoiceGenerator.Backend.Domain.Entities.BatchInvoiceItems", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BatchInvoiceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CurrencyCode")
                        .HasColumnType("int");

                    b.Property<decimal>("GrossAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ItemAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("ItemDiscountRate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ItemQuantity")
                        .HasColumnType("int");

                    b.Property<string>("ItemQuantityUnit")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("ItemText")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<decimal>("ValueAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("VatRate")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("BatchInvoiceId");

                    b.ToTable("BatchInvoiceItems");
                });

            modelBuilder.Entity("InvoiceGenerator.Backend.Domain.Entities.BatchInvoices", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("CountryCode")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("CustomerVatNumber")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("InvoiceNumber")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("InvoiceTemplateName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("ModifiedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("PaymentTerms")
                        .HasColumnType("int");

                    b.Property<int>("PaymentType")
                        .HasColumnType("int");

                    b.Property<string>("PostalArea")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<Guid>("ProcessBatchKey")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("StreetAddress")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<Guid>("UserBankDataId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserDetailId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ValueDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("VoucherDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ProcessBatchKey");

                    b.HasIndex("UserBankDataId");

                    b.HasIndex("UserDetailId");

                    b.HasIndex("UserId");

                    b.ToTable("BatchInvoices");
                });

            modelBuilder.Entity("InvoiceGenerator.Backend.Domain.Entities.BatchInvoicesProcessing", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<TimeSpan?>("BatchProcessingTime")
                        .HasColumnType("time");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("BatchInvoicesProcessing");
                });

            modelBuilder.Entity("InvoiceGenerator.Backend.Domain.Entities.InvoiceTemplates", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ContentType")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<byte[]>("Data")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<DateTime>("GeneratedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("ShortDescription")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("InvoiceTemplates");
                });

            modelBuilder.Entity("InvoiceGenerator.Backend.Domain.Entities.IssuedInvoices", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ContentType")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("GeneratedAt")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("InvoiceData")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("InvoiceNumber")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("IssuedInvoices");
                });

            modelBuilder.Entity("InvoiceGenerator.Backend.Domain.Entities.UserBankData", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AccountNumber")
                        .IsRequired()
                        .HasMaxLength(28)
                        .HasColumnType("nvarchar(28)");

                    b.Property<string>("BankName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("SwiftNumber")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserBankData");
                });

            modelBuilder.Entity("InvoiceGenerator.Backend.Domain.Entities.UserDetails", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("CompanyName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("CountryCode")
                        .HasColumnType("int");

                    b.Property<int>("CurrencyCode")
                        .HasColumnType("int");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<string>("StreetAddress")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("VatNumber")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserDetails");
                });

            modelBuilder.Entity("InvoiceGenerator.Backend.Domain.Entities.Users", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsActivated")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PrivateKey")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("Registered")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserAlias")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("InvoiceGenerator.Backend.Domain.Entities.VatNumberPatterns", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CountryCode")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<string>("Pattern")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("VatNumberPatterns");
                });

            modelBuilder.Entity("InvoiceGenerator.Backend.Domain.Entities.AllowDomains", b =>
                {
                    b.HasOne("InvoiceGenerator.Backend.Domain.Entities.Users", "User")
                        .WithMany("AllowDomains")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_AllowDomains_User")
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("InvoiceGenerator.Backend.Domain.Entities.BatchInvoiceItems", b =>
                {
                    b.HasOne("InvoiceGenerator.Backend.Domain.Entities.BatchInvoices", "BatchInvoices")
                        .WithMany("BatchInvoiceItems")
                        .HasForeignKey("BatchInvoiceId")
                        .HasConstraintName("FK_BatchInvoiceItems_BatchInvoices")
                        .IsRequired();

                    b.Navigation("BatchInvoices");
                });

            modelBuilder.Entity("InvoiceGenerator.Backend.Domain.Entities.BatchInvoices", b =>
                {
                    b.HasOne("InvoiceGenerator.Backend.Domain.Entities.BatchInvoicesProcessing", "BatchInvoicesProcessing")
                        .WithMany("BatchInvoices")
                        .HasForeignKey("ProcessBatchKey")
                        .HasConstraintName("FK_BatchInvoices_BatchInvoicesProcessing")
                        .IsRequired();

                    b.HasOne("InvoiceGenerator.Backend.Domain.Entities.UserBankData", "UserBankData")
                        .WithMany("BatchInvoices")
                        .HasForeignKey("UserBankDataId")
                        .HasConstraintName("FK_BatchInvoices_UserBankData")
                        .IsRequired();

                    b.HasOne("InvoiceGenerator.Backend.Domain.Entities.UserDetails", "UserDetails")
                        .WithMany("BatchInvoices")
                        .HasForeignKey("UserDetailId")
                        .HasConstraintName("FK_BatchInvoices_UserDetails")
                        .IsRequired();

                    b.HasOne("InvoiceGenerator.Backend.Domain.Entities.Users", "Users")
                        .WithMany("BatchInvoices")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_BatchInvoices_Users")
                        .IsRequired();

                    b.Navigation("BatchInvoicesProcessing");

                    b.Navigation("UserBankData");

                    b.Navigation("UserDetails");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("InvoiceGenerator.Backend.Domain.Entities.IssuedInvoices", b =>
                {
                    b.HasOne("InvoiceGenerator.Backend.Domain.Entities.Users", "User")
                        .WithMany("IssuedInvoices")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("InvoiceGenerator.Backend.Domain.Entities.UserBankData", b =>
                {
                    b.HasOne("InvoiceGenerator.Backend.Domain.Entities.Users", "User")
                        .WithMany("UserBankData")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("InvoiceGenerator.Backend.Domain.Entities.UserDetails", b =>
                {
                    b.HasOne("InvoiceGenerator.Backend.Domain.Entities.Users", "User")
                        .WithMany("UserDetails")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("InvoiceGenerator.Backend.Domain.Entities.BatchInvoices", b =>
                {
                    b.Navigation("BatchInvoiceItems");
                });

            modelBuilder.Entity("InvoiceGenerator.Backend.Domain.Entities.BatchInvoicesProcessing", b =>
                {
                    b.Navigation("BatchInvoices");
                });

            modelBuilder.Entity("InvoiceGenerator.Backend.Domain.Entities.UserBankData", b =>
                {
                    b.Navigation("BatchInvoices");
                });

            modelBuilder.Entity("InvoiceGenerator.Backend.Domain.Entities.UserDetails", b =>
                {
                    b.Navigation("BatchInvoices");
                });

            modelBuilder.Entity("InvoiceGenerator.Backend.Domain.Entities.Users", b =>
                {
                    b.Navigation("AllowDomains");

                    b.Navigation("BatchInvoices");

                    b.Navigation("IssuedInvoices");

                    b.Navigation("UserBankData");

                    b.Navigation("UserDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
