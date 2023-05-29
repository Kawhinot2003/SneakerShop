using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SneakerShop.Models.Entities;
using SneakerShop.Models.PageModels;
using SneakerShop.Services.Interfaces;

namespace SneakerShop.Controllers
{
	public class OrdersController : Controller
	{

		private IGoodsService _GoodsService;
		private IOrdersService _OrdersService;
		private UserManager<IdentityUser> _UserManager;

		public OrdersController(IGoodsService goodsService, IOrdersService ordersService,
			UserManager<IdentityUser> userManager)
		{
			_GoodsService = goodsService;
			_OrdersService = ordersService;
			_UserManager = userManager;
		}

		public async Task<IActionResult> Index()
		{
			if (User.Identity.Name == null)
				return View(new OrdersPageModel(null, new List<OrderedGood>()));

			var user = await _UserManager.FindByNameAsync(User.Identity.Name);
			var userId = user.Id;
			var order = _OrdersService.GetAllOrders().FirstOrDefault(x => x.IdUser == userId);
			var goods = _OrdersService.GetAllOrderedGoods().Where(x => x.IdOrder == (order?.Id ?? -1)).ToList();

			return View(new OrdersPageModel(order, goods));
		}

	}
}