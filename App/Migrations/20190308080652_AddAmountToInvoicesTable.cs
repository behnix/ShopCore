﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Migrations
{
    public partial class AddAmountToInvoicesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "Amount",
                table: "Invoices",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Invoices");
        }
    }
}
