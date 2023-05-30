using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SneakerShop.Models.Entities;
using SneakerShop.Models.PageModels;
using SneakerShop.Services.Interfaces;
using System.Linq;

namespace SneakerShop.Controllers
{
	public class OrdersController : Controller
	{

		private IGoodsService _GoodsService;
		private ISizeService _SizeService;
		private IOrdersService _OrdersService;
		private UserManager<IdentityUser> _UserManager;

		public OrdersController(IGoodsService goodsService, ISizeService sizeService, 
			IOrdersService ordersService, UserManager<IdentityUser> userManager)
		{
			_GoodsService = goodsService;
			_SizeService = sizeService;
			_OrdersService = ordersService;
			_UserManager = userManager;
		}

		public async Task<IActionResult> Index()
		{
			if (User.Identity.Name == null)
				return View(new OrdersPageModel(new Dictionary<Order, List<OrdersPageModel.TempOrderedGood>>()));

			var user = await _UserManager.FindByNameAsync(User.Identity.Name);
			var userId = user.Id;
			var allGoods = _GoodsService.GetAllGoods();
			var sizes = _SizeService.GetAll().ToDictionary(x => x.Id, x => x.Name);
			var orders = _OrdersService.GetAllOrders().Where(x => x.IdUser == userId);
			var goods = _OrdersService.GetAllOrderedGoods()
				.Where(x => orders.Select(o => o.Id).Contains(x.IdOrder))
				.Select(x => new OrdersPageModel.TempOrderedGood(x.IdOrder, x.IdGood, x.IdSize, x.IdDiscount, x.Count,
					allGoods.Single(y => y.Id == x.IdGood), sizes[x.IdSize]))
				.GroupBy(x => x.IdOrder)
				.ToDictionary(x => orders.First(o => o.Id == x.Key), x => x.ToList());

			return View(new OrdersPageModel(goods));
		}

	}
}