﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InvoiceGenerator.Backend.Database.Migrations
{
    public partial class AddBatchInvoiceItemsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BatchInvoiceItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BatchInvoiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemText = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ItemQuantity = table.Column<int>(type: "int", nullable: false),
                    ItemQuantityUnit = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ItemAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ItemDiscountRate = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ValueAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VatRate = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    GrossAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CurrencyCode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BatchInvoiceItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BatchInvoiceItems_BatchInvoices",
                        column: x => x.BatchInvoiceId,
                        principalTable: "BatchInvoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BatchInvoiceItems_BatchInvoiceId",
                table: "BatchInvoiceItems",
                column: "BatchInvoiceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BatchInvoiceItems");
        }
    }
}
