﻿// <auto-generated />
using System;
using App.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace App.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190307083122_AddInvoicesTable")]
    partial class AddInvoicesTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("App.Domain.Entities.Faq.Faq", b =>
                {
                    b.Property<int>("FaqId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FaqAnswer");

                    b.Property<DateTime>("FaqDateTime");

                    b.Property<string>("FaqEmail")
                        .HasMaxLength(100);

                    b.Property<bool>("FaqIsPublished");

                    b.Property<int>("FaqLike");

                    b.Property<string>("FaqName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("FaqQuestion")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.HasKey("FaqId");

                    b.ToTable("Faqs");
                });

            modelBuilder.Entity("App.Domain.Entities.Invoice.Invoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CId");

                    b.Property<string>("CostumerAddress");

                    b.Property<string>("CostumerEmail");

                    b.Property<string>("CostumerName");

                    b.Property<string>("CostumerPhone");

                    b.Property<string>("EconomyCode");

                    b.Property<DateTime>("FactoredOn");

                    b.Property<bool>("IsOfficial");

                    b.Property<string>("MessageSent");

                    b.Property<string>("Name");

                    b.Property<string>("NationCode");

                    b.Property<bool>("Purchased");

                    b.Property<string>("RefNum");

                    b.Property<string>("SecurePan");

                    b.Property<string>("State");

                    b.Property<string>("StateCode");

                    b.Property<string>("TransactionNo");

                    b.Property<bool>("Transported");

                    b.Property<string>("UserId");

                    b.Property<string>("ZipCode");

                    b.HasKey("Id");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("App.Domain.Entities.Invoice.InvoiceDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("InvoiceId");

                    b.Property<decimal>("Price");

                    b.Property<int>("ProductId");

                    b.Property<int>("Quantity");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("InvoiceDetails");
                });

            modelBuilder.Entity("App.Domain.Entities.Page.Page", b =>
                {
                    b.Property<int>("PageId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PageContent");

                    b.Property<DateTime>("PageCreateDate");

                    b.Property<string>("PageDescriptionForSearchEngines")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<string>("PageShortUrl");

                    b.Property<string>("PageTitle")
                        .IsRequired();

                    b.Property<string>("PageTitleInBrowser")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<DateTime?>("PageUpdateDate");

                    b.Property<int>("PageVisit");

                    b.Property<int>("QuantityPostInPage");

                    b.Property<int>("RelatedPostGroup");

                    b.HasKey("PageId");

                    b.ToTable("Pages");
                });

            modelBuilder.Entity("App.Domain.Entities.Post.Group", b =>
                {
                    b.Property<int>("GroupId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GroupTitle")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("GroupId");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("App.Domain.Entities.Post.Post", b =>
                {
                    b.Property<int>("PostId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Author");

                    b.Property<int>("GroupId");

                    b.Property<bool>("IsPublished");

                    b.Property<string>("PostContent");

                    b.Property<DateTime>("PostCreationDate");

                    b.Property<string>("PostDescription")
                        .HasMaxLength(500);

                    b.Property<string>("PostDescriptionForSearchEngines")
                        .IsRequired()
                        .HasMaxLength(155);

                    b.Property<string>("PostImage")
                        .HasMaxLength(200);

                    b.Property<string>("PostSource")
                        .HasMaxLength(300);

                    b.Property<string>("PostTitle")
                        .HasMaxLength(150);

                    b.Property<string>("PostTitleInBrowser")
                        .IsRequired()
                        .HasMaxLength(65);

                    b.Property<DateTime?>("PostUpdateDate");

                    b.Property<int>("PostVisit");

                    b.Property<string>("ShortUrl");

                    b.HasKey("PostId");

                    b.HasIndex("Author");

                    b.HasIndex("GroupId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("App.Domain.Entities.Post.PostTag", b =>
                {
                    b.Property<int>("PostTagId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PostId");

                    b.Property<int>("TagId");

                    b.HasKey("PostTagId");

                    b.HasIndex("PostId");

                    b.HasIndex("TagId");

                    b.ToTable("PostTags");
                });

            modelBuilder.Entity("App.Domain.Entities.Post.Tag", b =>
                {
                    b.Property<int>("TagId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TagTitle")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("TagId");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("App.Domain.Entities.Product.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EnName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Logo");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("App.Domain.Entities.Product.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryImage");

                    b.Property<string>("EnName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("ParentId");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("App.Domain.Entities.Product.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CommentedOn");

                    b.Property<string>("Content")
                        .HasMaxLength(2000);

                    b.Property<bool>("IsConfirmed");

                    b.Property<int>("ProductId");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("App.Domain.Entities.Product.ConfigChart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId");

                    b.Property<string>("ConfigDescription");

                    b.Property<string>("ConfigDescriptionComplete");

                    b.Property<int>("ConfigGroupId");

                    b.Property<string>("FilterType");

                    b.Property<string>("Name");

                    b.Property<int>("Order");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ConfigGroupId");

                    b.ToTable("ConfigCharts");
                });

            modelBuilder.Entity("App.Domain.Entities.Product.ConfigDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ConfigChartId");

                    b.Property<int>("ConfigGroupId");

                    b.Property<int>("ProductId");

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.HasIndex("ConfigChartId");

                    b.ToTable("ConfigDetails");
                });

            modelBuilder.Entity("App.Domain.Entities.Product.ConfigGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId");

                    b.Property<string>("Name");

                    b.Property<int>("Order");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("ConfigGroups");
                });

            modelBuilder.Entity("App.Domain.Entities.Product.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ImageOrder");

                    b.Property<string>("Name");

                    b.Property<int>("ProductId");

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("App.Domain.Entities.Product.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BrandId");

                    b.Property<int>("CategoryId");

                    b.Property<bool>("CommentOn");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000);

                    b.Property<string>("Guarantee");

                    b.Property<string>("Image");

                    b.Property<int>("Like");

                    b.Property<string>("MetaDescription")
                        .IsRequired()
                        .HasMaxLength(155);

                    b.Property<string>("MetaTitle")
                        .IsRequired()
                        .HasMaxLength(65);

                    b.Property<string>("Model");

                    b.Property<long>("Price");

                    b.Property<long>("PriceCoworker");

                    b.Property<long>("PricePromotion");

                    b.Property<bool>("Published");

                    b.Property<int>("Sales");

                    b.Property<string>("ShortUrl");

                    b.Property<bool>("Status");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int>("Visit");

                    b.HasKey("ProductId");

                    b.HasIndex("BrandId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("App.Domain.Entities.Setting.Setting", b =>
                {
                    b.Property<int>("SettingId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AboutUs");

                    b.Property<string>("AboutUsDescription")
                        .HasMaxLength(155);

                    b.Property<string>("AboutUsTitle")
                        .HasMaxLength(65);

                    b.Property<string>("ContactDescription")
                        .HasMaxLength(155);

                    b.Property<string>("ContactTitle")
                        .HasMaxLength(65);

                    b.Property<string>("ContactWorkHour")
                        .HasMaxLength(100);

                    b.Property<string>("FaqDescription")
                        .HasMaxLength(155);

                    b.Property<string>("FaqText");

                    b.Property<string>("FaqTitle")
                        .HasMaxLength(65);

                    b.Property<string>("Index");

                    b.Property<int>("QuantityPostInIndex");

                    b.Property<string>("Service1")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Service1Description")
                        .IsRequired()
                        .HasMaxLength(300);

                    b.Property<string>("Service1Icon")
                        .IsRequired();

                    b.Property<string>("Service2")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Service2Description")
                        .IsRequired()
                        .HasMaxLength(300);

                    b.Property<string>("Service2Icon")
                        .IsRequired();

                    b.Property<string>("Service3")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Service3Description")
                        .IsRequired()
                        .HasMaxLength(300);

                    b.Property<string>("Service3Icon")
                        .IsRequired();

                    b.Property<string>("Service4")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Service4Description")
                        .IsRequired()
                        .HasMaxLength(300);

                    b.Property<string>("Service4Icon")
                        .IsRequired();

                    b.Property<string>("SiteAddress")
                        .HasMaxLength(500);

                    b.Property<string>("SiteCopyRightText")
                        .IsRequired()
                        .HasMaxLength(300);

                    b.Property<string>("SiteDescription")
                        .IsRequired()
                        .HasMaxLength(155);

                    b.Property<string>("SiteEmail")
                        .IsRequired();

                    b.Property<string>("SiteEmailPassword")
                        .HasMaxLength(100);

                    b.Property<string>("SiteFacebookId")
                        .HasMaxLength(100);

                    b.Property<string>("SiteInstagramId")
                        .HasMaxLength(100);

                    b.Property<string>("SiteName")
                        .IsRequired()
                        .HasMaxLength(65);

                    b.Property<string>("SiteNameInEnglish");

                    b.Property<string>("SiteSmsNumber")
                        .HasMaxLength(100);

                    b.Property<string>("SiteSmsSigniture")
                        .HasMaxLength(100);

                    b.Property<string>("SiteSmtp")
                        .HasMaxLength(100);

                    b.Property<string>("SiteTel")
                        .HasMaxLength(100);

                    b.Property<string>("SiteTelegramId")
                        .HasMaxLength(100);

                    b.Property<string>("SiteTwitterId")
                        .HasMaxLength(100);

                    b.Property<string>("Slogan1")
                        .IsRequired()
                        .HasMaxLength(300);

                    b.Property<string>("Slogan2")
                        .IsRequired()
                        .HasMaxLength(300);

                    b.Property<int>("SmtpPort");

                    b.Property<string>("Terms");

                    b.Property<string>("TermsDescription")
                        .HasMaxLength(155);

                    b.Property<string>("TermsTitle")
                        .HasMaxLength(65);

                    b.HasKey("SettingId");

                    b.ToTable("Settings");
                });

            modelBuilder.Entity("App.Domain.Identity.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("DisplayName");

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("App.Domain.Identity.RoleClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<DateTime>("GivenOn");

                    b.Property<int>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleClaims");
                });

            modelBuilder.Entity("App.Domain.Identity.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccessFailedCount");

                    b.Property<int>("Age");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName");

                    b.Property<int>("Gender");

                    b.Property<string>("GeneratedKey");

                    b.Property<string>("LastName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<DateTime>("RegisteredOn");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserAvatar");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("App.Domain.Identity.UserClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserClaims");
                });

            modelBuilder.Entity("App.Domain.Identity.UserLogin", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<DateTime>("LoggedOn");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<int>("UserId");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("UserLogins");
                });

            modelBuilder.Entity("App.Domain.Identity.UserRole", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("RoleId");

                    b.Property<DateTime>("GivenOn");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("App.Domain.Identity.UserToken", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<DateTime>("GeneratedOn");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("UserTokens");
                });

            modelBuilder.Entity("App.Domain.Entities.Invoice.InvoiceDetail", b =>
                {
                    b.HasOne("App.Domain.Entities.Product.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("App.Domain.Entities.Post.Post", b =>
                {
                    b.HasOne("App.Domain.Identity.User", "User")
                        .WithMany()
                        .HasForeignKey("Author")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("App.Domain.Entities.Post.Group", "Group")
                        .WithMany("Posts")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("App.Domain.Entities.Post.PostTag", b =>
                {
                    b.HasOne("App.Domain.Entities.Post.Post", "Post")
                        .WithMany("PostTags")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("App.Domain.Entities.Post.Tag", "Tag")
                        .WithMany("PostTags")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("App.Domain.Entities.Product.Comment", b =>
                {
                    b.HasOne("App.Domain.Identity.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("App.Domain.Entities.Product.ConfigChart", b =>
                {
                    b.HasOne("App.Domain.Entities.Product.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("App.Domain.Entities.Product.ConfigGroup", "ConfigGroup")
                        .WithMany()
                        .HasForeignKey("ConfigGroupId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("App.Domain.Entities.Product.ConfigDetail", b =>
                {
                    b.HasOne("App.Domain.Entities.Product.ConfigChart", "ConfigChart")
                        .WithMany()
                        .HasForeignKey("ConfigChartId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("App.Domain.Entities.Product.Product", b =>
                {
                    b.HasOne("App.Domain.Entities.Product.Brand", "Brand")
                        .WithMany()
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("App.Domain.Entities.Product.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("App.Domain.Identity.RoleClaim", b =>
                {
                    b.HasOne("App.Domain.Identity.Role", "Role")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("App.Domain.Identity.UserClaim", b =>
                {
                    b.HasOne("App.Domain.Identity.User", "User")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("App.Domain.Identity.UserLogin", b =>
                {
                    b.HasOne("App.Domain.Identity.User", "User")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("App.Domain.Identity.UserRole", b =>
                {
                    b.HasOne("App.Domain.Identity.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("App.Domain.Identity.User", "User")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("App.Domain.Identity.UserToken", b =>
                {
                    b.HasOne("App.Domain.Identity.User", "User")
                        .WithMany("Tokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
