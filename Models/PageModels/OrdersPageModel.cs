using Microsoft.AspNetCore.Mvc.RazorPages;
using SneakerShop.Models.Entities;

namespace SneakerShop.Models.PageModels
{
	public class OrdersPageModel : PageModel
	{

		public Order _Order { get; private set; }

		public List<OrderedGood> Goods { get; private set; }

		public OrdersPageModel(Order order, List<OrderedGood> goods)
		{
			_Order = order;
			Goods = goods;
		}

	}
}