using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Migrations
{
    public partial class RemoveProductIdPropToConfigDetailsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "ConfigDetails",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_ConfigDetails_ProductId",
                table: "ConfigDetails",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ConfigDetails_Products_ProductId",
                table: "ConfigDetails",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConfigDetails_Products_ProductId",
                table: "ConfigDetails");

            migrationBuilder.DropIndex(
                name: "IX_ConfigDetails_ProductId",
                table: "ConfigDetails");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "ConfigDetails",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
