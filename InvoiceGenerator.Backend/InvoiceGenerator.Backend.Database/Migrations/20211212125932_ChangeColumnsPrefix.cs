﻿// <auto-generated />
using Microsoft.EntityFrameworkCore.Migrations;

namespace InvoiceGenerator.Backend.Database.Migrations
{
    public partial class ChangeColumnsPrefix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CompanyVatNumber",
                table: "BatchInvoices",
                newName: "CustomerVatNumber");

            migrationBuilder.RenameColumn(
                name: "CompanyName",
                table: "BatchInvoices",
                newName: "CustomerName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CustomerVatNumber",
                table: "BatchInvoices",
                newName: "CompanyVatNumber");

            migrationBuilder.RenameColumn(
                name: "CustomerName",
                table: "BatchInvoices",
                newName: "CompanyName");
        }
    }
}