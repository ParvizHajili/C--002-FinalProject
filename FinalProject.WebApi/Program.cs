
using Business.Abstract;
using Business.Concrete;
using Business.Validations;
using DataAccess.Asbtract;
using DataAccess.Concrete;
using DataAccess.Context;
using Entities.Concrete.TableModels;
using Entities.Concrete.TableModels.Membership;
using FluentValidation;

namespace FinalProject.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddDbContext<ApplicationDbContext>()
                .AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            builder.Services.AddScoped<IAboutDal, AboutDal>();
            builder.Services.AddScoped<IAboutService, AboutManager>();
            builder.Services.AddScoped<IValidator<About>, AboutValidation>();

            builder.Services.AddScoped<IFoodCategoryDal, FoodCategoryDal>();
            builder.Services.AddScoped<IFoodCategoryService, FoodCategoryManager>();

            builder.Services.AddScoped<IFoodDal, FoodDal>();
            builder.Services.AddScoped<IFoodService, FoodManager>();

            builder.Services.AddScoped<ITagDal, TagDal>();
            builder.Services.AddScoped<ITagService, TagManager>();

            builder.Services.AddScoped<IBlogDal, BlogDal>();
            builder.Services.AddScoped<IBlogservice, BlogManager>();

            builder.Services.AddScoped<IBlogTagDal, BlogTagDal>();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
