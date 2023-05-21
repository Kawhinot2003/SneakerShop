using Microsoft.EntityFrameworkCore;
using SneakerShop.Models.Entities;

namespace SneakerShop.Domains.Contexts
{
	public class ApplicationContext : DbContext
	{

		private IConfiguration Configuration;

		public DbSet<BasketElement> Basket { get; set; }

		public DbSet<DiscountType> DiscountTypes { get; set; }

		public DbSet<Discount> Discounts { get; set; }

		public DbSet<Good> Goods { get; set; }

		public DbSet<Manufacturer> Manufacturers { get; set; }

		public DbSet<GoodCategory> GoodCategories { get; set; }

		public DbSet<Size> Sizes { get; set; }

		public DbSet<Order> Orders { get; set; }

		public DbSet<OrderType> OrderTypes { get; set; }

		public DbSet<OrderedGood> OrderedGoods { get; set; }

		public ApplicationContext(DbContextOptions<ApplicationContext> options, IConfiguration configuration) : base(options)
		{
			// как применить миграцию
			// dotnet tool update --global dotnet-ef

			// dotnet ef migrations add (название миграции, например, init) -c ApplicationContext
			// dotnet ef migrations add init -c ApplicationContext
			// dotnet ef migrations add init -c UsersContext

			// dotnet ef database update -c ApplicationContext
			// dotnet ef database update -c UsersContext

			Configuration = configuration;
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseNpgsql(Configuration.GetConnectionString("DefaultConnectionString"));
		}

	}
}