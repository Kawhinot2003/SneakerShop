using Microsoft.AspNetCore.Mvc;
using SneakerShop.Models.PageModels;
using SneakerShop.Services.Interfaces;
using SneakerShop.Models.Entities;
using Microsoft.AspNetCore.Identity;

namespace SneakerShop.Controllers
{
	public class GoodInfoController : Controller
	{

		private IGoodsService _GoodsService;
		private IBasketService _BasketService;
		private ISizeService _SizeService;
		private IDiscountsService _DiscountsService;
		private UserManager<IdentityUser> _UserManager;

		public GoodInfoController(IGoodsService goodsService, IBasketService basketService, 
			ISizeService sizeService, IDiscountsService discountsService, UserManager<IdentityUser> userManager)
		{
			_GoodsService = goodsService;
			_BasketService = basketService;
			_SizeService = sizeService;
			_DiscountsService = discountsService;
			_UserManager = userManager;
		}

		public IActionResult Index(int goodId)
		{
			var good = _GoodsService.GetGood(goodId);
			var sizes = _SizeService.GetAll().Where(x => x.IdGoodCategory == good.IdGoodCategory).ToList();
			return View(new ChoosedGoodPageModel(good, sizes));
		}

		public async Task<IActionResult> MakeOrder(int goodId, int choosedSizeId)
		{
			if (User.Identity.Name == null)
				return RedirectToAction("Login", "Authorization");

			var user = await _UserManager.FindByNameAsync(User.Identity.Name);
			var userId = user.Id;
			var discountId = _DiscountsService.GetAll().FirstOrDefault(x => x.IdGood == goodId)?.Id;
			_BasketService.Add(new BasketElement(goodId, choosedSizeId, userId, discountId, 1));

			return RedirectToAction("Index", "Basket");
		}

	}
}