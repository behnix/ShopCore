using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Migrations
{
    public partial class AddSlidersTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sliders",
                columns: table => new
                {
                    SliderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SliderName = table.Column<string>(maxLength: 100, nullable: false),
                    SliderImage = table.Column<string>(maxLength: 200, nullable: false),
                    SliderTitle1 = table.Column<string>(maxLength: 50, nullable: true),
                    SliderTitle2 = table.Column<string>(maxLength: 50, nullable: true),
                    SliderTitle3 = table.Column<string>(maxLength: 50, nullable: true),
                    SliderButtonText = table.Column<string>(maxLength: 50, nullable: true),
                    SliderButtonLink = table.Column<string>(maxLength: 200, nullable: true),
                    SliderType = table.Column<byte>(nullable: false),
                    SliderStartTime = table.Column<DateTime>(nullable: false),
                    SliderEndTime = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sliders", x => x.SliderId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sliders");
        }
    }
}
