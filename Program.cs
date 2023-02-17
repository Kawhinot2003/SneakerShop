using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SneakerShop.Domains.Contexts;
using SneakerShop.Models;
using SneakerShop.Repositories;
using SneakerShop.Repositories.Interfaces;
using SneakerShop.Services;

namespace SneakerShop
{
	public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

			builder.Services.AddDbContext<ApplicationContext>(options =>
				options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnectionString")));
			builder.Services.AddDbContext<UsersContext>(options =>
				options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnectionString")));

			builder.Services.AddIdentity<IdentityUser, IdentityRole>(opts =>
			{
				opts.User.RequireUniqueEmail = true;
				opts.Password.RequiredLength = 3;
				opts.Password.RequireNonAlphanumeric = false;
				opts.Password.RequireLowercase = false;
				opts.Password.RequireUppercase = false;
				opts.Password.RequireDigit = false;
			}).AddEntityFrameworkStores<UsersContext>().AddDefaultTokenProviders();

			builder.Services.ConfigureApplicationCookie(options =>
			{
				options.Cookie.Name = "myShopAuth";
				options.Cookie.HttpOnly = true;
				options.LoginPath = "/account/login";
				options.AccessDeniedPath = "/account/accessdenied";
				options.SlidingExpiration = true;
			});

			builder.Services.AddAuthorization(x =>
			{
				x.AddPolicy("AdminArea", policy => { policy.RequireRole("admin"); });
			});

			builder.Services.AddScoped<IDbRepository<BasketElement>, DbRepository<BasketElement>>();
			builder.Services.AddScoped<IDbRepository<Discount>, DbRepository<Discount>>();
			builder.Services.AddScoped<IDbRepository<GoodCategory>, DbRepository<GoodCategory>>();
			builder.Services.AddScoped<IDbRepository<Good>, DbRepository<Good>>();
			builder.Services.AddScoped<IDbRepository<Order>, DbRepository<Order>>();
			builder.Services.AddScoped<IDbRepository<OrderType>, DbRepository<OrderType>>();

			builder.Services.AddTransient<BasketService>();
			builder.Services.AddTransient<DiscountsService>();
			builder.Services.AddTransient<GoodCategoriesService>();
			builder.Services.AddTransient<GoodsService>();
			builder.Services.AddTransient<OrdersService>();
			builder.Services.AddTransient<OrderTypesService>();

			var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

			app.UseCookiePolicy();
			app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}