using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SneakerShop.Domains.Contexts;
using SneakerShop.Models.Entities;
using SneakerShop.Repositories;
using SneakerShop.Repositories.Interfaces;
using SneakerShop.Services;
using SneakerShop.Services.Interfaces;

namespace SneakerShop
{
	public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();

			var connString = builder.Configuration.GetConnectionString("DefaultConnectionString");
			builder.Services.AddDbContext<ApplicationContext>(options =>
				options.UseNpgsql(connString,
				options => options.SetPostgresVersion(new Version(9, 6, 24))));
			builder.Services.AddDbContext<UsersContext>(options =>
				options.UseNpgsql(connString,
				options => options.SetPostgresVersion(new Version(9, 6, 24))));

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
				options.LoginPath = "/Authorization/Login";
				options.AccessDeniedPath = "/account/accessdenied";
				options.SlidingExpiration = true;
			});

			builder.Services.AddAuthorization(x =>
			{
				x.AddPolicy("AdminArea", policy => { policy.RequireRole("admin"); });
			});

			builder.Services.AddScoped<IDbRepository<BasketElement>, DbRepository<BasketElement>>();
			builder.Services.AddScoped<IDbRepository<DiscountType>, DbRepository<DiscountType>>();
			builder.Services.AddScoped<IDbRepository<Discount>, DbRepository<Discount>>();
			builder.Services.AddScoped<IDbRepository<GoodCategory>, DbRepository<GoodCategory>>();
			builder.Services.AddScoped<IDbRepository<Good>, DbRepository<Good>>();
			builder.Services.AddScoped<IDbRepository<Manufacturer>, DbRepository<Manufacturer>>();
			builder.Services.AddScoped<IDbRepository<Order>, DbRepository<Order>>();
			builder.Services.AddScoped<IDbRepository<OrderType>, DbRepository<OrderType>>();
			builder.Services.AddScoped<IDbRepository<OrderedGood>, DbRepository<OrderedGood>>();
			builder.Services.AddScoped<IDbRepository<Size>, DbRepository<Size>>();

			builder.Services.AddTransient<IBasketService, BasketService>();
			builder.Services.AddTransient<IDiscountsService, DiscountsService>();
			builder.Services.AddTransient<IGoodsService, GoodsService>();
			builder.Services.AddTransient<IOrdersService, OrdersService>();
			builder.Services.AddTransient<ISizeService, SizeService>();

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

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute("admin", "{area:exists}/{controller=Home}/{action=AllActions}/{id?}");
				endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
			});

            app.Run();
        }
    }
}