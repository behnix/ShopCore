using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Migrations
{
    public partial class GeneratedKeyInUsersTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GeneratedKey",
                table: "Users",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GeneratedKey",
                table: "Users");
        }
    }
}
