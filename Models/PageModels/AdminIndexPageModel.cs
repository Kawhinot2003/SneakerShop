using Microsoft.AspNetCore.Mvc.RazorPages;
using SneakerShop.Models.Entities;

namespace SneakerShop.Models.PageModels
{
	public class AdminIndexPageModel : PageModel
	{

		public List<BasketElement> Basket { get; set; }

		public List<DiscountType> DiscountTypes { get; set; }

		public List<Discount> Discounts { get; set; }

		public List<Good> Goods { get; set; }

		public List<Manufacturer> Manufacturers { get; set; }

		public List<GoodCategory> GoodCategories { get; set; }

		public List<Size> Sizes { get; set; }

		public List<Order> Orders { get; set; }

		public List<OrderType> OrderTypes { get; set; }

		public List<OrderedGood> OrderedGoods { get; set; }

		public AdminIndexPageModel()
		{
			
		}

	}
}