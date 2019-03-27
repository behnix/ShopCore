using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Migrations
{
    public partial class AddImageAndDescriptionForProducsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Products_ProductId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_ProductId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "PriceCoworkerPromotion",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "TempPrice",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "TempPriceCoworker",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "DateTime",
                table: "Products",
                newName: "CreatedOn");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Products",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "MetaTitle",
                table: "Products",
                maxLength: 65,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "MetaDescription",
                table: "Products",
                maxLength: 155,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Products",
                maxLength: 1000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Products",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "CreatedOn",
                table: "Products",
                newName: "DateTime");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Products",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "MetaTitle",
                table: "Products",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 65);

            migrationBuilder.AlterColumn<string>(
                name: "MetaDescription",
                table: "Products",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 155);

            migrationBuilder.AddColumn<long>(
                name: "PriceCoworkerPromotion",
                table: "Products",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "TempPrice",
                table: "Products",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "TempPriceCoworker",
                table: "Products",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Images_ProductId",
                table: "Images",
                column: "ProductId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Products_ProductId",
                table: "Images",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
