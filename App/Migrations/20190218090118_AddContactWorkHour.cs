using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Migrations
{
    public partial class AddContactWorkHour : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContactWorkHour",
                table: "Settings",
                maxLength: 100,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContactWorkHour",
                table: "Settings");
        }
    }
}
