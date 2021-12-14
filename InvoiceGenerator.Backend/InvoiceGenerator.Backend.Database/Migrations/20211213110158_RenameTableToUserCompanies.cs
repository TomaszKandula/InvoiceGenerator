﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InvoiceGenerator.Backend.Database.Migrations
{
    public partial class RenameTableToUserCompanies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BatchInvoices_UserDetails",
                table: "BatchInvoices");

            migrationBuilder.DropTable(
                name: "UserDetails");

            migrationBuilder.RenameColumn(
                name: "UserDetailId",
                table: "BatchInvoices",
                newName: "UserCompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_BatchInvoices_UserDetailId",
                table: "BatchInvoices",
                newName: "IX_BatchInvoices_UserCompanyId");

            migrationBuilder.CreateTable(
                name: "UserCompanies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    VatNumber = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    StreetAddress = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    City = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CurrencyCode = table.Column<int>(type: "int", nullable: false),
                    CountryCode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCompanies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserCompanies_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserCompanies_UserId",
                table: "UserCompanies",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BatchInvoices_UserCompanies",
                table: "BatchInvoices",
                column: "UserCompanyId",
                principalTable: "UserCompanies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BatchInvoices_UserCompanies",
                table: "BatchInvoices");

            migrationBuilder.DropTable(
                name: "UserCompanies");

            migrationBuilder.RenameColumn(
                name: "UserCompanyId",
                table: "BatchInvoices",
                newName: "UserDetailId");

            migrationBuilder.RenameIndex(
                name: "IX_BatchInvoices_UserCompanyId",
                table: "BatchInvoices",
                newName: "IX_BatchInvoices_UserDetailId");

            migrationBuilder.CreateTable(
                name: "UserDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    City = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CountryCode = table.Column<int>(type: "int", nullable: false),
                    CurrencyCode = table.Column<int>(type: "int", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    StreetAddress = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VatNumber = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserDetails_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserDetails_UserId",
                table: "UserDetails",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BatchInvoices_UserDetails",
                table: "BatchInvoices",
                column: "UserDetailId",
                principalTable: "UserDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
