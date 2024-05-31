using Business.Abstract;
using Business.Concrete;
using Business.Validations;
using DataAccess.Asbtract;
using DataAccess.Concrete;
using DataAccess.Context;
using Entities.Concrete.TableModels;
using Entities.Concrete.TableModels.Membership;
using FluentValidation;
using Microsoft.AspNetCore.Identity;

namespace FinalProject.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //builder.Services.AddScoped
            //builder.Services.AddTransient
            //builder.Services.AddSingleton
            builder.Services.AddAuthentication();
            builder.Services.AddAuthorization();

            builder.Services.AddDbContext<ApplicationDbContext>()
                .AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            builder.Services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequiredLength = 5;

                options.User.RequireUniqueEmail = true;
            });

            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.ExpireTimeSpan = TimeSpan.FromDays(20);
                options.Cookie.Name = "Restaurant";
                options.Cookie.HttpOnly = false;
            });

            builder.Services.AddScoped<IAboutDal, AboutDal>();
            builder.Services.AddScoped<IAboutService, AboutManager>();
            builder.Services.AddScoped<IValidator<About>,AboutValidation>();

            builder.Services.AddScoped<IFoodCategoryDal,FoodCategoryDal>();
            builder.Services.AddScoped<IFoodCategoryService,FoodCategoryManager>();

            builder.Services.AddScoped<IFoodDal, FoodDal>();
            builder.Services.AddScoped<IFoodService, FoodManager>();

            builder.Services.AddScoped<ITagDal, TagDal>();
            builder.Services.AddScoped<ITagService, TagManager>();

            builder.Services.AddScoped<IBlogDal, BlogDal>();
            builder.Services.AddScoped<IBlogservice, BlogManager>();

            builder.Services.AddScoped<IBlogTagDal, BlogTagDal>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            //app.MapControllerRoute(
            //    name: "default",
            //    pattern: "{controller=Home}/{action=Index}/{id?}");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                            name: "areas",
                            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                            name: "default",
                            pattern: "{controller=Home}/{action=Index}/{id?}");

            });


            app.Run();
        }
    }
}
