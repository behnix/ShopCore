using System;
using App.Core.Convertors;
using App.Core.Services;
using App.Data;
using App.Domain.Identity;
using App.Services;
using App.Services.Identity;
using App.Services.Identity.Managers;
using App.Services.Identity.Stores;
using App.Services.Identity.Validators;
using App.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SendEmail;

namespace App
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {


            services.AddIdentity<User, Role>(option =>
            {
                option.User.RequireUniqueEmail = true;
                option.Password.RequireUppercase = false;
                option.Password.RequiredLength = 3;
                option.Password.RequireLowercase = false;
                option.Password.RequireUppercase = false;
                option.Password.RequireDigit = false;
                option.Password.RequireNonAlphanumeric = false;
                option.Password.RequiredUniqueChars = 0;
                option.SignIn.RequireConfirmedEmail = false;
            })
                .AddUserStore<AppUserStore>()
                .AddRoleStore<AppRoleStore>()
                .AddUserValidator<AppUserValidator>()
                .AddRoleValidator<AppRoleValidator>()
                .AddUserManager<AppUserManager>()
                .AddRoleManager<AppRoleManager>()
                .AddSignInManager<AppSignInManager>()
                .AddErrorDescriber<AppErrorDescriber>()
                .AddClaimsPrincipalFactory<AppClaimsPrincipalFactory>()
                .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.Name = "App.Cookie";
                options.AccessDeniedPath = "/AccessDenied";
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromDays(30);
                options.Cookie.Expiration = TimeSpan.FromDays(30);
                options.LoginPath = "/Login";
                // ReturnUrlParameter requires 
                //using Microsoft.AspNetCore.Authentication.Cookies;
                options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
                options.SlidingExpiration = true;
            });

            #region Context
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")
                );
            });
            #endregion

            #region IoC

            services.AddTransient<IViewRenderService, RenderViewToString>();
            services.AddTransient<IPostService, PostService>();
            services.AddTransient<IGroupService, GroupService>();
            services.AddTransient<ITagService, TagService>();
            services.AddTransient<IPostTagService, PostTagService>();
            services.AddTransient<IFaqService, FaqService>();
            services.AddTransient<IPageService, PageService>();
            services.AddTransient<ISettingService, SettingService>();
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddTransient<ISmsSender, SmsSender>();
            services.AddTransient<IBrandService, BrandService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IConfigChartService, ConfigChartService>();
            services.AddTransient<IConfigGroupService, ConfigGroupService>();
            services.AddTransient<IConfigDetailService, ConfigDetailService>();
            services.AddTransient<ICommentService, CommentService>();
            services.AddTransient<IInvoiceService, InvoiceService>();
            services.AddTransient<IInvoiceDetailService, InvoiceDetailService>();
            services.AddTransient<ISliderService, SliderService>();

            #endregion

            services.AddMvc()
                .AddRazorPagesOptions(options =>
                {
                    options.Conventions.AuthorizeFolder("/Admin");
                    options.Conventions.AuthorizePage("/Account/UserArea");
                }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromDays(7);
                options.Cookie.HttpOnly = true;
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseDeveloperExceptionPage();
                //app.UseExceptionHandler("/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseSession();
            app.UseMvc();
        }
    }
}
