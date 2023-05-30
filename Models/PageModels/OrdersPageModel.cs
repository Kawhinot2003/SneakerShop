using Microsoft.AspNetCore.Mvc.RazorPages;
using SneakerShop.Models.Entities;

namespace SneakerShop.Models.PageModels
{
	public class OrdersPageModel : PageModel
	{

		public Dictionary<Order, List<TempOrderedGood>> UserOrders { get; private set; }

		public OrdersPageModel(Dictionary<Order, List<TempOrderedGood>> orders)
		{
			UserOrders = orders;
		}

		public class TempOrderedGood : OrderedGood
		{

			public Good _Good { get; private set; }

			public string SizeName { get; private set; }

			public TempOrderedGood(int idOrder, int idGood, int idSize, int? idDiscount, int count, Good good, string sizeName) 
				: base(idOrder, idGood, idSize, idDiscount, count)
			{
				_Good = good;
				SizeName = sizeName;
			}


		}

	}
}