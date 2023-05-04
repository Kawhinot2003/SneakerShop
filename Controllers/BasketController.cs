using Microsoft.AspNetCore.Mvc;
using SneakerShop.Models.PageModels;
using SneakerShop.Models;
using SneakerShop.Services.Interfaces;
using SneakerShop.Services;
using SneakerShop.Models.Entities;
using Microsoft.AspNetCore.Identity;

namespace SneakerShop.Controllers
{
	public class BasketController : Controller
	{

		private IGoodsService _GoodsService;
		private IBasketService _BasketService;
		private ISizeService _SizeService;
		private IOrdersService _OrdersService;
		private UserManager<IdentityUser> _UserManager;

		public BasketController(IGoodsService goodsService, IBasketService basketService, ISizeService sizeService, 
			IOrdersService ordersService, UserManager<IdentityUser> userManager)
		{
			_GoodsService = goodsService;
			_BasketService = basketService;
			_SizeService = sizeService;
			_OrdersService = ordersService;
			_UserManager = userManager;
		}

		public async Task<IActionResult> Index()
		{
			if (User.Identity.Name == null)
				return View(new BasketPageModel(new List<(Good, string, int)>()));

			var user = await _UserManager.FindByNameAsync(User.Identity.Name);
			var userId = user.Id;
			var basketElements = _BasketService.GetAll().Where(x => x.IdUser == userId).ToList();
			var userGoodsInBasket = _GoodsService.GetAllGoods().Where(x => basketElements.Select(x => x.Id).Contains(x.Id)).ToList();
			var result = new List<(Good, string, int)>();
			result.AddRange(basketElements.Select(x => (_GoodsService.GetGood(x.IdGood), _SizeService.Get(x.IdSize).Name, x.Count)));

			return View(new BasketPageModel(result));
		}

		public async Task<IActionResult> ChangeGoodCount(int goodId, int operationType)
		{
			var user = await _UserManager.FindByNameAsync(User.Identity.Name);
			var userId = user.Id;
			var basketElement = _BasketService.GetAll().First(x => x.IdUser == userId && x.IdGood == goodId);

			switch (operationType)
			{
				case 0: 
					if (basketElement.Count > 1)
					{
						basketElement.Count--;
						_BasketService.Edit(basketElement);
					}
					else
						_BasketService.Delete(basketElement.Id);
					break;
				case 1:
					basketElement.Count++;
					_BasketService.Edit(basketElement);
					break;
			}

			return RedirectToAction("Index", "Basket");
		}

		public async Task<IActionResult> MakeOrder() 
		{
			var user = await _UserManager.FindByNameAsync(User.Identity.Name);
			var userId = user.Id;
			var basketElements = _BasketService.GetAll().Where(x => x.IdUser == userId).ToList();

			_OrdersService.MakeOrderFromBasket(basketElements);

			foreach (var basketElementId in basketElements.Select(x => x.Id))
				_BasketService.Delete(basketElementId);

			return RedirectToAction("Index", "Orders");
		}

	}
}