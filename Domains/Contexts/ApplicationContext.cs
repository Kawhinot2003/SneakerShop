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

			//GoodCategories.Add(new GoodCategory(1, "Кроссовки", "Описание"));
			//GoodCategories.Add(new GoodCategory(2, "Обувь какая-то", "Описание"));

			//OrderTypes.Add(new OrderType(1, "Заказ покупателя"));
			//OrderTypes.Add(new OrderType(2, "Заказ сотрудника"));

			//Discounts.Add(new Discount(1, 50, "Летняя скидка"));
			//Discounts.Add(new Discount(2, 25, "Зимняя скидка"));

			//Goods.Add(new Good(1, 1, "Кроссовки абибас", 100, null, 2, "34", "Внатуре чоткие кроссы ежжы", @"https://sun9-67.userapi.com/impg/o7TwMrf6nlUVGwC-mh_ionyQazQdpAhV75JkIg/6O81L7CjbA4.jpg?size=1080x590&quality=96&sign=8eae82bb7bc7da2f557443a8b3bf1fa3&type=album"));
			//Goods.Add(new Good(2, 1, "Кроссовки найк", 500, 1, 0, "40", "Не чоткие кросы", @"https://sun9-46.userapi.com/impg/9f-NUD0abgaJFB3unm0ZZxGIulFURwI6Ig1dtw/hc9Xu0AQPQk.jpg?size=604x251&quality=96&sign=080534e03181c6089584817b93f3e23d&type=album"));


		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			// Можно сюда сразу занести данные и миграцию сделать на заполнение БД

			/*

			GoodCategories.Add(new GoodCategory(1, "Кроссовки", "Описание"));
			GoodCategories.Add(new GoodCategory(2, "Обувь какая-то", "Описание"));

			OrderTypes.Add(new OrderType(1, "Заказ покупателя"));
			OrderTypes.Add(new OrderType(2, "Заказ сотрудника"));

			Discounts.Add(new Discount(1, 50, "Летняя скидка"));
			Discounts.Add(new Discount(2, 25, "Зимняя скидка"));

			Goods.Add(new Good(1, 1, "Кроссовки абибас", 100, null, 2, "34", "Внатуре чоткие кроссы ежжы"));
			Goods.Add(new Good(2, 1, "Кроссовки найк", 500, 1, 0, "40", "Не чоткие кросы"));

			*/
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseNpgsql(Configuration.GetConnectionString("DefaultConnectionString"));
		}

	}
}