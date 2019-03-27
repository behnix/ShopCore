using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Domain.Entities.Faq;
using App.Domain.Entities.Invoice;
using App.Domain.Entities.Page;
using App.Domain.Entities.Post;
using App.Domain.Entities.Product;
using App.Domain.Entities.Setting;
using App.Domain.Entities.Slider;
using App.Domain.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace App.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, int, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>(modelBuilder =>
            {
                modelBuilder.ToTable("Users");
            });

            builder.Entity<Role>(modelBuilder =>
            {
                modelBuilder.ToTable("Roles");

            });

            builder.Entity<UserClaim>(modelBuilder =>
            {
                modelBuilder.ToTable("UserClaims");

                modelBuilder
                    .HasOne(userClaim => userClaim.User)
                    .WithMany(user => user.Claims)
                    .HasForeignKey(userClaim => userClaim.UserId);
            });

            builder.Entity<UserRole>(modelBuilder =>
            {
                modelBuilder.ToTable("UserRoles");

                modelBuilder
                    .HasOne(userRole => userRole.User)
                    .WithMany(user => user.Roles)
                    .HasForeignKey(userRole => userRole.UserId);

                modelBuilder
                    .HasOne(userRole => userRole.Role)
                    .WithMany(role => role.Users)
                    .HasForeignKey(userRole => userRole.RoleId);
            });

            builder.Entity<UserLogin>(modelBuilder =>
            {
                modelBuilder.ToTable("UserLogins");

                modelBuilder
                    .HasOne(userLogin => userLogin.User)
                    .WithMany(user => user.Logins)
                    .HasForeignKey(userLogin => userLogin.UserId);
            });

            builder.Entity<RoleClaim>(modelBuilder =>
            {
                modelBuilder.ToTable("RoleClaims");

                modelBuilder.HasOne(roleClaim => roleClaim.Role)
                    .WithMany(role => role.Claims)
                    .HasForeignKey(roleClaim => roleClaim.RoleId);
            });

            builder.Entity<UserToken>(modelBuilder =>
            {
                modelBuilder.ToTable("UserTokens");

                modelBuilder.HasOne(userToken => userToken.User)
                    .WithMany(token => token.Tokens)
                    .HasForeignKey(userToken => userToken.UserId);
            });
        }

        public DbSet<User> User { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<PostTag> PostTags { get; set; }
        public DbSet<Faq> Faqs { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<ConfigGroup> ConfigGroups { get; set; }
        public DbSet<ConfigChart> ConfigCharts { get; set; }
        public DbSet<ConfigDetail> ConfigDetails { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceDetail> InvoiceDetails { get; set; }
        public DbSet<Slider> Sliders { get; set; }
    }
}
