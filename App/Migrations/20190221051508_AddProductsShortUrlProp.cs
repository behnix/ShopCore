using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Migrations
{
    public partial class AddProductsShortUrlProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Sales",
                table: "Products",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ShortUrl",
                table: "Products",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sales",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ShortUrl",
                table: "Products");
        }
    }
}
