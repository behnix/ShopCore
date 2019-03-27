using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Migrations
{
    public partial class addTermsInSettingsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SiteName",
                table: "Settings",
                maxLength: 65,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 120);

            migrationBuilder.AlterColumn<string>(
                name: "SiteDescription",
                table: "Settings",
                maxLength: 155,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 160);

            migrationBuilder.AlterColumn<string>(
                name: "FaqTitle",
                table: "Settings",
                maxLength: 65,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 120,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FaqDescription",
                table: "Settings",
                maxLength: 155,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 160,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ContactTitle",
                table: "Settings",
                maxLength: 65,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 120,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ContactDescription",
                table: "Settings",
                maxLength: 155,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 160,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AboutUsTitle",
                table: "Settings",
                maxLength: 65,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 120,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AboutUsDescription",
                table: "Settings",
                maxLength: 155,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 160,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Terms",
                table: "Settings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TermsDescription",
                table: "Settings",
                maxLength: 155,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TermsTitle",
                table: "Settings",
                maxLength: 65,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Terms",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "TermsDescription",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "TermsTitle",
                table: "Settings");

            migrationBuilder.AlterColumn<string>(
                name: "SiteName",
                table: "Settings",
                maxLength: 120,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 65);

            migrationBuilder.AlterColumn<string>(
                name: "SiteDescription",
                table: "Settings",
                maxLength: 160,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 155);

            migrationBuilder.AlterColumn<string>(
                name: "FaqTitle",
                table: "Settings",
                maxLength: 120,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 65,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FaqDescription",
                table: "Settings",
                maxLength: 160,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 155,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ContactTitle",
                table: "Settings",
                maxLength: 120,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 65,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ContactDescription",
                table: "Settings",
                maxLength: 160,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 155,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AboutUsTitle",
                table: "Settings",
                maxLength: 120,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 65,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AboutUsDescription",
                table: "Settings",
                maxLength: 160,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 155,
                oldNullable: true);
        }
    }
}
