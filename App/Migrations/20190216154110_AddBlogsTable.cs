using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Migrations
{
    public partial class AddBlogsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Faqs",
                columns: table => new
                {
                    FaqId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FaqQuestion = table.Column<string>(maxLength: 500, nullable: false),
                    FaqAnswer = table.Column<string>(nullable: true),
                    FaqIsPublished = table.Column<bool>(nullable: false),
                    FaqName = table.Column<string>(maxLength: 100, nullable: false),
                    FaqEmail = table.Column<string>(maxLength: 100, nullable: true),
                    FaqLike = table.Column<int>(nullable: false),
                    FaqDateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faqs", x => x.FaqId);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    GroupId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GroupTitle = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.GroupId);
                });

            migrationBuilder.CreateTable(
                name: "Pages",
                columns: table => new
                {
                    PageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PageTitle = table.Column<string>(nullable: false),
                    PageTitleInBrowser = table.Column<string>(maxLength: 100, nullable: false),
                    PageDescriptionForSearchEngines = table.Column<string>(maxLength: 150, nullable: false),
                    PageContent = table.Column<string>(nullable: true),
                    PageCreateDate = table.Column<DateTime>(nullable: false),
                    PageUpdateDate = table.Column<DateTime>(nullable: true),
                    PageVisit = table.Column<int>(nullable: false),
                    PageShortUrl = table.Column<string>(nullable: true),
                    RelatedPostGroup = table.Column<int>(nullable: false),
                    QuantityPostInPage = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pages", x => x.PageId);
                });

            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    SettingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SiteName = table.Column<string>(maxLength: 120, nullable: false),
                    SiteDescription = table.Column<string>(maxLength: 160, nullable: false),
                    SiteTel = table.Column<string>(maxLength: 100, nullable: true),
                    SiteAddress = table.Column<string>(maxLength: 500, nullable: true),
                    SiteEmail = table.Column<string>(nullable: false),
                    SiteEmailPassword = table.Column<string>(maxLength: 100, nullable: true),
                    SiteSmtp = table.Column<string>(maxLength: 100, nullable: true),
                    SiteSmsNumber = table.Column<string>(maxLength: 100, nullable: true),
                    SiteSmsSigniture = table.Column<string>(maxLength: 100, nullable: true),
                    SiteTelegramId = table.Column<string>(maxLength: 100, nullable: true),
                    SiteInstagramId = table.Column<string>(maxLength: 100, nullable: true),
                    SiteTwitterId = table.Column<string>(maxLength: 100, nullable: true),
                    SiteFacebookId = table.Column<string>(maxLength: 100, nullable: true),
                    SiteCopyRightText = table.Column<string>(maxLength: 300, nullable: false),
                    AboutUs = table.Column<string>(nullable: true),
                    Index = table.Column<string>(nullable: true),
                    Slogan1 = table.Column<string>(maxLength: 300, nullable: false),
                    Slogan2 = table.Column<string>(maxLength: 300, nullable: false),
                    Service1 = table.Column<string>(maxLength: 100, nullable: false),
                    Service1Icon = table.Column<string>(nullable: false),
                    Service1Description = table.Column<string>(maxLength: 300, nullable: false),
                    Service2 = table.Column<string>(maxLength: 100, nullable: false),
                    Service2Icon = table.Column<string>(nullable: false),
                    Service2Description = table.Column<string>(maxLength: 300, nullable: false),
                    Service3 = table.Column<string>(maxLength: 100, nullable: false),
                    Service3Icon = table.Column<string>(nullable: false),
                    Service3Description = table.Column<string>(maxLength: 300, nullable: false),
                    Service4 = table.Column<string>(maxLength: 100, nullable: false),
                    Service4Icon = table.Column<string>(nullable: false),
                    Service4Description = table.Column<string>(maxLength: 300, nullable: false),
                    ContactTitle = table.Column<string>(maxLength: 120, nullable: true),
                    ContactDescription = table.Column<string>(maxLength: 160, nullable: true),
                    FaqTitle = table.Column<string>(maxLength: 120, nullable: true),
                    FaqDescription = table.Column<string>(maxLength: 160, nullable: true),
                    AboutUsTitle = table.Column<string>(maxLength: 120, nullable: true),
                    FaqText = table.Column<string>(nullable: true),
                    AboutUsDescription = table.Column<string>(maxLength: 160, nullable: true),
                    SiteNameInEnglish = table.Column<string>(nullable: true),
                    QuantityPostInIndex = table.Column<int>(nullable: false),
                    SmtpPort = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.SettingId);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    TagId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TagTitle = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.TagId);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    PostId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GroupId = table.Column<int>(nullable: false),
                    PostTitle = table.Column<string>(maxLength: 150, nullable: true),
                    PostTitleInBrowser = table.Column<string>(maxLength: 65, nullable: false),
                    PostDescription = table.Column<string>(maxLength: 500, nullable: true),
                    PostDescriptionForSearchEngines = table.Column<string>(maxLength: 155, nullable: false),
                    PostContent = table.Column<string>(nullable: true),
                    PostCreationDate = table.Column<DateTime>(nullable: false),
                    PostUpdateDate = table.Column<DateTime>(nullable: true),
                    PostVisit = table.Column<int>(nullable: false),
                    PostSource = table.Column<string>(maxLength: 300, nullable: true),
                    PostImage = table.Column<string>(maxLength: 200, nullable: true),
                    Author = table.Column<int>(nullable: false),
                    IsPublished = table.Column<bool>(nullable: false),
                    ShortUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.PostId);
                    table.ForeignKey(
                        name: "FK_Posts_Users_Author",
                        column: x => x.Author,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Posts_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostTags",
                columns: table => new
                {
                    PostTagId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PostId = table.Column<int>(nullable: false),
                    TagId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostTags", x => x.PostTagId);
                    table.ForeignKey(
                        name: "FK_PostTags_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "PostId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostTags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "TagId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_Author",
                table: "Posts",
                column: "Author");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_GroupId",
                table: "Posts",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_PostTags_PostId",
                table: "PostTags",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_PostTags_TagId",
                table: "PostTags",
                column: "TagId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Faqs");

            migrationBuilder.DropTable(
                name: "Pages");

            migrationBuilder.DropTable(
                name: "PostTags");

            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Groups");
        }
    }
}
